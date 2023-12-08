#nullable enable

using System;
using System.Collections.Generic;
using StorybrewCommon.Storyboarding;
using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

public class Cock
{
    protected Cock(Action action)
    {
        Action = action;
    }

    public int Timer { get; set; }
    private Action Action { get; }

    public void Tick()
    {
        Timer--;
        if (Timer == 0)
        {
            Action();
        }
    }
}

public abstract class GameObject
{
    protected readonly GameEngine engine;
    // TODO: this underlying sprite *could* change at any point, and is affected by sprite_index, image_index and image_speed variables
    // currently this is done manually as few sprites use any of those, but this should be supported in GameObject in the future
    public OsbSprite? UnderlyingSprite { get; protected internal set; }
    public IReadOnlyList<Cock> Clocks { get; protected set; } = Array.Empty<Cock>();

    public double CurrentX { get; private set; }
    public double CurrentY { get; private set; }
    public double NextX { get; private set; }
    public double NextY { get; private set; }
    protected double nextXOffset;
    protected double nextYOffset;

    // total movement per step
    public double Speed { get; set; }

    // gamemaker direction, aka 0 = right, 90 = up, 180 = left, 270 = down
    public double Direction { get; set; }
    public double Friction { get; set; }
    protected internal double GravityStrength { get; set; }
    protected double GravityDirection { get; set; }

    // sprite rotation in gamemaker degree
    public virtual double Rotation { get; protected set; }
    private double _previousRotation;
    public bool RotationChanged()
    {
        bool ret = Rotation != _previousRotation;
        _previousRotation = Rotation;
        return ret;
    }

    private double _previousScale = 0; // intentionally 0 instead of 1 to force a one-time ScaleChanged==true
    private double _scale = 1;

    public virtual double Scale
    {
        get => _scale;
        protected internal set => _scale = Math.Max(value, 0);
    }

    public bool ScaleChanged()
    {
        bool ret = Scale != _previousScale;
        _previousScale = Scale;
        return ret;
    }

    public virtual double Alpha
    {
        get => _alpha;
        protected set => _alpha = Math.Min(Math.Max(value, 0), 1);
    }

    private double _previousAlpha = 1;
    private double _alpha = 1;

    public bool AlphaChanged()
    {
        bool ret = Alpha != _previousAlpha;
        _previousAlpha = Alpha;
        return ret;
    }

    private bool wasInvisible = true; // set to true so there is one initial InvisibleChanged==true; a later invisibility change could break otherwise
    public bool Invisible { get; internal set; }

    public bool InvisibleChanged()
    {
        bool ret = Invisible != wasInvisible;
        wasInvisible = Invisible;
        return ret;
    }

    protected bool IsOffscreen()
    {
        // minimum and maximum values for the playfield; everything beyond is out of screen
        const double minX = 0 - 8;
        const double maxX = 800 + 8;
        const double minY = 0 - 8;
        const double maxY = 600 + 8;

        return NextX - engine.ViewXOffset is < minX or > maxX || NextY - engine.ViewYOffset is < minY or > maxY;
    }

    protected bool IsOutsideOfRoom()
    {
        const double minX = 0 - 8;
        const double maxX = 2400 + 8;
        const double minY = 0 - 8;
        const double maxY = 3072 + 8;

        return NextX is < minX or > maxX || NextY is < minY or > maxY;
    }

    protected void CollideWithBorders()
    {
        // minimum and maximum positions that a sprite can have before it's considered to be "in the wall"
        const int minXWall = 40;
        const int maxXWall = 800 - 40;
        const int minYWall = 40;
        const int maxYWall = 608 - 40;

        double directionRad = GamemakerDegreeToRad(Direction);
        double nextX = CurrentX + Math.Cos(directionRad) * Speed;
        double nextY = CurrentY + Math.Sin(directionRad) * Speed;

        if (nextX is < minXWall or > maxXWall)
            Direction = 180 - Direction;
        if (nextY is < minYWall or > maxYWall)
            Direction = -Direction;
    }
    protected void CollideWithBorders2()
    {
        // minimum and maximum positions that a sprite can have before it's considered to be "in the wall"
        // alternate function for bottom right room position
        const int minXWall = 1600 + 40;
        const int maxXWall = 1600 + 800 - 40;
        const int minYWall = 3072 - 608 + 40;
        const int maxYWall = 3072 - 40;

        double directionRad = GamemakerDegreeToRad(Direction);
        double nextX = CurrentX + Math.Cos(directionRad) * Speed;
        double nextY = CurrentY + Math.Sin(directionRad) * Speed;

        if (nextX is < minXWall or > maxXWall)
            Direction = 180 - Direction;
        if (nextY is < minYWall or > maxYWall)
            Direction = -Direction;
    }

    public virtual void Step()
    {
        CurrentX = NextX;
        CurrentY = NextY;

        foreach (Cock clock in Clocks)
        {
            clock.Tick();
        }

        // apply friction. looks correct to do this before calculating next position
        // for future reference check 0:19.900, objects in the middle need to be exactly stacked
        if (Speed != 0)
        {
            double newSpeed = Speed - Friction;
            // if passing through 0, set new speed to 0
            if (newSpeed * Speed < 0) newSpeed = 0;

            Speed = newSpeed;
        }

        double directionRad = GamemakerDegreeToRad(Direction);
        double diffX = Math.Cos(directionRad) * Speed;
        double diffY = Math.Sin(directionRad) * Speed;

        if (GravityStrength > 0)
        {
            double gravityDirectionRad = GamemakerDegreeToRad(GravityDirection);
            double gravityX = Math.Cos(gravityDirectionRad) * GravityStrength;
            double gravityY = Math.Sin(gravityDirectionRad) * GravityStrength;
            diffX += gravityX;
            diffY += gravityY;
            Direction = PointDirection(0, 0, diffX, diffY);
            Speed = PointDistance(0, 0, diffX, diffY);
        }

        NextX = CurrentX + nextXOffset + diffX;
        NextY = CurrentY + nextYOffset + diffY;

        // because i'm simulating smooth movement and those offsets are used for teleports,
        // not applying those offsets to the current pos could cause single-frame "bullet" movement across the screen
        CurrentX += nextXOffset;
        CurrentY += nextYOffset;

        nextXOffset = nextYOffset = 0;
    }

    protected GameObject(GameEngine engine, double initialX = 400, double initialY = 300)
    {
        this.engine = engine;
        CurrentX = NextX = initialX;
        CurrentY = NextY = initialY;
    }
}


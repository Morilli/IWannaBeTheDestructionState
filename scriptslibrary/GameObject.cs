#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using StorybrewCommon.Storyboarding;
using static StorybrewScripts.Utils;

namespace StorybrewScripts;

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
    public OsbSprite? UnderlyingSprite { get; protected set; }
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

        nextXOffset = nextYOffset = 0;
    }

    protected GameObject(GameEngine engine, double initialX = 400, double initialY = 300)
    {
        this.engine = engine;
        CurrentX = NextX = initialX;
        CurrentY = NextY = initialY;
    }
}

#region Timeline18
public class Object730 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object730 parent) : base(() =>
        {
            parent.CollideWithBorders();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object730 parent) : base(() =>
        {
            parent.Friction++;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object730 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object730 parent) : base(() =>
        {
            parent.engine.AddObject(new Object732(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object730 parent) : base(() =>
        {
            for (int i = 0; i < 20; i++)
            {
                var idx = new Object730(parent.engine, 400, 304)
                {
                    Speed = 25,
                    Direction = i * 18
                };
                parent.engine.AddObject(idx);
            }
        }) { }
    }

    public Object730(GameEngine engine, int initialX, int initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;
        Clocks[3].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public class Object731 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object731 parent) : base(() =>
        {
            parent.a += 0.01;
            parent.engine.ViewAngle -= 1 - parent.a;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object731 parent) : base(() =>
        {
            parent.engine.ViewAngle += 8;
            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object731(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
    }
}

public class Object732 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object732 parent) : base(() =>
        {
            parent.Scale -= 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen() || Scale <= 0) engine.DeleteObject(this);
    }

    public Object732(GameEngine engine, double initialX = 400, double initialY = 340) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }
}

public class Object733 : GameObject
{
    private double a;
    private int b;
    private double c;
    private double e;
    private double f;
    private int g;

    private class Clock0 : Cock
    {
        public Clock0(Object733 parent) : base(() =>
        {
            parent.b++;
            for (int i = 0; i < 10; i++)
            {
                var newObject = new Object734(parent.engine, 400, 152)
                {
                    Speed = 25 + parent.f,
                    Direction = parent.a + 36 * i + parent.b + parent.c + parent.g
                };
                parent.engine.AddObject(newObject);
            }

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object733 parent) : base(() =>
        {
            parent.b--;
            parent.Clocks[1].Timer = 3;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object733 parent) : base(() =>
        {
            var repeat = random.Next(1, 3);
            Object735 idx;
            for (int i = 0; i < repeat; i++)
            {
                idx = new Object735(parent.engine, 400, 152)
                {
                    Speed = random.Next(7, 15),
                    Direction = random.Next(361)
                };
                parent.engine.AddObject(idx);
            }

            idx = new Object735(parent.engine, 400, 152)
            {
                Speed = random.Next(7, 15),
                Direction = PointDirection(400, 152, parent.engine.PlayerX, parent.engine.PlayerY) + random.Next(16, 345)
            };
            parent.engine.AddObject(idx);

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object733 parent) : base(() =>
        {
            parent.b -= 2;
            parent.Clocks[3].Timer = 3;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object733 parent) : base(() =>
        {
            parent.c += parent.e;
            parent.e += 0.1;
            parent.f += 0.2;
            parent.Clocks[4].Timer = 1;
        }) { }
    }
    private class Clock5 : Cock
    {
        public Clock5(Object733 parent) : base(() =>
        {
            parent.g++;
            parent.Clocks[5].Timer = 4;
        }) { }
    }

    public Object733(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this),
            new Clock5(this)
        };

        a = PointDirection(400, 152, engine.PlayerX, engine.PlayerY) + 18;
        engine.Generator.Log($"player x: {engine.PlayerX}, player y: {engine.PlayerY}, a: {a}");
        Clocks[0].Timer = 1;
        Clocks[2].Timer = 1;
    }
}

public class Object734 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object734 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }
    public Object734(GameEngine engine, int initialX, int initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
        Invisible = true;
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);

    public override void Step()
    {
        base.Step();
        if (PointDistance(CurrentX, CurrentY, 400, 300) > 500) engine.DeleteObject(this);
    }
}

public class Object735 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object735 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object735(GameEngine engine, int initialX, int initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);

    public override void Step()
    {
        base.Step();
        if (PointDistance(CurrentX, CurrentY, 400, 300) > 500) engine.DeleteObject(this);
    }
}

public class Object741 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object741 parent) : base(() =>
        {
            parent.CollideWithBorders();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object741 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object741 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object741(GameEngine engine, int initialX = 400, int initialY = 152) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public class Object742 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object742 parent) : base(() =>
        {
            parent.CollideWithBorders();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object742 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object742 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object742 parent) : base(() =>
        {
            parent.nextYOffset -= 8;
            parent.Clocks[3].Timer = 1;
        }) { }
    }

    public Object742(GameEngine engine, int initialX = 400, int initialY = 152) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public class Object743 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object743 parent) : base(() =>
        {
            parent.a += 0.01;
            parent.engine.ViewAngle += 1 - parent.a;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object743 parent) : base(() =>
        {
            parent.engine.ViewAngle -= 8;
            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object743(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
    }
}

public class Object744 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object744 parent) : base(() =>
        {
            parent.a += 0.2;
            parent.engine.ViewXOffset = random.Next((int)(-8 - parent.a), (int)(9 + parent.a));
            parent.engine.ViewYOffset = random.Next((int)(-8 - parent.a), (int)(9 + parent.a));
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object744(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object745 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object745 parent) : base(() =>
        {
            parent.Alpha += 0.02;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object745(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 1.5 * 400, initialY + 1.5 + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 3;
        Alpha = 0;
    }
}

public sealed class Object746 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object746 parent) : base(() =>
        {
            parent.Alpha += 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object746(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1100000, "sprite513.png");
        Scale = 2; // technically scale 2 but we wanna cover the entire osu screen, not just the "playfield"
        Alpha = 0;
    }

    public override void Step()
    {
        base.Step();
        if (Alpha >= 1)
        {
            foreach (Object745 object745 in engine.Objects.OfType<Object745>()) engine.DeleteObject(object745);
        }
    }
}
#endregion

#region Timeline19

public sealed class Object722 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object722 parent) : base(() =>
        {
            parent.a += 0.01;
            parent.Alpha = 0.75 + random.NextDouble() * 0.25 - parent.a;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object722(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite513.png");
        Scale = 2;
    }

    public override void Step()
    {
        base.Step();
        if (a >= 1) engine.DeleteObject(this);
    }
}

public class Object748 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 2;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 6;
            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset -= 2;
            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 13;
            parent.Clocks[3].Timer = 1;
        }) { }
    }

    public Object748(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
        };
        Clocks[0].Timer = 1;

    }
}

public class Object750 : GameObject
{
    private int a;

    private class Clock0 : Cock
    {
        public Clock0(Object750 parent) : base(() =>
        {
            parent.a += 10;
            var newObject = new Object751(parent.engine, 1600, random.Next(0 + parent.a, 609 + parent.a))
            {
                Speed = random.Next(6, 9),
                Direction = random.Next(-90, 91)
            };
            parent.engine.AddObject(newObject);

            newObject = new Object751(parent.engine, 2400, random.Next(0 + parent.a, 609 + parent.a))
            {
                Speed = random.Next(6, 9),
                Direction = random.Next(90, 271)
            };
            parent.engine.AddObject(newObject);

            parent.Clocks[0].Timer = 6;
        }) { }
    }

    public Object750(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
        };
        Clocks[0].Timer = 1;
    }
}

public class Object751 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object751 parent) : base(() =>
        {
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object751 parent) : base(() =>
        {
            parent.Speed = 40;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object751 parent) : base(() =>
        {
            if (random.Next(4) == 0)
            {
                parent.Clocks[1].Timer = 1;
            }
        }) { }
    }

    public Object751(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object752 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object752 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object752(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 5 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 10; // technically xscale 2, yscale 10; need to check whether this makes any difference
    }
}

public sealed class Object754 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object754 parent) : base(() =>
        {
            parent.Invisible = false;
            parent.nextXOffset += 800;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object754 parent) : base(() =>
        {
            parent.Invisible = true;
            parent.nextXOffset -= 800;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object754 parent) : base(() =>
        {
            if (random.Next(4) == 0) parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object754 parent) : base(() =>
        {
            // TODO check if this is necessary; it seems to be a "block killer" sprite
            // parent.engine.AddObject(new Object757(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object754(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
        Invisible = true;
    }

    public override void Step()
    {
        base.Step();
        if (Speed != 0 && IsOffscreen()) engine.DeleteObject(this);
    }
}

public class Object755 : GameObject
{
    public Object755(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object758 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object758 parent) : base(() =>
        {
            parent.Invisible = false;
            parent.nextXOffset += 800;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object758 parent) : base(() =>
        {
            parent.Invisible = true;
            parent.nextXOffset -= 800;
        }) { }
    }

    public Object758(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
        Invisible = true;
    }

    public override void Step()
    {
        base.Step();
        if (Speed != 0 && IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object759 : GameObject
{
    private readonly double a;

    private class Clock0 : Cock
    {
        public Clock0(Object759 parent) : base(() =>
        {
            parent.Speed = parent.a;
        }) { }
    }

    public Object759(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        a = Speed;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object762 : GameObject
{
    public Object762(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object763 : GameObject
{
    public Object763(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object764 : GameObject
{
    public Object764(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object765 : GameObject
{
    public Object765(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object766 : GameObject
{
    public Object766(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class BgObject : GameObject
{
    public BgObject(GameEngine engine, double initialX, double initialY, string roomSuffix) : base(engine, initialX + 400, initialY + 1536)
    {
        UnderlyingSprite = engine.Generator.CreateSprite(-727, $"room150_{roomSuffix}.png");
        Invisible = true;
    }
}

public sealed class Object769 : GameObject
{
    public Object769(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite(10, "sprite521.png");
    }
}

public sealed class Object770 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object770 parent) : base(() =>
        {
            parent.engine.AddObject(new Object771(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object770(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png"); // technically 520 with image speed 0
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object771 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object771 parent) : base(() =>
        {
            parent.Scale -= 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object771(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object772 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object772 parent) : base(() =>
        {
            parent.CollideWithBorders2();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object772 parent) : base(() =>
        {
            parent.Friction -= 0.01;
            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object772 parent) : base(() =>
        {
            if (parent.CurrentX <= 2384) parent.nextXOffset += 816;
            if (parent.CurrentX >= 3216) parent.nextXOffset -= 816;
            if (parent.CurrentY <= 2448) parent.nextYOffset += 624;
            if (parent.CurrentY >= 3056) parent.nextYOffset -= 624;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object772 parent) : base(() =>
        {
            parent.engine.AddObject(new Object774(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object772 parent) : base(() =>
        {
            parent.Speed = 30;
            parent.Direction = random.Next(361);
        }) { }
    }

    public Object772(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object774 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object774 parent) : base(() =>
        {
            parent.Scale -= 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object774(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object773 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object773 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object773(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 2;
    }
}

public sealed class Object775 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object775 parent) : base(() =>
        {
            parent.a += 2;
            parent.engine.ViewAngle += 10 + parent.a;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object775(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object776 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object776 parent) : base(() =>
        {
            parent.Alpha += 0.02;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object776(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 2 * 400, initialY + 2 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 4;
        Alpha = 0;
    }
}

public sealed class Object777 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object777 parent) : base(() =>
        {
            parent.Alpha += 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object777 parent) : base(() =>
        {
            parent.Alpha -= 0.02;

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object777(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 2 * 400, initialY + 2 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite513.png");
        Scale = 4;
        Alpha = 0;
    }

    public override void Step()
    {
        base.Step();
        if (Alpha < 0) engine.DeleteObject(this);
    }
}

public sealed class Object778 : GameObject
{
    private double a;
    private double b;
    private double c;
    private double d;
    internal double e;
    private double f;

    private class Clock0 : Cock
    {
        public Clock0(Object778 parent) : base(() =>
        {
            parent.d += 0.02;

            parent.engine.AddObject(new Object779(parent.engine, 1616, 2480)
            {
                Speed = 8 + parent.f,
                Direction = PointDirection(1616, 2480, parent.engine.PlayerX, parent.engine.PlayerY)
            });
            parent.engine.AddObject(new Object779(parent.engine, 2384, 2480)
            {
                Speed = 8 + parent.f,
                Direction = PointDirection(2384, 2480, parent.engine.PlayerX, parent.engine.PlayerY)
            });

            parent.Clocks[0].Timer = (int)(15 + parent.d / parent.e);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object778 parent) : base(() =>
        {
            parent.a += 15;

            parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
            {
                Speed = 8 + parent.f,
                Direction = parent.a - 15
            });
            parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
            {
                Speed = 8 + parent.f,
                Direction = parent.a + 165
            });

            parent.Clocks[1].Timer = (int)(5 / parent.e);
        }) { }
    }
    private class Clock2 : Cock
    {
        private static readonly int[] Choice1 = { 6, 10, 15, 20 };
        private static readonly int[] Choice2 = { 5, 11, 16, 22 };
        public Clock2(Object778 parent) : base(() =>
        {
            for (int i = 0; i < 3; i++)
            {
                parent.b += Choice1[random.Next(4)];
                parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
                {
                    Speed = random.Next(4, 7),
                    Direction = parent.b
                });
                parent.c += Choice2[random.Next(4)];
                parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
                {
                    Speed = random.Next(4, 7),
                    Direction = parent.c
                });
            }

            parent.Clocks[2].Timer = 6;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object778 parent) : base(() =>
        {
            for (int i = 0; i < 40; i++)
            {
                parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
                {
                    Speed = random.Next(2, 14) + parent.f,
                    Direction = random.Next(361)
                });
            }
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object778 parent) : base(() =>
        {
            parent.f += 0.2;

            parent.Clocks[4].Timer = 1;
        }) { }
    }

    public Object778(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 1;

        e = 1;
    }
}

public sealed class Object779 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object779 parent) : base(() =>
        {
            parent.Speed = 25;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object779 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object779 parent) : base(() =>
        {
            parent.engine.AddObject(new Object825(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                // Speed = parent.Speed,
                // Direction = parent.Direction
            });
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object779(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object825 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object825 parent) : base(() =>
        {
            parent.Speed = 25;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object825 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }

    public Object825(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);

    public override void Step()
    {
        base.Step();
        // I haven't fully understood "outside the room" yet
        if (CurrentX <= 1560 || CurrentY <= 2424 || IsOffscreen())
        {
            engine.DeleteObject(this);
        }
    }
}

public sealed class Object823 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object823 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object823(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 2;
    }
}

#endregion

#region Timeline20

public sealed class Object785 : GameObject
{
    private double a;
    private double b;
    private double c;

    private class Clock0 : Cock
    {
        public Clock0(Object785 parent) : base(() =>
        {
            parent.b += 0.2;

            parent.engine.AddObject(new Object783(parent.engine, 1600, 2528)
            {
                Speed = 50
            });

            parent.Clocks[0].Timer = (int)(32 - parent.b + parent.c);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object785 parent) : base(() =>
        {
            parent.a += 0.2;

            parent.engine.AddObject(new Object783(parent.engine, 2400, 2528)
            {
                Speed = 50,
                Direction = 180
            });

            parent.Clocks[1].Timer = (int)(32 - parent.a + parent.c);
        }) { }
    }

    public Object785(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 16;
        Clocks[1].Timer = 1;
    }
}

public sealed class Object783 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object783 parent) : base(() =>
        {
            parent.engine.AddObject(new Object784(parent.engine, parent.CurrentX + random.Next(-48, 49), parent.CurrentY + random.Next(-48, 49), parent.image_index));

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object783 parent) : base(() =>
        {
            parent.engine.AddObject(new Object786(parent.engine, parent.CurrentX + random.Next(-48, 49), parent.CurrentY + random.Next(-48, 49), parent.image_index));

            parent.Clocks[1].Timer = 2;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object783 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object783(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 1;

        image_index = random.Next(8);
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{image_index}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object784 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object784 parent) : base(() =>
        {
            parent.Speed = 14;
            parent.Direction = random.Next(-105, -74);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object784 parent) : base(() =>
        {
            parent.Scale -= 0.2;

            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object784 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object784 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object784 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
            parent.Clocks[4].Timer = 1;
        }) { }
    }

    public Object784(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 10;
        Clocks[1].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
        Scale = 3;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
        if (Scale <= 1)
        {
            Scale = 1;
            Clocks[1].Timer = 0;
        }
    }
}

public sealed class Object786 : GameObject
{
    private readonly double a;
    private readonly double b;

    private class Clock0 : Cock
    {
        public Clock0(Object786 parent) : base(() =>
        {
            parent.Speed = 14;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + random.Next(2) == 0 ? parent.a : parent.b;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object786 parent) : base(() =>
        {
            parent.Scale -= 0.2;

            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object786 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object786 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object786 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
            parent.Clocks[4].Timer = 1;
        }) { }
    }

    public Object786(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 10;
        Clocks[1].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
        Scale = 3;

        a = random.Next(-60,-14);
        b = random.Next(15,61);

    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
        if (Scale <= 1)
        {
            Scale = 1;
            Clocks[1].Timer = 0;
        }
    }
}

public sealed class Object790 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object790 parent) : base(() =>
        {
            parent.engine.AddObject(new Object789(parent.engine));

            parent.Clocks[0].Timer = 15;
        }) { }
    }

    public Object790(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object789 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object789 parent) : base(() =>
        {
            parent.engine.ViewXOffset += 8;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object789 parent) : base(() =>
        {
            parent.engine.ViewXOffset = 1600;
            parent.engine.ViewYOffset = 2464;
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object789(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 5;

        engine.ViewXOffset -= 32;
        engine.AddObject(new Object787(engine, 2400, engine.PlayerY)
        {
            Speed = 30,
            Direction = 180
        });
    }
}

public sealed class Object787 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object787 parent) : base(() =>
        {
            parent.engine.AddObject(new Object788(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
            {
                Speed = 15,
                Direction = 180
            });

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object787 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object787 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object787(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;

        image_index = random.Next(8);
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{image_index}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object788 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object788 parent) : base(() =>
        {
            parent.Scale -= 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object788(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object794 : GameObject
{
    private double image_index;
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object794 parent) : base(() =>
        {
            for (int i = 0; i < 2; i++)
            {
                parent.engine.AddObject(new Object795(parent.engine, parent.CurrentX, parent.CurrentY, (int)parent.image_index)
                {
                    Speed = 14,
                    Direction = random.Next(361)
                });
                parent.engine.AddObject(new Object795(parent.engine, parent.CurrentX, parent.CurrentY, (int)parent.image_index)
                {
                    Speed = 14,
                    Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 1 + random.NextDouble() * 358
                });
            }

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object794 parent) : base(() =>
        {
            parent.a += 0.2;
            parent.engine.ForEach<Object795>(o => o.Speed = 75);

            parent.Clocks[1].Timer = (int)(15 + parent.a);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object794 parent) : base(() =>
        {
            parent.engine.ForEach<Object795>(o => o.Speed = 15);

            parent.Clocks[2].Timer = (int)(15 + parent.a);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object794 parent) : base(() =>
        {
            parent.image_index++;

            parent.Clocks[3].Timer = (int)(15 + parent.a);
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object794 parent) : base(() =>
        {
            parent.image_index += 0.06;

            parent.Clocks[4].Timer = 1;
        }) { }
    }

    public Object794(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 15;
        Clocks[2].Timer = 16;
        Clocks[3].Timer = 15;
    }

    public override void Step()
    {
        base.Step();
        if (CurrentX <= 1592 || CurrentY <= 2456) engine.DeleteObject(this);
    }
}

public sealed class Object795 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object795 parent) : base(() =>
        {
            parent.Friction -= 0.015;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object795 parent) : base(() =>
        {
            if(parent.CurrentX < 1592) parent.engine.DeleteObject(parent);
            if(parent.CurrentX > 2408) parent.engine.DeleteObject(parent);
            if(parent.CurrentY < 2456) parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object795(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex % 8}.png");
    }

    public override void Step()
    {
        base.Step();
        if (PointDistance(CurrentX, CurrentY, 2000, 2768) > 500) engine.DeleteObject(this);
    }
}

public sealed class Object796 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object796 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 8;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object796 parent) : base(() =>
        {
            parent.engine.ViewXOffset = 1600;
            parent.engine.ViewYOffset = 2464;
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object796(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 5;

        engine.ViewYOffset -= 32;
        engine.AddObject(new Object797(engine, engine.PlayerX, 2464)
        {
            Speed = 30,
            Direction = -90
        });
    }
}

public sealed class Object797 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object797 parent) : base(() =>
        {
            parent.engine.AddObject(new Object788(parent.engine, parent.engine.PlayerX, parent.engine.PlayerY, parent.image_index)
            {
                Speed = 15,
                Direction = -90
            });

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object797 parent) : base(() =>
        {
            parent.Friction -= 0.015;

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object797(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        image_index = random.Next(8);
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{image_index}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object802 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object802 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object802(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 2 * 400, initialY + 2 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 4;
    }
}

public sealed class Object801 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object801 parent) : base(() =>
        {
            parent.engine.AddObject(new Object799(parent.engine));

            parent.Clocks[0].Timer = 15;
        }) { }
    }

    public Object801(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object799 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object799 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object799(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        int imageIndex = random.Next(8);

        double a = random.NextDouble() * 30;
        for (int i = 0; i < 12; i++)
        {
            engine.AddObject(new Object800(engine, 2000, 2768, imageIndex)
            {
                Speed = 10,
                Direction = a + 30 * i
            });
        }

    }
}

public sealed class Object800 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object800 parent) : base(() =>
        {
            parent.Friction += 0.01;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object800 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
        }) { }
    }
    private class Clock2 : Cock
    {
        // is actually empty in original source
        public Clock2(Object800 parent) : base(() => {}) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object800 parent) : base(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object804(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
                {
                    Scale = 0.5 + random.NextDouble() * 0.5,
                    Speed = random.Next(4, 17),
                    Direction = PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768) + random.Next(90, 271)
                });
            }

            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object800(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 15;

        image_index = imageIndex;
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object804 : GameObject
{
    public Object804(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
        GravityStrength = 0.4;
        GravityDirection = PointDirection(CurrentX, CurrentY, 2000, 2768) + 180;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object803 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object803 parent) : base(() =>
        {
            parent.engine.ViewWidth += 16;
            parent.engine.ViewHeight += 16;
            parent.engine.ViewXOffset -= 8;
            parent.engine.ViewYOffset -= 8;
            parent.engine.ViewAngle--;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object803 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
            parent.engine.ViewWidth = 800;
            parent.engine.ViewHeight = 608;
            parent.engine.ViewXOffset = 1600;
            parent.engine.ViewYOffset = 2464;
            parent.engine.ViewAngle = 0;

            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object803(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 10;
    }
}

public sealed class Object805 : GameObject
{
    private int image_index;
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object805 parent) : base(() =>
        {
            parent.image_index = random.Next(8);

            parent.a = random.NextDouble() * 24;
            for (int i = 0; i < 15; i++)
            {
                parent.engine.AddObject(new Object806(parent.engine, 2000, 2464, parent.image_index)
                {
                    Speed = 18,
                    Direction = parent.a + 24 * i
                });
            }

            parent.Clocks[0].Timer = 30;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object805 parent) : base(() =>
        {
            parent.image_index = random.Next(8);

            parent.a = random.NextDouble() * 24;
            for (int i = 0; i < 15; i++)
            {
                parent.engine.AddObject(new Object807(parent.engine, 2000, 2464, parent.image_index)
                {
                    Speed = 18,
                    Direction = parent.a + 24 * i
                });
            }

            parent.Clocks[1].Timer = 30;
        }) { }
    }

    public Object805(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 15;

        image_index = random.Next(8);
    }
}

public sealed class Object806 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object806 parent) : base(() =>
        {
            parent.Direction += 2.5;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object806 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object806 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object806(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object807 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object807 parent) : base(() =>
        {
            parent.Direction -= 2.5;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object807 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object807 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object807(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object808 : GameObject
{
    private double d;
    private double e;

    private class Clock0 : Cock
    {
        public Clock0(Object808 parent) : base(() =>
        {
            parent.d += 50.0 / 70; // 0.7142857142857143
            int repeat = random.Next(4) == 0 ? 3 : 2;
            for (int i = 0; i < repeat; i++)
            {
                var newObject = new Object809(parent.engine, 2000, 2464)
                {
                    c = 90 - parent.d,
                    Speed = 15,
                    Direction = random.Next(361)
                };
                newObject.Clocks[3].Timer = (int)(90 - parent.d);

                parent.engine.AddObject(newObject);
            }

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object808 parent) : base(() =>
        {
            parent.e += 0.3;

            int repeat = random.Next(3) == 0 ? 2 : 3;
            for (int i = 0; i < repeat; i++)
            {
                parent.engine.AddObject(new Object810(parent.engine, 2000, 2464)
                {
                    Speed = 15 + parent.e,
                    Direction = random.Next(361)
                });
            }

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object808(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object809 : GameObject
{
    internal double c;

    private class Clock0 : Cock
    {
        public Clock0(Object809 parent) : base(() =>
        {
            parent.Direction += parent.c;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object809 parent) : base(() =>
        {
            parent.Direction -= parent.c;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object809 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object809 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }

    public Object809(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[random.Next(2)].Timer = 15;
        Clocks[2].Timer = 1 + random.Next(15);

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{random.Next(8)}.png");
        Invisible = true;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}
    
public sealed class Object810 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object810 parent) : base(() =>
        {
            parent.Speed = 7;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
            parent.GravityDirection = -90;
            parent.GravityStrength = 0.2;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object810 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object810(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{random.Next(8)}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object811 : GameObject
{
    public Object811(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOutsideOfRoom() || NextX < 1600 - 8) engine.DeleteObject(this);
    }
}

public sealed class Object813 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object813 parent) : base(() =>
        {
            parent.Speed = 2;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object813 parent) : base(() =>
        {
            parent.Friction -= 0.04;

            parent.Clocks[1].Timer = 1;
        }) { }
    }
    public Object813(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOutsideOfRoom() || NextX < 1600 - 8 || PointDistance(NextX, NextY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

#endregion

#region Timeline21

public sealed class Object814 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object814 parent) : base(() =>
        {
            parent.Scale -= 0.2; // TODO xscale yscale -0.22

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object814 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object814 parent) : base(() => { }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object814 parent) : base(() => { }) { }
    }

    public Object814(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 1) Clocks[0].Timer = 0;
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}



#endregion

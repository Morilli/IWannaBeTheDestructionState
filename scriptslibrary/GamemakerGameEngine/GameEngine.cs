using System;
using System.Collections.Generic;
using System.Linq;
using StorybrewCommon.Storyboarding.CommandValues;
using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

public class GameEngine
{
    public IReadOnlyList<GameObject> Objects => _objects;
    private readonly List<GameObject> _objects = new();
    private readonly List<GameObject> _toRemove = new();
    private readonly List<GameObject> _toAdd = new();

    public int CurrentStep { get; private set; }
    public int CurrentTime { get; private set; }
    public double PlayerX { get; set; } = 40;
    public double PlayerY { get; set; } = 600 - 40;
    public double PlayerXSpeed { get; set; }
    public double PlayerYSpeed { get; set; }
    private double _previousViewAngle;
    public double ViewAngle { get; set; }
    public int ViewXOffset { get; set; }
    public int ViewYOffset { get; set; }
    public double ViewWidth { get; set; } = 800;
    public double ViewHeight { get; set; } = 600;
    private int _previousViewXOffset;
    private int _previousViewYOffset;
    private double _previousViewWidth = 800;
    private double _previousViewHeight = 600;

    // a bit annoying that this has to exist, but this is a cause of the smooth movement simulation
    // every "camera" movement (xoffset, yoffset) is done smoothly from the previous position
    // sometimes this isn't desired, so this function can be used to forcefully teleport the view
    public void SetNewViewOffsets(int xOffset, int yOffset)
    {
        ViewXOffset = _previousViewXOffset = xOffset;
        ViewYOffset = _previousViewYOffset = yOffset;
    }

    public void AddObject(GameObject @object)
    {
        _toAdd.Add(@object);
    }

    public void DeleteObject(GameObject @object)
    {
        _toRemove.Add(@object);
    }

    public void ForEach<T>(Action<T> operation)
    {
        foreach (T objectT in Objects.OfType<T>())
        {
            operation(objectT);
        }
    }

    private void ForEach(Action<GameObject> operation)
    {
        foreach (GameObject gameObject in Objects)
        {
            operation(gameObject);
        }
    }

    public void Step(int steps)
    {
        while (steps-- > 0)
        {
            Step();
        }
    }

    private void UpdateObjects()
    {
        foreach (GameObject temp in _toRemove)
        {
            _objects.Remove(temp);
        }

        _toRemove.Clear();

        _objects.AddRange(_toAdd);
        _toAdd.Clear();
    }

    public Timeline CurrentTimeline { get; set; }

    public void Step()
    {
        // order of operations:
        // https://forum.gamemaker.io/index.php?threads/events-priority.1995/#post-16470
        // https://manual.gamemaker.io/monthly/en/#t=The_Asset_Editors%2FObject_Properties%2FEvent_Order.htm

        ForEach(gameObject => gameObject.BeginStep());
        UpdateObjects();

        CurrentTimeline?.Step();
        UpdateObjects();

        ForEach(gameObject => gameObject.TickClocks());
        UpdateObjects();

        ForEach(gameObject => gameObject.Step());
        UpdateObjects();

        ForEach(gameObject => gameObject.UpdatePosition());
        UpdateObjects();

        ForEach(gameObject => gameObject.EndStep());
        UpdateObjects();

        // draw code
        double viewWidthMultiplier = 640 / ViewWidth;
        double viewHeightMultiplier = 480 / ViewHeight;
        double previousViewWidthMultiplier = 640 / _previousViewWidth;
        double previousViewHeightMultiplier = 480 / _previousViewHeight;
        foreach (GameObject aliveObject in Objects)
        {
            if (aliveObject.UnderlyingSprite is null) continue;
            bool invisibleChanged = aliveObject.InvisibleChanged();
            if (invisibleChanged)
            {
                aliveObject.UnderlyingSprite.Fade(CurrentTime, aliveObject.Invisible ? 0 : aliveObject.Alpha);
            }

            if (aliveObject.Invisible) continue;

            CommandPosition current = Rotate(new CommandPosition(aliveObject.PreviousX - _previousViewXOffset, aliveObject.PreviousY - _previousViewYOffset), _previousViewAngle);
            CommandPosition next = Rotate(new CommandPosition(aliveObject.CurrentX - ViewXOffset, aliveObject.CurrentY - ViewYOffset), ViewAngle);
            aliveObject.UnderlyingSprite.Move(CurrentTime, CurrentTime + stepMilliseconds,
                current.X * previousViewWidthMultiplier, current.Y * previousViewHeightMultiplier, next.X * viewWidthMultiplier, next.Y * viewHeightMultiplier);

            if (invisibleChanged)
                aliveObject.UnderlyingSprite.Rotate(CurrentTime, GamemakerDegreeToRad(aliveObject.Rotation) - DegToRad(ViewAngle));
            else if (ViewAngle != _previousViewAngle || aliveObject.Rotation != aliveObject.PreviousRotation)
                aliveObject.UnderlyingSprite.Rotate(CurrentTime, CurrentTime + stepMilliseconds,
                    GamemakerDegreeToRad(aliveObject.PreviousRotation) - DegToRad(_previousViewAngle),
                    GamemakerDegreeToRad(aliveObject.Rotation) - DegToRad(ViewAngle));

            if (invisibleChanged)
                aliveObject.UnderlyingSprite.ScaleVec(CurrentTime, aliveObject.Scale * viewWidthMultiplier, aliveObject.Scale * viewHeightMultiplier);
            else if (ViewHeight != _previousViewHeight || ViewWidth != _previousViewWidth || aliveObject.Scale != aliveObject.PreviousScale)
                aliveObject.UnderlyingSprite.ScaleVec(CurrentTime, CurrentTime + stepMilliseconds, aliveObject.PreviousScale * viewWidthMultiplier,
                    aliveObject.PreviousScale * viewHeightMultiplier, aliveObject.Scale * viewWidthMultiplier, aliveObject.Scale * viewHeightMultiplier);

            if (!invisibleChanged && aliveObject.Alpha != aliveObject.PreviousAlpha)
                aliveObject.UnderlyingSprite.Fade(CurrentTime, CurrentTime + stepMilliseconds, aliveObject.PreviousAlpha, aliveObject.Alpha);
        }

        // need to handle BG separately because we need to keep up the illusion of angle actually changing y'know
        if (ViewAngle != _previousViewAngle)
            Generator.BgSprite?.Rotate(CurrentTime, CurrentTime + stepMilliseconds, Generator.BgSprite.RotationAt(CurrentTime), -DegToRad(ViewAngle));
        Generator.BgSprite?.Move(CurrentTime, CurrentTime + stepMilliseconds,
            (Generator.BgSprite.InitialPosition.X - _previousViewXOffset) * previousViewWidthMultiplier,
            (Generator.BgSprite.InitialPosition.Y - _previousViewYOffset) * previousViewHeightMultiplier,
            (Generator.BgSprite.InitialPosition.X - ViewXOffset) * viewWidthMultiplier,
            (Generator.BgSprite.InitialPosition.Y - ViewYOffset) * viewHeightMultiplier);
        Generator.BgSprite?.ScaleVec(CurrentTime, CurrentTime + stepMilliseconds, previousViewWidthMultiplier, previousViewHeightMultiplier,
            viewWidthMultiplier, viewHeightMultiplier);

        PlayerX += PlayerXSpeed;
        PlayerY += PlayerYSpeed;
        CurrentStep++;
        CurrentTime += stepMilliseconds;
        _previousViewAngle = ViewAngle;
        _previousViewXOffset = ViewXOffset;
        _previousViewYOffset = ViewYOffset;
        _previousViewWidth = ViewWidth;
        _previousViewHeight = ViewHeight;
    }

    public GameEngine(ISpriteGenerator generator, int initialStep = 0, int initialTime = 0)
    {
        Generator = generator;
        CurrentStep = initialStep;
        CurrentTime = initialTime;
    }

    public ISpriteGenerator Generator { get; }
}

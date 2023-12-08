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
    public double ViewXOffset { get; set; }
    public double ViewYOffset { get; set; }
    public double ViewWidth { get; set; } = 800;
    public double ViewHeight { get; set; } = 600;
    private double _previousViewXOffset;
    private double _previousViewYOffset;
    private double _previousViewWidth = 800;
    private double _previousViewHeight = 600;

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

    public void Step(int steps)
    {
        while (steps --> 0)
        {
            Step();
        }
    }

    public void Step()
    {
        // TODO: I'm not sure if doing the remove/add operations both before and after a step are correct:
        // Not doing them after can cause off-by-one conditions where an object is already in the toAdd queue, but won't
        // get affected by commands from the timeline immediately after, as that only affects Objects, not toAdd.
        // However, not doing those before is also problematic as you get a similar problem: Objects added from the timeline
        // aren't stepped in the immediately following step as they are added to toAdd and only get added to the Objects list after the step.
        // It's difficult to figure out whether this is 100% correct for now, but at least this is robust.
        foreach (GameObject temp in _toRemove)
        {
            _objects.Remove(temp);
        }
        _toRemove.Clear();

        _objects.AddRange(_toAdd);
        _toAdd.Clear();

        foreach (GameObject aliveObject in Objects)
        {
            aliveObject.Step();
        }

        foreach (GameObject temp in _toRemove)
        {
            _objects.Remove(temp);
        }
        _toRemove.Clear();

        _objects.AddRange(_toAdd);
        _toAdd.Clear();

        double viewWidthMultiplier = 640 / ViewWidth;
        double viewHeightMultiplier = 480 / ViewHeight;
        double previousViewWidthMultiplier = 640 / _previousViewWidth;
        double previousViewHeightMultiplier = 480 / _previousViewHeight;
        foreach(GameObject aliveObject in Objects)
        {
            if (aliveObject.UnderlyingSprite is null) continue;
            if (aliveObject.InvisibleChanged())
            {
                aliveObject.UnderlyingSprite.Fade(CurrentTime, aliveObject.Invisible ? 0 : aliveObject.Alpha);
            }

            if (aliveObject.Invisible) continue;

            CommandPosition current = Rotate(new CommandPosition(aliveObject.CurrentX - ViewXOffset, aliveObject.CurrentY - ViewYOffset), _previousViewAngle);
            CommandPosition next = Rotate(new CommandPosition(aliveObject.NextX - ViewXOffset, aliveObject.NextY - ViewYOffset), ViewAngle);
            aliveObject.UnderlyingSprite.Move(CurrentTime, CurrentTime + stepMilliseconds,
                current.X * previousViewWidthMultiplier, current.Y * previousViewHeightMultiplier, next.X * viewWidthMultiplier, next.Y * viewHeightMultiplier);

            // TODO: this technically is problematic, as objects may want to be spawned with a default rotation and only changed later
            // this method will apply the rotation to the entire object's lifetime before CurrentTime as well though
            // we can't just do a currentstep -> nextstep rotation though because then objects may have an incorrect initial rotation
            if (ViewAngle != _previousViewAngle || aliveObject.RotationChanged())
                aliveObject.UnderlyingSprite.Rotate(CurrentTime, GamemakerDegreeToRad(aliveObject.Rotation) - DegToRad(ViewAngle));

            if (aliveObject.ScaleChanged() || ViewHeight != _previousViewHeight || ViewWidth != _previousViewWidth)
                aliveObject.UnderlyingSprite.Scale(CurrentTime, aliveObject.Scale * viewHeightMultiplier); // todo vector scale both
            if (aliveObject.AlphaChanged())
                aliveObject.UnderlyingSprite.Fade(CurrentTime, aliveObject.Alpha);
        }
        // need to handle BG separately because we need to keep up the illusion of angle actually changing y'know
        if (ViewAngle != _previousViewAngle)
            Generator.BgSprite?.Rotate(CurrentTime, CurrentTime + stepMilliseconds, Generator.BgSprite.RotationAt(CurrentTime), -DegToRad(ViewAngle));
        Generator.BgSprite?.Move(CurrentTime, CurrentTime + stepMilliseconds,
            (Generator.BgSprite.InitialPosition.X - _previousViewXOffset) * previousViewWidthMultiplier, (Generator.BgSprite.InitialPosition.Y - _previousViewYOffset) * previousViewHeightMultiplier,
            (Generator.BgSprite.InitialPosition.X - ViewXOffset) * viewWidthMultiplier, (Generator.BgSprite.InitialPosition.Y - ViewYOffset) * viewHeightMultiplier);
        // if (viewHeightMultiplier != 0.8 || viewWidthMultiplier != 0.8)
            Generator.BgSprite?.Scale(CurrentTime, viewHeightMultiplier); // todo vector scale both

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

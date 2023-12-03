using System;
using System.Collections.Generic;
using System.Linq;
using StorybrewCommon.Storyboarding.CommandValues;
using static StorybrewScripts.Utils;

namespace StorybrewScripts;

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
    private double _previousViewXOffset;
    private double _previousViewYOffset;

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
        foreach(GameObject aliveObject in Objects)
        {
            if (aliveObject.UnderlyingSprite is null) continue;
            if (aliveObject.InvisibleChanged())
            {
                aliveObject.UnderlyingSprite.Fade(CurrentTime, aliveObject.Invisible ? 0 : aliveObject.Alpha);
            }

            if (aliveObject.Invisible) continue;

            if (ViewAngle != 0) // could probably remove this condition and keep just the if part
            {
                CommandPosition current = Rotate(new CommandPosition(aliveObject.CurrentX - ViewXOffset, aliveObject.CurrentY - ViewYOffset), ViewAngle);
                CommandPosition next = Rotate(new CommandPosition(aliveObject.NextX - ViewXOffset, aliveObject.NextY - ViewYOffset), ViewAngle);
                aliveObject.UnderlyingSprite.MovePrecisely(CurrentTime, CurrentTime + stepMilliseconds,
                    current.X, current.Y, next.X, next.Y);
            }
            else
            {
                aliveObject.UnderlyingSprite.MovePrecisely(CurrentTime, CurrentTime + stepMilliseconds,
                    aliveObject.CurrentX - ViewXOffset, aliveObject.CurrentY - ViewYOffset, aliveObject.NextX - ViewXOffset, aliveObject.NextY - ViewYOffset);
            }

            // TODO: this technically is problematic, as objects may want to be spawned with a default rotation and only changed later
            // this method will apply the rotation to the entire object's lifetime before CurrentTime as well though
            if (ViewAngle != _previousViewAngle || aliveObject.RotationChanged())
                aliveObject.UnderlyingSprite.Rotate(CurrentTime, aliveObject.Rotation - DegToRad(ViewAngle));

            if (aliveObject.ScaleChanged())
                aliveObject.UnderlyingSprite.Scale(CurrentTime, aliveObject.Scale * 0.8);
            if (aliveObject.AlphaChanged())
                aliveObject.UnderlyingSprite.Fade(CurrentTime, aliveObject.Alpha);
        }
        // need to handle BG separately because we need to keep up the illusion of angle actually changing y'know
        if (ViewAngle != _previousViewAngle)
            Generator.BgSprite?.Rotate(CurrentTime, CurrentTime + stepMilliseconds, Generator.BgSprite.RotationAt(CurrentTime), -DegToRad(ViewAngle));
        Generator.BgSprite?.MovePrecisely(CurrentTime, CurrentTime + stepMilliseconds,
            Generator.BgSprite.InitialPosition.X - _previousViewXOffset, Generator.BgSprite.InitialPosition.Y - _previousViewYOffset,
            Generator.BgSprite.InitialPosition.X - ViewXOffset, Generator.BgSprite.InitialPosition.Y - ViewYOffset);

        PlayerX += PlayerXSpeed;
        PlayerY += PlayerYSpeed;
        CurrentStep++;
        CurrentTime += stepMilliseconds;
        _previousViewAngle = ViewAngle;
        _previousViewXOffset = ViewXOffset;
        _previousViewYOffset = ViewYOffset;
    }

    public GameEngine(ISpriteGenerator generator, int initialStep = 0, int initialTime = 0)
    {
        Generator = generator;
        CurrentStep = initialStep;
        CurrentTime = initialTime;
    }

    public ISpriteGenerator Generator { get; }
}

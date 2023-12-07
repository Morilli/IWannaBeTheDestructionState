using System;
using OpenTK;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.CommandValues;
using static StorybrewScripts.Utils;

namespace StorybrewScripts;

internal static class OsbSpriteExtensions
{
    // minimum and maximum values for the playfield; everything beyond is out of screen
    // this may only hold true for 16:9 monitors and the specific objects used, but idc
    private const double minX = -130 / positionMultiplier;
    private const double maxX = 770 / positionMultiplier;
    private const double minY = -12 / positionMultiplier;
    private const double maxY = 492 / positionMultiplier;

    internal static CommandPosition? MovePrecisely(this OsbSprite sprite, double startTime, double endTime, double startX, double startY, double endX, double endY)
    {
        sprite.Move(startTime, endTime, startX * positionMultiplier, startY * positionMultiplier, endX * positionMultiplier, endY * positionMultiplier);

        return endX is >= minX and <= maxX && endY is >= minY and <= maxY ? new CommandPosition(endX, endY) : null;
    }

    // move an object into a specific direction (in RAD) with a specific speed, until it is offscreen
    internal static CommandPosition? MoveWith(this OsbSprite sprite, double startTime, double initialXPos, double initialYPos, double direction, double speed, int maxFramesToLive=int.MaxValue)
    {
        double x = Math.Cos(direction) * speed;
        double y = Math.Sin(direction) * speed;

        var framesToOffscreenX = x == 0 ? double.PositiveInfinity : Math.Max(Math.Ceiling((maxX - initialXPos) / x), Math.Ceiling((minX - initialXPos) / x));
        var framesToOffscreenY = y == 0 ? double.PositiveInfinity : Math.Max(Math.Ceiling((maxY - initialYPos) / y), Math.Ceiling((minY - initialYPos) / y));
        var framesToLive = Math.Min(Math.Min(framesToOffscreenX, framesToOffscreenY), maxFramesToLive);

        return sprite.MovePrecisely(startTime, startTime + framesToLive * stepMilliseconds, initialXPos, initialYPos, initialXPos + framesToLive * x, initialYPos + framesToLive * y);
    }

    // assumes a 32x32 border around the playfield that objects bounce off of
    internal static CommandPosition MoveWithCollision(this OsbSprite sprite, double startTime, double initialXPos, double initialYPos, double direction, double speed, int framesToLive)
    {
        if (framesToLive <= 0) throw new ArgumentException($"framesToLive must be greater than 0, was {framesToLive}", nameof(framesToLive));

        const int minXWall = 40;
        const int maxXWall = 800 - 40;
        const int minYWall = 40;
        const int maxYWall = 600 - 40;

        double xDiff = Math.Cos(direction) * speed;
        double yDiff = Math.Sin(direction) * speed;

        var framesToWallX = xDiff == 0
            ? double.PositiveInfinity
            : Math.Max(Math.Ceiling((maxXWall - initialXPos) / xDiff), Math.Floor((minXWall - initialXPos) / xDiff));
        var framesToWallY = yDiff == 0
            ? double.PositiveInfinity
            : Math.Max(Math.Ceiling((maxYWall - initialYPos) / yDiff), Math.Floor((minYWall - initialYPos) / yDiff));
        int framesToWall = (int)Math.Min(Math.Min(framesToWallX, framesToWallY), framesToLive);

        CommandPosition? ret = sprite.MovePrecisely(startTime, startTime + framesToWall * stepMilliseconds, initialXPos, initialYPos, initialXPos + framesToWall * xDiff, initialYPos + framesToWall * yDiff);
        framesToLive -= framesToWall;
        if (framesToLive <= 0)
        {
            return ret!.Value;
        }

        if (framesToWallX <= framesToWallY)
            direction = DegToRad(180) - direction;
        if (framesToWallY <= framesToWallX)
            direction = -direction;

        return sprite.MoveWithCollision(startTime + framesToWall * stepMilliseconds, initialXPos + framesToWall * xDiff, initialYPos + framesToWall * yDiff, direction, speed, framesToLive);
    }

    internal static void MoveAwayFromPlayer(this OsbSprite sprite, double startTime, CommandPosition spritePosition, CommandPosition playerPosition)
    {
        double playerDistance = spritePosition.DistanceFrom(playerPosition);
        sprite.MoveAwayFromPlayer(startTime, spritePosition, playerPosition, 5 + playerDistance / 15);
    }

    internal static void MoveAwayFromPlayer(this OsbSprite sprite, double startTime, CommandPosition spritePosition, CommandPosition playerPosition, double speed)
    {
        double direction = Math.Atan2(spritePosition.Y - playerPosition.Y, spritePosition.X - playerPosition.X);
        sprite.MoveWith(startTime, spritePosition.X, spritePosition.Y, direction, speed);
    }

    internal static OsbSprite CreateSprite(this StoryboardLayer layer, string path, double initialX, double initialY)
    {
        return layer.CreateSprite(path, OsbOrigin.Centre, new Vector2((float)(initialX * positionMultiplier), (float)(initialY * positionMultiplier)));
    }
}

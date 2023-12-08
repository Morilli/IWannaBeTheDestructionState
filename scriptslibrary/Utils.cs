using System;
using StorybrewCommon.Storyboarding.CommandValues;

namespace StorybrewScripts;

public static class Utils
{
    internal const double playfieldMiddleX = 400;
    internal const double playfieldMiddleY = 300;

    public static readonly Random random = new();
    internal static double DegToRad(double degree) => degree * Math.PI / 180;
    internal static double GamemakerDegreeToRad(double gamemakerDegree) => DegToRad(-gamemakerDegree);

    internal const int stepMilliseconds = 20; // 50 fps

    internal const double positionMultiplier = 0.8; // gamemaker to osu coordinate multiplier

    internal static double RadToDeg(double rad) => rad * 180 / Math.PI;

    internal static double PointDirection(double fromX, double fromY, double toX, double toY) => RadToDeg(-Math.Atan2(toY - fromY, toX - fromX));
    internal static double PointDistance(double fromX, double fromY, double toX, double toY) => Math.Sqrt(Math.Pow(toX - fromX, 2) + Math.Pow(toY - fromY, 2));

    internal static CommandPosition Rotate(CommandPosition position, double angle)
    {
        if (angle == 0) return position;

        double radAngle = DegToRad(-angle);
        double newX = playfieldMiddleX + (position.X - playfieldMiddleX) * Math.Cos(radAngle) - (position.Y - playfieldMiddleY) * Math.Sin(radAngle);
        double newY = playfieldMiddleY + (position.X - playfieldMiddleX) * Math.Sin(radAngle) + (position.Y - playfieldMiddleY) * Math.Cos(radAngle);

        return new CommandPosition(newX, newY);
    }
}

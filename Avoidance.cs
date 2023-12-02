using System;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.CommandValues;
using static StorybrewScripts.Utils;

namespace StorybrewScripts;

/// <summary>
/// <see cref="Avoidance"/>
/// </summary>
public class Avoidance : StoryboardObjectGenerator
{
    private StoryboardLayer OverlayLayer => GetLayer("Overlay");

    // storyboard commands for the background
    private void DoBG(int startTime, int duration)
    {
        var sprite = GetLayer("Foreground").CreateSprite("bg.png", playfieldMiddleX, playfieldMiddleY);
        sprite.Scale(startTime, startTime + duration, positionMultiplier, positionMultiplier);
    }

    // fade in in the beginning
    private void Do722(int startTime)
    {
        double a = 0.01;
        var sprite = OverlayLayer.CreateSprite("sprite513.png", playfieldMiddleX, playfieldMiddleY);
        sprite.Fade(0, startTime, 0, 1);
        sprite.Scale(startTime, startTime + 100 * stepMilliseconds, 2 * positionMultiplier, 2 * positionMultiplier);
        for (int i = 0; i < 100; i++)
        {
            double opacity = 0.75 + random.NextDouble() * 0.25 - a;
            opacity = Math.Max(opacity, 0);
            sprite.Fade(startTime + i * stepMilliseconds, startTime + (i + 1) * stepMilliseconds, opacity, opacity);
            a += 0.01;
        }
    }

    // first pattern
    private void Do719(int startTime, int flyAwayTime)
    {
        // "estimate" player position based on where people usually stand in this avoidance
        CommandPosition playerPosition = new CommandPosition(40, 600 - 40);

        double currentStartTime = startTime;
        double delay = 0;
        // the 8 bouncing objects spawning from the top middle of the room
        for (int _ = 0; _ < 8; _++)
        {
            delay += 0.8;
            int a = random.Next(360); // technically targeting the player, but yknow
            for (int i = 0; i < 8; i++)
            {
                const double speed = 4;
                double direction = a + i * 45;
                var sprite = OverlayLayer.CreateSprite("sprite514.png");
                CommandPosition finalPosition = sprite.MoveWithCollision(currentStartTime, 400, 152, DegToRad(direction), speed, (int)(flyAwayTime - currentStartTime) / stepMilliseconds);

                // quickly move objects away from player at frame 520
                sprite.MoveAwayFromPlayer(flyAwayTime, finalPosition, playerPosition);
            }

            currentStartTime += (65 - delay) * stepMilliseconds;
        }

        currentStartTime = startTime;
        // the falling objects spawning at random locations at the top of the screen
        for (int _ = 0; _ < 50; _++)
        {
            int initialX = random.Next(801);
            var sprite = OverlayLayer.CreateSprite("sprite514.png");
            const int speed = 6;
            double direction = DegToRad(90);
            CommandPosition? onScreen = sprite.MoveWith(currentStartTime, initialX, 0, direction, speed, (int)(flyAwayTime - currentStartTime) / stepMilliseconds);

            // quickly move objects away from player at frame 520
            if (onScreen is CommandPosition finalPosition)
            {
                sprite.MoveAwayFromPlayer(flyAwayTime, finalPosition, playerPosition);
            }

            currentStartTime += 10 * stepMilliseconds;
        }
    }

    // second pattern
    private void Do725(int startTime)
    {
        const int initialX = 400;
        const int initialY = 152;
        for (int i = 0; i < 4; i++)
        {
            var sprite = OverlayLayer.CreateSprite("sprite514.png", initialX, initialY);
            double currentX = initialX;
            double currentY = initialY;
            int direction = i * 360 / 4; // this just works because the direction is a multiple of 90
            double friction = -0.01;
            double speed = 15;
            for (int j = 0, a = 0, b = 0; j < 200; j++)
            {
                if (j % 3 == 0)
                {
                    a += 8;
                    b++;
                    var sprite2 = OverlayLayer.CreateSprite("sprite514.png", currentX, currentY);
                    var sprite3 = OverlayLayer.CreateSprite("sprite514.png", currentX, currentY);
                    double newSpeed = 10 + Math.Abs(7.5 * Math.Cos(b));
                    sprite2.MoveWith(startTime + j * stepMilliseconds, currentX, currentY, DegToRad(direction + 15 + a), newSpeed);
                    sprite3.MoveWith(startTime + j * stepMilliseconds, currentX, currentY, DegToRad(direction - 15 - a), newSpeed);
                }
                double x = Math.Cos(DegToRad(direction)) * speed;
                double y = Math.Sin(DegToRad(direction)) * speed;
                sprite.MovePrecisely(startTime + j * stepMilliseconds, startTime + (j + 1) * stepMilliseconds, currentX, currentY, currentX + x, currentY + y);
                currentX += x;
                currentY += y;
                if (currentX <= -8) currentX += 808;
                if (currentX >= 808) currentX -= 808;
                if (currentY <= -8) currentY += 616;
                if (currentY >= 616) currentY -= 616;
                speed -= friction;
                friction -= 0.01;
            }
        }
    }

    // the 30 highspeed random objects from the top of the screen
    private void Do729(int startTime, int flyAwayTime)
    {
        // once again we need to estimate the player position
        // based on scientific research this will be close to the bottom left corner
        // TODO could be somewhat randomized, but needs to be the same for all invocations with same flyAwayTime
        CommandPosition playerPosition = new CommandPosition(80, 600 - 40);
        for (int _ = 0; _ < 30; _++)
        {
            int direction = random.Next(360);
            const int speed = 17;
            int x = random.Next(48, 753);
            const int y = 32;
            var sprite = OverlayLayer.CreateSprite("sprite514.png", x, y);
            CommandPosition? onScreen = sprite.MoveWith(startTime, x, y, DegToRad(direction), speed, (flyAwayTime - startTime) / stepMilliseconds);
            if (onScreen is CommandPosition finalPosition)
            {
                sprite.MoveAwayFromPlayer(flyAwayTime, finalPosition, playerPosition, speed: 60);
            }
        }
    }

    // can't find good descriptions anymore; 0:19
    private void Do730(int startTime, int frictionStartTime, int targetPlayerTime)
    {
        const int initialX = 400;
        const int initialY = 304;
        CommandPosition estimatedPlayerPosition = new CommandPosition(80, 600 - 40);
        int framesToMove = (targetPlayerTime - startTime) / 20;
        int frictionStartFrame = (frictionStartTime - startTime) / 20 - 1;

        for (int i = 0; i < 20; i++)
        {
            var sprite = OverlayLayer.CreateSprite("sprite514.png");
            double direction = DegToRad(i * 18);
            double speed = 25;
            double currentX = initialX;
            double currentY = initialY;
            double friction = 0;
            CommandPosition? spritePosition = null;
            for (int frame = 0; frame < framesToMove; frame++)
            {
                if (frame == frictionStartFrame)
                    friction = 1;

                if (speed <= 0) speed = 0;
                const int minXWall = 40;
                const int maxXWall = 800 - 40;
                const int minYWall = 40;
                const int maxYWall = 600 - 40;

                double xDiff = Math.Cos(direction) * speed;
                double yDiff = Math.Sin(direction) * speed;

                var framesToWallX = xDiff == 0
                    ? double.PositiveInfinity
                    : Math.Max((maxXWall - currentX) / xDiff, (minXWall - currentX) / xDiff);
                var framesToWallY = yDiff == 0
                    ? double.PositiveInfinity
                    : Math.Max((maxYWall - currentY) / yDiff, (minYWall - currentY) / yDiff);

                spritePosition = sprite.MovePrecisely(startTime + frame * stepMilliseconds, startTime + (frame+1) * stepMilliseconds, currentX, currentY, currentX + xDiff, currentY + yDiff);

                if (framesToWallX < 2)
                    direction = DegToRad(180) - direction;
                if (framesToWallY < 2)
                    direction = -direction;

                currentX += xDiff;
                currentY += yDiff;
                speed -= friction;

                var sprite2 = OverlayLayer.CreateSprite("sprite514.png", currentX, currentY);
                sprite2.Scale(startTime + (frame+1) * stepMilliseconds, startTime + (frame+11) * stepMilliseconds, 1, 0);
            }

            // now target the player and try to utterly annihilate him with high speed projectiles
            speed = 40;
            direction = Math.Atan2(estimatedPlayerPosition.Y - spritePosition!.Value.Y, estimatedPlayerPosition.X - spritePosition.Value.X);
            int currentStartTime = targetPlayerTime;

            while (spritePosition is CommandPosition onScreenPosition)
            {
                double x = Math.Cos(direction) * speed;
                double y = Math.Sin(direction) * speed;

                var sprite2 = OverlayLayer.CreateSprite("sprite514.png", onScreenPosition.X, onScreenPosition.Y);
                sprite2.Scale(currentStartTime + stepMilliseconds, currentStartTime + 11*stepMilliseconds, 1, 0);

                spritePosition = sprite.MovePrecisely(currentStartTime, currentStartTime + stepMilliseconds, onScreenPosition.X, onScreenPosition.Y, onScreenPosition.X + x, onScreenPosition.Y + y);

                currentStartTime += stepMilliseconds;
            }
        }
    }


    public override void Generate()
    {
        int startTime = 26 * stepMilliseconds;
        DoBG(startTime, 120_000);
        Do722(startTime);
        Do719(startTime, 520 * stepMilliseconds);
        Do725(520 * stepMilliseconds);
        Do729(768 * stepMilliseconds, 822 * stepMilliseconds);
        Do729(778 * stepMilliseconds, 822 * stepMilliseconds);
        Do729(790 * stepMilliseconds, 822 * stepMilliseconds);
        Do729(804 * stepMilliseconds, 822 * stepMilliseconds);
        Do729(816 * stepMilliseconds, 822 * stepMilliseconds);
        Do729(828 * stepMilliseconds, 880 * stepMilliseconds);
        Do729(840 * stepMilliseconds, 880 * stepMilliseconds);
        Do729(852 * stepMilliseconds, 880 * stepMilliseconds);
        Do729(862 * stepMilliseconds, 880 * stepMilliseconds);
        Do729(874 * stepMilliseconds, 880 * stepMilliseconds);
        Do729(888 * stepMilliseconds, 936 * stepMilliseconds);
        Do729(900 * stepMilliseconds, 936 * stepMilliseconds);
        Do729(912 * stepMilliseconds, 936 * stepMilliseconds);
        Do729(924 * stepMilliseconds, 936 * stepMilliseconds);
        // Do730(954 * stepMilliseconds, 970 * stepMilliseconds, 996 * stepMilliseconds);

        // DoRotate(1014 + stepMilliseconds, )
        var step = 1014;
        var backRotate = 1118;

        // after 18 more steps create 731 and 733
    }
}

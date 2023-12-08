using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

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
            engine.ForEach<Object745>(engine.DeleteObject);
        }
    }
}

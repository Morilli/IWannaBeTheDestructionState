using System;
using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

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

    public override double Rotation => Direction;

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

    public override double Rotation => Direction;

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

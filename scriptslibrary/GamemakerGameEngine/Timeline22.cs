using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

public sealed class Object827 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object827 parent) : base(() =>
        {
            var a = PointDirection(parent.CurrentX, parent.CurrentY, 2000, 3072);
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object828(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 25,
                    Direction = a + 36 * i
                });
            }

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object827 parent) : base(() =>
        {
            parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 12,
                Direction = random.Next(361)
            });
            parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 12,
                Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + random.Next(16, 345)
            });

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object827(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 5;

        GravityStrength = 0.38;
        GravityDirection = 180;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object828 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object828 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }

    public Object828(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
        Invisible = true;
    }

    public override double Rotation => GamemakerDegreeToRad(Direction); // technically only done on initial step, but this is fine

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object829 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object829 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object829 parent) : base(() =>
        {
            parent.Speed = 8;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }

    public Object829(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
        Invisible = true;
    }

    public override double Rotation => GamemakerDegreeToRad(Direction); // technically only done on initial step, but this is fine

    public override void Step()
    {
        base.Step();
        if (NextY >= 2432 + 8) Invisible = false;
        if (NextX is > 2400 + 8 or < 1600 - 8 || (NextY > 3072 + 8 && PointDistance(NextX, NextY, 2000, 2768) > 500) || PointDistance(NextX, NextY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

public sealed class Object830 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object830 parent) : base(() =>
        {
            parent.engine.AddObject(new Object829(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            });

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object830 parent) : base(() =>
        {
            parent.engine.AddObject(new Object829(parent.engine, 1600, 2464)
            {
                Speed = 13,
                Direction = random.Next(-90, 1)
            });
            parent.engine.AddObject(new Object829(parent.engine, 2400, 2464)
            {
                Speed = 13,
                Direction = random.Next(180, 271)
            });

            parent.Clocks[1].Timer = 3;
        }) { }
    }

    public Object830(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object831 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object831 parent) : base(() =>
        {
            var a = PointDirection(parent.CurrentX, parent.CurrentY, 2000, 3072);
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object828(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 25,
                    Direction = a + 36 * i
                });
            }

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object831 parent) : base(() =>
        {
            parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 12,
                Direction = random.Next(361)
            });
            parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 12,
                Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + random.Next(16, 345)
            });

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object831(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 5;

        GravityStrength = 0.38;
        GravityDirection = 0;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object840 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object840 parent) : base(() =>
        {
            parent.engine.AddObject(new Object841(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            });
            parent.engine.AddObject(new Object842(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            });

            parent.Clocks[0].Timer = 4;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object840 parent) : base(() =>
        {
            var newObject = new Object841(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            };
            newObject.Clocks[2].Timer = 1;
            parent.engine.AddObject(newObject);
            var newObject2 = new Object842(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            };
            newObject2.Clocks[2].Timer = 1;
            parent.engine.AddObject(newObject2);

            parent.Clocks[1].Timer = 4;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object840 parent) : base(() =>
        {
            var newObject = new Object841(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            };
            newObject.Clocks[3].Timer = 1;
            parent.engine.AddObject(newObject);
            var newObject2 = new Object842(parent.engine, random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = random.Next(-150, -29)
            };
            newObject2.Clocks[3].Timer = 1;
            parent.engine.AddObject(newObject2);

            parent.Clocks[2].Timer = 4;
        }) { }
    }

    public Object840(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;
    }
}

public sealed class Object841 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object841 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object841 parent) : base(() =>
        {
            parent.Speed = 10;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object841 parent) : base(() =>
        {
            parent.Direction += 3;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object841 parent) : base(() =>
        {
            parent.Direction -= 6;

            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object841 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock5 : Cock
    {
        public Clock5(Object841 parent) : base(() =>
        {
            parent.engine.AddObject(new Object846(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object841(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
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

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
        Invisible = true;
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);

    public override void Step()
    {
        base.Step();
        if (NextY >= 2432) Invisible = false;
        if (NextX <= 1593 || PointDistance(NextX, NextY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

public sealed class Object842 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object842 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object842 parent) : base(() =>
        {
            parent.Speed = 10;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object842 parent) : base(() =>
        {
            parent.Direction -= 3;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object842 parent) : base(() =>
        {
            parent.Direction += 6;

            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object842 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock5 : Cock
    {
        public Clock5(Object842 parent) : base(() =>
        {
            parent.engine.AddObject(new Object846(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object842(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
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

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
        Invisible = true;
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);

    public override void Step()
    {
        base.Step();
        if (NextY >= 2432) Invisible = false;
        if (NextX <= 1593 || PointDistance(NextX, NextY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

public sealed class Object846 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object846 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object846(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object843 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object843 parent) : base(() =>
        {
            double a = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object828(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 25,
                    Direction = a + 36 * i
                });
            }

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object843 parent) : base(() =>
        {
            int repeat = random.Next(1, 3);
            for (int i = 0; i < repeat; i++)
            {
                parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 12,
                    Direction = random.Next(361)
                });
            }
            parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 12,
                Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + random.Next(16, 345)
            });

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object843(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        GravityStrength = 0.38;
        GravityDirection = 180;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object844 : GameObject
{
    private readonly double a;
    private double b;
    private double c;

    private class Clock0 : Cock
    {
        public Clock0(Object844 parent) : base(() =>
        {
            parent.b += 0.2;

            parent.engine.AddObject(new Object845(parent.engine, 1664 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 1792 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 1920 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 2048 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 2176 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 2304 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });

            parent.Clocks[0].Timer = (int)(32 - parent.b);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object844 parent) : base(() =>
        {
            parent.c += 0.2;

            parent.engine.AddObject(new Object845(parent.engine, 1728 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 1856 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 1984 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 2112 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });
            parent.engine.AddObject(new Object845(parent.engine, 2240 + 16, 2464)
            {
                Speed = parent.a,
                Direction = -90
            });

            parent.Clocks[1].Timer = (int)(32 - parent.c);
        }) { }
    }

    public Object844(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 16;

        a = 15;
    }
}

public sealed class Object845 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object845 parent) : base(() =>
        {
            parent.engine.AddObject(new Object849(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object845(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
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
        if (NextY <= 2448) engine.DeleteObject(this);
    }
}

public sealed class Object849 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object849 parent) : base(() =>
        {
            parent.Friction -= 0.0048;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object849 parent) : base(() =>
        {
            parent.GravityStrength = 0.3 + random.NextDouble() * 0.1;
            parent.GravityDirection = random.Next(-100, -79);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object849 parent) : base(() =>
        {
            if (parent.CurrentY <= 2456) parent.nextYOffset += 608 + 16;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object849 parent) : base(() =>
        {
            parent.Speed = random.Next(3, 11);
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object849 parent) : base(() =>
        {
            parent.engine.AddObject(new Object850(parent.engine, parent.CurrentX, parent.CurrentY));
            // TODO image_index = image_index
            parent.engine.DeleteObject(parent);
        }) { }
    }
    private class Clock5 : Cock
    {
        public Clock5(Object849 parent) : base(() =>
        {
            if (parent.CurrentY >= 3072) parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object849(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
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
        Clocks[0].Timer = 1;
        Clocks[2].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override double Rotation => GamemakerDegreeToRad(Direction);
}

public sealed class Object850 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object850 parent) : base(() =>
        {
            parent.Speed = 17;
            parent.Direction = random.Next(-180, 1);
        }) { }
    }

    public Object850(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite522_0.png"); // TODO check image index correctness
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}


using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

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

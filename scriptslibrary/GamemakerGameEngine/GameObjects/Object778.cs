namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

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
                Direction = Utils.PointDirection(1616, 2480, parent.engine.PlayerX, parent.engine.PlayerY)
            });
            parent.engine.AddObject(new Object779(parent.engine, 2384, 2480)
            {
                Speed = 8 + parent.f,
                Direction = Utils.PointDirection(2384, 2480, parent.engine.PlayerX, parent.engine.PlayerY)
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
                parent.b += Choice1[Utils.random.Next(4)];
                parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
                {
                    Speed = Utils.random.Next(4, 7),
                    Direction = parent.b
                });
                parent.c += Choice2[Utils.random.Next(4)];
                parent.engine.AddObject(new Object779(parent.engine, 2000, 2616)
                {
                    Speed = Utils.random.Next(4, 7),
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
                    Speed = Utils.random.Next(2, 14) + parent.f,
                    Direction = Utils.random.Next(361)
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

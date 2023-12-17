namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

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

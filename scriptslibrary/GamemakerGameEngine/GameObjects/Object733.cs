namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

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
            var repeat = Utils.random.Next(1, 3);
            Object735 idx;
            for (int i = 0; i < repeat; i++)
            {
                idx = new Object735(parent.engine, 400, 152)
                {
                    Speed = Utils.random.Next(7, 15),
                    Direction = Utils.random.Next(361)
                };
                parent.engine.AddObject(idx);
            }

            idx = new Object735(parent.engine, 400, 152)
            {
                Speed = Utils.random.Next(7, 15),
                Direction = Utils.PointDirection(400, 152, parent.engine.PlayerX, parent.engine.PlayerY) + Utils.random.Next(16, 345)
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

        a = Utils.PointDirection(400, 152, engine.PlayerX, engine.PlayerY) + 18;
        Clocks[0].Timer = 1;
        Clocks[2].Timer = 1;
    }
}

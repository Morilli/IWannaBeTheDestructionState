namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object808 : GameObject
{
    private double d;
    private double e;

    private class Clock0 : Cock
    {
        public Clock0(Object808 parent) : base(() =>
        {
            parent.d += 50.0 / 70; // 0.7142857142857143
            int repeat = Utils.random.Next(4) == 0 ? 3 : 2;
            for (int i = 0; i < repeat; i++)
            {
                var newObject = new Object809(parent.engine, 2000, 2464)
                {
                    c = 90 - parent.d,
                    Speed = 15,
                    Direction = Utils.random.Next(361)
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

            int repeat = Utils.random.Next(3) == 0 ? 2 : 3;
            for (int i = 0; i < repeat; i++)
            {
                parent.engine.AddObject(new Object810(parent.engine, 2000, 2464)
                {
                    Speed = 15 + parent.e,
                    Direction = Utils.random.Next(361)
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

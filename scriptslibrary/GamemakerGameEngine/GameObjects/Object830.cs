namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object830 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object830 parent) : base(() =>
        {
            parent.engine.AddObject(new Object829(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
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
                Direction = Utils.random.Next(-90, 1)
            });
            parent.engine.AddObject(new Object829(parent.engine, 2400, 2464)
            {
                Speed = 13,
                Direction = Utils.random.Next(180, 271)
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

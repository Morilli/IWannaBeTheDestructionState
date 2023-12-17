namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object856 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object856 parent) : base(() =>
        {
            parent.engine.AddObject(new Object857(parent.engine, 1600, Utils.random.Next(2464, 3073))
            {
                Speed = 10,
                Direction = Utils.random.Next(-90, 91)
            });
            parent.engine.AddObject(new Object857(parent.engine, 2400, Utils.random.Next(2464, 3073))
            {
                Speed = 10,
                Direction = Utils.random.Next(90, 271)
            });

            parent.Clocks[0].Timer = 4;
        }) { }
    }

    public Object856(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

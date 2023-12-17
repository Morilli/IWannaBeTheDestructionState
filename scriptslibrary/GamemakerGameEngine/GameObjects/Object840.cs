namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object840 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object840 parent) : base(() =>
        {
            parent.engine.AddObject(new Object841(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
            });
            parent.engine.AddObject(new Object842(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
            });

            parent.Clocks[0].Timer = 4;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object840 parent) : base(() =>
        {
            var newObject = new Object841(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
            };
            newObject.Clocks[2].Timer = 1;
            parent.engine.AddObject(newObject);
            var newObject2 = new Object842(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
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
            var newObject = new Object841(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
            };
            newObject.Clocks[3].Timer = 1;
            parent.engine.AddObject(newObject);
            var newObject2 = new Object842(parent.engine, Utils.random.Next(1600, 2401), 2272)
            {
                Speed = 13,
                Direction = Utils.random.Next(-150, -29)
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

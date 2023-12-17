namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object750 : GameObject
{
    private int a;

    private class Clock0 : Cock
    {
        public Clock0(Object750 parent) : base(() =>
        {
            parent.a += 10;
            var newObject = new Object751(parent.engine, 1600, Utils.random.Next(0 + parent.a, 609 + parent.a))
            {
                Speed = Utils.random.Next(6, 9),
                Direction = Utils.random.Next(-90, 91)
            };
            parent.engine.AddObject(newObject);

            newObject = new Object751(parent.engine, 2400, Utils.random.Next(0 + parent.a, 609 + parent.a))
            {
                Speed = Utils.random.Next(6, 9),
                Direction = Utils.random.Next(90, 271)
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

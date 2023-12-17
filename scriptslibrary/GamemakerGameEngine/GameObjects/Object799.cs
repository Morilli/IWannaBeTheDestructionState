namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

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

        int imageIndex = Utils.random.Next(8);

        double a = Utils.random.NextDouble() * 30;
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

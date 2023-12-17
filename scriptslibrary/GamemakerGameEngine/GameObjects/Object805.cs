namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object805 : GameObject
{
    private int image_index;
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object805 parent) : base(() =>
        {
            parent.image_index = Utils.random.Next(8);

            parent.a = Utils.random.NextDouble() * 24;
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
            parent.image_index = Utils.random.Next(8);

            parent.a = Utils.random.NextDouble() * 24;
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

        image_index = Utils.random.Next(8);
    }
}

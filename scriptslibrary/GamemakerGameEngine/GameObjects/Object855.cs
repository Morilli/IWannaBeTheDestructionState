namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object855 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object855 parent) : base(() =>
        {
            int a = Utils.random.Next(21);
            int imageIndex = Utils.random.Next(8);
            for (int i = 0; i < 18; i++)
            {
                parent.engine.AddObject(new Object854(parent.engine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 20 * i

                });
            }

            parent.Clocks[0].Timer = 2;
        }) { }
    }

    public Object855(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

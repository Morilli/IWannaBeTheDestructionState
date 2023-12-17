using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object858 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object858 parent) : base(() =>
        {
            for (int i = 0; i < 3; i++)
            {
                parent.engine.AddObject(new Object854(parent.engine, 2000, 2616, random.Next(8))
                {
                    Speed = random.Next(8, 23),
                    Direction = random.Next(361)
                });
            }

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object858 parent) : base(() =>
        {
            int imageIndex = random.Next(8);
            int a = random.Next(37);
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object854(parent.engine, 2000, 2616, imageIndex)
                {
                    Speed = 23,
                    Direction = a + 36 * i
                });
            }

            parent.Clocks[1].Timer = 2;
        }) { }
    }

    public Object858(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[1].Timer = 1;
    }
}

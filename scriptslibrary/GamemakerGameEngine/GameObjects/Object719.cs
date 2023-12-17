namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object719 : GameObject
{
    private double b;

    private class Clock0 : Cock
    {
        public Clock0(Object719 parent) : base(() =>
        {
            parent.b += 0.8;

            var a = Utils.PointDirection(400, 152, parent.engine.PlayerX, parent.engine.PlayerY);
            for (int i = 0; i < 8; i++)
            {
                parent.engine.AddObject(new Object723(parent.engine, 400, 152)
                {
                    Speed = 4,
                    Direction = a + 45 * i
                });
            }

            parent.Clocks[0].Timer = (int)(65 - parent.b);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object719 parent) : base(() =>
        {
            parent.engine.AddObject(new Object724(parent.engine, Utils.random.Next(801), 0)
            {
                Speed = 6,
                Direction = -90
            });

            parent.Clocks[1].Timer = 10;
        }) { }
    }

    public Object719(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
    }
}

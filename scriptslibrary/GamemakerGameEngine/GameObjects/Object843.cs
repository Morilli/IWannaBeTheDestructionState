namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object843 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object843 parent) : base(() =>
        {
            double a = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object828(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 25,
                    Direction = a + 36 * i
                });
            }

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object843 parent) : base(() =>
        {
            int repeat = Utils.random.Next(1, 3);
            for (int i = 0; i < repeat; i++)
            {
                parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 12,
                    Direction = Utils.random.Next(361)
                });
            }
            parent.engine.AddObject(new Object829(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 12,
                Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + Utils.random.Next(16, 345)
            });

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object843(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        GravityStrength = 0.38;
        GravityDirection = 180;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object851 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object851 parent) : base(() =>
        {
            double a = Utils.PointDirection(parent.CurrentX, parent.CurrentY, 2000, 3072);
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
        public Clock1(Object851 parent) : base(() =>
        {
            for (int i = 0; i < 2; i++)
            {
                parent.engine.AddObject(new Object853(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = 13,
                    Direction = Utils.random.Next(361)
                });
            }

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object851(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1; // commented out
        Clocks[1].Timer = 1;

        GravityStrength = 0.38;
        GravityDirection = 180;
    }

    public override void EndStep()
    {
        base.EndStep();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

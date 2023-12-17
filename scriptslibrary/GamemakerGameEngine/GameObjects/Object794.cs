namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object794 : GameObject
{
    private double image_index;
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object794 parent) : base(() =>
        {
            for (int i = 0; i < 2; i++)
            {
                parent.engine.AddObject(new Object795(parent.engine, parent.CurrentX, parent.CurrentY, (int)parent.image_index)
                {
                    Speed = 14,
                    Direction = Utils.random.Next(361)
                });
                parent.engine.AddObject(new Object795(parent.engine, parent.CurrentX, parent.CurrentY, (int)parent.image_index)
                {
                    Speed = 14,
                    Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 1 + Utils.random.NextDouble() * 358
                });
            }

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object794 parent) : base(() =>
        {
            parent.a += 0.2;
            parent.engine.ForEach<Object795>(o => o.Speed = 75);

            parent.Clocks[1].Timer = (int)(15 + parent.a);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object794 parent) : base(() =>
        {
            parent.engine.ForEach<Object795>(o => o.Speed = 15);

            parent.Clocks[2].Timer = (int)(15 + parent.a);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object794 parent) : base(() =>
        {
            parent.image_index++;

            parent.Clocks[3].Timer = (int)(15 + parent.a);
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object794 parent) : base(() =>
        {
            parent.image_index += 0.06;

            parent.Clocks[4].Timer = 1;
        }) { }
    }

    public Object794(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 15;
        Clocks[2].Timer = 16;
        Clocks[3].Timer = 15;
    }

    public override void Step()
    {
        base.Step();
        if (CurrentX <= 1592 || CurrentY <= 2456) engine.DeleteObject(this);
    }
}

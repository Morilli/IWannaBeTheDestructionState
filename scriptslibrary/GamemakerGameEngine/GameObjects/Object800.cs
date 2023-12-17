namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object800 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object800 parent) : base(() =>
        {
            parent.Friction += 0.01;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object800 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
        }) { }
    }
    private class Clock2 : Cock
    {
        // is actually empty in original source
        public Clock2(Object800 parent) : base(() => {}) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object800 parent) : base(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                parent.engine.AddObject(new Object804(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
                {
                    Scale = 0.5 + Utils.random.NextDouble() * 0.5,
                    Speed = Utils.random.Next(4, 17),
                    Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768) + Utils.random.Next(90, 271)
                });
            }

            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object800(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 15;

        image_index = imageIndex;
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

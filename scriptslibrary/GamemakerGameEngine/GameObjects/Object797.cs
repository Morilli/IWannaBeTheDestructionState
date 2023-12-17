namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object797 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object797 parent) : base(() =>
        {
            parent.engine.AddObject(new Object788(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
            {
                Speed = 15,
                Direction = -90
            });

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object797 parent) : base(() =>
        {
            parent.Friction -= 0.015;

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object797(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        image_index = Utils.random.Next(8);
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{image_index}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object783 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object783 parent) : base(() =>
        {
            parent.engine.AddObject(new Object784(parent.engine, parent.CurrentX + Utils.random.Next(-48, 49), parent.CurrentY + Utils.random.Next(-48, 49), parent.image_index));

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object783 parent) : base(() =>
        {
            parent.engine.AddObject(new Object786(parent.engine, parent.CurrentX + Utils.random.Next(-48, 49), parent.CurrentY + Utils.random.Next(-48, 49), parent.image_index));

            parent.Clocks[1].Timer = 2;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object783 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object783(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 1;

        image_index = Utils.random.Next(8);
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{image_index}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

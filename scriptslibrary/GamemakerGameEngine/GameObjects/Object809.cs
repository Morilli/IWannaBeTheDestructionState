namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object809 : GameObject
{
    internal double c;

    private class Clock0 : Cock
    {
        public Clock0(Object809 parent) : base(() =>
        {
            parent.Direction += parent.c;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object809 parent) : base(() =>
        {
            parent.Direction -= parent.c;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object809 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object809 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }

    public Object809(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[Utils.random.Next(2)].Timer = 15;
        Clocks[2].Timer = 1 + Utils.random.Next(15);

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{Utils.random.Next(8)}.png");
        Invisible = true;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

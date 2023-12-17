namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object849 : GameObject
{
    internal int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object849 parent) : base(() =>
        {
            parent.Friction -= 0.0048;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object849 parent) : base(() =>
        {
            parent.GravityStrength = 0.3 + Utils.random.NextDouble() * 0.1;
            parent.GravityDirection = Utils.random.Next(-100, -79);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object849 parent) : base(() =>
        {
            if (parent.PreviousY <= 2456) parent.nextYOffset += 608 + 16;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object849 parent) : base(() =>
        {
            parent.Speed = Utils.random.Next(3, 11);
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object849 parent) : base(() =>
        {
            parent.engine.AddObject(new Object850(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index));
            parent.engine.DeleteObject(parent);
        }) { }
    }
    private class Clock5 : Cock
    {
        public Clock5(Object849 parent) : base(() =>
        {
            if (parent.PreviousY >= 3072) parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object849(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this),
            new Clock5(this)
        };
        Clocks[0].Timer = 1;
        Clocks[2].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override void BeginStep()
    {
        base.BeginStep();
        Rotation = Direction;
    }
}

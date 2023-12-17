namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object770 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object770 parent) : base(() =>
        {
            parent.engine.AddObject(new Object771(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object770(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png"); // technically 520 with image speed 0
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

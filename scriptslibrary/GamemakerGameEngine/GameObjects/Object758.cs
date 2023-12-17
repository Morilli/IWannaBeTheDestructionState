namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object758 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object758 parent) : base(() =>
        {
            parent.Invisible = false;
            parent.nextXOffset += 800;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object758 parent) : base(() =>
        {
            parent.Invisible = true;
            parent.nextXOffset -= 800;
        }) { }
    }

    public Object758(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
        Invisible = true;
    }

    public override void Step()
    {
        base.Step();
        if (Speed != 0 && IsOffscreen()) engine.DeleteObject(this);
    }
}

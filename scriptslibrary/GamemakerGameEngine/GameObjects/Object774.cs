namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object774 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object774 parent) : base(() =>
        {
            parent.Scale -= 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object774(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

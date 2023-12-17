namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object817 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object817 parent) : base(() =>
        {
            parent.Scale -= 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object817(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen() || Scale <= 0) engine.DeleteObject(this);
    }
}

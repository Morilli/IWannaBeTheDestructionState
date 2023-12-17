namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object788 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object788 parent) : base(() =>
        {
            parent.Scale -= 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object788(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

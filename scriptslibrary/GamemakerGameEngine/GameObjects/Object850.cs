namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object850 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object850 parent) : base(() =>
        {
            parent.Speed = 17;
            parent.Direction = Utils.random.Next(-180, 1);
        }) { }
    }

    public Object850(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object759 : GameObject
{
    private readonly double a;

    private class Clock0 : Cock
    {
        public Clock0(Object759 parent) : base(() =>
        {
            parent.Speed = parent.a;
        }) { }
    }

    public Object759(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        a = Speed;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

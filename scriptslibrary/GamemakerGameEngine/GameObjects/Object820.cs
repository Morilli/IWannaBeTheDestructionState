namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object820 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object820 parent) : base(() =>
        {
            parent.engine.AddObject(new Object821(parent.engine, parent.CurrentX, parent.CurrentY));

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object820(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

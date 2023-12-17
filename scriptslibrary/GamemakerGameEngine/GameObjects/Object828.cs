namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object828 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object828 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }

    public Object828(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
        Invisible = true;
    }

    public override void BeginStep()
    {
        base.BeginStep();
        Rotation = Direction;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

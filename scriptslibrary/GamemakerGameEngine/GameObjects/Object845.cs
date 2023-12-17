namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object845 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object845 parent) : base(() =>
        {
            parent.engine.AddObject(new Object849(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = parent.Speed,
                Direction = parent.Direction
            });
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object845(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override void BeginStep()
    {
        base.BeginStep();
        Rotation = Direction;
    }

    public override void Step()
    {
        base.Step();
        if (CurrentY <= 2448) engine.DeleteObject(this);
    }
}

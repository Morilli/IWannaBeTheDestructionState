namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object825 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object825 parent) : base(() =>
        {
            parent.Speed = 25;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object825 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }

    public Object825(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

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
        if (CurrentX <= 1560 || CurrentY <= 2424 || IsOffscreen())
        {
            engine.DeleteObject(this);
        }
    }
}

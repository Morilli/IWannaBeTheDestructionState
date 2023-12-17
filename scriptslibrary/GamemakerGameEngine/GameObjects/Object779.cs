namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object779 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object779 parent) : base(() =>
        {
            parent.Speed = 25;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object779 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object779 parent) : base(() =>
        {
            parent.engine.AddObject(new Object825(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                // Speed = parent.Speed,
                // Direction = parent.Direction
            });
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object779(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

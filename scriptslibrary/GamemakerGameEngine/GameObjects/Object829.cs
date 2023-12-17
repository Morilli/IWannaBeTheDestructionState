namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object829 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object829 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object829 parent) : base(() =>
        {
            parent.Speed = 8;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }

    public Object829(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

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
        if (CurrentY >= 2432 + 8) Invisible = false;
        if (CurrentX is > 2400 + 8 or < 1600 - 8 || (CurrentY > 3072 + 8 && Utils.PointDistance(CurrentX, CurrentY, 2000, 2768) > 500) || Utils.PointDistance(CurrentX, CurrentY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

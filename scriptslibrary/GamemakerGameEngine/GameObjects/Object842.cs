namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object842 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object842 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object842 parent) : base(() =>
        {
            parent.Speed = 10;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object842 parent) : base(() =>
        {
            parent.Direction -= 3;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object842 parent) : base(() =>
        {
            parent.Direction += 6;

            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object842 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock5 : Cock
    {
        public Clock5(Object842 parent) : base(() =>
        {
            parent.engine.AddObject(new Object846(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object842(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this),
            new Clock5(this)
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
        if (CurrentY >= 2432) Invisible = false;
        if (CurrentX <= 1593 || Utils.PointDistance(CurrentX, CurrentY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

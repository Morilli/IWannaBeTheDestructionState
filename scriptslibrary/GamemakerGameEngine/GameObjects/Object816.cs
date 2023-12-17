namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object816 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object816 parent) : base(() =>
        {
            parent.CollideWithBorders2();

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object816 parent) : base(() =>
        {
            parent.Friction += 1.2;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object816 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object816 parent) : base(() =>
        {
            parent.engine.AddObject(new Object817(parent.engine, parent.CurrentX, parent.CurrentY));

            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object816 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768) + 180;
        }) { }
    }

    public Object816(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;
        Clocks[3].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

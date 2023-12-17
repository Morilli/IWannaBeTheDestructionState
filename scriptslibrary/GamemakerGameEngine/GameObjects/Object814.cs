namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object814 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object814 parent) : base(() =>
        {
            parent.Scale -= 0.2; // TODO xscale yscale -0.22

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object814 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object814 parent) : base(() => { }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object814 parent) : base(() => { }) { }
    }

    public Object814(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 1) Clocks[0].Timer = 0;
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

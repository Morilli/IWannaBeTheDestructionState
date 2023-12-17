namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object784 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object784 parent) : base(() =>
        {
            parent.Speed = 14;
            parent.Direction = Utils.random.Next(-105, -74);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object784 parent) : base(() =>
        {
            parent.Scale -= 0.2;

            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object784 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object784 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object784 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
            parent.Clocks[4].Timer = 1;
        }) { }
    }

    public Object784(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 10;
        Clocks[1].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
        Scale = 3;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
        if (Scale <= 1)
        {
            Scale = 1;
            Clocks[1].Timer = 0;
        }
    }
}

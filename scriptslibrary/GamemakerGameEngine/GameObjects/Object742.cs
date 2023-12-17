namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object742 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object742 parent) : base(() =>
        {
            parent.CollideWithBorders();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object742 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object742 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object742 parent) : base(() =>
        {
            parent.nextYOffset -= 8;
            parent.Clocks[3].Timer = 1;
        }) { }
    }

    public Object742(GameEngine engine, int initialX = 400, int initialY = 152) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

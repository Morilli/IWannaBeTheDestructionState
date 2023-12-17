namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object772 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object772 parent) : base(() =>
        {
            parent.CollideWithBorders2();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object772 parent) : base(() =>
        {
            parent.Friction -= 0.01;
            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object772 parent) : base(() =>
        {
            if (parent.CurrentX <= 2384) parent.nextXOffset += 816;
            if (parent.CurrentX >= 3216) parent.nextXOffset -= 816;
            if (parent.CurrentY <= 2448) parent.nextYOffset += 624;
            if (parent.CurrentY >= 3056) parent.nextYOffset -= 624;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object772 parent) : base(() =>
        {
            parent.engine.AddObject(new Object774(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object772 parent) : base(() =>
        {
            parent.Speed = 30;
            parent.Direction = Utils.random.Next(361);
        }) { }
    }

    public Object772(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
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

        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

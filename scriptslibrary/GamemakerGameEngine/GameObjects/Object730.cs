namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object730 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object730 parent) : base(() =>
        {
            parent.CollideWithBorders();
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object730 parent) : base(() =>
        {
            parent.Friction++;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object730 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object730 parent) : base(() =>
        {
            parent.engine.AddObject(new Object732(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object730 parent) : base(() =>
        {
            for (int i = 0; i < 20; i++)
            {
                var idx = new Object730(parent.engine, 400, 304)
                {
                    Speed = 25,
                    Direction = i * 18
                };
                parent.engine.AddObject(idx);
            }
        }) { }
    }

    public Object730(GameEngine engine, int initialX, int initialY) : base(engine, initialX, initialY)
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

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object751 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object751 parent) : base(() =>
        {
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object751 parent) : base(() =>
        {
            parent.Speed = 40;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object751 parent) : base(() =>
        {
            if (Utils.random.Next(4) == 0)
            {
                parent.Clocks[1].Timer = 1;
            }
        }) { }
    }

    public Object751(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
        };

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
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

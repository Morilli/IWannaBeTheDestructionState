namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object734 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object734 parent) : base(() =>
        {
            parent.Invisible = false;
        }) { }
    }
    public Object734(GameEngine engine, int initialX, int initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

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
        if (Utils.PointDistance(CurrentX, CurrentY, 400, 300) > 500) engine.DeleteObject(this);
    }
}

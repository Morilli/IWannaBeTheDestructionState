namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object724 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object724 parent) : base(() =>
        {
            parent.Speed = 5 + Utils.PointDistance(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) / 15;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object724(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void EndStep()
    {
        base.EndStep();
        if (IsOutsideOfRoom()) engine.DeleteObject(this);
    }
}

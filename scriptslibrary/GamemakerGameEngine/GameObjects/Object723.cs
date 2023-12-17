namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object723 : GameObject
{
    private double b;

    private class Clock0 : Cock
    {
        public Clock0(Object723 parent) : base(() =>
        {
            parent.CollideWithBorders();

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object723 parent) : base(() =>
        {
            parent.Speed = 5 + Utils.PointDistance(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) / 15;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object723(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
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

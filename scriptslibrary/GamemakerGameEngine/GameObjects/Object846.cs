namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object846 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object846 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object846(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

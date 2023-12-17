namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object810 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object810 parent) : base(() =>
        {
            parent.Speed = 7;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
            parent.GravityDirection = -90;
            parent.GravityStrength = 0.2;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object810 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object810(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{Utils.random.Next(8)}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object813 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object813 parent) : base(() =>
        {
            parent.Speed = 2;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object813 parent) : base(() =>
        {
            parent.Friction -= 0.04;

            parent.Clocks[1].Timer = 1;
        }) { }
    }
    public Object813(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOutsideOfRoom() || CurrentX < 1600 - 8 || PointDistance(CurrentX, CurrentY, 2000, 2768) >= 1000) engine.DeleteObject(this);
    }
}

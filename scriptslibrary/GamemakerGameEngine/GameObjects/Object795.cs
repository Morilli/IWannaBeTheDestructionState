namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object795 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object795 parent) : base(() =>
        {
            parent.Friction -= 0.015;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object795 parent) : base(() =>
        {
            if(parent.CurrentX < 1592) parent.engine.DeleteObject(parent);
            if(parent.CurrentX > 2408) parent.engine.DeleteObject(parent);
            if(parent.CurrentY < 2456) parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object795(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex % 8}.png");
    }

    public override void Step()
    {
        base.Step();
        if (Utils.PointDistance(CurrentX, CurrentY, 2000, 2768) > 500) engine.DeleteObject(this);
    }
}

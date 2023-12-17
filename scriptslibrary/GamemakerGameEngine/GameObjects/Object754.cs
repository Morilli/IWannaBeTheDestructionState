namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object754 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object754 parent) : base(() =>
        {
            parent.Invisible = false;
            parent.nextXOffset += 800;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object754 parent) : base(() =>
        {
            parent.Invisible = true;
            parent.nextXOffset -= 800;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object754 parent) : base(() =>
        {
            if (Utils.random.Next(4) == 0) parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object754 parent) : base(() =>
        {
            // parent.engine.AddObject(new Object757(parent.engine, parent.CurrentX, parent.CurrentY));
            parent.Speed = 40;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object754(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
        Invisible = true;
    }

    public override void Step()
    {
        base.Step();
        if (Speed != 0 && IsOffscreen()) engine.DeleteObject(this);
    }
}

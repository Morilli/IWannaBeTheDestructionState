namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object777 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object777 parent) : base(() =>
        {
            parent.Alpha += 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object777 parent) : base(() =>
        {
            parent.Alpha -= 0.02;

            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object777(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 2 * 400, initialY + 2 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite513.png");
        Scale = 4;
        Alpha = 0;
    }

    public override void Step()
    {
        base.Step();
        if (Alpha <= 0) engine.DeleteObject(this);
    }
}

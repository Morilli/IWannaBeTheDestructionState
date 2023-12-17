namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object722 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object722 parent) : base(() =>
        {
            parent.a += 0.01;
            parent.Alpha = 0.75 + Utils.random.NextDouble() * 0.25 - parent.a;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object722(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite513.png");
        Scale = 2;
    }

    public override void Step()
    {
        base.Step();
        if (a >= 1) engine.DeleteObject(this);
    }
}

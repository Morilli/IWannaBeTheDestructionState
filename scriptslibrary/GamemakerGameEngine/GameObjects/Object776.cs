namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object776 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object776 parent) : base(() =>
        {
            parent.Alpha += 0.02;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object776(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 2 * 400, initialY + 2 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 4;
        Alpha = 0;
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object745 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object745 parent) : base(() =>
        {
            parent.Alpha += 0.02;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object745(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 1.5 * 400, initialY + 1.5 + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 3;
        Alpha = 0;
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object752 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object752 parent) : base(() =>
        {
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object752(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 5 * 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite517.png");
        Scale = 10; // technically xscale 2, yscale 10; need to check whether this makes any difference
    }
}

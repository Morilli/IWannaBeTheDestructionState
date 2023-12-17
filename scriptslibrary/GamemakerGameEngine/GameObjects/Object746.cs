namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object746 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object746 parent) : base(() =>
        {
            parent.Alpha += 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object746(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite(-1100000, "sprite513.png");
        Scale = 2;
        Alpha = 0;
    }

    public override void Step()
    {
        base.Step();
        if (Alpha >= 1)
        {
            engine.ForEach<Object745>(engine.DeleteObject);
        }
    }
}

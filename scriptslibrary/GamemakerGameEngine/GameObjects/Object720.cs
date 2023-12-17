namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object720 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object720 parent) : base(() =>
        {
            parent.Alpha -= 0.01;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object720(GameEngine engine, double initialX, double initialY) : base(engine, initialX + 400, initialY + 304)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite(-1000000, "sprite513.png");
        Scale = 2;
    }

    public override void Step()
    {
        base.Step();
        if (Alpha <= 0) engine.DeleteObject(this);
    }
}

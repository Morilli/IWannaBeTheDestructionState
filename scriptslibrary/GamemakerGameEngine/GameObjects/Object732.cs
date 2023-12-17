namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object732 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object732 parent) : base(() =>
        {
            parent.Scale -= 0.1;
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen() || Scale <= 0) engine.DeleteObject(this);
    }

    public Object732(GameEngine engine, double initialX = 400, double initialY = 340) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }
}

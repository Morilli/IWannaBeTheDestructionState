namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object775 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object775 parent) : base(() =>
        {
            parent.a += 2;
            parent.engine.ViewAngle += 10 + parent.a;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object775(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

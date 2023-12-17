namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object744 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object744 parent) : base(() =>
        {
            parent.a += 0.2;
            parent.engine.ViewXOffset = Utils.random.Next((int)(-8 - parent.a), (int)(9 + parent.a));
            parent.engine.ViewYOffset = Utils.random.Next((int)(-8 - parent.a), (int)(9 + parent.a));
            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object744(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

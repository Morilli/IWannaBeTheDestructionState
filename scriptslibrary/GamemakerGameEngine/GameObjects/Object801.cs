namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object801 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object801 parent) : base(() =>
        {
            parent.engine.AddObject(new Object799(parent.engine));

            parent.Clocks[0].Timer = 15;
        }) { }
    }

    public Object801(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

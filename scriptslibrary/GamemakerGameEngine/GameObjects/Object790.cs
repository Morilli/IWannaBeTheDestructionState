namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object790 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object790 parent) : base(() =>
        {
            parent.engine.AddObject(new Object789(parent.engine));

            parent.Clocks[0].Timer = 15;
        }) { }
    }

    public Object790(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;
    }
}

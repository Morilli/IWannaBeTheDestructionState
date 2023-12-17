namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object796 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object796 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 8;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object796 parent) : base(() =>
        {
            parent.engine.ViewXOffset = 1600;
            parent.engine.ViewYOffset = 2464;
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object796(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 5;

        engine.ViewYOffset -= 32;
        engine.AddObject(new Object797(engine, engine.PlayerX, 2464)
        {
            Speed = 30,
            Direction = -90
        });
    }
}

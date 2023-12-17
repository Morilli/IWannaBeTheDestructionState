namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object789 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object789 parent) : base(() =>
        {
            parent.engine.ViewXOffset += 8;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object789 parent) : base(() =>
        {
            parent.engine.ViewXOffset = 1600;
            parent.engine.ViewYOffset = 2464;
            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object789(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 5;

        engine.ViewXOffset -= 32;
        engine.AddObject(new Object787(engine, 2400, engine.PlayerY)
        {
            Speed = 30,
            Direction = 180
        });
    }
}

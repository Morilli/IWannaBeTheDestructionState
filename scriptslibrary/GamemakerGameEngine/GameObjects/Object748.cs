namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object748 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 2;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 6;
            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset -= 2;
            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object748 parent) : base(() =>
        {
            parent.engine.ViewYOffset += 13;
            parent.Clocks[3].Timer = 1;
        }) { }
    }

    public Object748(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
        };
        Clocks[0].Timer = 1;

    }
}

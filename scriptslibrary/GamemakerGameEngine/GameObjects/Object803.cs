namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object803 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object803 parent) : base(() =>
        {
            parent.engine.ViewWidth += 16;
            parent.engine.ViewHeight += 16;
            parent.engine.ViewXOffset -= 8;
            parent.engine.ViewYOffset -= 8;
            parent.engine.ViewAngle--;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object803 parent) : base(() =>
        {
            parent.Clocks[0].Timer = 0;
            parent.engine.ViewWidth = 800;
            parent.engine.ViewHeight = 608;
            parent.engine.ViewXOffset = 1600;
            parent.engine.ViewYOffset = 2464;
            parent.engine.ViewAngle = 0;

            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object803(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
        Clocks[1].Timer = 10;
    }
}

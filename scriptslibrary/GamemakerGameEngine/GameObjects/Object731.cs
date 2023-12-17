namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object731 : GameObject
{
    private double a;

    private class Clock0 : Cock
    {
        public Clock0(Object731 parent) : base(() =>
        {
            parent.a += 0.01;
            parent.engine.ViewAngle -= 1 - parent.a;
            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object731 parent) : base(() =>
        {
            parent.engine.ViewAngle += 8;
            parent.Clocks[1].Timer = 1;
        }) { }
    }

    public Object731(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;
    }
}

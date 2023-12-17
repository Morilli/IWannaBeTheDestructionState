namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object785 : GameObject
{
    private double a;
    private double b;
    private double c;

    private class Clock0 : Cock
    {
        public Clock0(Object785 parent) : base(() =>
        {
            parent.b += 0.2;

            parent.engine.AddObject(new Object783(parent.engine, 1600, 2528)
            {
                Speed = 50
            });

            parent.Clocks[0].Timer = (int)(32 - parent.b + parent.c);
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object785 parent) : base(() =>
        {
            parent.a += 0.2;

            parent.engine.AddObject(new Object783(parent.engine, 2400, 2528)
            {
                Speed = 50,
                Direction = 180
            });

            parent.Clocks[1].Timer = (int)(32 - parent.a + parent.c);
        }) { }
    }

    public Object785(GameEngine engine) : base(engine)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 16;
        Clocks[1].Timer = 1;
    }
}

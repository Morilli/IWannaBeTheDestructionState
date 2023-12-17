namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object859 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object859 parent) : base(() =>
        {
            parent.Alpha -= 0.02;

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object859 parent) : base(() =>
        {
            parent.Alpha -= 0.02;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object859(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (Alpha <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

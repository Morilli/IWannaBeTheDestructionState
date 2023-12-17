namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object854 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object854 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object854 parent) : base(() =>
        {
            parent.engine.AddObject(new Object859(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
            {
                Speed = parent.Speed,
                Direction = parent.Direction
            });

            parent.engine.DeleteObject(parent);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object854 parent) : base(() =>
        {
            parent.engine.AddObject(new Object859(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
            {
                Speed = parent.Speed,
                Direction = parent.Direction
            });

            parent.engine.DeleteObject(parent);
        }) { }
    }

    public Object854(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };

        image_index = imageIndex;
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (Alpha <= 0 || IsOffscreen()) engine.DeleteObject(this);
    }
}

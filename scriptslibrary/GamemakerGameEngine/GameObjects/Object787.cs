namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object787 : GameObject
{
    private readonly int image_index;

    private class Clock0 : Cock
    {
        public Clock0(Object787 parent) : base(() =>
        {
            parent.engine.AddObject(new Object788(parent.engine, parent.CurrentX, parent.CurrentY, parent.image_index)
            {
                Speed = 15,
                Direction = 180
            });

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object787 parent) : base(() =>
        {
            parent.Speed = 3;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object787 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object787(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this)
        };
        Clocks[0].Timer = 1;

        image_index = Utils.random.Next(8);
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{image_index}.png");
    }

    public override void EndStep()
    {
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

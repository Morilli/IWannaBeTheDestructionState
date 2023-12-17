namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object853 : GameObject
{
    public Object853(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite546_{Utils.random.Next(8)}.png");
    }

    public override void BeginStep()
    {
        base.BeginStep();
        Rotation = Direction;
    }

    public override void EndStep()
    {
        base.EndStep();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object811 : GameObject
{
    public Object811(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOutsideOfRoom() || CurrentX < 1600 - 8) engine.DeleteObject(this);
    }
}

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object762 : GameObject
{
    public Object762(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite516.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

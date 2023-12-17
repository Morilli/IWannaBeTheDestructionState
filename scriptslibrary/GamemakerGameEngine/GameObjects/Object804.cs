namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class Object804 : GameObject
{
    public Object804(GameEngine engine, double initialX, double initialY, int imageIndex) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite($"sprite522_{imageIndex}.png");
        GravityStrength = 0.4;
        GravityDirection = Utils.PointDirection(CurrentX, CurrentY, 2000, 2768) + 180;
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

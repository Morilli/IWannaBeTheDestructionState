namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public sealed class BgObject : GameObject
{
    public BgObject(GameEngine engine, double initialX, double initialY, string roomSuffix) : base(engine, initialX + 400, initialY + 1536)
    {
        UnderlyingSprite = engine.Generator.CreateSprite(-727, $"room150_{roomSuffix}.png");
        Invisible = true;
    }
}

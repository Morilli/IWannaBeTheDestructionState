namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object728 : GameObject
{
    public Object728(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
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

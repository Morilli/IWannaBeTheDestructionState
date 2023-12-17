namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

// WYSI
public class Object727 : GameObject
{
    public Object727(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    // public override void Step()
    // {
    //     base.Step();
    //     if (Utils.PointDistance(CurrentX, CurrentY, 400, 304) >= 1000
    //        || CurrentX <= -8 || CurrentX >= 808 || CurrentY <= -8 || CurrentY >= 616)
    //         engine.DeleteObject(this);
    // }

    public override void EndStep()
    {
        base.EndStep();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

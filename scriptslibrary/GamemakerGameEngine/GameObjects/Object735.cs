using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object735 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object735 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object735(GameEngine engine, int initialX, int initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite515.png");
    }

    public override void BeginStep()
    {
        base.BeginStep();
        Rotation = Direction;
    }

    public override void Step()
    {
        base.Step();
        if (PointDistance(CurrentX, CurrentY, 400, 300) > 500) engine.DeleteObject(this);
    }
}

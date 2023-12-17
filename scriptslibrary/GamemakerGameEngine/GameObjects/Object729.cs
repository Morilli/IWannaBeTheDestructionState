using System;

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object729 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object729 parent) : base(() =>
        {
            throw new NotImplementedException();
            // never called in game so not implemented
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object729 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = Utils.PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }

    public Object729(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
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

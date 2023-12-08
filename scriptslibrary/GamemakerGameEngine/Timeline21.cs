using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine;

public sealed class Object814 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object814 parent) : base(() =>
        {
            parent.Scale -= 0.2; // TODO xscale yscale -0.22

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object814 parent) : base(() =>
        {
            parent.Speed = 60;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY) + 180;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object814 parent) : base(() => { }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object814 parent) : base(() => { }) { }
    }

    public Object814(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (Scale <= 1) Clocks[0].Timer = 0;
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object816 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object816 parent) : base(() =>
        {
            parent.CollideWithBorders2();

            parent.Clocks[0].Timer = 1;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object816 parent) : base(() =>
        {
            parent.Friction += 1.2;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object816 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, parent.engine.PlayerX, parent.engine.PlayerY);
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object816 parent) : base(() =>
        {
            parent.engine.AddObject(new Object817(parent.engine, parent.CurrentX, parent.CurrentY));

            parent.Clocks[3].Timer = 1;
        }) { }
    }
    private class Clock4 : Cock
    {
        public Clock4(Object816 parent) : base(() =>
        {
            parent.Speed = 40;
            parent.Direction = PointDirection(parent.CurrentX, parent.CurrentY, 2000, 2768) + 180;
        }) { }
    }

    public Object816(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this),
            new Clock4(this)
        };
        Clocks[0].Timer = 1;
        Clocks[3].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object817 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object817 parent) : base(() =>
        {
            parent.Scale -= 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object817(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen() || Scale <= 0) engine.DeleteObject(this);
    }
}

public sealed class Object820 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object820 parent) : base(() =>
        {
            parent.engine.AddObject(new Object821(parent.engine, parent.CurrentX, parent.CurrentY));

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object820(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 2;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen()) engine.DeleteObject(this);
    }
}

public sealed class Object821 : GameObject
{
    private class Clock0 : Cock
    {
        public Clock0(Object821 parent) : base(() =>
        {
            parent.Scale -= 0.1;

            parent.Clocks[0].Timer = 1;
        }) { }
    }

    public Object821(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (IsOffscreen() || Scale <= 0) engine.DeleteObject(this);
    }
}

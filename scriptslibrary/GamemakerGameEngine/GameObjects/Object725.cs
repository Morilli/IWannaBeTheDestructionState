using System;

namespace StorybrewScripts.GamemakerGameEngine.GameObjects;

public class Object725 : GameObject
{
    private double a;
    private double b;

    private class Clock0 : Cock
    {
        public Clock0(Object725 parent) : base(() =>
        {
            parent.a += 8;
            parent.b += 1;

            parent.engine.AddObject(new Object727(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 10 + Math.Abs(7.5 * Math.Cos(parent.b)),
                Direction = parent.Direction + 15 + parent.a
            });
            parent.engine.AddObject(new Object727(parent.engine, parent.CurrentX, parent.CurrentY)
            {
                Speed = 10 + Math.Abs(7.5 * Math.Cos(parent.b)),
                Direction = parent.Direction - 15 - parent.a
            });

            parent.Clocks[0].Timer = 3;
        }) { }
    }
    private class Clock1 : Cock
    {
        public Clock1(Object725 parent) : base(() =>
        {
            parent.Direction += 0.1;

            parent.Clocks[1].Timer = 1;
        }) { }
    }
    private class Clock2 : Cock
    {
        public Clock2(Object725 parent) : base(() =>
        {
            parent.Friction -= 0.01;

            parent.Clocks[2].Timer = 1;
        }) { }
    }
    private class Clock3 : Cock
    {
        public Clock3(Object725 parent) : base(() =>
        {
            int a = Utils.random.Next(31);
            for (int i = 0; i < 12; i++)
            {
                parent.engine.AddObject(new Object728(parent.engine, parent.CurrentX, parent.CurrentY)
                {
                    Speed = Utils.random.Next(10, 13),
                    Direction = a + 30 * i
                });
            }
        }) { }
    }

    public Object725(GameEngine engine, double initialX, double initialY) : base(engine, initialX, initialY)
    {
        Clocks = new Cock[]
        {
            new Clock0(this),
            new Clock1(this),
            new Clock2(this),
            new Clock3(this)
        };
        Clocks[0].Timer = 1;

        UnderlyingSprite = engine.Generator.CreateSprite("sprite514.png");
    }

    public override void Step()
    {
        base.Step();
        if (CurrentX <= -8) nextXOffset += 808;
        if (CurrentX >= 808) nextXOffset -= 808;
        if (CurrentY <= -8) nextYOffset += 616;
        if (CurrentY >= 616) nextYOffset -= 616;
    }
}

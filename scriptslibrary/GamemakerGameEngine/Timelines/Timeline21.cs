using static StorybrewScripts.Utils;
using StorybrewScripts.GamemakerGameEngine.GameObjects;

namespace StorybrewScripts.GamemakerGameEngine.Timelines;

public class Timeline21 : Timeline
{
    public Timeline21(GameEngine gameEngine)
    {
        actions[0] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[10] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[22] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[36] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[48] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[56] = () =>
        {
            gameEngine.ForEach<Object814>(o => o.Clocks[1].Timer = 1);
            gameEngine.ForEach<Object814>(o => o.Clocks[2].Timer = 0);
            gameEngine.ForEach<Object814>(o => o.Clocks[3].Timer = 0);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[62] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[72] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[84] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[94] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[106] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[114] = () =>
        {
            gameEngine.ForEach<Object814>(o => o.Clocks[1].Timer = 1);
            gameEngine.ForEach<Object814>(o => o.Clocks[2].Timer = 0);
            gameEngine.ForEach<Object814>(o => o.Clocks[3].Timer = 0);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[120] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[132] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[144] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[156] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                var newObject = new Object814(gameEngine, random.Next(1600 + 48, 1600 + 753), 2496)
                {
                    Speed = e,
                    Direction = random.Next(361),
                };
                newObject.Clocks[random.Next(2, 4)].Timer = 1;
                gameEngine.AddObject(newObject);
            }
        };

        actions[168] = () =>
        {
            gameEngine.ForEach<Object814>(o => o.Clocks[1].Timer = 1);
            gameEngine.ForEach<Object814>(o => o.Clocks[2].Timer = 0);
            gameEngine.ForEach<Object814>(o => o.Clocks[3].Timer = 0);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[186] = () =>
        {
            gameEngine.ViewXOffset = 1600;
            gameEngine.ViewYOffset = 2464;
            for (int i = 0; i < 30; i++)
            {
                gameEngine.AddObject(new Object816(gameEngine, 2000, 2768)
                {
                    Speed = 30,
                    Direction = i * 12
                });
            }
        };

        actions[202] = () =>
        {
            gameEngine.ForEach<Object816>(o => o.Clocks[1].Timer = 1);
        };

        actions[229] = () =>
        {
            gameEngine.ForEach<Object816>(o =>
            {
                if (PointDistance(o.CurrentX, o.CurrentY, 2000, 2768) < 1)
                    gameEngine.DeleteObject(o);
            });
            // gameEngine.AddObject(new Object819(gameEngine, 2000, 2768));
            // gameEngine.ForEach<Object816>(gameEngine.DeleteObject);
            // gameEngine.ForEach<Object817>(gameEngine.DeleteObject);
        };

        actions[230] = () =>
        {
            gameEngine.AddObject(new Object820(gameEngine, 2000, 2768)
            {
                Speed = 40,
                Direction = 35
            });
            gameEngine.AddObject(new Object820(gameEngine, 2000, 2768)
            {
                Speed = 40,
                Direction = 145
            });
            gameEngine.AddObject(new Object820(gameEngine, 2000, 2768)
            {
                Speed = 40,
                Direction = -35
            });
            gameEngine.AddObject(new Object820(gameEngine, 2000, 2768)
            {
                Speed = 40,
                Direction = -145
            });
            gameEngine.ForEach<Object816>(o =>
            {
                o.Friction = 0;
                o.Clocks[0].Timer = 0;
                o.Clocks[4].Timer = 1;
            });
        };

        actions[245] = () => { gameEngine.CurrentTimeline = new Timeline22(gameEngine, 53); };
    }
}

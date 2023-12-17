#define DO_COMMENTED_CODE

using static StorybrewScripts.Utils;
using StorybrewScripts.GamemakerGameEngine.GameObjects;

namespace StorybrewScripts.GamemakerGameEngine.Timelines;

public class Timeline22 : Timeline
{
    public Timeline22(GameEngine gameEngine, int initialStep) : base(initialStep)
    {
        actions[53] = () =>
        {
            gameEngine.AddObject(new Object731(gameEngine));
            gameEngine.AddObject(new Object827(gameEngine, 1600, 2616)
            {
                Speed = 20
            });
        };

        actions[150] = () => { gameEngine.AddObject(new Object830(gameEngine)); };

        actions[157] = () =>
        {
            gameEngine.ForEach<Object731>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object735>(o =>
            {
                o.Clocks[2].Timer = 0;
                o.Clocks[0].Timer = 1;
            });
        };

        actions[161] = () =>
        {
            gameEngine.ForEach<Object731>(gameEngine.DeleteObject);
            gameEngine.ViewAngle = 0;
        };

        actions[246] = () => { gameEngine.ForEach<Object829>(o => o.Speed = 26); };

        actions[250] = () => { gameEngine.ForEach<Object829>(o => o.Speed = 13); };

        actions[262] = () => { gameEngine.ForEach<Object829>(o => o.Speed = 26); };

        actions[266] = () => { gameEngine.ForEach<Object829>(o => o.Speed = 13); };

        actions[277] = () =>
        {
            gameEngine.ForEach<Object830>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object829>(o => o.Clocks[1].Timer = 1);
        };

        actions[283] = () => { gameEngine.ForEach<Object829>(o => o.Clocks[0].Timer = 1); };

        actions[298] = () =>
        {
            gameEngine.AddObject(new Object743(gameEngine));
            gameEngine.AddObject(new Object831(gameEngine, 2400, 2616)
            {
                Speed = 20,
                Direction = 180
            });
        };

        actions[395] = () => { gameEngine.AddObject(new Object840(gameEngine)); };

        actions[403] = () =>
        {
            gameEngine.ForEach<Object743>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
        };

        actions[407] = () =>
        {
            gameEngine.ForEach<Object743>(gameEngine.DeleteObject);
            gameEngine.ViewAngle = 0;
        };

        actions[480] = () =>
        {
            gameEngine.ForEach<Object840>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object841>(o => o.Clocks[2].Timer = 1);
            gameEngine.ForEach<Object842>(o => o.Clocks[2].Timer = 1);
        };

        actions[495] = () =>
        {
            gameEngine.ForEach<Object840>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[2].Timer = 1;
            });
            gameEngine.ForEach<Object841>(o =>
            {
                o.Clocks[2].Timer = 0;
                o.Clocks[3].Timer = 1;
            });
            gameEngine.ForEach<Object842>(o =>
            {
                o.Clocks[2].Timer = 0;
                o.Clocks[3].Timer = 1;
            });
        };

        actions[510] = () =>
        {
            gameEngine.ForEach<Object840>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
            });
            gameEngine.ForEach<Object841>(o =>
            {
                o.Clocks[2].Timer = 1;
                o.Clocks[3].Timer = 0;
            });
            gameEngine.ForEach<Object842>(o =>
            {
                o.Clocks[2].Timer = 1;
                o.Clocks[3].Timer = 0;
            });
        };

        actions[525] = () =>
        {
            gameEngine.ForEach<Object840>(o =>
            {
                o.Clocks[0].Timer = 1;
                o.Clocks[1].Timer = 0;
            });
            gameEngine.ForEach<Object841>(o => o.Clocks[2].Timer = 0);
            gameEngine.ForEach<Object842>(o => o.Clocks[2].Timer = 0);
        };

        actions[532] = () =>
        {
            gameEngine.ForEach<Object841>(o => o.Clocks[5].Timer = 1);
            gameEngine.ForEach<Object842>(o => o.Clocks[5].Timer = 1);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.ForEach<Object840>(gameEngine.DeleteObject);
        };

        actions[546] = () =>
        {
            gameEngine.PlayerXSpeed = 2;
            gameEngine.ForEach<Object846>(o => o.Clocks[0].Timer = 1);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.AddObject(new Object843(gameEngine, 1600, 2616)
            {
                Speed = 20
            });
            gameEngine.AddObject(new Object844(gameEngine));
        };

        actions[652] = () =>
        {
            gameEngine.PlayerXSpeed = 0;
            gameEngine.AddObject(new Object856(gameEngine));
        };

        actions[776] = () =>
        {
            gameEngine.ForEach<Object844>(o =>
            {
                // o.Clocks[0].Timer = 0;
                // o.Clocks[1].Timer = 0;
                gameEngine.DeleteObject(o); // this isn't actually done in the original game, maybe it was supposed to be reused later
            });
            gameEngine.ForEach<Object845>(o =>
            {
                o.Speed = 0;
                o.Direction = 90;
            });
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.ForEach<Object857>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object856>(gameEngine.DeleteObject);
        };

        actions[790] = () =>
        {
            gameEngine.ForEach<Object845>(o => o.Speed = 13);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.AddObject(new Object847(gameEngine, 2400, 2616)
            {
                Speed = 20,
                Direction = 180
            });
            gameEngine.ForEach<Object857>(o => o.Speed = 25);
        };

        actions[900] = () => { gameEngine.ForEach<Object845>(o => o.Clocks[0].Timer = 1); };

        actions[977] = () =>
        {
            gameEngine.ForEach<Object849>(o =>
            {
                int imageIndex = random.Next(8);
                o.UnderlyingSprite = gameEngine.Generator.CreateSprite($"sprite546_{imageIndex}.png");
                o.Scale = 0.999999999999; // massive hack because underlying sprite changes aren't fully supported yet
                o.image_index = imageIndex;
                o.Friction = 0;
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
                o.Clocks[3].Timer = 1;
                o.Clocks[5].Timer = 1;
            });
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[1024] = () =>
        {
            gameEngine.ForEach<Object849>(o => o.Clocks[4].Timer = 1);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[1039] = () =>
        {
#if DO_COMMENTED_CODE
            gameEngine.AddObject(new Object851(gameEngine, 1600, 2464)
            {
                Speed = 20,
                Direction = 0
            });
            gameEngine.AddObject(new Object852(gameEngine, 2400, 2464)
            {
                Speed = 20,
                Direction = 180
            });
#endif

            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.ForEach<Object850>(gameEngine.DeleteObject);
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1050] = () =>
        {
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.ForEach<Object850>(gameEngine.DeleteObject);
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1060] = () =>
        {
            gameEngine.ForEach<Object850>(gameEngine.DeleteObject);
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1070] = () =>
        {
            double dir = PointDirection(2000, 2616, gameEngine.PlayerX, gameEngine.PlayerY);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = dir + 18 * i + 9
                });
            }
        };

        actions[1082] = () => { gameEngine.ForEach<Object854>(o => o.Speed = 40); };

        actions[1102] = () =>
        {
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            // rty = irandom_range(1800,2200)
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1112] = () =>
        {
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            // rty = irandom_range(1800,2200)
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1122] = () =>
        {
            double dir = PointDirection(2000, 2616, gameEngine.PlayerX, gameEngine.PlayerY);
            int imageIndex = random.Next(8);
            // rty = irandom_range(1800,2200)
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = dir + 18 * i + 9
                });
            }
        };

        actions[1134] = () =>
        {
#if DO_COMMENTED_CODE
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 15,
                    Direction = a + 18 * i
                });
            }
#endif
            gameEngine.AddObject(new Object855(gameEngine));
        };

        actions[1145] = () => { gameEngine.ForEach<Object855>(gameEngine.DeleteObject); };

        actions[1162] = () =>
        {
#if DO_COMMENTED_CODE
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, random.Next(8))
                {
                    Speed = 8 + random.NextDouble() * 11,
                    Direction = random.Next(361)
                });
            }
#endif
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 17,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1172] = () =>
        {
#if DO_COMMENTED_CODE
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, random.Next(8))
                {
                    Speed = 8 + random.NextDouble() * 12,
                    Direction = random.Next(361)
                });
            }
#endif
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 19,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1182] = () =>
        {
#if DO_COMMENTED_CODE
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, random.Next(8))
                {
                    Speed = 8 + random.NextDouble() * 13,
                    Direction = random.Next(361)
                });
            }
#endif
            int a = random.Next(19);
            int imageIndex = random.Next(8);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object854(gameEngine, 2000, 2616, imageIndex)
                {
                    Speed = 21,
                    Direction = a + 18 * i
                });
            }
        };

        actions[1194] = () => { gameEngine.AddObject(new Object858(gameEngine)); };

        actions[1224] = () =>
        {
            gameEngine.ForEach<Object854>(o => o.Speed = 1);
            gameEngine.ForEach<Object858>(gameEngine.DeleteObject);
        };

        actions[1254] = () => { gameEngine.ForEach<Object854>(o => o.Clocks[1].Timer = 1); };

        actions[1269] = () => { gameEngine.ForEach<Object859>(o => o.Clocks[1].Timer = 1); };

        actions[1400] = () =>
        {
            // TODO warp
        };
    }
}

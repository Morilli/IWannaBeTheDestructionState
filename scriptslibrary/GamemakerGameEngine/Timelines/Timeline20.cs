using StorybrewScripts.GamemakerGameEngine.GameObjects;
using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine.Timelines;

public class Timeline20 : Timeline
{
    public Timeline20(GameEngine gameEngine, int initialStep) : base(initialStep)
    {
        actions[62] = () => { gameEngine.AddObject(new Object785(gameEngine /*, 1600, 2464*/)); };

        actions[194] = () => { gameEngine.AddObject(new Object790(gameEngine)); };

        // not technically in the timeline but we need to simulate player movement
        actions[204] = () =>
        {
            gameEngine.PlayerX = 1640;
            gameEngine.PlayerXSpeed = 0;
            gameEngine.PlayerYSpeed = -3;
        };

        actions[229] = () => { gameEngine.PlayerYSpeed = 3; };

        actions[254] = () => { gameEngine.PlayerYSpeed = 0; };

        actions[280] = () =>
        {
            gameEngine.ForEach<Object785>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object790>(gameEngine.DeleteObject);
        };

        actions[288] = () =>
        {
            gameEngine.ForEach<Object784>(o =>
            {
                o.Clocks[2].Timer = 1;
                o.Clocks[4].Timer = 1;
            });
            gameEngine.ForEach<Object786>(o =>
            {
                o.Clocks[2].Timer = 1;
                o.Clocks[4].Timer = 1;
            });
            gameEngine.ForEach<Object783>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object788>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object787>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
        };

        actions[294] = () =>
        {
            gameEngine.ForEach<Object784>(o => o.Clocks[3].Timer = 1);
            gameEngine.ForEach<Object786>(o => o.Clocks[3].Timer = 1);
            gameEngine.ForEach<Object787>(o => o.Clocks[2].Timer = 1);
        };

        actions[310] = () =>
        {
            gameEngine.AddObject(new Object794(gameEngine, 2400, 3072)
            {
                Speed = PointDistance(2400, 3072, 2400, 2464) / 120,
                Direction = 90
            });
        };

        actions[430] = () =>
        {
            gameEngine.ForEach<Object794>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[2].Timer = 0;
                o.Clocks[4].Timer = 1;
                o.Speed = PointDistance(2400, 2464, 1600, 2464) / 64;
                o.Direction = 180;
            });
        };

        actions[440] = () =>
        {
            gameEngine.AddObject(new Object796(gameEngine));
            gameEngine.PlayerXSpeed = 2;
        };

        actions[454] = () => { gameEngine.AddObject(new Object796(gameEngine)); };

        actions[468] = () =>
        {
            gameEngine.AddObject(new Object796(gameEngine));
            gameEngine.PlayerXSpeed = -2;
        };

        actions[472] = () => { gameEngine.AddObject(new Object796(gameEngine)); };

        actions[476] = () => { gameEngine.AddObject(new Object796(gameEngine)); };

        actions[484] = () => { gameEngine.AddObject(new Object796(gameEngine)); };

        actions[494] = () =>
        {
            gameEngine.PlayerXSpeed = 0;
            gameEngine.ForEach<Object795>(o =>
            {
                o.Speed = 1;
                o.Direction = PointDirection(o.CurrentX, o.CurrentY, 2000, 2768) + 30;
                o.Clocks[0].Timer = 1;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object797>(o =>
            {
                o.Speed = 1;
                o.Direction = PointDirection(o.CurrentX, o.CurrentY, 2000, 2768) + 30;
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object788>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object794>(gameEngine.DeleteObject);
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[556] = () =>
        {
            gameEngine.ForEach<Object795>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object797>(gameEngine.DeleteObject);
            gameEngine.AddObject(new Object801(gameEngine));
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[612] = () => { gameEngine.ForEach<Object801>(gameEngine.DeleteObject); };

        actions[616] = () =>
        {
            gameEngine.ViewWidth = 768;
            gameEngine.ViewHeight = 576;
            gameEngine.ViewXOffset = 1616;
            gameEngine.ViewYOffset = 2480;
            gameEngine.ViewAngle = 2;
            gameEngine.ForEach<Object800>(o =>
            {
                o.Scale = 2;
                o.Friction = 0;
                o.Speed = 10;
                o.Clocks[0].Timer = 0;
            });
        };

        actions[617] = () => { gameEngine.ForEach<Object800>(o => o.Speed = 0); };

        actions[622] = () =>
        {
            gameEngine.ViewWidth = 736;
            gameEngine.ViewHeight = 544;
            gameEngine.ViewXOffset = 1632;
            gameEngine.ViewYOffset = 2496;
            gameEngine.ViewAngle = -4;
            gameEngine.ForEach<Object800>(o => o.Speed = 10);
        };

        actions[623] = () => { gameEngine.ForEach<Object800>(o => o.Speed = 0); };

        actions[632] = () =>
        {
            gameEngine.ViewWidth = 704;
            gameEngine.ViewHeight = 512;
            gameEngine.ViewXOffset = 1648;
            gameEngine.ViewYOffset = 2512;
            gameEngine.ViewAngle = 6;
            gameEngine.ForEach<Object800>(o => o.Speed = 10);
        };

        actions[633] = () => { gameEngine.ForEach<Object800>(o => o.Speed = 0); };

        actions[638] = () =>
        {
            gameEngine.ViewWidth = 672;
            gameEngine.ViewHeight = 480;
            gameEngine.ViewXOffset = 1664;
            gameEngine.ViewYOffset = 2528;
            gameEngine.ViewAngle = -8;
            gameEngine.ForEach<Object800>(o => o.Speed = 10);
        };

        actions[639] = () => { gameEngine.ForEach<Object800>(o => o.Speed = 0); };

        actions[647] = () =>
        {
            gameEngine.ViewWidth = 640;
            gameEngine.ViewHeight = 448;
            gameEngine.ViewXOffset = 1680;
            gameEngine.ViewYOffset = 2544;
            gameEngine.ViewAngle = 10;
            gameEngine.ForEach<Object800>(o => o.Speed = 10);
        };

        actions[648] = () => { gameEngine.ForEach<Object800>(o => o.Speed = 0); };

        actions[662] = () =>
        {
            gameEngine.AddObject(new Object803(gameEngine));
            gameEngine.ForEach<Object800>(o => o.Clocks[3].Timer = 1);
        };

        actions[681] = () => { gameEngine.AddObject(new Object805(gameEngine)); };

        actions[780] = () =>
        {
            gameEngine.ForEach<Object806>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object807>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object805>(gameEngine.DeleteObject);
        };

        actions[786] = () =>
        {
            gameEngine.ForEach<Object806>(o => o.Clocks[2].Timer = 1);
            gameEngine.ForEach<Object807>(o => o.Clocks[2].Timer = 1);
        };

        actions[800] = () => { gameEngine.AddObject(new Object808(gameEngine)); };

        actions[926] = () =>
        {
            gameEngine.ForEach<Object808>(o => o.Clocks[0].Timer = 0);
            gameEngine.ForEach<Object808>(o => o.Clocks[1].Timer = 1);
        };

        actions[986] = () =>
        {
            gameEngine.ForEach<Object810>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object808>(gameEngine.DeleteObject);
        };

        actions[1033] = () =>
        {
            gameEngine.ForEach<Object810>(o =>
            {
                o.GravityStrength = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        };

        actions[1048] = () =>
        {
            double a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 7)
                {
                    Speed = 1 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 6)
                {
                    Speed = 3 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 5)
                {
                    Speed = 5 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 4)
                {
                    Speed = 7 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 3)
                {
                    Speed = 9 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 2)
                {
                    Speed = 11 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = PointDirection(2000, 2616, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 1)
                {
                    Speed = 13 + random.NextDouble(),
                    Direction = a + 9 * i + 4.5
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2000, 2616, 0)
                {
                    Speed = 15 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }
        };

        actions[1108] = () =>
        {
            gameEngine.ForEach<Object811>(o =>
            {
                o.Speed = 10;
                o.Direction = -90;
            });
        };

        actions[1114] = () => { gameEngine.ForEach<Object811>(o => o.Speed = 0); };

        actions[1120] = () =>
        {
            gameEngine.ForEach<Object811>(o =>
            {
                o.Speed = 10;
                o.Direction = -90;
            });
        };

        actions[1124] = () => { gameEngine.ForEach<Object811>(o => o.Speed = 0); };

        actions[1130] = () =>
        {
            gameEngine.ForEach<Object811>(o =>
            {
                o.Speed = 10;
                o.Direction = -90;
            });
        };

        actions[1132] = () => { gameEngine.ForEach<Object811>(o => o.Speed = 0); };

        actions[1138] = () =>
        {
            gameEngine.ForEach<Object811>(o =>
            {
                o.Speed = 10;
                o.Direction = -90;
            });
        };

        actions[1170] = () =>
        {
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.ForEach<Object811>(gameEngine.DeleteObject);

            double a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 7)
                {
                    Speed = 1 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = PointDirection(1600, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 6)
                {
                    Speed = 3 + random.NextDouble(),
                    Direction = a + 9 * i + 4.5
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 5)
                {
                    Speed = 5 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 4)
                {
                    Speed = 7 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 3)
                {
                    Speed = 9 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 2)
                {
                    Speed = 11 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 1600, 2464, 1)
                {
                    Speed = 13 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 1600, 2464, 0)
                {
                    Speed = 15 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 7)
                {
                    Speed = 1 + random.NextDouble(),
                    Direction = a + 9 * i + 4.5
                });
            }

            a = PointDirection(1600, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 6)
                {
                    Speed = 3 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 5)
                {
                    Speed = 5 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 4)
                {
                    Speed = 7 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 3)
                {
                    Speed = 9 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 2)
                {
                    Speed = 11 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = random.Next(10);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object813(gameEngine, 2400, 2464, 1)
                {
                    Speed = 13 + random.NextDouble(),
                    Direction = a + 9 * i
                });
            }

            a = PointDirection(2400, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 40; i++)
            {
                gameEngine.AddObject(new Object811(gameEngine, 2400, 2464, 0)
                {
                    Speed = 15 + random.NextDouble(),
                    Direction = a + 9 * i + 4.5
                });
            }
        };

        actions[1232] = () =>
        {
            gameEngine.ForEach<Object813>(o =>
            {
                o.Speed = 10;
                o.Direction = -90;
            });
        };

        actions[1238] = () => { gameEngine.ForEach<Object813>(o => o.Speed = 0); };

        actions[1244] = () => { gameEngine.ForEach<Object813>(o => o.Speed = 10); };

        actions[1248] = () => { gameEngine.ForEach<Object813>(o => o.Speed = 0); };

        actions[1256] = () => { gameEngine.ForEach<Object813>(o => o.Speed = 10); };

        actions[1258] = () => { gameEngine.ForEach<Object813>(o => o.Speed = 0); };

        actions[1262] = () =>
        {
            gameEngine.ForEach<Object813>(o =>
            {
                o.Clocks[0].Timer = 1;
                o.Clocks[1].Timer = 1;
            });
        };

        actions[1293] = () =>
        {
            gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
            gameEngine.ForEach<Object813>(gameEngine.DeleteObject);

            gameEngine.CurrentTimeline = new Timeline21(gameEngine);
        };
    }
}

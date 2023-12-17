using System.Linq;
using StorybrewScripts.GamemakerGameEngine.GameObjects;
using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine.Timelines;

public class Timeline18 : Timeline
{
    public Timeline18(GameEngine gameEngine, int initialStep) : base(initialStep)
    {
        // from room150
        gameEngine.AddObject(new Object719(gameEngine));
        gameEngine.AddObject(new Object720(gameEngine, 0, 0));

        actions[26] = () =>
        {
            gameEngine.ForEach<Object719>(o =>
            {
                o.Clocks[0].Timer = 1;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object720>(o => { o.Clocks[0].Timer = 1; });
            gameEngine.AddObject(new Object722(gameEngine, 0, 0));
        };

        actions[517] = () =>
        {
            gameEngine.ForEach<Object719>(o =>
            {
                // just delete instead of disabling the timers; this object isn't further used anyway
                gameEngine.DeleteObject(o);
                // o.Clocks[0].Timer = 0;
                // o.Clocks[1].Timer = 0;
            });
        };

        actions[520] = () =>
        {
            gameEngine.ForEach<Object723>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.ForEach<Object724>(o => o.Clocks[0].Timer = 1);

            for (int i = 0; i < 4; i++)
            {
                var newObject = new Object725(gameEngine, 400, 152)
                {
                    Speed = 15,
                    Direction = 90 + 90 * i
                };
                newObject.Clocks[2].Timer = 1;

                gameEngine.AddObject(newObject);
            }
        };

        actions[726] = () => { gameEngine.ForEach<Object725>(gameEngine.DeleteObject); };

        actions[768] = () =>
        {
            // gameEngine.ForEach<Object719>(o => o.Clocks[2].Timer = 1); // ??? this clock doesn't even exist
            gameEngine.ForEach<Object725>(o => o.Clocks[3].Timer = 1);
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[778] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[790] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[804] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[816] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[822] = () =>
        {
            gameEngine.ForEach<Object729>(o => o.Clocks[1].Timer = 1);
        };

        actions[828] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[840] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[852] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[862] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[874] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[880] = () =>
        {
            gameEngine.ForEach<Object729>(o => o.Clocks[1].Timer = 1);
        };

        actions[888] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[900] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };


        actions[912] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[924] = () =>
        {
            for (int i = 0; i < d; i++)
            {
                gameEngine.AddObject(new Object729(gameEngine, random.Next(48, 753), 32)
                {
                    Speed = c,
                    Direction = random.Next(361)
                });
            }
        };

        actions[936] = () =>
        {
            gameEngine.ForEach<Object729>(o => o.Clocks[1].Timer = 1);
        };

        actions[954] = () =>
        {
            for (int i = 0; i < 20; i++)
            {
                var newObject = new Object730(gameEngine, 400, 304)
                {
                    Speed = 25,
                    Direction = i * 18
                };
                gameEngine.AddObject(newObject);
            }
        };

        actions[970] = () => { gameEngine.ForEach<Object730>(o => o.Clocks[1].Timer = 1); };

        actions[996] = () =>
        {
            gameEngine.ForEach<Object730>(object730 =>
            {
                object730.Friction = 0;
                object730.Clocks[0].Timer = 0;
                object730.Clocks[1].Timer = 0;
                object730.Clocks[2].Timer = 1;
            });
        };

        actions[1014] = () =>
        {
            gameEngine.PlayerXSpeed = 2.5;
            gameEngine.AddObject(new Object731(gameEngine));
            gameEngine.AddObject(new Object733(gameEngine));
        };

        actions[1118] = () =>
        {
            foreach (Object731 object731 in gameEngine.Objects.OfType<Object731>())
            {
                object731.Clocks[0].Timer = 0;
                object731.Clocks[1].Timer = 1;
            }

            foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) object733.Clocks[2].Timer = 0;
            gameEngine.ForEach<Object735>(o => o.Clocks[0].Timer = 1);
        };

        actions[1122] = () =>
        {
            foreach (Object731 object731 in gameEngine.Objects.OfType<Object731>()) gameEngine.DeleteObject(object731);
            gameEngine.ViewAngle = 0;
        };

        actions[1204] = () =>
        {
            for (int i = 0; i < 30; i++)
            {
                var newObject = new Object741(gameEngine)
                {
                    Speed = random.Next(10, 16),
                    Direction = random.Next(361)
                };
                gameEngine.AddObject(newObject);
            }
        };

        actions[1220] = () =>
        {
            for (int i = 0; i < 30; i++)
            {
                var newObject = new Object742(gameEngine)
                {
                    Speed = random.Next(10, 16),
                    Direction = random.Next(361)
                };
                gameEngine.AddObject(newObject);
            }
        };

        actions[1238] = () =>
        {
            foreach (Object741 object741 in gameEngine.Objects.OfType<Object741>())
            {
                object741.Clocks[0].Timer = 0;
                object741.Clocks[1].Timer = 1;
            }


            foreach (Object742 object742 in gameEngine.Objects.OfType<Object742>())
            {
                object742.Clocks[0].Timer = 0;
                object742.Clocks[1].Timer = 1;
                object742.Clocks[3].Timer = 1;
            }
        };

        actions[1244] = () =>
        {
            gameEngine.PlayerXSpeed = -2;

            foreach (Object741 object741 in gameEngine.Objects.OfType<Object741>()) object741.Clocks[2].Timer = 1;
            foreach (Object742 object742 in gameEngine.Objects.OfType<Object742>())
            {
                object742.Clocks[2].Timer = 1;
                object742.Clocks[3].Timer = 0;
            }
        };

        actions[1258] = () =>
        {
            foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>())
            {
                object733.Clocks[2].Timer = 1;
                object733.Clocks[3].Timer = 1;
            }

            gameEngine.AddObject(new Object743(gameEngine));
        };

        actions[1362] = () =>
        {
            foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>())
            {
                object733.Clocks[1].Timer = 1;
                object733.Clocks[2].Timer = 0;
                object733.Clocks[3].Timer = 0;
            }

            foreach (Object735 object735 in gameEngine.Objects.OfType<Object735>()) object735.Clocks[0].Timer = 1;
            foreach (Object743 object743 in gameEngine.Objects.OfType<Object743>())
            {
                object743.Clocks[0].Timer = 0;
                object743.Clocks[1].Timer = 1;
            }
        };

        actions[1366] = () =>
        {
            gameEngine.ViewAngle = 0;

            foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) object733.Clocks[4].Timer = 1;
            foreach (Object743 object743 in gameEngine.Objects.OfType<Object743>()) gameEngine.DeleteObject(object743);
        };

        actions[1380] = () =>
        {
            gameEngine.AddObject(new Object744(gameEngine));
            gameEngine.AddObject(new Object745(gameEngine, -200, -152));
        };


        actions[1440] = () =>
        {
            gameEngine.ViewXOffset = gameEngine.ViewYOffset = 0;

            gameEngine.AddObject(new Object746(gameEngine, 0, 0));
            foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) gameEngine.DeleteObject(object733);
            foreach (Object734 object734 in gameEngine.Objects.OfType<Object734>()) gameEngine.DeleteObject(object734);
            foreach (Object744 object744 in gameEngine.Objects.OfType<Object744>()) gameEngine.DeleteObject(object744);
        };

        actions[1488] = () =>
        {
            gameEngine.PlayerX = 1900;
            gameEngine.PlayerY = 152;
            gameEngine.PlayerXSpeed = 0;
            gameEngine.PlayerYSpeed = 2;
            gameEngine.SetNewViewOffsets(1600, 0);
            foreach (Object746 object746 in gameEngine.Objects.OfType<Object746>()) gameEngine.DeleteObject(object746);

            // technically the next timeline is called with 17 steps later with initial step 64,
            // but we need to setup the moving background in that timeline, so switch earlier
            gameEngine.CurrentTimeline = new Timeline19(gameEngine, 64 - 17);
        };
    }
}

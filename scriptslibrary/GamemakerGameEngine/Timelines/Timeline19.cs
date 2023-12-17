using System.Linq;
using StorybrewCommon.Storyboarding;
using StorybrewScripts.GamemakerGameEngine.GameObjects;
using static StorybrewScripts.Utils;

namespace StorybrewScripts.GamemakerGameEngine.Timelines;

public class Timeline19 : Timeline
{
    private static void BuildRoom150(GameEngine gameEngine)
    {
        for (int i = 0; i < 6; i++)
        for (int j = 0; j < 5; j++)
        {
            gameEngine.AddObject(new Object754(gameEngine, 928 + 16 + 4 * 32 * j, 576 + 16 + 6 * 32 * i));
            gameEngine.AddObject(new Object754(gameEngine, 864 + 16 + 4 * 32 * i, 672 + 16 + 6 * 32 * j));
        }

        for (int i = 0; i < 6; i++)
        for (int j = 0; j < 2; j++)
        {
            gameEngine.AddObject(new Object758(gameEngine, 1120 + 16 + 4 * 32 * j, 1248 + 16 + 6 * 32 * i));
        }

        for (int i = 0; i < 6; i++)
        {
            gameEngine.AddObject(new Object758(gameEngine, 1184 + 16, 1344 + 16 + 6 * 32 * i));
        }
    }

    public Timeline19(GameEngine gameEngine, int initialStep) : base(initialStep)
    {
        BuildRoom150(gameEngine);
        gameEngine.Generator.SetBgSprite("room150_emptyT.png", OsbOrigin.TopLeft, 1600, 0);

        // this acts as a collection of type 756/747 objects, aka when the blocks would appear one of these dummy bg objects gets visible instead
        var fullBgObject = new BgObject(gameEngine, 1600, 0, "fullT");
        var halfBgObject = new BgObject(gameEngine, 1600, 0, "halfT");
        gameEngine.AddObject(fullBgObject);
        gameEngine.AddObject(halfBgObject);
        fullBgObject.Invisible = false;

        actions[64] = () =>
        {
            gameEngine.AddObject(new Object748(gameEngine));
            gameEngine.AddObject(new Object750(gameEngine));
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            int[] loopCounts = { 6, 7, 8, 7, 6 };
            for (int i = 0; i < loopCounts.Length; i++)
            {
                for (int j = 0; j < loopCounts[i]; j++)
                {
                    var newObject = new Object755(gameEngine, 1744 + 128 * i, 592)
                    {
                        Speed = random.Next(3, 8),
                        Direction = random.Next(361)
                    };
                    gameEngine.AddObject(newObject);
                }
            }
        };

        actions[292] = () =>
        {
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[0].Timer = 1;
            // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[0].Timer = 1;
            fullBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[306] = () =>
        {
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[1].Timer = 1;
            // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[1].Timer = 1;
            fullBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[432] = () =>
        {
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[0].Timer = 1;
            // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[0].Timer = 1;
            fullBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[462] = () =>
        {
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[1].Timer = 1;
            // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[1].Timer = 1;
            fullBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[524] = () =>
        {
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[0].Timer = 1;
            // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[0].Timer = 1;
            fullBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            foreach (Object750 object750 in gameEngine.Objects.OfType<Object750>()) gameEngine.DeleteObject(object750);
            foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Speed = 0;
        };

        actions[530] = () =>
        {
            foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[0].Timer = 1;
            // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[1].Timer = 1;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[538] = () =>
        {
            foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[2].Timer = 1;
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[2].Timer = 1;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[541] = () =>
        {
            foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[2].Timer = 1;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[544] = () =>
        {
            foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[2].Timer = 1;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[2].Timer = 1;
        };

        actions[547] = () =>
        {
            foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[1].Timer = 1;
            foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[3].Timer = 1;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[552] = () =>
        {
            foreach (Object748 object748 in gameEngine.Objects.OfType<Object748>())
            {
                object748.Clocks[0].Timer = 0;
                object748.Clocks[1].Timer = 1;
            }

            fullBgObject.Invisible = true;
            gameEngine.DeleteObject(fullBgObject);
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            halfBgObject.Invisible = false;

            foreach (Object755 object755 in gameEngine.Objects.OfType<Object755>()) gameEngine.DeleteObject(object755);
            for (int i = 0; i < 5; i++)
            {
                gameEngine.AddObject(new Object759(gameEngine, 1700, 1100)
                {
                    Speed = 5,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object762(gameEngine, 1700, 1100)
                {
                    Speed = 6,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object763(gameEngine, 1700, 1100)
                {
                    Speed = 7,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object764(gameEngine, 1700, 1100)
                {
                    Speed = 8,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object765(gameEngine, 1700, 1100)
                {
                    Speed = 9,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object766(gameEngine, 1700, 1100)
                {
                    Speed = 10,
                    Direction = random.Next(361)
                });
            }

            for (int i = 0; i < 5; i++)
            {
                gameEngine.AddObject(new Object759(gameEngine, 2300, 1568)
                {
                    Speed = 5,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object762(gameEngine, 2300, 1568)
                {
                    Speed = 6,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object763(gameEngine, 2300, 1568)
                {
                    Speed = 7,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object764(gameEngine, 2300, 1568)
                {
                    Speed = 8,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object765(gameEngine, 2300, 1568)
                {
                    Speed = 9,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object766(gameEngine, 2300, 1568)
                {
                    Speed = 10,
                    Direction = random.Next(361)
                });
            }
        };

        actions[600] = () =>
        {
            foreach (Object748 object748 in gameEngine.Objects.OfType<Object748>())
            {
                object748.Clocks[1].Timer = 0;
                object748.Clocks[2].Timer = 1;
            }

            halfBgObject.Invisible = true;
            gameEngine.ForEach<Object758>(o => o.Clocks[0].Timer = 1);
            foreach (Object759 object759 in gameEngine.Objects.OfType<Object759>()) object759.Speed = -2;
            foreach (Object762 object762 in gameEngine.Objects.OfType<Object762>()) object762.Speed = -2;
            foreach (Object763 object763 in gameEngine.Objects.OfType<Object763>()) object763.Speed = -2;
            foreach (Object764 object764 in gameEngine.Objects.OfType<Object764>()) object764.Speed = -2;
            foreach (Object765 object765 in gameEngine.Objects.OfType<Object765>()) object765.Speed = -2;
            foreach (Object766 object766 in gameEngine.Objects.OfType<Object766>()) object766.Speed = -2;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[614] = () =>
        {
            gameEngine.ForEach<Object748>(object748 =>
            {
                object748.Clocks[1].Timer = 1;
                object748.Clocks[2].Timer = 0;
            });
            gameEngine.ForEach<Object758>(o => o.Clocks[1].Timer = 1);
            gameEngine.ForEach<Object759>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object762>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object763>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object764>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object765>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object766>(gameEngine.DeleteObject);
            halfBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            for (int i = 0; i < 5; i++)
            {
                gameEngine.AddObject(new Object759(gameEngine, 2300, 1368)
                {
                    Speed = 5,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object762(gameEngine, 2300, 1368)
                {
                    Speed = 6,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object763(gameEngine, 2300, 1368)
                {
                    Speed = 7,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object764(gameEngine, 2300, 1368)
                {
                    Speed = 8,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object765(gameEngine, 2300, 1368)
                {
                    Speed = 9,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object766(gameEngine, 2300, 1368)
                {
                    Speed = 10,
                    Direction = random.Next(361)
                });
            }

            for (int i = 0; i < 5; i++)
            {
                gameEngine.AddObject(new Object759(gameEngine, 1700, 1836)
                {
                    Speed = 5,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object762(gameEngine, 1700, 1836)
                {
                    Speed = 6,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object763(gameEngine, 1700, 1836)
                {
                    Speed = 7,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object764(gameEngine, 1700, 1836)
                {
                    Speed = 8,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object765(gameEngine, 1700, 1836)
                {
                    Speed = 9,
                    Direction = random.Next(361)
                });
                gameEngine.AddObject(new Object766(gameEngine, 1700, 1836)
                {
                    Speed = 10,
                    Direction = random.Next(361)
                });
            }
        };

        actions[640] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object759>(o => o.Speed = -2);
            gameEngine.ForEach<Object762>(o => o.Speed = -2);
            gameEngine.ForEach<Object763>(o => o.Speed = -2);
            gameEngine.ForEach<Object764>(o => o.Speed = -2);
            gameEngine.ForEach<Object765>(o => o.Speed = -2);
            gameEngine.ForEach<Object766>(o => o.Speed = -2);
            halfBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[2].Timer = 1;
            });
        };

        actions[646] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[1].Timer = 1);
            gameEngine.ForEach<Object759>(o => o.Speed = 5);
            gameEngine.ForEach<Object762>(o => o.Speed = 6);
            gameEngine.ForEach<Object763>(o => o.Speed = 7);
            gameEngine.ForEach<Object764>(o => o.Speed = 8);
            gameEngine.ForEach<Object765>(o => o.Speed = 9);
            gameEngine.ForEach<Object766>(o => o.Speed = 10);
            halfBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
            });
        };

        actions[666] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object759>(o => o.Speed = -2);
            gameEngine.ForEach<Object762>(o => o.Speed = -2);
            gameEngine.ForEach<Object763>(o => o.Speed = -2);
            gameEngine.ForEach<Object764>(o => o.Speed = -2);
            gameEngine.ForEach<Object765>(o => o.Speed = -2);
            gameEngine.ForEach<Object766>(o => o.Speed = -2);
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[2].Timer = 1;
            });
            halfBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[680] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[1].Timer = 1);
            halfBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
            });
            gameEngine.ForEach<Object759>(o => o.Speed = 5);
            gameEngine.ForEach<Object762>(o => o.Speed = 6);
            gameEngine.ForEach<Object763>(o => o.Speed = 7);
            gameEngine.ForEach<Object764>(o => o.Speed = 8);
            gameEngine.ForEach<Object765>(o => o.Speed = 9);
            gameEngine.ForEach<Object766>(o => o.Speed = 10);
        };

        actions[686] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object759>(o => o.Speed = -2);
            gameEngine.ForEach<Object762>(o => o.Speed = -2);
            gameEngine.ForEach<Object763>(o => o.Speed = -2);
            gameEngine.ForEach<Object764>(o => o.Speed = -2);
            gameEngine.ForEach<Object765>(o => o.Speed = -2);
            gameEngine.ForEach<Object766>(o => o.Speed = -2);
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[2].Timer = 1;
            });
            halfBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[692] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[1].Timer = 1);
            halfBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
            });
            gameEngine.ForEach<Object759>(o => o.Speed = 5);
            gameEngine.ForEach<Object762>(o => o.Speed = 6);
            gameEngine.ForEach<Object763>(o => o.Speed = 7);
            gameEngine.ForEach<Object764>(o => o.Speed = 8);
            gameEngine.ForEach<Object765>(o => o.Speed = 9);
            gameEngine.ForEach<Object766>(o => o.Speed = 10);
        };

        actions[708] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object759>(o => o.Speed = -2);
            gameEngine.ForEach<Object762>(o => o.Speed = -2);
            gameEngine.ForEach<Object763>(o => o.Speed = -2);
            gameEngine.ForEach<Object764>(o => o.Speed = -2);
            gameEngine.ForEach<Object765>(o => o.Speed = -2);
            gameEngine.ForEach<Object766>(o => o.Speed = -2);
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[2].Timer = 1;
            });
            halfBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[720] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[1].Timer = 1);
            halfBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
            });
            gameEngine.ForEach<Object759>(o => o.Speed = 5);
            gameEngine.ForEach<Object762>(o => o.Speed = 6);
            gameEngine.ForEach<Object763>(o => o.Speed = 7);
            gameEngine.ForEach<Object764>(o => o.Speed = 8);
            gameEngine.ForEach<Object765>(o => o.Speed = 9);
            gameEngine.ForEach<Object766>(o => o.Speed = 10);
        };

        actions[726] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[0].Timer = 1);
            gameEngine.ForEach<Object759>(o => o.Speed = -2);
            gameEngine.ForEach<Object762>(o => o.Speed = -2);
            gameEngine.ForEach<Object763>(o => o.Speed = -2);
            gameEngine.ForEach<Object764>(o => o.Speed = -2);
            gameEngine.ForEach<Object765>(o => o.Speed = -2);
            gameEngine.ForEach<Object766>(o => o.Speed = -2);
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[2].Timer = 1;
            });
            halfBgObject.Invisible = true;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[732] = () =>
        {
            gameEngine.ForEach<Object758>(o => o.Clocks[1].Timer = 1);
            halfBgObject.Invisible = false;
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[2].Timer = 0;
            });
            gameEngine.ForEach<Object759>(o => o.Speed = 5);
            gameEngine.ForEach<Object762>(o => o.Speed = 6);
            gameEngine.ForEach<Object763>(o => o.Speed = 7);
            gameEngine.ForEach<Object764>(o => o.Speed = 8);
            gameEngine.ForEach<Object765>(o => o.Speed = 9);
            gameEngine.ForEach<Object766>(o => o.Speed = 10);
        };

        actions[738] = () =>
        {
            gameEngine.ForEach<Object748>(o =>
            {
                o.Clocks[1].Timer = 0;
                o.Clocks[3].Timer = 1;
            });
            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        };

        actions[801] = () =>
        {
            gameEngine.DeleteObject(halfBgObject);
            gameEngine.ViewYOffset = 2464;
            gameEngine.Generator.SetBgSprite("sprite521.png", OsbOrigin.Centre, gameEngine.ViewXOffset + 400, gameEngine.ViewYOffset + 304);

            gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
            gameEngine.ForEach<Object748>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object758>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object759>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object762>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object763>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object764>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object765>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object766>(gameEngine.DeleteObject);
            // gameEngine.AddObject(new Object769(gameEngine, 1600, 2464));
            double direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 15; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 2000, 2768)
                {
                    Speed = 30,
                    Direction = direction + 24 * i
                });
            }
        };

        actions[813] = () =>
        {
            double direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 15; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 2000, 2768)
                {
                    Speed = 30,
                    Direction = direction + 24 * i
                });
            }
        };

        actions[826] = () =>
        {
            double direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 15; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 2000, 2768)
                {
                    Speed = 30,
                    Direction = direction + 24 * i
                });
            }
        };

        actions[837] = () =>
        {
            double direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 15; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 2000, 2768)
                {
                    Speed = 30,
                    Direction = direction + 24 * i
                });
            }
        };

        actions[847] = () =>
        {
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object772(gameEngine, 2000, 2768)
                {
                    Speed = 15,
                    Direction = 18 * i
                });
            }
        };

        actions[862] = () =>
        {
            double direction = PointDirection(1600, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 1600, 2464)
                {
                    Speed = 30,
                    Direction = direction + 18 * i
                });
            }

            gameEngine.AddObject(new Object773(gameEngine, 2400, 2464)); // not actually visible cause offscreen lul
        };

        actions[874] = () =>
        {
            double direction = PointDirection(2400, 3072, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 2400, 3072)
                {
                    Speed = 30,
                    Direction = direction + 18 * i
                });
            }
        };

        actions[886] = () =>
        {
            double direction = PointDirection(1600, 3072, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 1600, 3072)
                {
                    Speed = 30,
                    Direction = direction + 18 * i
                });
            }
        };

        actions[898] = () =>
        {
            double direction = PointDirection(2400, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
            for (int i = 0; i < 20; i++)
            {
                gameEngine.AddObject(new Object770(gameEngine, 2400, 2464)
                {
                    Speed = 30,
                    Direction = direction + 18 * i
                });
            }
        };

        actions[908] = () =>
        {
            gameEngine.ForEach<Object772>(o =>
            {
                o.Clocks[1].Timer = 1;
                o.Clocks[3].Timer = 1;
            });
        };

        actions[984] = () =>
        {
            gameEngine.ForEach<Object772>(o => o.Clocks[4].Timer = 1);
            gameEngine.AddObject(new Object775(gameEngine));
            gameEngine.AddObject(new Object776(gameEngine, 1200, 2160));
        };

        actions[1028] = () => { gameEngine.AddObject(new Object777(gameEngine, 1200, 2160)); };

        actions[1038] = () =>
        {
            gameEngine.PlayerXSpeed = -1;
            gameEngine.PlayerYSpeed = 0;
            gameEngine.PlayerX = 2200;
            gameEngine.PlayerY = 3024;
            gameEngine.ViewAngle = 0;
            gameEngine.ForEach<Object777>(o =>
            {
                o.Clocks[0].Timer = 0;
                o.Clocks[1].Timer = 1;
            });
            gameEngine.AddObject(new Object778(gameEngine));
            gameEngine.AddObject(new Object722(gameEngine, 1600, 2464));
            gameEngine.ForEach<Object772>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object774>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object775>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object776>(gameEngine.DeleteObject);
        };

        actions[1292] = () =>
        {
            gameEngine.ForEach<Object778>(o =>
            {
                o.e = 2;
                o.Clocks[3].Timer = 1;
            });
        };

        actions[1354] = () => { gameEngine.ForEach<Object778>(o => o.Clocks[3].Timer = 1); };

        actions[1416] = () =>
        {
            gameEngine.ForEach<Object778>(o =>
            {
                o.e = 4;
                o.Clocks[3].Timer = 1;
                o.Clocks[4].Timer = 1;
            });
        };

        actions[1446] = () => { gameEngine.ForEach<Object778>(o => o.Clocks[3].Timer = 1); };

        actions[1477] = () =>
        {
            gameEngine.ForEach<Object778>(gameEngine.DeleteObject);
            gameEngine.ForEach<Object779>(o =>
            {
                o.Clocks[0].Timer = 1;
                o.Clocks[2].Timer = 1;
            });
            gameEngine.AddObject(new Object823(gameEngine, 1600, 2464));
        };

        actions[1480] = () => { gameEngine.ForEach<Object825>(o => o.Speed = 0); };

        actions[1493] = () => { gameEngine.ForEach<Object825>(o => o.Clocks[0].Timer = 1); };

        actions[1496] = () => { gameEngine.ForEach<Object825>(o => o.Speed = 0); };

        actions[1508] = () => { gameEngine.ForEach<Object825>(o => o.Clocks[0].Timer = 1); };

        actions[1511] = () =>
        {
            gameEngine.ForEach<Object825>(o => o.Speed = 0);
            // gameEngine.ForEach<Object825>(o => o.Speed = 0);
        };

        actions[1522] = () =>
        {
            // gameEngine.ForEach<Object825>(o => o.Clocks[1].Timer = 1);
            gameEngine.ForEach<Object825>(o => o.Clocks[1].Timer = 1);
        };

        actions[1538] = () => { gameEngine.CurrentTimeline = new Timeline20(gameEngine, 62); };
    }
}

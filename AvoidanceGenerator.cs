#nullable enable

using System.Linq;
using OpenTK;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts.GamemakerGameEngine;
using static StorybrewScripts.Utils;

namespace StorybrewScripts;

public class AvoidanceGenerator : StoryboardObjectGenerator, ISpriteGenerator
{
    private StoryboardLayer OverlayLayer => GetLayer("Overlay");

    public OsbSprite? BgSprite { get; private set; }
    public OsbSprite CreateSprite(string path) => OverlayLayer.CreateSprite(path);

    public OsbSprite CreateSprite(int depth, string path) => GetLayer(depth.ToString()).CreateSprite(path);

    // from Object719, which is spawned in Room150 initially, starts Timeline18 and acts as parent object for the timelines
    private const double c = 17;
    private const double d = 30;
    private const double e = 18.5;

    private void Timeline18(GameEngine gameEngine)
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
        gameEngine.Step(16); // 970
        foreach (Object730 object730 in gameEngine.Objects.OfType<Object730>()) object730.Clocks[1].Timer = 1;

        gameEngine.Step(26); // 996
        gameEngine.PlayerXSpeed = 2;
        foreach (Object730 object730 in gameEngine.Objects.OfType<Object730>())
        {
            object730.Friction = 0;
            object730.Clocks[0].Timer = 0;
            object730.Clocks[1].Timer = 0;
            object730.Clocks[2].Timer = 1;
        }

        gameEngine.Step(18); // 1014
        gameEngine.AddObject(new Object731(gameEngine));
        gameEngine.AddObject(new Object733(gameEngine));

        gameEngine.Step(104); // 1118
        foreach (Object731 object731 in gameEngine.Objects.OfType<Object731>())
        {
            object731.Clocks[0].Timer = 0;
            object731.Clocks[1].Timer = 1;
        }
        foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) object733.Clocks[2].Timer = 0;
        gameEngine.ForEach<Object735>(o => o.Clocks[0].Timer = 1);

        gameEngine.Step(4); // 1122
        foreach (Object731 object731 in gameEngine.Objects.OfType<Object731>()) gameEngine.DeleteObject(object731);
        gameEngine.ViewAngle = 0;
        gameEngine.Step(82);
        for (int i = 0; i < 30; i++)
        {
            var newObject = new Object741(gameEngine)
            {
                Speed = random.Next(10, 16),
                Direction = random.Next(361)
            };
            gameEngine.AddObject(newObject);
        }

        gameEngine.Step(16);
        for (int i = 0; i < 30; i++)
        {
            var newObject = new Object742(gameEngine)
            {
                Speed = random.Next(10, 16),
                Direction = random.Next(361)
            };
            gameEngine.AddObject(newObject);
        }

        gameEngine.Step(18);
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
        gameEngine.Step(6);
        foreach (Object741 object741 in gameEngine.Objects.OfType<Object741>()) object741.Clocks[2].Timer = 1;
        foreach (Object742 object742 in gameEngine.Objects.OfType<Object742>())
        {
            object742.Clocks[2].Timer = 1;
            object742.Clocks[3].Timer = 0;
        }

        gameEngine.PlayerXSpeed = -2;
        gameEngine.Step(14);
        foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>())
        {
            object733.Clocks[2].Timer = 1;
            object733.Clocks[3].Timer = 1;
        }
        gameEngine.AddObject(new Object743(gameEngine));
        gameEngine.Step(104);
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
        gameEngine.Step(4);
        foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) object733.Clocks[4].Timer = 1;
        foreach (Object743 object743 in gameEngine.Objects.OfType<Object743>()) gameEngine.DeleteObject(object743);
        gameEngine.ViewAngle = 0;
        gameEngine.Step(14);
        gameEngine.AddObject(new Object744(gameEngine));
        gameEngine.AddObject(new Object745(gameEngine, -200, -152));
        gameEngine.Step(60);
        gameEngine.AddObject(new Object746(gameEngine, 0, 0));
        foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) gameEngine.DeleteObject(object733);
        foreach (Object734 object734 in gameEngine.Objects.OfType<Object734>()) gameEngine.DeleteObject(object734);
        foreach (Object744 object744 in gameEngine.Objects.OfType<Object744>()) gameEngine.DeleteObject(object744);
        gameEngine.ViewXOffset = gameEngine.ViewYOffset = 0;

        gameEngine.Step(48);
        gameEngine.PlayerX = 1900;
        gameEngine.PlayerY = 152;
        gameEngine.ViewXOffset = 1600;
        gameEngine.PlayerXSpeed = 0;
        gameEngine.PlayerYSpeed = 2;
        foreach (Object746 object746 in gameEngine.Objects.OfType<Object746>()) gameEngine.DeleteObject(object746);
    }

    private void Timeline19(GameEngine gameEngine)
    {
        BgSprite = null;

        BuildRoom150(gameEngine);
        // this acts as a collection of type 756/747 objects, aka when the blocks would appear one of these dummy bg objects gets visible instead
        var fullBgObject = new BgObject(gameEngine, 1600, 0, "fullT");
        var halfBgObject = new BgObject(gameEngine, 1600, 0, "halfT");
        gameEngine.AddObject(fullBgObject);
        gameEngine.AddObject(halfBgObject);
        fullBgObject.Invisible = false;

        // technically part of the previous timeline but we need to setup BG before starting this one
        gameEngine.Step(17); // 64
        BgSprite = GetLayer("Room").CreateSprite("room150_emptyT.png", OsbOrigin.TopLeft, new Vector2(1600, 0));
        // BgSprite.Scale(1488 * stepMilliseconds, 2289 * stepMilliseconds, positionMultiplier, positionMultiplier);
        // starts at step 64, before that is presumably testing code
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
        gameEngine.Step(228);
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[0].Timer = 1;
        // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[0].Timer = 1;
        fullBgObject.Invisible = true;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(14);
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[1].Timer = 1;
        // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[1].Timer = 1;
        fullBgObject.Invisible = false;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(126);
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[0].Timer = 1;
        // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[0].Timer = 1;
        fullBgObject.Invisible = true;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(30);
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[1].Timer = 1;
        // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[1].Timer = 1;
        fullBgObject.Invisible = false;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(62);
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[0].Timer = 1;
        // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[0].Timer = 1;
        fullBgObject.Invisible = true;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        foreach (Object750 object750 in gameEngine.Objects.OfType<Object750>()) gameEngine.DeleteObject(object750);
        foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Speed = 0;

        gameEngine.Step(6);
        foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[0].Timer = 1;
        // foreach (Object758 object758 in gameEngine.Objects.OfType<Object758>()) object758.Clocks[1].Timer = 1;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(8);
        foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[2].Timer = 1;
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[2].Timer = 1;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(3);
        foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[2].Timer = 1;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(3);
        foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[2].Timer = 1;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[2].Timer = 1;

        gameEngine.Step(3);
        foreach (Object751 object751 in gameEngine.Objects.OfType<Object751>()) object751.Clocks[1].Timer = 1;
        foreach (Object754 object754 in gameEngine.Objects.OfType<Object754>()) object754.Clocks[3].Timer = 1;
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(5);
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

        gameEngine.Step(48);
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

        gameEngine.Step(14); // 614
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

        gameEngine.Step(26);
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

        gameEngine.Step(6);
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

        gameEngine.Step(20); // 666
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

        gameEngine.Step(14); // 680
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

        gameEngine.Step(6); // 686
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

        gameEngine.Step(6); // 692
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

        gameEngine.Step(16); // 708
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

        gameEngine.Step(12); // 720
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

        gameEngine.Step(6); // 726
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

        gameEngine.Step(6); // 732
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

        gameEngine.Step(6); // 738
        gameEngine.ForEach<Object748>(o =>
        {
            o.Clocks[1].Timer = 0;
            o.Clocks[3].Timer = 1;
        });
        gameEngine.AddObject(new Object752(gameEngine, 1600, 0));

        gameEngine.Step(63); // 801
        gameEngine.DeleteObject(halfBgObject);
        gameEngine.ViewYOffset = 2464;
        BgSprite = GetLayer("Room").CreateSprite("sprite521.png", OsbOrigin.Centre,
            new Vector2((float)(gameEngine.ViewXOffset + playfieldMiddleX), (float)(gameEngine.ViewYOffset + 304)));
        // BgSprite.Scale(gameEngine.CurrentTime, gameEngine.CurrentTime + 200 * stepMilliseconds, positionMultiplier, positionMultiplier);
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
        var direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 15; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 2000,2768)
            {
                Speed = 30,
                Direction = direction + 24 * i
            });
        }

        gameEngine.Step(12); // 813
        direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 15; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 2000,2768)
            {
                Speed = 30,
                Direction = direction + 24 * i
            });
        }

        gameEngine.Step(13); // 826
        direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 15; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 2000,2768)
            {
                Speed = 30,
                Direction = direction + 24 * i
            });
        }

        gameEngine.Step(11); // 837
        direction = PointDirection(2000, 2768, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 15; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 2000,2768)
            {
                Speed = 30,
                Direction = direction + 24 * i
            });
        }

        gameEngine.Step(10); // 847
        for (int i = 0; i < 20; i++)
        {
            gameEngine.AddObject(new Object772(gameEngine, 2000,2768)
            {
                Speed = 15,
                Direction = 18 * i
            });
        }

        gameEngine.Step(15); // 862
        direction = PointDirection(1600, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 20; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 1600,2464)
            {
                Speed = 30,
                Direction = direction + 18 * i
            });
        }
        gameEngine.AddObject(new Object773(gameEngine, 2400, 2464));

        gameEngine.Step(12); // 874
        direction = PointDirection(2400, 3072, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 20; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 2400,3072)
            {
                Speed = 30,
                Direction = direction + 18 * i
            });
        }

        gameEngine.Step(12); // 886
        direction = PointDirection(1600, 3072, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 20; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 1600,3072)
            {
                Speed = 30,
                Direction = direction + 18 * i
            });
        }

        gameEngine.Step(12); // 898
        direction = PointDirection(2400, 2464, gameEngine.PlayerX, gameEngine.PlayerY);
        for (int i = 0; i < 20; i++)
        {
            gameEngine.AddObject(new Object770(gameEngine, 2400,2464)
            {
                Speed = 30,
                Direction = direction + 18 * i
            });
        }

        gameEngine.Step(10); // 908
        gameEngine.ForEach<Object772>(o =>
        {
            o.Clocks[1].Timer = 1;
            o.Clocks[3].Timer = 1;
        });

        gameEngine.Step(76); // 984
        gameEngine.ForEach<Object772>(o => o.Clocks[4].Timer = 1);
        gameEngine.AddObject(new Object775(gameEngine));
        gameEngine.AddObject(new Object776(gameEngine, 1200, 2160));

        gameEngine.Step(44); // 1028
        gameEngine.AddObject(new Object777(gameEngine, 1200, 2160));

        gameEngine.Step(10); // 1038
        gameEngine.PlayerXSpeed = -1;
        gameEngine.PlayerYSpeed = 0;
        gameEngine.PlayerY = 0;
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

        gameEngine.Step(254); // 1292
        gameEngine.ForEach<Object778>(o =>
        {
            o.e = 2;
            o.Clocks[3].Timer = 1;
        });

        gameEngine.Step(62); // 1354
        gameEngine.ForEach<Object778>(o => o.Clocks[3].Timer = 1);

        gameEngine.Step(62); // 1416
        gameEngine.ForEach<Object778>(o =>
        {
            o.e = 4;
            o.Clocks[3].Timer = 1;
            o.Clocks[4].Timer = 1;
        });

        gameEngine.Step(30); // 1446
        gameEngine.ForEach<Object778>(o => o.Clocks[3].Timer = 1);

        gameEngine.Step(30); // 1477
        gameEngine.ForEach<Object778>(gameEngine.DeleteObject);
        gameEngine.Step(1);
        gameEngine.ForEach<Object779>(o =>
        {
            o.Clocks[0].Timer = 1;
            o.Clocks[2].Timer = 1;
        });
        gameEngine.AddObject(new Object823(gameEngine, 1600, 2464));

        gameEngine.Step(3); // 1480
        gameEngine.ForEach<Object825>(o => o.Speed = 0);

        gameEngine.Step(13); // 1493
        gameEngine.ForEach<Object825>(o => o.Clocks[0].Timer = 1);

        gameEngine.Step(3); // 1496
        gameEngine.ForEach<Object825>(o => o.Speed = 0);

        gameEngine.Step(12); // 1508
        gameEngine.ForEach<Object825>(o => o.Clocks[0].Timer = 1);

        gameEngine.Step(3); // 1511
        gameEngine.ForEach<Object825>(o => o.Speed = 0);
        // gameEngine.ForEach<Object825>(o => o.Speed = 0);

        gameEngine.Step(11); // 1522
        // gameEngine.ForEach<Object825>(o => o.Clocks[1].Timer = 1);
        gameEngine.ForEach<Object825>(o => o.Clocks[1].Timer = 1);

        gameEngine.Step(16); // 1538
        // set timeline 20
    }

    private void BuildRoom150(GameEngine gameEngine)
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

    private void Timeline20(GameEngine gameEngine)
    {
        // starts at step 62
        gameEngine.AddObject(new Object785(gameEngine/*, 1600, 2464*/));

        gameEngine.Step(132); // 194
        gameEngine.AddObject(new Object790(gameEngine));
        gameEngine.Step(10);
        gameEngine.PlayerX = 1640;
        gameEngine.PlayerXSpeed = 0;
        gameEngine.PlayerYSpeed = -3;
        gameEngine.Step(25);
        gameEngine.PlayerYSpeed = 3;
        gameEngine.Step(25);
        gameEngine.PlayerYSpeed = 0;

        gameEngine.Step(26); // 280
        gameEngine.ForEach<Object785>(gameEngine.DeleteObject);
        gameEngine.ForEach<Object790>(gameEngine.DeleteObject);

        gameEngine.Step(8); // 288
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

        gameEngine.Step(6); // 294
        gameEngine.ForEach<Object784>(o => o.Clocks[3].Timer = 1);
        gameEngine.ForEach<Object786>(o => o.Clocks[3].Timer = 1);
        gameEngine.ForEach<Object787>(o => o.Clocks[2].Timer = 1);

        gameEngine.Step(16); // 310
        gameEngine.AddObject(new Object794(gameEngine, 2400, 3072)
        {
            Speed = PointDistance(2400, 3072, 2400, 2464) / 120,
            Direction = 90
        });

        gameEngine.Step(120); // 430
        gameEngine.ForEach<Object794>(o =>
        {
            o.Clocks[1].Timer = 0;
            o.Clocks[2].Timer = 0;
            o.Clocks[4].Timer = 1;
            o.Speed = PointDistance(2400, 2464, 1600, 2464) / 64;
            o.Direction = 180;
        });

        gameEngine.Step(10); // 440
        gameEngine.AddObject(new Object796(gameEngine));
        gameEngine.PlayerXSpeed = 2;

        gameEngine.Step(14); // 454
        gameEngine.AddObject(new Object796(gameEngine));

        gameEngine.Step(14); // 468
        gameEngine.AddObject(new Object796(gameEngine));
        gameEngine.PlayerXSpeed = -2;

        gameEngine.Step(4); // 472
        gameEngine.AddObject(new Object796(gameEngine));

        gameEngine.Step(4); // 476
        gameEngine.AddObject(new Object796(gameEngine));

        gameEngine.Step(8); // 484
        gameEngine.AddObject(new Object796(gameEngine));

        gameEngine.Step(10); // 494
        gameEngine.PlayerXSpeed = 0;
        gameEngine.ForEach<Object795>(o =>
        {
            o.Speed = 1;
            o.Direction = PointDirection(o.NextX, o.NextY, 2000, 2768) + 30;
            o.Clocks[0].Timer = 1;
            o.Clocks[1].Timer = 1;
        });
        gameEngine.ForEach<Object797>(o =>
        {
            o.Speed = 1;
            o.Direction = PointDirection(o.NextX, o.NextY, 2000, 2768) + 30;
            o.Clocks[0].Timer = 0;
            o.Clocks[1].Timer = 1;
        });
        gameEngine.ForEach<Object788>(gameEngine.DeleteObject);
        gameEngine.ForEach<Object794>(gameEngine.DeleteObject);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));

        gameEngine.Step(62); // 556
        gameEngine.ForEach<Object795>(gameEngine.DeleteObject);
        gameEngine.ForEach<Object797>(gameEngine.DeleteObject);
        gameEngine.AddObject(new Object801(gameEngine));
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));

        gameEngine.Step(56); // 612
        gameEngine.ForEach<Object801>(gameEngine.DeleteObject);

        gameEngine.Step(4); // 616
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

        gameEngine.Step(); // 617
        gameEngine.ForEach<Object800>(o => o.Speed = 0);

        gameEngine.Step(5); // 622
        gameEngine.ViewWidth = 736;
        gameEngine.ViewHeight = 544;
        gameEngine.ViewXOffset = 1632;
        gameEngine.ViewYOffset = 2496;
        gameEngine.ViewAngle = -4;
        gameEngine.ForEach<Object800>(o => o.Speed = 10);

        gameEngine.Step(); // 623
        gameEngine.ForEach<Object800>(o => o.Speed = 0);

        gameEngine.Step(9); // 632
        gameEngine.ViewWidth = 704;
        gameEngine.ViewHeight = 512;
        gameEngine.ViewXOffset = 1648;
        gameEngine.ViewYOffset = 2512;
        gameEngine.ViewAngle = 6;
        gameEngine.ForEach<Object800>(o => o.Speed = 10);

        gameEngine.Step(); // 633
        gameEngine.ForEach<Object800>(o => o.Speed = 0);

        gameEngine.Step(5); // 638
        gameEngine.ViewWidth = 672;
        gameEngine.ViewHeight = 480;
        gameEngine.ViewXOffset = 1664;
        gameEngine.ViewYOffset = 2528;
        gameEngine.ViewAngle = -8;
        gameEngine.ForEach<Object800>(o => o.Speed = 10);

        gameEngine.Step(); // 639
        gameEngine.ForEach<Object800>(o => o.Speed = 0);

        gameEngine.Step(8); // 647
        gameEngine.ViewWidth = 640;
        gameEngine.ViewHeight = 448;
        gameEngine.ViewXOffset = 1680;
        gameEngine.ViewYOffset = 2544;
        gameEngine.ViewAngle = 10;
        gameEngine.ForEach<Object800>(o => o.Speed = 10);

        gameEngine.Step(); // 648
        gameEngine.ForEach<Object800>(o => o.Speed = 0);

        gameEngine.Step(14); // 662
        gameEngine.AddObject(new Object803(gameEngine));
        gameEngine.ForEach<Object800>(o => o.Clocks[3].Timer = 1);

        gameEngine.Step(19); // 681
        gameEngine.AddObject(new Object805(gameEngine));

        gameEngine.Step(99); // 780
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

        gameEngine.Step(6); // 786
        gameEngine.ForEach<Object806>(o => o.Clocks[2].Timer = 1);
        gameEngine.ForEach<Object807>(o => o.Clocks[2].Timer = 1);

        gameEngine.Step(14); // 800
        gameEngine.AddObject(new Object808(gameEngine));

        gameEngine.Step(126); // 926
        gameEngine.ForEach<Object808>(o => o.Clocks[0].Timer = 0);
        gameEngine.ForEach<Object808>(o => o.Clocks[1].Timer = 1);

        gameEngine.Step(60); // 986
        gameEngine.ForEach<Object810>(o => o.Clocks[0].Timer = 1);
        gameEngine.ForEach<Object808>(gameEngine.DeleteObject);

        gameEngine.Step(47); // 1033
        gameEngine.ForEach<Object810>(o =>
        {
            o.GravityStrength = 0;
            o.Clocks[1].Timer = 1;
        });
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));

        gameEngine.Step(15); // 1048
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

        gameEngine.Step(60); // 1108
        gameEngine.ForEach<Object811>(o =>
        {
            o.Speed = 10;
            o.Direction = -90;
        });

        gameEngine.Step(6); // 1114
        gameEngine.ForEach<Object811>(o => o.Speed = 0);

        gameEngine.Step(6); // 1120
        gameEngine.ForEach<Object811>(o =>
        {
            o.Speed = 10;
            o.Direction = -90;
        });

        gameEngine.Step(4); // 1124
        gameEngine.ForEach<Object811>(o => o.Speed = 0);

        gameEngine.Step(6); // 1130
        gameEngine.ForEach<Object811>(o =>
        {
            o.Speed = 10;
            o.Direction = -90;
        });

        gameEngine.Step(2); // 1132
        gameEngine.ForEach<Object811>(o => o.Speed = 0);

        gameEngine.Step(6); // 1138
        gameEngine.ForEach<Object811>(o =>
        {
            o.Speed = 10;
            o.Direction = -90;
        });

        gameEngine.Step(32); // 1170
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        gameEngine.ForEach<Object811>(gameEngine.DeleteObject);

        a = random.Next(10);
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

        gameEngine.Step(62); // 1232
        gameEngine.ForEach<Object813>(o =>
        {
            o.Speed = 10;
            o.Direction = -90;
        });

        gameEngine.Step(6); // 1238
        gameEngine.ForEach<Object813>(o => o.Speed = 0);

        gameEngine.Step(6); // 1244
        gameEngine.ForEach<Object813>(o => o.Speed = 10);

        gameEngine.Step(4); // 1248
        gameEngine.ForEach<Object813>(o => o.Speed = 0);

        gameEngine.Step(8); // 1256
        gameEngine.ForEach<Object813>(o => o.Speed = 10);

        gameEngine.Step(2); // 1258
        gameEngine.ForEach<Object813>(o => o.Speed = 0);

        gameEngine.Step(4); // 1262
        gameEngine.ForEach<Object813>(o =>
        {
            o.Clocks[0].Timer = 1;
            o.Clocks[1].Timer = 1;
        });

        gameEngine.Step(31);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        gameEngine.ForEach<Object813>(gameEngine.DeleteObject);
    }

    private void Timeline21(GameEngine gameEngine)
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

        gameEngine.Step(10); // 10
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

        gameEngine.Step(12); // 22
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

        gameEngine.Step(14); // 36
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

        gameEngine.Step(12); // 48
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

        gameEngine.Step(8); // 56
        gameEngine.ForEach<Object814>(o => o.Clocks[1].Timer = 1);
        gameEngine.ForEach<Object814>(o => o.Clocks[2].Timer = 0);
        gameEngine.ForEach<Object814>(o => o.Clocks[3].Timer = 0);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));

        gameEngine.Step(6); // 62
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

        gameEngine.Step(10); // 72
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

        gameEngine.Step(12); // 84
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

        gameEngine.Step(10); // 94
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

        gameEngine.Step(12); // 106
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

        gameEngine.Step(8); // 114
        gameEngine.ForEach<Object814>(o => o.Clocks[1].Timer = 1);
        gameEngine.ForEach<Object814>(o => o.Clocks[2].Timer = 0);
        gameEngine.ForEach<Object814>(o => o.Clocks[3].Timer = 0);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));

        gameEngine.Step(6); // 120
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

        gameEngine.Step(12); // 132
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

        gameEngine.Step(12); // 144
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

        gameEngine.Step(12); // 156
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

        gameEngine.Step(12); // 168
        gameEngine.ForEach<Object814>(o => o.Clocks[1].Timer = 1);
        gameEngine.ForEach<Object814>(o => o.Clocks[2].Timer = 0);
        gameEngine.ForEach<Object814>(o => o.Clocks[3].Timer = 0);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));

        gameEngine.Step(18); // 186
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

        gameEngine.Step(16); // 202
        gameEngine.ForEach<Object816>(o => o.Clocks[1].Timer = 1);

        gameEngine.Step(27); // 229
        gameEngine.ForEach<Object816>(o =>
        {
            if (PointDistance(o.CurrentX, o.CurrentY, 2000, 2768) < 1)
                gameEngine.DeleteObject(o);
        });
        // gameEngine.AddObject(new Object819(gameEngine, 2000, 2768));
        // gameEngine.ForEach<Object816>(gameEngine.DeleteObject);
        // gameEngine.ForEach<Object817>(gameEngine.DeleteObject);

        gameEngine.Step(); // 230
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

        gameEngine.Step(15); // 245
    }

    private void Timeline22(GameEngine gameEngine)
    {
        // starts at step 53, before is separate testing code
        gameEngine.AddObject(new Object731(gameEngine));
        gameEngine.AddObject(new Object827(gameEngine, 1600, 2616)
        {
            Speed = 20
        });

        gameEngine.Step(97); // 150
        gameEngine.AddObject(new Object830(gameEngine));

        gameEngine.Step(7); // 157
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

        gameEngine.Step(4); // 161
        gameEngine.ForEach<Object731>(gameEngine.DeleteObject);
        gameEngine.ViewAngle = 0;

        gameEngine.Step(85); // 246
        gameEngine.ForEach<Object829>(o => o.Speed = 26);

        gameEngine.Step(4); // 250
        gameEngine.ForEach<Object829>(o => o.Speed = 13);

        gameEngine.Step(12); // 262
        gameEngine.ForEach<Object829>(o => o.Speed = 26);

        gameEngine.Step(4); // 266
        gameEngine.ForEach<Object829>(o => o.Speed = 13);

        gameEngine.Step(11); // 277
        gameEngine.ForEach<Object830>(gameEngine.DeleteObject);
        gameEngine.ForEach<Object829>(o => o.Clocks[1].Timer = 1);

        gameEngine.Step(6); // 283
        gameEngine.ForEach<Object829>(o => o.Clocks[0].Timer = 1);

        gameEngine.Step(15); // 298
        gameEngine.AddObject(new Object743(gameEngine));
        gameEngine.AddObject(new Object831(gameEngine, 2400, 2616)
        {
            Speed = 20,
            Direction = 180
        });

        gameEngine.Step(97); // 395
        gameEngine.AddObject(new Object840(gameEngine));

        gameEngine.Step(8); // 403
        gameEngine.ForEach<Object743>(o =>
        {
            o.Clocks[0].Timer = 0;
            o.Clocks[1].Timer = 1;
        });

        gameEngine.Step(4); // 407
        gameEngine.ForEach<Object743>(gameEngine.DeleteObject);
        gameEngine.ViewAngle = 0;

        gameEngine.Step(73); // 480
        gameEngine.ForEach<Object840>(o =>
        {
            o.Clocks[0].Timer = 0;
            o.Clocks[1].Timer = 1;
        });
        gameEngine.ForEach<Object841>(o => o.Clocks[2].Timer = 1);
        gameEngine.ForEach<Object842>(o => o.Clocks[2].Timer = 1);

        gameEngine.Step(15); // 495
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

        gameEngine.Step(15); // 510
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

        gameEngine.Step(15); // 525
        gameEngine.ForEach<Object840>(o =>
        {
            o.Clocks[0].Timer = 1;
            o.Clocks[1].Timer = 0;
        });
        gameEngine.ForEach<Object841>(o => o.Clocks[2].Timer = 0);
        gameEngine.ForEach<Object842>(o => o.Clocks[2].Timer = 0);

        gameEngine.Step(7); // 532
        gameEngine.ForEach<Object841>(o => o.Clocks[5].Timer = 1);
        gameEngine.ForEach<Object842>(o => o.Clocks[5].Timer = 1);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        gameEngine.ForEach<Object840>(gameEngine.DeleteObject);

        gameEngine.Step(14); // 546
        gameEngine.ForEach<Object846>(o => o.Clocks[0].Timer = 1);
        gameEngine.AddObject(new Object802(gameEngine, 1200, 2160));
        gameEngine.AddObject(new Object843(gameEngine, 1600, 2616)
        {
            Speed = 20
        });
        gameEngine.AddObject(new Object844(gameEngine));

        gameEngine.Step(106); // 652


    }

    public override void Generate()
    {
        BgSprite = GetLayer("Room").CreateSprite("sprite521.png", OsbOrigin.Centre, new Vector2((float)playfieldMiddleX, (float)playfieldMiddleY));
        // BgSprite.Scale(26 * stepMilliseconds, 1487 * stepMilliseconds, positionMultiplier, positionMultiplier);

        GameEngine gameEngine = new GameEngine(this, 26, 26 * stepMilliseconds);

        gameEngine.Step(928); // 954

        Timeline18(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");

        Timeline19(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");

        Timeline20(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");

        Timeline21(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");

        Timeline22(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");


    }
}

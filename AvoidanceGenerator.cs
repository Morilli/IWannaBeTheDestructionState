#nullable enable

using System.Linq;
using OpenTK;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using static StorybrewScripts.Utils;

namespace StorybrewScripts;

public class AvoidanceGenerator : StoryboardObjectGenerator, ISpriteGenerator
{
    private StoryboardLayer OverlayLayer => GetLayer("Overlay");

    public OsbSprite? BgSprite { get; private set; }
    public OsbSprite CreateSprite(string path) => OverlayLayer.CreateSprite(path);

    public OsbSprite CreateSprite(string path, double initialX, double initialY) => OverlayLayer.CreateSprite(path, initialX, initialY);

    public OsbSprite CreateSprite(int depth, string path) => GetLayer(depth.ToString()).CreateSprite(path);

    private void Timeline18(GameEngine gameEngine)
    {
        for (int i = 0; i < 20; i++)
        {
            var newObject = new Object730(gameEngine)
            {
                Speed = 25,
                Direction = i * 18
            };
            gameEngine.AddObject(newObject);
        }
        gameEngine.Step(16);
        foreach (Object730 object730 in gameEngine.Objects.OfType<Object730>()) object730.Clocks[1].Timer = 1;
        gameEngine.Step(26);
        foreach (Object730 object730 in gameEngine.Objects.OfType<Object730>())
        {
            object730.Friction = 0;
            object730.Clocks[0].Timer = 0;
            object730.Clocks[1].Timer = 0;
            object730.Clocks[2].Timer = 1;
        }

        gameEngine.PlayerXSpeed = 2;
        gameEngine.Step(18);
        gameEngine.AddObject(new Object731(gameEngine));
        gameEngine.AddObject(new Object733(gameEngine));
        gameEngine.Step(104);
        foreach (Object731 object731 in gameEngine.Objects.OfType<Object731>())
        {
            object731.Clocks[0].Timer = 0;
            object731.Clocks[1].Timer = 1;
        }
        foreach (Object733 object733 in gameEngine.Objects.OfType<Object733>()) object733.Clocks[2].Timer = 0;
        gameEngine.Step(4);
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
        // BgSprite = null;
        BgSprite = GetLayer("Room").CreateSprite("room150_emptyT.png", OsbOrigin.TopLeft, Vector2.Zero);
        BgSprite.Scale(1488 * stepMilliseconds, 2289 * stepMilliseconds, positionMultiplier, positionMultiplier);

        BuildRoom150(gameEngine);
        // this acts as a collection of type 756/747 objects, aka when the blocks would appear one of these dummy bg objects gets visible instead
        var fullBgObject = new BgObject(gameEngine, 1600, 0, "fullT");
        var halfBgObject = new BgObject(gameEngine, 1600, 0, "halfT");
        gameEngine.AddObject(fullBgObject);
        gameEngine.AddObject(halfBgObject);
        fullBgObject.Invisible = false;

        // technically part of the previous timeline but we need to setup BG before starting this one
        gameEngine.Step(17); // 64
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
            new Vector2((float)(gameEngine.ViewXOffset + playfieldMiddleX), (float)(gameEngine.ViewYOffset + playfieldMiddleY)));
        BgSprite.Scale(gameEngine.CurrentTime, gameEngine.CurrentTime + 200 * stepMilliseconds, positionMultiplier, positionMultiplier);
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

    public override void Generate()
    {
        BgSprite = GetLayer("Room").CreateSprite("sprite521.png", OsbOrigin.Centre, new Vector2((float)playfieldMiddleX, (float)playfieldMiddleY));
        BgSprite.Scale(26 * stepMilliseconds, 1487 * stepMilliseconds, positionMultiplier, positionMultiplier);

        GameEngine gameEngine = new GameEngine(this, 954, 954 * stepMilliseconds);

        Timeline18(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");

        Timeline19(gameEngine);
        Log($"current step: {gameEngine.CurrentStep}, alive objects: {gameEngine.Objects.Count}");


    }
}

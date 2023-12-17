#nullable enable

using StorybrewCommon.Storyboarding;

namespace StorybrewScripts;

public interface ISpriteGenerator
{
    public OsbSprite CreateSprite(string path);
    public OsbSprite CreateSprite(int depth, string path);

    public OsbSprite? BgSprite { get; }
    public void SetBgSprite(string path, OsbOrigin origin, int initialX, int initialY);

    public void Log(string message);
}

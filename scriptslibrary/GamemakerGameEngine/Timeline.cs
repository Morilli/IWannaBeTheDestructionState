using System;
using System.Collections.Generic;

namespace StorybrewScripts.GamemakerGameEngine;

public abstract class Timeline
{
    // from Object719, which is spawned in Room150 initially, starts Timeline18 and acts as parent object for the timelines
    protected const double c = 17;
    protected const double d = 30;
    protected const double e = 18.5;

    public int CurrentStep { get; set; }

    public IReadOnlyDictionary<int, Action> Actions => actions;
    protected readonly Dictionary<int, Action> actions = new();

    public void Step()
    {
        if (actions.TryGetValue(CurrentStep++, out Action action))
        {
            action();
        }
    }

    protected Timeline(int initialStep = 0)
    {
        CurrentStep = initialStep;
    }
}

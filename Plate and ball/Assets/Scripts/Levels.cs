using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels
{
    public List<Dictionary<string, int>> LevelsList()
    {
        List<Dictionary<string, int>> levels = new List<Dictionary<string, int>>()
        {
            level1,
            level2
        };
        return levels;
    }

    Dictionary<string, int> level1 = new Dictionary<string, int>()
    {
        {"Block",13 },
        {"HeavyBlock",7 }
    };
    Dictionary<string, int> level2 = new Dictionary<string, int>()
    {
        {"Block",3 },
        {"HeavyBlock",3 }
    };
}

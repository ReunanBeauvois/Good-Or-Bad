using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [HideInInspector]
    public int level;
    [HideInInspector]
    public int levelMemory;
    public Score _score;

    public int pointsToReachToLevelUp;

    // Update is called once per frame
    void Update()
    {
        EditLevel();
    }

    void EditLevel()
    {
        if (((_score.currentScore / pointsToReachToLevelUp) % pointsToReachToLevelUp) > 0)
        {
            levelMemory = level;

            level = ((_score.currentScore / pointsToReachToLevelUp) % pointsToReachToLevelUp);

            if (level < levelMemory)
            {
                level = levelMemory;
            }
        }

        if (TryGetComponent<Text>(out Text _text))
        {
            if (_text != null)
            {
                if (level <= 0)
                { level = 0; _text.text = "Level : 000"; }
                if (level > 0 && level < 10)
                { _text.text = "Level : 00" + level; }
                if (level >= 10 && level < 100)
                { _text.text = "Level : 0" + level; }
                if (level >= 100 && level < 1000)
                { _text.text = "Level : " + level; }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int gold;
    public int goldMemory;
    public int gainAfterCertainAmountPoints;
    public Score currentScore;

    // Update is called once per frame
    void Update()
    {
        EditGold();
    }

    void EditGold()
    {
        if (currentScore == null)
        {
            currentScore = FindObjectOfType<Score>();
        }
        if (currentScore != null)
        {
            if (((currentScore.currentScore / gainAfterCertainAmountPoints) % gainAfterCertainAmountPoints) > 0)
            {
                goldMemory = gold;

                gold = ((currentScore.currentScore / gainAfterCertainAmountPoints) % gainAfterCertainAmountPoints);

                if (gold < goldMemory)
                {
                    gold = goldMemory;
                }
            }

            if (TryGetComponent<Text>(out Text _text))
            {
                if (_text != null)
                {
                    if (gold <= 0)
                    { gold = 0; _text.text = "0000000"; }
                    if (gold > 0 && gold < 10)
                    { _text.text = "000000" + gold; }
                    if (gold >= 10 && gold < 100)
                    { _text.text = "00000" + gold; }
                    if (gold >= 100 && gold < 1000)
                    { _text.text = "0000" + gold; }
                    if (gold >= 1000 && gold < 10000)
                    { _text.text = "000" + gold; }
                    if (gold >= 10000 && gold < 100000)
                    { _text.text = "00" + gold; }
                    if (gold >= 100000 && gold < 1000000)
                    { _text.text = "0" + gold; }
                    if (gold >= 1000000 && gold <= 9999999)
                    { _text.text = "" + gold; }
                    if (gold >= 9999999)
                    { gold = 9999999; _text.text = "" + gold; }
                }
            }
        }
    }
}

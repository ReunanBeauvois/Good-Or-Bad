using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficheGold : MonoBehaviour
{
    public Gold _goldReference;
    public int gold;

    // Update is called once per frame
    void Update()
    {
        DisplayGold();
    }

    void DisplayGold()
    {
        if (TryGetComponent<Text>(out Text _text))
        {
            if (_text != null && _goldReference != null)
            {
                if (_goldReference.TryGetComponent<Text>(out Text _goldText))
                {
                    gold = _goldReference.goldMemory;
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

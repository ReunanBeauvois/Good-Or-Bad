using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficheScore : MonoBehaviour
{
    public Score _scoreReference;

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    void DisplayScore()
    {
        if (TryGetComponent<Text>(out Text _text))
        {
            if (_text != null && _scoreReference != null)
            {
                if (_scoreReference.TryGetComponent<Text>(out Text _scoreText))
                {
                    _text.text = _scoreText.text;
                }
            }
        }
    }
}

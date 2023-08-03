using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficheNiveauJoueur : MonoBehaviour
{
    public Level _levelReference;

    // Update is called once per frame
    void Update()
    {
        DisplayLevel();
    }

    void DisplayLevel()
    {
        if (TryGetComponent<Text>(out Text _text))
        {
            if (_text != null && _levelReference != null)
            {
                if (_levelReference.TryGetComponent<Text>(out Text _levelText))
                {
                    _text.text = _levelText.text;
                }
            }
        }
    }
}

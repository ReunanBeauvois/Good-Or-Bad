using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class BuyBoosters : MonoBehaviour, ISelectHandler
{
    public bool estSelectionne;
    [HideInInspector]
    public BuyBoosters[] nonSelectionne;
    public List<BuyBoosters> _nonSelectionne;
    public NewColors newColorsReference;

    private void Update()
    {
        if (estSelectionne)
        {
            var color = GetComponent<Button>().colors;
            color.normalColor = color.selectedColor;
            GetComponent<Button>().colors = color;
        }
        if (!estSelectionne)
        {
            var color = GetComponent<Button>().colors;
            color.normalColor = Color.white;
            GetComponent<Button>().colors = color;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        estSelectionne = true;

        if (newColorsReference != null)
        {
            if (!newColorsReference.chercheObjets)
            {
                newColorsReference.ChercheObjetAvecSacOuGenerateur();
                newColorsReference.referenceLevel = newColorsReference.referenceLevel.Distinct().ToList();
                if (newColorsReference.referenceLevel.Count > 0)
                {
                    for (int i = 0; i < newColorsReference.referenceLevel.Count; ++i)
                    {
                        newColorsReference.referenceLevel[i].sacs = newColorsReference.referenceLevel[i].sacs.Distinct().ToList();
                        newColorsReference.referenceLevel[i].generateurs = newColorsReference.referenceLevel[i].generateurs.Distinct().ToList();
                    }
                }
                newColorsReference.chercheObjets = true;
            }

        }

        nonSelectionne = FindObjectsOfType<BuyBoosters>();

        if (nonSelectionne.Length > 0)
        {
            for (int i = 0; i < nonSelectionne.Length; ++i)
            {
                _nonSelectionne.Add(nonSelectionne[i]);
            }
        }

        if (_nonSelectionne.Count > 0)
        {
            for (int i = 0; i < _nonSelectionne.Count; ++i)
            {
                if (_nonSelectionne.Contains(this.GetComponent<BuyBoosters>()))
                {
                    _nonSelectionne.Remove(this.GetComponent<BuyBoosters>());
                }
            }
        }

        _nonSelectionne = _nonSelectionne.Distinct().ToList();

        if (_nonSelectionne.Count > 0)
        {
            for (int i = 0; i < _nonSelectionne.Count; ++i)
            {
                if (estSelectionne)
                {
                    _nonSelectionne[i].estSelectionne = false;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssocierNiveauBouton : MonoBehaviour, IDeselectHandler, ISelectHandler
{
    public bool estSelectionne;

    public void OnDeselect(BaseEventData data)
    {
        estSelectionne = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        estSelectionne = true;
    }
}

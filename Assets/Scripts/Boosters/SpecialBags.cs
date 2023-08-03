using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBags : MonoBehaviour
{
    public NewColors newColorsReference;

    public Button boutonReference;
    public Button boutonAchat;

    public bool chercheObjets;

    public List<GameObject> sacs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boutonReference != null)
        {
            if (boutonReference.TryGetComponent<Button>(out Button _bouton))
            {
                if (_bouton != null)
                {
                    _bouton.onClick.AddListener(SacsAvecCouleursEtFormes);
                }
            }
        }
    }

    public void ChercheObjetAvecSac()
    {
        if (newColorsReference != null)
        {
            if (newColorsReference.referenceLevel.Count > 0)
            {
                for (int i = 0; i < newColorsReference.referenceLevel.Count; ++i)
                {
                    if (newColorsReference.referenceLevel[i].sacs.Count > 0)
                    {
                        for (int j = 0; j < newColorsReference.referenceLevel[i].sacs.Count; ++j)
                        {
                            sacs.Add(newColorsReference.referenceLevel[i].sacs[j]);
                        }
                    }
                }
            }
        }
    }

    public void SacsAvecCouleursEtFormes()
    {
        if (!chercheObjets)
        {
            ChercheObjetAvecSac();
            chercheObjets = true;
        }
    }
}

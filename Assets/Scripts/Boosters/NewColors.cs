using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class SacGenerateur
{
    public List<GameObject> sacs, generateurs;
}

public class NewColors : MonoBehaviour
{
    public List<Material> couleurs;
    public GameObject niveauxReference;

    public Button boutonReference;

    public Button boutonAchat;

    public List<SacGenerateur> referenceLevel;

    [HideInInspector]
    public int indexDeLaCouleurAAjouter;
    [HideInInspector]
    public bool couleurAjoutee;
    [HideInInspector]
    public float tempsAvantDeCliquerANouveau;
    [HideInInspector]
    public bool chercheObjets;

    public int niveauAchat;

    // Update is called once per frame
    void Update()
    {
        if (couleurAjoutee)
        {
            boutonReference.interactable = false;
            tempsAvantDeCliquerANouveau += Time.deltaTime;
        }

        if (tempsAvantDeCliquerANouveau >= 1)
        {
            niveauAchat += 1;
            boutonReference.interactable = true;
            couleurAjoutee = false;
            boutonAchat.interactable = true;
            tempsAvantDeCliquerANouveau = 0;
        }

        if (niveauAchat >= 9)
        {
            var colors = GetComponent<Button>().colors;
            colors.disabledColor = new Color(0, 1, 0.5f, 1);
            GetComponent<Button>().colors = colors;

            boutonReference.interactable = false;

            for (int i = 0; i < referenceLevel.Count; ++i)
            {
                for (int j = 0; j < referenceLevel[i].generateurs.Count; ++j)
                {
                    if (referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Count < couleurs.Count)
                    {
                        for (int k = 0; k < couleurs.Count; ++k)
                        {
                            if (!referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Contains(couleurs[k]))
                            {
                                referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Add(couleurs[k]);
                            }
                        }
                    }
                }
                for (int j = 0; j < referenceLevel[i].sacs.Count; ++j)
                {
                    if (referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux.Count < couleurs.Count)
                    {
                        for (int k = 0; k < couleurs.Count; ++k)
                        {
                            if (!referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux.Contains(couleurs[k]))
                            {
                                referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux.Add(couleurs[k]);
                            }
                        }
                    }
                }
            }
        }
    }

    public void ChercheObjetAvecSacOuGenerateur()
    {
        if (niveauxReference != null)
        {
            if (niveauxReference.transform.childCount > 0)
            {
                for (int i = 0; i < niveauxReference.transform.childCount; ++i)
                {
                    referenceLevel.Add(new SacGenerateur());

                    for (int k = 0; k < referenceLevel.Count; ++k)
                    {
                        referenceLevel[k].sacs = new List<GameObject>(20);
                        referenceLevel[k].generateurs = new List<GameObject>(20);
                    }
                }

                for (int i = 0; i < referenceLevel.Count; ++i)
                {
                    for (int j = 0; j < 30; ++j)
                    {
                        referenceLevel[i].sacs.Add(null);
                        referenceLevel[i].generateurs.Add(null);
                    }
                }

                for (int i = 0; i < referenceLevel.Count; ++i)
                {
                    for (int j = 0; j < niveauxReference.transform.GetChild(i).transform.childCount; ++j)
                    {
                        if (niveauxReference.transform.GetChild(i).transform.gameObject == niveauxReference.transform.GetChild(i).transform.GetChild(j).transform.parent.gameObject)
                        {
                            if (niveauxReference.transform.GetChild(i).transform.GetChild(j).transform.GetComponent<CouleurSac>())
                            {
                                referenceLevel[i].sacs[j] = niveauxReference.transform.GetChild(i).transform.GetChild(j).transform.gameObject;
                            }
                            if (niveauxReference.transform.GetChild(i).transform.GetChild(j).transform.GetComponent<GenerateurParties>())
                            {
                                referenceLevel[i].generateurs[j] = niveauxReference.transform.GetChild(i).transform.GetChild(j).transform.gameObject;
                            }
                        }
                    }
                    referenceLevel[i].sacs = referenceLevel[i].sacs.Distinct().ToList();
                    referenceLevel[i].generateurs = referenceLevel[i].generateurs.Distinct().ToList();
                }

                for (int i = 0; i < referenceLevel.Count; ++i)
                {
                    for (int j = 0; j < referenceLevel[i].generateurs.Count; ++j)
                    {
                        if (referenceLevel[i].generateurs[j] == null)
                        {
                            referenceLevel[i].generateurs.RemoveAt(j);
                        }
                    }
                    for (int j = 0; j < referenceLevel[i].sacs.Count; ++j)
                    {
                        if (referenceLevel[i].sacs[j] == null)
                        {
                            referenceLevel[i].sacs.RemoveAt(j);
                        }
                    }
                }
            }
        }
    }

    public void NewColorsToAdd()
    {
        if (!chercheObjets)
        {
            ChercheObjetAvecSacOuGenerateur();
            chercheObjets = true;
        }

        if (chercheObjets && !couleurAjoutee)
        {
            if (couleurs.Count > 0)
            { indexDeLaCouleurAAjouter = Random.Range(0, couleurs.Count); }

            if (referenceLevel.Count > 0)
            {
                for (int i = 0; i < referenceLevel.Count; ++i)
                {
                    if (referenceLevel[i].generateurs.Count > 0 && referenceLevel[i].sacs.Count > 0)
                    {
                        for (int j = 0; j < referenceLevel[i].generateurs.Count; ++j)
                        {
                            if (referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Count > 0 && !referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Contains(couleurs[indexDeLaCouleurAAjouter]))
                            {
                                if (referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Count > 0)
                                {
                                    referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Add(couleurs[indexDeLaCouleurAAjouter]);
                                    referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux = referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Distinct().ToList();
                                }
                                if (referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux.Count > 0)
                                {
                                    referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux.Add(couleurs[indexDeLaCouleurAAjouter]);
                                    referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux = referenceLevel[i].sacs[j].GetComponent<CouleurSac>().materiaux.Distinct().ToList();
                                }

                                couleurAjoutee = true;
                            }
                            if (referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Count > 0 && referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().materiaux.Contains(couleurs[indexDeLaCouleurAAjouter]))
                            {
                                NewColorsToAdd();
                                tempsAvantDeCliquerANouveau = 0;
                            }
                        }
                    }
                }
            }
        }

        boutonAchat.interactable = false;
    }
}
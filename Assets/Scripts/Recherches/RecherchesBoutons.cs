using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Recherches
{
    public class RecherchesBoutons
    {
        // Cette fonction nous permet de récupérer tout objet avec un composant Button ou Texte pour en influencer l'interaction, sans intervention humaine
        public void BouclesRecherches(GameObject objet, List<Button> buttons, bool isInteragible)
        {
            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<Button>(out Button _button))
                    { buttons.Add(_button); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<Button>(out Button _button2))
                            { buttons.Add(_button2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<Button>(out Button _button3))
                                    { buttons.Add(_button3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<Button>(out Button _button4))
                                            { buttons.Add(_button4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<Button>(out Button _button5))
                                                    { buttons.Add(_button5); }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (buttons.Count > 0)
            {
                for (int i = 0; i < buttons.Count; ++i)
                {
                    buttons[i].interactable = isInteragible;
                }
            }
        }

        public void BouclesRecherchesSansEtat(GameObject objet, List<Button> buttons)
        {
            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<Button>(out Button _button))
                    { buttons.Add(_button); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<Button>(out Button _button2))
                            { buttons.Add(_button2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<Button>(out Button _button3))
                                    { buttons.Add(_button3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<Button>(out Button _button4))
                                            { buttons.Add(_button4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<Button>(out Button _button5))
                                                    { buttons.Add(_button5); }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
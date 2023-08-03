using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Recherches
{
    public class RecherchesTransparence
    {
        // Cette fonction nous permet de récupérer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        public void BouclesRecherches(GameObject objet, float transparence, List<Image> images, List<Text> textes)
        {
            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<Image>(out Image _image))
                    { images.Add(_image); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<Image>(out Image _image2))
                            { images.Add(_image2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<Image>(out Image _image3))
                                    { images.Add(_image3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<Image>(out Image _image4))
                                            { images.Add(_image4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<Image>(out Image _image5))
                                                    { images.Add(_image5); }
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

            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<Text>(out Text _text))
                    { textes.Add(_text); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<Text>(out Text _text2))
                            { textes.Add(_text2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<Text>(out Text _text3))
                                    { textes.Add(_text3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<Text>(out Text _text4))
                                            { textes.Add(_text4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<Text>(out Text _text5))
                                                    { textes.Add(_text5); }
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

            if (images.Count > 0)
            {
                for (int i = 0; i < images.Count; ++i)
                {
                    var color = images[i].color;
                    color.a = transparence;
                    images[i].color = color;
                }
            }

            if (textes.Count > 0)
            {
                for (int i = 0; i < textes.Count; ++i)
                {
                    var color = textes[i].color;
                    color.a = transparence;
                    textes[i].color = color;
                }
            }
        }

        public void BouclesRecherchesSansModifierTransparence(GameObject objet, List<Image> images, List<Text> textes)
        {
            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<Image>(out Image _image))
                    { images.Add(_image); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<Image>(out Image _image2))
                            { images.Add(_image2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<Image>(out Image _image3))
                                    { images.Add(_image3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<Image>(out Image _image4))
                                            { images.Add(_image4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<Image>(out Image _image5))
                                                    { images.Add(_image5); }
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

            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<Text>(out Text _text))
                    { textes.Add(_text); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<Text>(out Text _text2))
                            { textes.Add(_text2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<Text>(out Text _text3))
                                    { textes.Add(_text3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<Text>(out Text _text4))
                                            { textes.Add(_text4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<Text>(out Text _text5))
                                                    { textes.Add(_text5); }
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

        public void EcranSelectionNiveauActif(List<Image> images1, List<Image> images2, List<Text> textes1, List<Text> textes2, GameObject ecran1, GameObject ecran2, float temps, bool bouton)
        {
            if (images1.Count > 0)
            {
                for (int i = 0; i < images1.Count; ++i)
                {
                    var color = images1[i].color;
                    color.a = 0;
                    images1[i].color = color;
                }
            }

            if (textes1.Count > 0)
            {
                for (int i = 0; i < textes1.Count; ++i)
                {
                    var color = textes1[i].color;
                    color.a = 0;
                    textes1[i].color = color;
                }
            }

            if (images2.Count > 0)
            {
                for (int i = 0; i < images2.Count; ++i)
                {
                    var color = images2[i].color;
                    color.a = 1;
                    images2[i].color = color;
                }
            }

            if (textes2.Count > 0)
            {
                for (int i = 0; i < textes2.Count; ++i)
                {
                    var color = textes2[i].color;
                    color.a = 1;
                    textes2[i].color = color;
                }
            }

            ecran1.SetActive(false);
            ecran2.SetActive(true);

            temps = 1;
            bouton = false;
        }

        public void EcranSelectionNiveauActifUnEcran(List<Image> images1, List<Text> textes1, GameObject ecran1, float temps, bool bouton)
        {
            if (images1.Count > 0)
            {
                for (int i = 0; i < images1.Count; ++i)
                {
                    var color = images1[i].color;
                    color.a = 0;
                    images1[i].color = color;
                }
            }

            if (textes1.Count > 0)
            {
                for (int i = 0; i < textes1.Count; ++i)
                {
                    var color = textes1[i].color;
                    color.a = 0;
                    textes1[i].color = color;
                }
            }

            ecran1.SetActive(false);

            temps = 1;
            bouton = false;
        }

        // Permet de changer la transparence alpha des objets présents dans les écrans
        public void ReglageTransparence(List<Image> listeDesImagesDemarrage, List<Image> listeDesImagesSelectionNiveau, List<Text> listeDesTextesDemarrage, List<Text> listeDesTextesSelectionNiveau, GameObject ecranDemarrage, GameObject ecranSelectionNiveau, float tempsDeTransition, bool boutonActif)
        {
            if (listeDesImagesDemarrage.Count > 0)
            {
                for (int i = 0; i < listeDesImagesDemarrage.Count; ++i)
                {
                    var color = listeDesImagesDemarrage[i].color;
                    color.a -= tempsDeTransition;
                    listeDesImagesDemarrage[i].color = color;

                    if (color.a <= 0)
                    {
                        EcranSelectionNiveauActif(listeDesImagesDemarrage, listeDesImagesSelectionNiveau, listeDesTextesDemarrage, listeDesTextesSelectionNiveau, ecranDemarrage, ecranSelectionNiveau, tempsDeTransition, boutonActif);
                    }
                }
            }

            if (listeDesTextesDemarrage.Count > 0)
            {
                for (int i = 0; i < listeDesTextesDemarrage.Count; ++i)
                {
                    var color = listeDesTextesDemarrage[i].color;
                    color.a -= tempsDeTransition;
                    listeDesTextesDemarrage[i].color = color;

                    if (color.a <= 0)
                    {
                        EcranSelectionNiveauActif(listeDesImagesDemarrage, listeDesImagesSelectionNiveau, listeDesTextesDemarrage, listeDesTextesSelectionNiveau, ecranDemarrage, ecranSelectionNiveau, tempsDeTransition, boutonActif);
                    }
                }
            }

            if (listeDesImagesSelectionNiveau.Count > 0)
            {
                for (int i = 0; i < listeDesImagesSelectionNiveau.Count; ++i)
                {
                    var color = listeDesImagesSelectionNiveau[i].color;
                    color.a += tempsDeTransition;
                    listeDesImagesSelectionNiveau[i].color = color;

                    if (color.a >= 1)
                    {
                        EcranSelectionNiveauActif(listeDesImagesDemarrage, listeDesImagesSelectionNiveau, listeDesTextesDemarrage, listeDesTextesSelectionNiveau, ecranDemarrage, ecranSelectionNiveau, tempsDeTransition, boutonActif);
                    }
                }
            }

            if (listeDesTextesSelectionNiveau.Count > 0)
            {
                for (int i = 0; i < listeDesTextesSelectionNiveau.Count; ++i)
                {
                    var color = listeDesTextesSelectionNiveau[i].color;
                    color.a += tempsDeTransition;
                    listeDesTextesSelectionNiveau[i].color = color;

                    if (color.a >= 1)
                    {
                        EcranSelectionNiveauActif(listeDesImagesDemarrage, listeDesImagesSelectionNiveau, listeDesTextesDemarrage, listeDesTextesSelectionNiveau, ecranDemarrage, ecranSelectionNiveau, tempsDeTransition, boutonActif);
                    }
                }
            }
        }



        // Permet de changer la transparence alpha des objets présents dans les écrans
        public void ReglageTransparenceUnEcran(List<Image> listeDesImagesDemarrage, List<Text> listeDesTextesDemarrage, GameObject ecranDemarrage, float tempsDeTransition, bool boutonActif)
        {
            if (listeDesImagesDemarrage.Count > 0)
            {
                for (int i = 0; i < listeDesImagesDemarrage.Count; ++i)
                {
                    var color = listeDesImagesDemarrage[i].color;
                    color.a -= tempsDeTransition;
                    listeDesImagesDemarrage[i].color = color;

                    if (color.a <= 0)
                    {
                        EcranSelectionNiveauActifUnEcran(listeDesImagesDemarrage, listeDesTextesDemarrage, ecranDemarrage, tempsDeTransition, boutonActif);
                    }
                }
            }

            if (listeDesTextesDemarrage.Count > 0)
            {
                for (int i = 0; i < listeDesTextesDemarrage.Count; ++i)
                {
                    var color = listeDesTextesDemarrage[i].color;
                    color.a -= tempsDeTransition;
                    listeDesTextesDemarrage[i].color = color;

                    if (color.a <= 0)
                    {
                        EcranSelectionNiveauActifUnEcran(listeDesImagesDemarrage, listeDesTextesDemarrage, ecranDemarrage, tempsDeTransition, boutonActif);
                    }
                }
            }
        }
    }
}



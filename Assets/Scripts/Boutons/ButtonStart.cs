using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Recherches;

public class ButtonStart : ButtonBase
{
    // On cr�� ces variables pour :
    // 1 - Activer l'�cran de s�lection des niveaux
    // 2 - Lancer la transparence alpha permettant de faire une transition propre
    // 3 - D�sactiver l'�cran de d�marrage une fois la transition entre les deux �crans effectu�es
    /********************************************************************************************/
    public GameObject ecranDemarrage;
    public GameObject ecranSelectionNiveau;
    public GameObject ecranBoutique;

    [HideInInspector]
    public List<Image> listeDesImagesDemarrage;
    [HideInInspector]
    public List<Text> listeDesTextesDemarrage;

    [HideInInspector]
    public List<Button> listeDesBoutonsDemarrage;
    [HideInInspector]
    public List<Button> listeDesBoutonsSelectionNiveau;
    [HideInInspector]
    public List<Button> listeDesBoutonsBoutique;

    [HideInInspector]
    public List<Image> listeDesImagesSelectionNiveau;
    [HideInInspector]
    public List<Text> listeDesTextesSelectionNiveau;

    [HideInInspector]
    public List<Image> listeDesImagesBoutique;
    [HideInInspector]
    public List<Text> listeDesTextesBoutique;

    private bool boutonActif;
    public float tempsDeTransition;
    /********************************************************************************************/

    private void DesactiverLesEcrans()
    {
        // On active l'�cran de d�marrage
        ecranDemarrage.SetActive(true);
        // On d�sactive l'�cran de s�lection des niveaux
        ecranSelectionNiveau.SetActive(false);
        // On d�sactive l'�cran de la boutique
        ecranBoutique.SetActive(false);
    }

    // On r�cup�re la liste des objets � rendre transparents
    private void ListeDesObjetsARendreTransparentOuNon()
    {
        RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

        // Cette fonction nous permet de r�cup�rer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherches(ecranDemarrage, 1.0f, listeDesImagesDemarrage, listeDesTextesDemarrage);
        recherchesEcranDemarrage.BouclesRecherches(ecranSelectionNiveau, 0.0f, listeDesImagesSelectionNiveau, listeDesTextesSelectionNiveau);
        recherchesEcranDemarrage.BouclesRecherches(ecranBoutique, 0.0f, listeDesImagesBoutique, listeDesTextesBoutique);
    }

    // On r�cup�re la liste des boutons � rendre interagible ou non
    private void ListeDesBoutonsARendreInteragibleOuNon()
    {
        RecherchesBoutons recherchesEcranDemarrage = new RecherchesBoutons();

        // Cette fonction nous permet de r�cup�rer tout objet avec un composant bouton pour en influencer l'interaction, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherches(ecranDemarrage, listeDesBoutonsDemarrage, true);
        recherchesEcranDemarrage.BouclesRecherches(ecranSelectionNiveau, listeDesBoutonsSelectionNiveau, false);
        recherchesEcranDemarrage.BouclesRecherches(ecranBoutique, listeDesBoutonsBoutique, false);
    }

    private void Start()
    {
        DesactiverLesEcrans();

        // V�rifie qu'un component Button est pr�sent sur l'objet
        // Si c'est le cas, alors on peut ajouter un �v�nement sur le bouton
        if (TryGetComponent<Button>(out Button _button))
        {
            _button.onClick.AddListener(Cliquer);
        }

        ListeDesObjetsARendreTransparentOuNon();
        ListeDesBoutonsARendreInteragibleOuNon();
    }

    // La fonction ajout�e en tant qu'�v�nement sur le bouton
    public override void Cliquer()
    {
        boutonActif = true;
    }

    private void Update()
    {
        Demarrage();
    }

    // Fonction permettant d'acc�der � l'�cran de s�lection des niveaux
    private void Demarrage()
    {
        if (boutonActif)
        {
            if (listeDesBoutonsDemarrage.Count > 0)
            {
                for (int i = 0; i < listeDesBoutonsDemarrage.Count; ++i)
                {
                    listeDesBoutonsDemarrage[i].interactable = false;
                }
            }

            if (tempsDeTransition < 1)
            {
                ecranDemarrage.SetActive(true);
                ecranSelectionNiveau.SetActive(true);

                tempsDeTransition += 0.00025f;

                RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

                // Permet de changer la transparence alpha des objets pr�sents dans les �crans
                recherchesEcranDemarrage.ReglageTransparence(listeDesImagesDemarrage, listeDesImagesSelectionNiveau, listeDesTextesDemarrage, listeDesTextesSelectionNiveau, ecranDemarrage, ecranSelectionNiveau, tempsDeTransition, boutonActif);
            }
        }

        if (listeDesImagesDemarrage[0].color.a <= 0)
        {
            if (listeDesBoutonsSelectionNiveau.Count > 0)
            {
                for (int i = 0; i < listeDesBoutonsSelectionNiveau.Count; ++i)
                {
                    listeDesBoutonsSelectionNiveau[i].interactable = true;
                }
            }

            tempsDeTransition = 0;
            boutonActif = false;
        }
    }
}
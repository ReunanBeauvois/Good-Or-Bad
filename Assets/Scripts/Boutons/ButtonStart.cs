using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Recherches;

public class ButtonStart : ButtonBase
{
    // On créé ces variables pour :
    // 1 - Activer l'écran de sélection des niveaux
    // 2 - Lancer la transparence alpha permettant de faire une transition propre
    // 3 - Désactiver l'écran de démarrage une fois la transition entre les deux écrans effectuées
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
        // On active l'écran de démarrage
        ecranDemarrage.SetActive(true);
        // On désactive l'écran de sélection des niveaux
        ecranSelectionNiveau.SetActive(false);
        // On désactive l'écran de la boutique
        ecranBoutique.SetActive(false);
    }

    // On récupére la liste des objets à rendre transparents
    private void ListeDesObjetsARendreTransparentOuNon()
    {
        RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

        // Cette fonction nous permet de récupérer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherches(ecranDemarrage, 1.0f, listeDesImagesDemarrage, listeDesTextesDemarrage);
        recherchesEcranDemarrage.BouclesRecherches(ecranSelectionNiveau, 0.0f, listeDesImagesSelectionNiveau, listeDesTextesSelectionNiveau);
        recherchesEcranDemarrage.BouclesRecherches(ecranBoutique, 0.0f, listeDesImagesBoutique, listeDesTextesBoutique);
    }

    // On récupére la liste des boutons à rendre interagible ou non
    private void ListeDesBoutonsARendreInteragibleOuNon()
    {
        RecherchesBoutons recherchesEcranDemarrage = new RecherchesBoutons();

        // Cette fonction nous permet de récupérer tout objet avec un composant bouton pour en influencer l'interaction, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherches(ecranDemarrage, listeDesBoutonsDemarrage, true);
        recherchesEcranDemarrage.BouclesRecherches(ecranSelectionNiveau, listeDesBoutonsSelectionNiveau, false);
        recherchesEcranDemarrage.BouclesRecherches(ecranBoutique, listeDesBoutonsBoutique, false);
    }

    private void Start()
    {
        DesactiverLesEcrans();

        // Vérifie qu'un component Button est présent sur l'objet
        // Si c'est le cas, alors on peut ajouter un événement sur le bouton
        if (TryGetComponent<Button>(out Button _button))
        {
            _button.onClick.AddListener(Cliquer);
        }

        ListeDesObjetsARendreTransparentOuNon();
        ListeDesBoutonsARendreInteragibleOuNon();
    }

    // La fonction ajoutée en tant qu'événement sur le bouton
    public override void Cliquer()
    {
        boutonActif = true;
    }

    private void Update()
    {
        Demarrage();
    }

    // Fonction permettant d'accéder à l'écran de sélection des niveaux
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

                // Permet de changer la transparence alpha des objets présents dans les écrans
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
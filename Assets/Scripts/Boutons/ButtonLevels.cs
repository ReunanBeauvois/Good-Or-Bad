using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Recherches;

public class ButtonLevels : ButtonBase
{
    // On créé ces variables pour :
    // 1 - Activer l'écran de sélection des niveaux
    // 2 - Lancer la transparence alpha permettant de faire une transition propre
    // 3 - Désactiver l'écran de démarrage une fois la transition entre les deux écrans effectuées
    /********************************************************************************************/
    public GameObject ecranPartieTerminee;
    public GameObject ecranSelectionNiveau;

    //[HideInInspector]
    public List<Image> listeDesImagesPartieTerminee;
    //[HideInInspector]
    public List<Image> listeDesImagesSelectionNiveau;

    //[HideInInspector]
    public List<Button> listeDesBoutonsPartieTerminee;
    //[HideInInspector]
    public List<Button> listeDesBoutonsSelectionNiveau;

    //[HideInInspector]
    public List<Text> listeDesTextesPartieTerminee;
    //[HideInInspector]
    public List<Text> listeDesTextesSelectionNiveau;

    private bool boutonActif;
    public float tempsDeTransition;
    /********************************************************************************************/

    // On récupére la liste des objets à rendre transparents
    private void ListeDesObjetsARendreTransparentOuNon()
    {
        RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

        // Cette fonction nous permet de récupérer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherchesSansModifierTransparence(ecranPartieTerminee, listeDesImagesPartieTerminee, listeDesTextesPartieTerminee);
        recherchesEcranDemarrage.BouclesRecherchesSansModifierTransparence(ecranSelectionNiveau, listeDesImagesSelectionNiveau, listeDesTextesSelectionNiveau);
    }

    // On récupére la liste des boutons à rendre interagible ou non
    private void ListeDesBoutonsARendreInteragibleOuNon()
    {
        RecherchesBoutons recherchesEcranDemarrage = new RecherchesBoutons();

        // Cette fonction nous permet de récupérer tout objet avec un composant bouton pour en influencer l'interaction, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherchesSansEtat(ecranPartieTerminee, listeDesBoutonsPartieTerminee);
        recherchesEcranDemarrage.BouclesRecherchesSansEtat(ecranSelectionNiveau, listeDesBoutonsSelectionNiveau);
    }

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        AccesEcranNiveaux();
    }

    // Fonction permettant d'accéder à l'écran de la boutique
    private void AccesEcranNiveaux()
    {
        if (boutonActif)
        {
            if (listeDesBoutonsPartieTerminee.Count > 0)
            {
                for (int i = 0; i < listeDesBoutonsPartieTerminee.Count; ++i)
                {
                    listeDesBoutonsPartieTerminee[i].interactable = false;
                }
            }

            if (tempsDeTransition < 1)
            {
                ecranPartieTerminee.SetActive(true);
                ecranSelectionNiveau.SetActive(true);

                tempsDeTransition += 0.00005f;

                RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

                // Permet de changer la transparence alpha des objets présents dans les écrans
                recherchesEcranDemarrage.ReglageTransparence(listeDesImagesPartieTerminee, listeDesImagesSelectionNiveau, listeDesTextesPartieTerminee, listeDesTextesSelectionNiveau, ecranPartieTerminee, ecranSelectionNiveau, tempsDeTransition, boutonActif);
            }
        }

        if (listeDesImagesPartieTerminee[0].color.a <= 0)
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

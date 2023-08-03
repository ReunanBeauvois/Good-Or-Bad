using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Recherches;

public class ButtonShop : ButtonBase
{
    // On cr�� ces variables pour :
    // 1 - Activer l'�cran de s�lection des niveaux
    // 2 - Lancer la transparence alpha permettant de faire une transition propre
    // 3 - D�sactiver l'�cran de d�marrage une fois la transition entre les deux �crans effectu�es
    /********************************************************************************************/
    public GameObject ecranSelectionNiveau;
    public GameObject ecranBoutique;

    [HideInInspector]
    public List<Image> listeDesImagesSelectionNiveau;
    [HideInInspector]
    public List<Image> listeDesImagesBoutique;

    [HideInInspector]
    public List<Button> listeDesBoutonsSelectionNiveau;
    [HideInInspector]
    public List<Button> listeDesBoutonsBoutique;

    [HideInInspector]
    public List<Text> listeDesTextesSelectionNiveau;
    [HideInInspector]
    public List<Text> listeDesTextesBoutique;

    private bool boutonActif;
    public float tempsDeTransition;
    /********************************************************************************************/

    // On r�cup�re la liste des objets � rendre transparents
    private void ListeDesObjetsARendreTransparentOuNon()
    {
        RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

        // Cette fonction nous permet de r�cup�rer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherchesSansModifierTransparence(ecranSelectionNiveau, listeDesImagesSelectionNiveau, listeDesTextesSelectionNiveau);
        recherchesEcranDemarrage.BouclesRecherchesSansModifierTransparence(ecranBoutique, listeDesImagesBoutique, listeDesTextesBoutique);
    }

    // On r�cup�re la liste des boutons � rendre interagible ou non
    private void ListeDesBoutonsARendreInteragibleOuNon()
    {
        RecherchesBoutons recherchesEcranDemarrage = new RecherchesBoutons();

        // Cette fonction nous permet de r�cup�rer tout objet avec un composant bouton pour en influencer l'interaction, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherchesSansEtat(ecranSelectionNiveau, listeDesBoutonsSelectionNiveau);
        recherchesEcranDemarrage.BouclesRecherchesSansEtat(ecranBoutique, listeDesBoutonsBoutique);
    }

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        AccesBoutique();
    }

    // Fonction permettant d'acc�der � l'�cran de la boutique
    private void AccesBoutique()
    {
        if (boutonActif)
        {
            if (listeDesBoutonsSelectionNiveau.Count > 0)
            {
                for (int i = 0; i < listeDesBoutonsSelectionNiveau.Count; ++i)
                {
                    listeDesBoutonsSelectionNiveau[i].interactable = false;
                }
            }

            if (tempsDeTransition < 1)
            {
                ecranSelectionNiveau.SetActive(true);
                ecranBoutique.SetActive(true);

                tempsDeTransition += 0.00005f;

                RecherchesTransparence recherchesEcranDemarrage = new RecherchesTransparence();

                // Permet de changer la transparence alpha des objets pr�sents dans les �crans
                recherchesEcranDemarrage.ReglageTransparence(listeDesImagesSelectionNiveau, listeDesImagesBoutique, listeDesTextesSelectionNiveau, listeDesTextesBoutique, ecranSelectionNiveau, ecranBoutique, tempsDeTransition, boutonActif);
            }
        }

        if (listeDesImagesSelectionNiveau[0].color.a <= 0)
        {
            if (listeDesBoutonsBoutique.Count > 0)
            {
                for (int i = 0; i < listeDesBoutonsBoutique.Count; ++i)
                {
                    listeDesBoutonsBoutique[i].interactable = true;
                }
            }

            tempsDeTransition = 0;
            boutonActif = false;
        }
    }
}

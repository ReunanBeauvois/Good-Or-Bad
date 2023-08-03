using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using Recherches;

public class ButtonPlay : ButtonBase
{
    // On créé ces variables pour :
    // 1 - Activer l'écran de sélection des niveaux
    // 2 - Lancer la transparence alpha permettant de faire une transition propre
    // 3 - Désactiver l'écran de démarrage une fois la transition entre les deux écrans effectuées
    /********************************************************************************************/
    public GameObject ecranSelectionNiveau;
    public GameObject conteneurDesBooleensNiveaux;
    public GameObject conteneurDesNiveaux3D;
    public GameObject niveauQuiSeraCharge;
    public GameObject UINiveau;
    public Chronometre chronometreReference;

    [HideInInspector]
    public List<Image> listeDesImagesSelectionNiveau;
    [HideInInspector]
    public List<Image> listeDesImagesEcranDuNiveau;

    [HideInInspector]
    public List<Button> listeDesBoutonsSelectionNiveau;
    [HideInInspector]
    public List<AssocierNiveauBouton> tableauDesBoutonsDesNiveaux;
    [HideInInspector]
    public List<bool> tableauDesBooleensDesNiveaux;

    [HideInInspector]
    public List<Text> listeDesTextesSelectionNiveau;
    [HideInInspector]
    public List<Text> listeDesTextesEcranDuNiveau;

    //[HideInInspector]
    public List<MeshRenderer> listeDesMeshRendererSelectionNiveau;

    public bool boutonActif;
    public bool appelFonctionStart;
    public float tempsDeTransition;

    // On récupére la liste des objets à rendre transparents
    private void ListeDesObjetsARendreTransparentOuNon()
    {
        // Cette fonction nous permet de récupérer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        RecherchesTransparence recherchesEcranNiveau = new RecherchesTransparence();
        recherchesEcranNiveau.BouclesRecherchesSansModifierTransparence(ecranSelectionNiveau, listeDesImagesSelectionNiveau, listeDesTextesSelectionNiveau);
        recherchesEcranNiveau.BouclesRecherches(UINiveau, 0.0f, listeDesImagesEcranDuNiveau, listeDesTextesEcranDuNiveau);
    }

    // On récupére la liste des boutons à rendre interagible ou non
    private void ListeDesBoutonsARendreInteragibleOuNon()
    {
        RecherchesBoutons recherchesEcranNiveau = new RecherchesBoutons();

        // Cette fonction nous permet de récupérer tout objet avec un composant bouton pour en influencer l'interaction, sans intervention humaine
        recherchesEcranNiveau.BouclesRecherchesSansEtat(ecranSelectionNiveau, listeDesBoutonsSelectionNiveau);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (listeDesImagesSelectionNiveau.Count > 0)
        {
            listeDesImagesSelectionNiveau.Clear();
        }
        if (listeDesImagesEcranDuNiveau.Count > 0)
        {
            listeDesImagesEcranDuNiveau.Clear();
        }

        if (listeDesBoutonsSelectionNiveau.Count > 0)
        {
            listeDesBoutonsSelectionNiveau.Clear();
        }
        if (tableauDesBoutonsDesNiveaux.Count > 0)
        {
            tableauDesBoutonsDesNiveaux.Clear();
        }

        if (tableauDesBooleensDesNiveaux.Count > 0)
        {
            tableauDesBooleensDesNiveaux.Clear();
        }

        if (listeDesTextesSelectionNiveau.Count > 0)
        {
            listeDesTextesSelectionNiveau.Clear();
        }
        if (listeDesTextesEcranDuNiveau.Count > 0)
        {
            listeDesTextesEcranDuNiveau.Clear();
        }

        if (listeDesMeshRendererSelectionNiveau.Count > 0)
        {
            listeDesMeshRendererSelectionNiveau.Clear();
        }

        if (conteneurDesBooleensNiveaux.transform.childCount > 0)
        {
            for (int i = 0; i < conteneurDesBooleensNiveaux.transform.childCount; ++i)
            {
                tableauDesBoutonsDesNiveaux.Add(conteneurDesBooleensNiveaux.transform.GetChild(i).transform.GetComponent<AssocierNiveauBouton>());
                tableauDesBooleensDesNiveaux.Add(conteneurDesBooleensNiveaux.transform.GetChild(i).transform.GetComponent<AssocierNiveauBouton>().estSelectionne);
            }
        }

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
        if (!appelFonctionStart)
        {
            Start();
            appelFonctionStart = true;
        }

        if (conteneurDesBooleensNiveaux.transform.childCount > 0)
        {
            for (int i = 0; i < tableauDesBoutonsDesNiveaux.Count; ++i)
            {
                tableauDesBooleensDesNiveaux[i] = tableauDesBoutonsDesNiveaux[i].estSelectionne;
            }
        }

        if (conteneurDesBooleensNiveaux.transform.childCount > 0 && !boutonActif)
        {
            for (int i = 0; i < tableauDesBoutonsDesNiveaux.Count; ++i)
            {
                if (tableauDesBooleensDesNiveaux[i] == true)
                {
                    niveauQuiSeraCharge = conteneurDesNiveaux3D.transform.GetChild(i).gameObject;
                    niveauQuiSeraCharge.SetActive(true);

                    if (chronometreReference != null)
                    {
                        chronometreReference.startingTimer = listeDesBoutonsSelectionNiveau[i + 2].GetComponent<LevelParameters>().timerValueToStartFrom;
                    }
                }
                if (tableauDesBooleensDesNiveaux[i] == false)
                {
                    conteneurDesNiveaux3D.transform.GetChild(i).gameObject.SetActive(false);
                }
                if (niveauQuiSeraCharge != null && niveauQuiSeraCharge.activeSelf)
                {
                    RecherchesMeshRenderer recherchesNiveauMesh = new RecherchesMeshRenderer();
                    recherchesNiveauMesh.BouclesRecherches(niveauQuiSeraCharge, listeDesMeshRendererSelectionNiveau, 0.0f);
                    listeDesMeshRendererSelectionNiveau = listeDesMeshRendererSelectionNiveau.Distinct().ToList();
                }
            }
        }

        AccessLevel();
    }

    // Fonction permettant d'accéder à l'écran de la boutique
    private void AccessLevel()
    {
        if (boutonActif)
        {
            if (niveauQuiSeraCharge == null)
            {
                conteneurDesNiveaux3D.transform.GetChild(0).gameObject.SetActive(true);
                niveauQuiSeraCharge = conteneurDesNiveaux3D.transform.GetChild(0).gameObject;

                RecherchesMeshRenderer recherchesNiveauMesh = new RecherchesMeshRenderer();
                recherchesNiveauMesh.BouclesRecherches(niveauQuiSeraCharge, listeDesMeshRendererSelectionNiveau, 0.0f);
                listeDesMeshRendererSelectionNiveau = listeDesMeshRendererSelectionNiveau.Distinct().ToList();
            }
            if (niveauQuiSeraCharge != null)
            {
                niveauQuiSeraCharge.SetActive(true);
            }

            if (tempsDeTransition < 1)
            {
                ecranSelectionNiveau.SetActive(true);
                UINiveau.SetActive(true);

                tempsDeTransition += 0.00035f;

                // Permet de changer la transparence alpha des objets présents dans les écrans
                RecherchesTransparence recherchesEcranNiveau = new RecherchesTransparence();

                recherchesEcranNiveau.ReglageTransparence(listeDesImagesSelectionNiveau, listeDesImagesEcranDuNiveau, listeDesTextesSelectionNiveau, listeDesTextesEcranDuNiveau, ecranSelectionNiveau, UINiveau, tempsDeTransition, boutonActif);

                RecherchesMeshRenderer recherchesMeshRendererNiveaux = new RecherchesMeshRenderer();
                recherchesMeshRendererNiveaux.ReglageTransparenceMeshRendererNiveaux(listeDesMeshRendererSelectionNiveau, tempsDeTransition);
            }
        }

        if (listeDesImagesSelectionNiveau[0].color.a <= 0)
        {
            if (listeDesBoutonsSelectionNiveau.Count > 0)
            {
                for (int i = 0; i < listeDesBoutonsSelectionNiveau.Count; ++i)
                {
                    listeDesBoutonsSelectionNiveau[i].interactable = false;
                }
            }

            boutonActif = false;
            appelFonctionStart = false;
            tempsDeTransition = 0;
        }
    }
}

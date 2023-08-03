using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using Recherches;

public class GameOver : MonoBehaviour
{
    // On créé ces variables pour :
    // 1 - Activer l'écran de sélection des niveaux
    // 2 - Lancer la transparence alpha permettant de faire une transition propre
    // 3 - Désactiver l'écran de démarrage une fois la transition entre les deux écrans effectuées
    /********************************************************************************************/
    public GameObject currentLevel;
    public GameObject ecranDesNiveaux;
    public GameObject ecranPartieTerminee;

    public ButtonPlay _play;
    public Chronometre _chrono;

    [HideInInspector]
    public List<Image> listeDesImagesEcranNiveaux;
    [HideInInspector]
    public List<Image> listeDesImagesPartieTerminee;

    [HideInInspector]
    public List<Button> listeDesBoutonsPartieTerminee;

    [HideInInspector]
    public List<Text> listeDesTextesEcranNiveaux;
    [HideInInspector]
    public List<Text> listeDesTextesPartieTerminee;

    [HideInInspector]
    public List<MeshRenderer> listeDesMeshRendererCurrentLevel;

    [HideInInspector]
    public float tempsDeTransition;
    [HideInInspector]
    public bool boutonActif;
    [HideInInspector]
    public bool lesMeshesSontRecuperes;

    public EnableOneColor oneColorButton;
    public SlowMotion velocityButton;
    public AddTime moreTimeButton;
    public ComboBoost comboBoostButton;
    public ScoreBoost scoreBoostButton;
    public CommunBag communBagButton;
    public Homing homingButton;
    public Vanish vanishButton;

    // On récupére la liste des objets à rendre transparents
    private void ListeDesObjetsARendreTransparentOuNon()
    {
        // Cette fonction nous permet de récupérer tout objet avec un composant Image ou Texte pour en influencer la couleur, sans intervention humaine
        RecherchesTransparence recherchesUINiveau = new RecherchesTransparence();

        recherchesUINiveau.BouclesRecherches(ecranPartieTerminee, 0.0f, listeDesImagesPartieTerminee, listeDesTextesPartieTerminee);
        recherchesUINiveau.BouclesRecherchesSansModifierTransparence(ecranDesNiveaux, listeDesImagesEcranNiveaux, listeDesTextesEcranNiveaux);
    }

    // On récupére la liste des boutons à rendre interagible ou non
    private void ListeDesBoutonsARendreInteragibleOuNon()
    {
        RecherchesBoutons recherchesEcranDemarrage = new RecherchesBoutons();

        // Cette fonction nous permet de récupérer tout objet avec un composant bouton pour en influencer l'interaction, sans intervention humaine
        recherchesEcranDemarrage.BouclesRecherches(ecranPartieTerminee, listeDesBoutonsPartieTerminee, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        ListeDesObjetsARendreTransparentOuNon();
        ListeDesBoutonsARendreInteragibleOuNon();
    }

    // Update is called once per frame
    void Update()
    {
        if (TryGetComponent<Chronometre>(out Chronometre _chrono))
        {
            if (_chrono.timer <= 0 && _chrono.isGameOver)
            {
                oneColorButton.timer = 0;
                velocityButton.timer = 0;
                moreTimeButton.timer = 0;
                comboBoostButton.timer = 0;
                scoreBoostButton.timer = 0;
                communBagButton.timer = 0;
                homingButton.timer = 0;
                vanishButton.timer = 0;

                oneColorButton.cooldown = 0;
                velocityButton.cooldown = 0;
                moreTimeButton.cooldown = 0;
                comboBoostButton.cooldown = 0;
                scoreBoostButton.cooldown = 0;
                communBagButton.cooldown = 0;
                homingButton.cooldown = 0;
                vanishButton.cooldown = 0;

                oneColorButton.oneColorFunctionCalled = false;
                velocityButton.slowMotionFunctionCalled = false;
                moreTimeButton.addTimeFunctionCalled = false;
                comboBoostButton.oneColorFunctionCalled = false;
                scoreBoostButton.oneColorFunctionCalled = false;
                communBagButton.communBagFunctionCalled = false;
                homingButton.homingFunctionCalled = false;
                vanishButton.vanishFunctionCalled = false;

                var effacerObjet = FindObjectsOfType<RigibodyManager>();

                if (effacerObjet.Length > 0)
                {
                    for (int i = 0; i < effacerObjet.Length; ++i)
                    {
                        Destroy(effacerObjet[i].gameObject);
                    }
                }

                boutonActif = true;
                AffcherEcranFinPartie();
            }
        }

        if (_play.niveauQuiSeraCharge != null)
        {
            currentLevel = _play.niveauQuiSeraCharge;
        }

        // Cette fonction nous permet de récupérer tout objet avec un composant MeshRenderer, sans intervention humaine
        RecherchesMeshRenderer recherchesMeshesNiveaux = new RecherchesMeshRenderer();

        if (currentLevel != null && GetComponent<Chronometre>().isGameOver && !lesMeshesSontRecuperes)
        {
            recherchesMeshesNiveaux.BouclesRecherchesSansInfluencerLaTransparence(currentLevel, listeDesMeshRendererCurrentLevel);
            listeDesMeshRendererCurrentLevel = listeDesMeshRendererCurrentLevel.Distinct().ToList();
            lesMeshesSontRecuperes = true;
        }
    }

    // Fonction permettant d'accéder à l'écran de la boutique
    private void AffcherEcranFinPartie()
    {
        if (lesMeshesSontRecuperes)
        {
            if (tempsDeTransition < 1)
            {
                ecranPartieTerminee.SetActive(true);

                tempsDeTransition += 0.00015f;

                RecherchesMeshRenderer meshesNiveauActuel = new RecherchesMeshRenderer();
                meshesNiveauActuel.ReglageTransparenceMeshRendererNiveaux(listeDesMeshRendererCurrentLevel, -tempsDeTransition);

                RecherchesTransparence transparenceNiveauActuel = new RecherchesTransparence();
                transparenceNiveauActuel.ReglageTransparenceUnEcran(listeDesImagesEcranNiveaux, listeDesTextesEcranNiveaux, ecranDesNiveaux, tempsDeTransition, false);
                transparenceNiveauActuel.ReglageTransparenceUnEcran(listeDesImagesPartieTerminee, listeDesTextesPartieTerminee, ecranPartieTerminee, -tempsDeTransition, false);
            }

            if (listeDesImagesEcranNiveaux[0].color.a <= 0)
            {
                if (listeDesBoutonsPartieTerminee.Count > 0)
                {
                    for (int i = 0; i < listeDesBoutonsPartieTerminee.Count; ++i)
                    {
                        listeDesBoutonsPartieTerminee[i].interactable = true;
                    }
                }

                currentLevel.SetActive(false);
                ecranDesNiveaux.SetActive(false);

                _chrono.isGameOver = false;

                tempsDeTransition = 0;
            }
        }
    }
}

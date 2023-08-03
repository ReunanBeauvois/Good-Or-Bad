using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurParties : MonoBehaviour
{
    public float timer;
    public float limitTimer;
    private GameObject _objet;
    private GameObject cube;
    private GameObject sphere;
    private GameObject triangle;
    private GameObject cylindre;

    public Score _score;
    public Chronometre _chrono;

    [HideInInspector]
    public GameObject selectionNiveaux;

    public List<Material> materiaux;

    public Vector3 forceGauche;
    public Vector3 forceDroite;

    [HideInInspector]
    public ButtonPlay _play;
    [HideInInspector]
    public int randomChoice;

    public int diversiteParties = 1;
    public int color;

    public bool colorChanges;
    public bool oneColor;
    public bool specialBag;

    // Start is called before the first frame update
    void Start()
    {
        cube = Resources.Load<GameObject>("Prefabs/Parties/Cube");
        sphere = Resources.Load<GameObject>("Prefabs/Parties/Sphere");
        triangle = Resources.Load<GameObject>("Prefabs/Parties/Triangle1");
        cylindre = Resources.Load<GameObject>("Prefabs/Parties/Cylinder");
        limitTimer = Random.Range(2.0f, 6.0f);
    }

    void ChoixDeLaProchainePartie()
    {
        randomChoice = Random.Range(0, diversiteParties);

        if (randomChoice == 0)
        { _objet = cube; _objet.tag = "Cube"; }
        if (randomChoice == 1)
        { _objet = sphere; _objet.tag = "Sphere"; }
        if (randomChoice == 2)
        { _objet = triangle; _objet.tag = "Triangle"; }
        if (randomChoice == 3)
        { _objet = cylindre; _objet.tag = "Cylindre"; }
    }

    void GenerationPartie()
    {
        var rot = this.transform.localEulerAngles;

        var objet = Instantiate(_objet, transform.localPosition, Quaternion.identity);

        if (objet.TryGetComponent<RigibodyManager>(out RigibodyManager _rigibody))
        {
            _rigibody._score = _score;
        }

        if (materiaux.Count > 0)
        {
            if (!colorChanges && !oneColor)
            {
                color = 0;
            }
            if (colorChanges && !oneColor)
            {
                color = Random.Range(0, materiaux.Count);
            }

            if (!oneColor)
            {
                if (objet.TryGetComponent<MeshRenderer>(out MeshRenderer _mesh)) { _mesh.materials[0].color = materiaux[color].color; }
                if (this.transform.TryGetComponent<MeshRenderer>(out MeshRenderer _mesh2)) { _mesh2.materials[0].color = materiaux[color].color; }
            }

            if (oneColor)
            {
                if (objet.TryGetComponent<MeshRenderer>(out MeshRenderer _mesh)) { _mesh.materials[0].color = Color.red; }
                if (this.transform.TryGetComponent<MeshRenderer>(out MeshRenderer _mesh2)) { _mesh2.materials[0].color = Color.red; }
            }
        }

        objet.transform.LookAt(rot);

        var _vec = new Vector3(objet.transform.localEulerAngles.x * 4, objet.transform.localEulerAngles.y, objet.transform.localEulerAngles.z);

        if (transform.localPosition.x < 0)
        {
            if (objet.transform.TryGetComponent<Rigidbody>(out Rigidbody _r)) { _r.AddForce(forceGauche); }
        }
        if (transform.localPosition.x > 0)
        {
            if (objet.transform.TryGetComponent<Rigidbody>(out Rigidbody _r)) { _r.AddForce(forceDroite); }
        }

        if (_objet == triangle) { objet.transform.localEulerAngles = new Vector3(-90, 0, 0); }
        else { objet.transform.localEulerAngles = Vector3.zero; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_chrono.isGameOver)
        {
            if (!_play.boutonActif && !selectionNiveaux.activeSelf)
            {
                if (timer < limitTimer)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= limitTimer)
                {
                    ChoixDeLaProchainePartie();

                    GenerationPartie();

                    limitTimer = Random.Range(2.0f, 6.0f);

                    timer = 0;
                }
            }
        }
    }
}

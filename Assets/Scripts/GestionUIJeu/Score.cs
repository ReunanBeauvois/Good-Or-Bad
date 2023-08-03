using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Score : MonoBehaviour
{
    public List<RigibodyManager> parties;

    public ButtonPlay _play;

    public GameObject selectionNiveaux;

    public List<Material> materiaux;
    [HideInInspector]
    public GameObject objetDansUnSac;
    [HideInInspector]
    public Collider sac;

    public Chronometre _chrono;

    public int currentScore;
    public int currentCombo;

    public int colorCombo;
    public int shapeCombo;
    public int colorShapeCombo;

    public int comboBoost;
    public int scoreBoost;

    public bool colorComboEnabled;
    public bool shapeComboEnabled;
    public bool colorShapeComboEnabled;

    public bool comboBoostEnabled;
    public bool scoreBoostEnabled;
    public bool scoreForCommunBag;

    // Start is called before the first frame update
    void Start()
    {
        currentCombo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!comboBoostEnabled)
        {
            comboBoost = 1;
        }
        if (comboBoostEnabled)
        {
            comboBoost = 3;
        }

        if (!scoreBoostEnabled)
        {
            scoreBoost = 1;
        }
        if (scoreBoostEnabled)
        {
            scoreBoost = 2;
        }

        if (_chrono.isGameOver)
        {
            if (parties.Count > 0)
            {
                for (int i = 0; i < parties.Count; ++i)
                {
                    Destroy(parties[i].gameObject);

                }
                parties.Clear();
            }
        }
        if (!_chrono.isGameOver)
        {
            if (!_play.boutonActif && !selectionNiveaux.activeSelf)
            {
                parties.Add(FindObjectOfType<RigibodyManager>());

                parties = parties.Distinct().ToList();

                if (parties.Count > 0)
                {
                    if (sac != null && objetDansUnSac != null)
                    {
                        if (scoreForCommunBag)
                        {
                            if (currentCombo < 1) { currentCombo = 1; }
                            if (comboBoost < 1) { comboBoost = 1; }
                            if (scoreBoost < 1) { scoreBoost = 1; }
                            if (colorCombo < 1) { colorCombo = 1; }
                            if (shapeCombo < 1) { shapeCombo = 1; }
                            if (colorShapeCombo < 1) { colorShapeCombo = 1; }
                            currentScore += 500 * comboBoost * scoreBoost * colorCombo * shapeCombo * colorShapeCombo * currentCombo;
                        }
                        if (!scoreForCommunBag)
                        {
                            if (!shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Cube")
                                {
                                    currentCombo += 1;
                                    currentScore += 5 * currentCombo;
                                }
                            }
                            if (shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Cube" && sac.transform.GetChild(0).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    shapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (10 * shapeCombo * scoreBoost * currentCombo);
                                }
                            }
                            if (colorShapeComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Cube" && sac.transform.GetChild(0).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    colorShapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (20 * colorShapeCombo * scoreBoost * currentCombo);
                                }
                            }

                            if (!shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Sphere")
                                {
                                    currentCombo += 1;
                                    currentScore += 10 * currentCombo;
                                }
                            }
                            if (shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Sphere" && sac.transform.GetChild(1).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    shapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (20 * shapeCombo * scoreBoost * currentCombo);
                                }
                            }
                            if (colorShapeComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Sphere" && sac.transform.GetChild(1).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    colorShapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (40 * colorShapeCombo * scoreBoost * currentCombo);
                                }
                            }

                            if (!shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Cylindre")
                                {
                                    currentCombo += 1;
                                    currentScore += 15 * currentCombo;
                                }
                            }
                            if (shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Cylindre" && sac.transform.GetChild(2).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    shapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (30 * shapeCombo * scoreBoost * currentCombo);
                                }
                            }
                            if (colorShapeComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Cylindre" && sac.transform.GetChild(2).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    colorShapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (60 * colorShapeCombo * scoreBoost * currentCombo);
                                }
                            }

                            if (!shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Triangle")
                                {
                                    currentCombo += 1;
                                    currentScore += 20 * currentCombo;
                                }
                            }
                            if (shapeComboEnabled && !colorComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Triangle" && sac.transform.GetChild(3).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    shapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (40 * shapeCombo * scoreBoost * currentCombo);
                                }
                            }
                            if (colorShapeComboEnabled)
                            {
                                if (objetDansUnSac.tag == "Triangle" && sac.transform.GetChild(3).transform.gameObject.activeSelf)
                                {
                                    currentCombo += 1;
                                    colorShapeCombo += (1 * comboBoost * currentCombo);
                                    currentScore += (80 * colorShapeCombo * scoreBoost * currentCombo);
                                }
                            }

                            if (objetDansUnSac.tag == "Cube" && !sac.transform.GetChild(0).transform.gameObject.activeSelf)
                            {
                                if (shapeComboEnabled && !colorComboEnabled)
                                { currentScore -= 40; shapeCombo = 1; currentCombo = 1; }
                                if (colorShapeComboEnabled)
                                { currentScore -= 80; shapeCombo = 1; currentCombo = 1; }
                            }
                            if (objetDansUnSac.tag == "Sphere" && !sac.transform.GetChild(1).transform.gameObject.activeSelf)
                            {
                                if (shapeComboEnabled && !colorComboEnabled)
                                { currentScore -= 40; shapeCombo = 1; currentCombo = 1; }
                                if (colorShapeComboEnabled)
                                { currentScore -= 80; shapeCombo = 1; currentCombo = 1; }
                            }
                            if (objetDansUnSac.tag == "Cylindre" && !sac.transform.GetChild(2).transform.gameObject.activeSelf)
                            {
                                if (shapeComboEnabled && !colorComboEnabled)
                                { currentScore -= 40; shapeCombo = 1; currentCombo = 1; }
                                if (colorShapeComboEnabled)
                                { currentScore -= 80; shapeCombo = 1; currentCombo = 1; }
                            }
                            if (objetDansUnSac.tag == "Triangle" && !sac.transform.GetChild(3).transform.gameObject.activeSelf)
                            {
                                if (shapeComboEnabled && !colorComboEnabled)
                                { currentScore -= 40; shapeCombo = 1; currentCombo = 1; }
                                if (colorShapeComboEnabled)
                                { currentScore -= 80; shapeCombo = 1; currentCombo = 1; }
                            }


                            if (sac.transform.TryGetComponent<MeshRenderer>(out MeshRenderer _meshSac) && objetDansUnSac.TryGetComponent<MeshRenderer>(out MeshRenderer _meshObjet))
                            {
                                if (_meshSac.materials[0].color == _meshObjet.materials[0].color)
                                {
                                    if (materiaux.Count > 0)
                                    {
                                        if (_meshObjet.materials[0].color == materiaux[0].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 15 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (30 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (45 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[1].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 22 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (44 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (66 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[2].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 10 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (20 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (30 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[3].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 05 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (10 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (15 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[4].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 18 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (36 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (54 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[5].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 20 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (40 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (60 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[6].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 30 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (60 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (90 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[7].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 42 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (84 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (126 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[8].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 50 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (100 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (150 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[9].color)
                                        {
                                            currentCombo += 1;
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore += 75 * scoreBoost * currentCombo; }
                                            if (!shapeComboEnabled && colorComboEnabled) { colorCombo += (1 * comboBoost); currentScore += (150 * colorCombo * scoreBoost * currentCombo); }
                                            if (colorShapeComboEnabled) { colorShapeCombo += (1 * comboBoost); currentScore += (225 * colorShapeCombo * scoreBoost * currentCombo); }
                                        }
                                    }
                                    Destroy(objetDansUnSac);
                                }
                                if (_meshSac.materials[0].color != _meshObjet.materials[0].color)
                                {
                                    currentCombo = 1;
                                    if (materiaux.Count > 0)
                                    {
                                        if (_meshObjet.materials[0].color == materiaux[0].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 10; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 20; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 30; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[1].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 20; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 40; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 60; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[2].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 07; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 14; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 21; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[3].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 04; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 08; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 12; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[4].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 16; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 32; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 48; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[5].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 15; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 30; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 45; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[6].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 22; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 44; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 66; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[7].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 30; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 60; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 90; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[8].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 30; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 60; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 90; colorShapeCombo = 1; }
                                        }

                                        if (_meshObjet.materials[0].color == materiaux[9].color)
                                        {
                                            if (!shapeComboEnabled && !colorComboEnabled) { currentScore -= 60; }
                                            if (!shapeComboEnabled && colorComboEnabled) { currentScore -= 120; colorCombo = 1; }
                                            if (colorShapeComboEnabled) { currentScore -= 180; colorShapeCombo = 1; }
                                        }
                                    }
                                    Destroy(objetDansUnSac);
                                }
                            }
                        }
                    }

                    for (int i = 0; i < parties.Count; ++i)
                    {
                        if (parties[i] == null)
                        {
                            parties.RemoveAt(i);
                        }
                    }
                }
            }

            if (TryGetComponent<Text>(out Text _text))
            {
                if (currentScore <= 0)
                {
                    currentScore = 0;
                    _text.text = "Score : 000000";
                }
                if (currentScore > 0 && currentScore < 10)
                {
                    _text.text = "Score : 00000" + currentScore;
                }
                if (currentScore >= 10 && currentScore < 100)
                {
                    _text.text = "Score : 0000" + currentScore;
                }
                if (currentScore >= 100 && currentScore < 1000)
                {
                    _text.text = "Score : 000" + currentScore;
                }
                if (currentScore >= 1000 && currentScore < 10000)
                {
                    _text.text = "Score : 00" + currentScore;
                }
                if (currentScore >= 10000 && currentScore < 100000)
                {
                    _text.text = "Score : 0" + currentScore;
                }
                if (currentScore >= 100000 && currentScore < 1000000)
                {
                    _text.text = "Score : " + currentScore;
                }
                if (currentScore >= 1000000)
                {
                    currentScore = 999999;
                    _text.text = "Score : 999999";
                }
            }
        }
    }
}

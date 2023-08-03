using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quete
{
    public int indexNiveau;
    public string queteTexte1;
    public bool quete1Resolue;
    public string queteTexte2;
    public bool quete2Resolue;
    public string queteTexte3;
    public bool quete3Resolue;
}

public class QuetesNiveaux : MonoBehaviour
{
    public ButtonPlay playReference;
    public GameObject contenuNiveaux;
    public GameObject contenuNiveaux3D;
    public List<Quete> listeQuetes;
    public Score scoreReference;
    public Gold goldReference;
    public Level levelReference;
    public Text defi1;
    public Text defi2;
    public Text defi3;

    public EnableOneColor oneColorReference;
    public SlowMotion slowMotionReference;
    public AddTime timeReference;
    public ComboBoost comboBoostReference;
    public ScoreBoost scoreBoostReference;
    public CommunBag communBagReference;
    public Homing homingReference;
    public Vanish vanishReference;

    public NewColors newColorsReference;
    public BoosterState booster2;
    public BoosterState booster3;
    public BoosterState booster4;
    public BoosterState booster5;
    public BoosterState booster6;
    public BoosterState booster7;
    public BoosterState booster8;
    public BoosterState booster9;
    public BoosterState booster10;
    public BoosterState booster11;
    public BoosterState booster12;
    public BoosterState booster13;
    public BoosterState booster14;

    public Text messageFinPartie;
    public Image emoji;
    public Sprite happySmiley;
    public Sprite sadSmiley;
    public Sprite neutralSmiley;

    void CouleurTexte(int indexNiveau, int indexEtoile)
    {
        if (playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(indexNiveau).gameObject)
        {
            var color = contenuNiveaux.transform.GetChild(indexNiveau).transform.GetChild(indexEtoile).gameObject.transform.GetComponent<Image>().color;
            color.r = 1; color.g = 1; color.b = 1;
            contenuNiveaux.transform.GetChild(indexNiveau).transform.GetChild(indexEtoile).gameObject.transform.GetComponent<Image>().color = color;
        }
        if (defi1 != null)
        {
            var color = defi1.color;
            color.r = 0; color.g = 1; color.b = 0;
            defi1.color = color;
        }
    }

    void Textes(int i)
    {
        if (defi1 != null)
        { defi1.text = listeQuetes[i].queteTexte1; }
        if (defi2 != null)
        { defi2.text = listeQuetes[i].queteTexte2; }
        if (defi3 != null)
        { defi3.text = listeQuetes[i].queteTexte3; }
    }

    void Quetes12(int i, int niveau, int score, int level, int goldGain1, int goldGain2)
    {
        if (!listeQuetes[i].quete1Resolue)
        {
            if (scoreReference.currentScore >= score)
            {
                goldReference.gold += goldGain1;
                listeQuetes[i].quete1Resolue = true;

                CouleurTexte(niveau, 1);
            }
        }
        if (!listeQuetes[i].quete2Resolue)
        {
            if (levelReference.levelMemory >= level)
            {
                goldReference.gold += goldGain2;
                listeQuetes[i].quete2Resolue = true;

                CouleurTexte(niveau, 2);
            }
        }
    }

    void Message(int i)
    {
        if (listeQuetes[i].quete1Resolue && listeQuetes[i].quete2Resolue && listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "VICTORY";
            emoji.sprite = happySmiley;
        }
        if (!listeQuetes[i].quete1Resolue && !listeQuetes[i].quete2Resolue && !listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "DEFEAT";
            emoji.sprite = sadSmiley;
        }
        if (listeQuetes[i].quete1Resolue && !listeQuetes[i].quete2Resolue && !listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "RESULTS";
            emoji.sprite = neutralSmiley;
        }
        if (!listeQuetes[i].quete1Resolue && listeQuetes[i].quete2Resolue && !listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "RESULTS";
            emoji.sprite = neutralSmiley;
        }
        if (!listeQuetes[i].quete1Resolue && !listeQuetes[i].quete2Resolue && listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "RESULTS";
            emoji.sprite = neutralSmiley;
        }
        if (listeQuetes[i].quete1Resolue && listeQuetes[i].quete2Resolue && !listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "RESULTS";
            emoji.sprite = neutralSmiley;
        }
        if (listeQuetes[i].quete1Resolue && !listeQuetes[i].quete2Resolue && listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "RESULTS";
            emoji.sprite = neutralSmiley;
        }
        if (!listeQuetes[i].quete1Resolue && listeQuetes[i].quete2Resolue && listeQuetes[i].quete3Resolue)
        {
            messageFinPartie.text = "RESULTS";
            emoji.sprite = neutralSmiley;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (listeQuetes.Count > 0 && scoreReference != null && goldReference != null && levelReference != null)
        {
            for (int i = 0; i < listeQuetes.Count; ++i)
            {
                if (listeQuetes[i].indexNiveau == 0 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(0).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(0).gameObject.activeSelf)
                    {
                        Quetes12(i, 0, 500, 5, 10, 20);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (scoreReference.currentCombo >= 5)
                            {
                                goldReference.gold += 30;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(0, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 1 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(1).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(1).gameObject.activeSelf)
                    {
                        Quetes12(i, 1, 1500, 15, 20, 40);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (scoreReference.currentCombo >= 10)
                            {
                                goldReference.gold += 60;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(1, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 2 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(2).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(2).gameObject.activeSelf)
                    {
                        Quetes12(i, 2, 2000, 20, 30, 60);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (scoreReference.currentCombo >= 15)
                            {
                                goldReference.gold += 90;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(2, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 3 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(3).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(3).gameObject.activeSelf)
                    {
                        Quetes12(i, 3, 3000, 30, 40, 80);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (oneColorReference.oneColorFunctionCalled)
                            {
                                goldReference.gold += 120;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(3, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 4 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(4).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(4).gameObject.activeSelf)
                    {
                        Quetes12(i, 4, 4500, 45, 50, 100);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (slowMotionReference.slowMotionFunctionCalled)
                            {
                                goldReference.gold += 150;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(4, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 5 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(5).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(5).gameObject.activeSelf)
                    {
                        Quetes12(i, 5, 5000, 60, 60, 120);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (timeReference.addTimeFunctionCalled)
                            {
                                goldReference.gold += 180;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(5, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 6 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(6).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(6).gameObject.activeSelf)
                    {
                        Quetes12(i, 6, 7500, 70, 70, 140);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (comboBoostReference.oneColorFunctionCalled)
                            {
                                goldReference.gold += 210;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(6, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 7 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(7).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(7).gameObject.activeSelf)
                    {
                        Quetes12(i, 7, 8500, 80, 80, 160);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (scoreBoostReference.oneColorFunctionCalled)
                            {
                                goldReference.gold += 240;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(7, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 8 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(8).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(8).gameObject.activeSelf)
                    {
                        Quetes12(i, 8, 10000, 100, 90, 180);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (communBagReference.communBagFunctionCalled)
                            {
                                goldReference.gold += 270;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(8, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 9 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(9).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(9).gameObject.activeSelf)
                    {
                        Quetes12(i, 9, 12000, 120, 100, 200);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (homingReference.homingFunctionCalled)
                            {
                                goldReference.gold += 300;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(9, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 10 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(10).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(10).gameObject.activeSelf)
                    {
                        Quetes12(i, 10, 15000, 150, 110, 220);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (vanishReference.vanishFunctionCalled)
                            {
                                goldReference.gold += 330;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(10, 3);
                            }
                        }
                        Message(i);
                    }
                }
                if (listeQuetes[i].indexNiveau == 11 && playReference.niveauQuiSeraCharge == contenuNiveaux3D.transform.GetChild(11).gameObject)
                {
                    Textes(i);

                    if (!contenuNiveaux3D.transform.GetChild(11).gameObject.activeSelf)
                    {
                        Quetes12(i, 11, 20000, 200, 120, 240);

                        if (!listeQuetes[i].quete3Resolue)
                        {
                            if (timeReference.addTimeFunctionCalled)
                            {
                                goldReference.gold += 360;
                                listeQuetes[i].quete3Resolue = true;

                                CouleurTexte(11, 3);
                            }
                        }
                        Message(i);
                    }
                }
            }
        }
    }
}

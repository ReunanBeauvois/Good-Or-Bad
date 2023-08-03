using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.EventSystems;

public class ButtonBuy : MonoBehaviour, IPointerDownHandler
{
    public GameObject conteneurBoosters;
    [HideInInspector]
    public BuyBoosters[] etatBoutonsBoosters;
    [HideInInspector]
    public List<BuyBoosters> _etatBoutonsBoosters;
    public List<BuyBoosters> _etatBoutonsBoosters2;

    public NewColors newColors;

    public bool estSelectionne;

    public Button oneColorButton;
    public Button velocityButton;
    public Button timeButton;
    public SpecialBags specialBags;
    public Score _scoreReference;
    public Button comboBoostButton;
    public Button scoreBoostButton;
    public Button oneBagButton;
    public Button homingButton;
    public Button vanishButton;

    public Gold _gold;
    public AfficheGold _afficheGold1, _afficheGold2, _afficheGold3;

    // Start is called before the first frame update
    void Start()
    {
        etatBoutonsBoosters = FindObjectsOfType<BuyBoosters>();

        if (etatBoutonsBoosters.Length > 0)
        {
            for (int i = 0; i < etatBoutonsBoosters.Length; ++i)
            {
                _etatBoutonsBoosters.Add(etatBoutonsBoosters[i]);
                _etatBoutonsBoosters = _etatBoutonsBoosters.Distinct().ToList();
                _etatBoutonsBoosters2.Add(null);
            }
        }

        if (conteneurBoosters != null)
        {
            if (conteneurBoosters.transform.childCount == _etatBoutonsBoosters.Count)
            {
                for (int i = 0; i < conteneurBoosters.transform.childCount; ++i)
                {
                    for (int j = 0; j < _etatBoutonsBoosters.Count; ++j)
                    {
                        if (conteneurBoosters.transform.GetChild(i).gameObject == _etatBoutonsBoosters[j].gameObject)
                        {
                            _etatBoutonsBoosters2[i] = _etatBoutonsBoosters[j];
                        }
                    }
                }
            }
        }
    }

    public void GoldDisplay(GameObject objet, int gold)
    {
        if (objet.TryGetComponent<Text>(out Text _text))
        {
            if (_text != null)
            {
                if (gold <= 0)
                { gold = 0; _text.text = "0000000"; }
                if (gold > 0 && gold < 10)
                { _text.text = "000000" + gold; }
                if (gold >= 10 && gold < 100)
                { _text.text = "00000" + gold; }
                if (gold >= 100 && gold < 1000)
                { _text.text = "0000" + gold; }
                if (gold >= 1000 && gold < 10000)
                { _text.text = "000" + gold; }
                if (gold >= 10000 && gold < 100000)
                { _text.text = "00" + gold; }
                if (gold >= 100000 && gold < 1000000)
                { _text.text = "0" + gold; }
                if (gold >= 1000000 && gold <= 9999999)
                { _text.text = "" + gold; }
                if (gold >= 9999999)
                { gold = 9999999; _text.text = "" + gold; }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_etatBoutonsBoosters2.Count > 0)
        {
            for (int i = 0; i < _etatBoutonsBoosters2.Count; ++i)
            {
                if (!estSelectionne)
                {
                    if (newColors.GetComponent<BuyBoosters>().estSelectionne)
                    {
                        if (_etatBoutonsBoosters2[0].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && _etatBoutonsBoosters2[0].gameObject.activeSelf)
                            {
                                if (!_price.onePrice)
                                {
                                    if (_gold.gold > _price.prices[newColors.niveauAchat])
                                    {
                                        _gold.gold = _gold.gold - _price.prices[newColors.niveauAchat];
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GetComponent<Button>().onClick.AddListener(newColors.NewColorsToAdd);

                                        for (int j = 0; j < _etatBoutonsBoosters2.Count; ++j)
                                        {
                                            _etatBoutonsBoosters2[j].estSelectionne = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(1).transform.GetComponent<BuyBoosters>().estSelectionne)
                    {
                        if (_etatBoutonsBoosters2[1].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(1).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        if (newColors != null)
                                        {
                                            if (newColors.chercheObjets)
                                            {
                                                if (newColors.referenceLevel.Count > 0)
                                                {
                                                    for (int k = 0; k < newColors.referenceLevel.Count; ++k)
                                                    {
                                                        for (int l = 0; l < newColors.referenceLevel[k].generateurs.Count; ++l)
                                                        { newColors.referenceLevel[k].generateurs[l].GetComponent<GenerateurParties>().colorChanges = true; }
                                                        for (int l = 0; l < newColors.referenceLevel[k].sacs.Count; ++l)
                                                        { newColors.referenceLevel[k].sacs[l].GetComponent<CouleurSac>().colorChanges = true; }
                                                    }
                                                }
                                            }
                                        }

                                        conteneurBoosters.transform.GetChild(1).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(1).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(2).transform.GetComponent<BuyBoosters>().estSelectionne)
                    {
                        if (_etatBoutonsBoosters2[2].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(2).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        oneColorButton.interactable = true;
                                        oneColorButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(2).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(2).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(3).transform.GetComponent<BuyBoosters>().estSelectionne)
                    {
                        if (_etatBoutonsBoosters2[3].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(3).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        velocityButton.interactable = true;
                                        velocityButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(3).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(3).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(4).transform.GetComponent<BuyBoosters>().estSelectionne)
                    {
                        if (_etatBoutonsBoosters2[4].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(4).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        timeButton.interactable = true;
                                        timeButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(4).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(4).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(5).transform.GetComponent<BuyBoosters>().estSelectionne)
                    {
                        if (_etatBoutonsBoosters2[5].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(5).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        if (specialBags != null)
                                        {
                                            if (specialBags.sacs.Count > 0)
                                            {
                                                for (int j = 0; j < specialBags.sacs.Count; ++j)
                                                {
                                                    if (specialBags.sacs[j].transform.childCount > 0)
                                                    {
                                                        for (int k = 0; k < specialBags.sacs[j].transform.childCount; ++k)
                                                        {
                                                            specialBags.sacs[j].transform.GetChild(k).transform.gameObject.SetActive(true);
                                                            specialBags.sacs[j].GetComponent<CouleurSac>().specialBag = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (newColors != null)
                                        {
                                            if (newColors.chercheObjets)
                                            {
                                                if (newColors.referenceLevel.Count > 0)
                                                {
                                                    for (int k = 0; k < newColors.referenceLevel.Count; ++k)
                                                    {
                                                        for (int l = 0; l < newColors.referenceLevel[k].generateurs.Count; ++l)
                                                        {
                                                            newColors.referenceLevel[k].generateurs[l].GetComponent<GenerateurParties>().diversiteParties = 4;
                                                            newColors.referenceLevel[k].generateurs[l].GetComponent<GenerateurParties>().specialBag = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        conteneurBoosters.transform.GetChild(5).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(5).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(6).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[6].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(6).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        _scoreReference.colorComboEnabled = true;
                                        conteneurBoosters.transform.GetChild(6).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(6).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(7).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[7].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(7).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        _scoreReference.shapeComboEnabled = true;
                                        conteneurBoosters.transform.GetChild(7).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(7).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(8).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[8].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(8).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        _scoreReference.colorShapeComboEnabled = true;
                                        conteneurBoosters.transform.GetChild(8).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(8).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }

                    if (conteneurBoosters.transform.GetChild(9).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[9].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(9).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        comboBoostButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(9).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(9).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(10).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[10].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(10).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        scoreBoostButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(10).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(10).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(11).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[11].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(11).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        oneBagButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(11).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(11).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(12).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[12].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(12).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        homingButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(12).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(12).transform.GetComponent<BoosterState>().boosterAchete = true;
                                    }
                                }
                            }
                        }
                    }
                    if (conteneurBoosters.transform.GetChild(13).transform.GetComponent<BuyBoosters>().estSelectionne && _scoreReference != null)
                    {
                        if (_etatBoutonsBoosters2[13].transform.gameObject.transform.GetChild(1).transform.TryGetComponent<BoosterPrices>(out BoosterPrices _price))
                        {
                            if (_price != null && !conteneurBoosters.transform.GetChild(13).transform.GetComponent<BoosterState>().boosterAchete)
                            {
                                if (_price.onePrice)
                                {
                                    if (_gold.gold > _price.uniquePrice)
                                    {
                                        _gold.gold = _gold.gold - _price.uniquePrice;
                                        _gold.goldMemory = _gold.gold;
                                        _afficheGold1.gold = _gold.gold;
                                        _afficheGold2.gold = _gold.gold;
                                        _afficheGold3.gold = _gold.gold;

                                        GoldDisplay(_gold.transform.gameObject, _gold.gold);
                                        GoldDisplay(_afficheGold1.transform.gameObject, _afficheGold1.gold);
                                        GoldDisplay(_afficheGold2.transform.gameObject, _afficheGold2.gold);
                                        GoldDisplay(_afficheGold3.transform.gameObject, _afficheGold3.gold);

                                        vanishButton.gameObject.SetActive(true);
                                        conteneurBoosters.transform.GetChild(13).transform.GetComponent<Button>().interactable = false;
                                        conteneurBoosters.transform.GetChild(13).transform.GetComponent<BoosterState>().boosterAchete = true;
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

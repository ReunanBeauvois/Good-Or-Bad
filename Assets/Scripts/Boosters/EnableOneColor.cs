using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableOneColor : MonoBehaviour
{
    public Button boutonReference;
    public float timer;
    public float timerLimit;
    public float cooldown;
    public float cooldownLimit;
    public bool oneColorFunctionCalled;
    public NewColors newColorsReference;

    // Update is called once per frame
    void Update()
    {
        if (boutonReference != null)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                var color = transform.GetChild(i).GetComponent<Image>().color;
                color.a = 0.5f;
                transform.GetChild(i).GetComponent<Image>().color = color;
            }

            if (!boutonReference.GetComponent<BoosterState>().boosterAchete)
            {
                GetComponent<Button>().interactable = false;

                for (int i = 0; i < transform.childCount; ++i)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);
                }
            }
            if (boutonReference.GetComponent<BoosterState>().boosterAchete)
            {
                for (int i = 0; i < transform.childCount; ++i)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                GetComponent<Button>().onClick.AddListener(OneColor);
            }
        }

        if (oneColorFunctionCalled)
        {
            if (timer == 0)
            {
                GetComponent<Button>().interactable = true;
                timer += Time.deltaTime;
                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);
                transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);

                if (newColorsReference.referenceLevel.Count > 0)
                {
                    for (int i = 0; i < newColorsReference.referenceLevel.Count; ++i)
                    {
                        for (int j = 0; j < newColorsReference.referenceLevel[i].sacs.Count; ++j)
                        {
                            newColorsReference.referenceLevel[i].sacs[j].GetComponent<CouleurSac>().oneColor = false;
                        }
                        for (int j = 0; j < newColorsReference.referenceLevel[i].generateurs.Count; ++j)
                        {
                            newColorsReference.referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().oneColor = false;
                        }
                    }
                }
            }
            if (timer > 0 && timer < timerLimit)
            {
                if (newColorsReference.referenceLevel.Count > 0)
                {
                    for (int i = 0; i < newColorsReference.referenceLevel.Count; ++i)
                    {
                        for (int j = 0; j < newColorsReference.referenceLevel[i].sacs.Count; ++j)
                        {
                            newColorsReference.referenceLevel[i].sacs[j].GetComponent<CouleurSac>().oneColor = true;
                        }
                        for (int j = 0; j < newColorsReference.referenceLevel[i].generateurs.Count; ++j)
                        {
                            newColorsReference.referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().oneColor = true;
                        }
                    }
                }

                GetComponent<Button>().interactable = false;
                timer += Time.deltaTime;

                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100 - 100 * (timer / timerLimit));
            }
            if (timer >= timerLimit)
            {
                if (newColorsReference.referenceLevel.Count > 0)
                {
                    for (int i = 0; i < newColorsReference.referenceLevel.Count; ++i)
                    {
                        for (int j = 0; j < newColorsReference.referenceLevel[i].sacs.Count; ++j)
                        {
                            newColorsReference.referenceLevel[i].sacs[j].GetComponent<CouleurSac>().oneColor = false;
                        }
                        for (int j = 0; j < newColorsReference.referenceLevel[i].generateurs.Count; ++j)
                        {
                            newColorsReference.referenceLevel[i].generateurs[j].GetComponent<GenerateurParties>().oneColor = false;
                        }
                    }
                }

                GetComponent<Button>().interactable = false;
                timer = timerLimit;

                if (cooldown < cooldownLimit)
                {
                    cooldown += Time.deltaTime;

                    transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100 - 100 * (cooldown / cooldownLimit));
                }
                if (cooldown >= cooldownLimit)
                {
                    GetComponent<Button>().interactable = true;
                    cooldown = 0;
                    timer = 0;
                    oneColorFunctionCalled = false;
                }
            }
        }
    }

    public void OneColor()
    {
        oneColorFunctionCalled = true;
    }
}

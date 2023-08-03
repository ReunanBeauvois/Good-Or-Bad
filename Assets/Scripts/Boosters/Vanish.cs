using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Vanish : MonoBehaviour
{
    public Button boutonReference;
    public GameObject niveauReference;
    public List<GameObject> plateaux;
    public ButtonPlay boutonPlayReference;
    public float timer;
    public float timerLimit;
    public float cooldown;
    public float cooldownLimit;
    public bool vanishFunctionCalled;

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

                GetComponent<Button>().onClick.AddListener(VanishFunction);
            }
        }
        if (vanishFunctionCalled)
        {
            if (timer == 0)
            {
                GetComponent<Button>().interactable = true;
                timer += Time.deltaTime;
                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);
                transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);

                if (boutonPlayReference != null)
                {
                    if (boutonPlayReference.niveauQuiSeraCharge != null)
                    {
                        niveauReference = boutonPlayReference.niveauQuiSeraCharge;
                    }

                    if (niveauReference != null)
                    {
                        if (niveauReference.transform.childCount > 0)
                        {
                            for (int i = 0; i < niveauReference.transform.childCount; ++i)
                            {
                                if (niveauReference.transform.GetChild(i).transform.TryGetComponent<Plates>(out Plates _plates))
                                {
                                    plateaux.Add(_plates.gameObject);
                                }
                            }
                            plateaux = plateaux.Distinct().ToList();
                        }
                    }
                }
            }
            if (timer > 0 && timer < timerLimit)
            {
                if (niveauReference != null)
                {
                    if (plateaux.Count > 0)
                    {
                        for (int i = 0; i < plateaux.Count; ++i)
                        {
                            plateaux[i].SetActive(false);
                        }
                    }
                }

                GetComponent<Button>().interactable = false;
                timer += Time.deltaTime;

                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100 - 100 * (timer / timerLimit));
            }
            if (timer >= timerLimit)
            {
                if (niveauReference != null)
                {
                    if (plateaux.Count > 0)
                    {
                        for (int i = 0; i < plateaux.Count; ++i)
                        {
                            plateaux[i].SetActive(true);
                        }
                    }
                    plateaux.Clear();
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
                    vanishFunctionCalled = false;
                }
            }
        }
    }

    public void VanishFunction()
    {
        vanishFunctionCalled = true;
    }
}

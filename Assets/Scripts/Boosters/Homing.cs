using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Homing : MonoBehaviour
{
    public Button boutonReference;
    public GameObject niveauReference;
    public Score scoreReference;
    public List<GameObject> sacs;
    public ButtonPlay boutonPlayReference;
    public RigibodyManager[] parties;
    [HideInInspector]
    public List<GameObject> cibles;
    [HideInInspector]
    public List<bool> aUneCible;
    public List<float> voyageAToB;
    public float timer;
    public float timerLimit;
    public float cooldown;
    public float cooldownLimit;
    public float speed;
    public bool homingFunctionCalled;

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

                GetComponent<Button>().onClick.AddListener(HomingFunction);
            }
        }
        if (homingFunctionCalled)
        {
            if (timer == 0)
            {
                GetComponent<Button>().interactable = true;
                timer += Time.deltaTime;
                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);
                transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);
            }
            if (timer > 0 && timer < timerLimit)
            {
                parties = FindObjectsOfType<RigibodyManager>();

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
                                if (niveauReference.transform.GetChild(i).transform.TryGetComponent<CouleurSac>(out CouleurSac _sacs))
                                {
                                    sacs.Add(_sacs.gameObject);
                                }
                            }

                            sacs = sacs.Distinct().ToList();
                        }
                    }

                    if (parties.Length > 0)
                    {
                        for (int i = 0; i < parties.Length; ++i)
                        {
                            if (aUneCible.Count < parties.Length)
                            {
                                aUneCible.Add(false);
                                cibles.Add(null);
                                voyageAToB.Add(0);
                            }
                        }
                    }

                    if (cibles.Count > 0)
                    {
                        for (int i = 0; i < sacs.Count; ++i)
                        {
                            for (int j = 0; j < parties.Length; ++j)
                            {
                                if (sacs[i].GetComponent<CouleurSac>().materiaux[0].color == parties[j].transform.gameObject.GetComponent<MeshRenderer>().materials[0].color && !parties[j]._collision)
                                {
                                    voyageAToB[j] += speed;
                                    parties[j].transform.gameObject.transform.localPosition = Vector3.Lerp
                                        (
                                        parties[j].transform.gameObject.transform.localPosition,
                                        new Vector3(sacs[i].transform.localPosition.x, sacs[i].transform.localPosition.y, parties[j].transform.gameObject.transform.localPosition.z),
                                        voyageAToB[j]
                                        );
                                }
                                else
                                {
                                    if (sacs[i].GetComponent<CouleurSac>().specialBag && !parties[j]._collision)
                                    {
                                        if (parties[j].gameObject.tag == "Cube" && sacs[i].GetComponent<CouleurSac>().indexShape == 0)
                                        {
                                            if (sacs[i].transform.GetChild(sacs[i].GetComponent<CouleurSac>().indexShape).gameObject.activeSelf)
                                            {
                                                voyageAToB[j] += speed;
                                                parties[j].transform.gameObject.transform.localPosition = Vector3.Lerp
                                                    (
                                                    parties[j].transform.gameObject.transform.localPosition,
                                                    new Vector3(sacs[i].transform.localPosition.x, sacs[i].transform.localPosition.y, parties[j].transform.gameObject.transform.localPosition.z),
                                                    voyageAToB[j]
                                                    );
                                            }
                                        }
                                        if (parties[j].gameObject.tag == "Sphere" && sacs[i].GetComponent<CouleurSac>().indexShape == 1)
                                        {
                                            if (sacs[i].transform.GetChild(sacs[i].GetComponent<CouleurSac>().indexShape).gameObject.activeSelf)
                                            {
                                                voyageAToB[j] += speed;
                                                parties[j].transform.gameObject.transform.localPosition = Vector3.Lerp
                                                    (
                                                    parties[j].transform.gameObject.transform.localPosition,
                                                    new Vector3(sacs[i].transform.localPosition.x, sacs[i].transform.localPosition.y, parties[j].transform.gameObject.transform.localPosition.z),
                                                    voyageAToB[j]
                                                    );
                                            }
                                        }
                                        if (parties[j].gameObject.tag == "Cylindre" && sacs[i].GetComponent<CouleurSac>().indexShape == 2)
                                        {
                                            if (sacs[i].transform.GetChild(sacs[i].GetComponent<CouleurSac>().indexShape).gameObject.activeSelf)
                                            {
                                                voyageAToB[j] += speed;
                                                parties[j].transform.gameObject.transform.localPosition = Vector3.Lerp
                                                    (
                                                    parties[j].transform.gameObject.transform.localPosition,
                                                    new Vector3(sacs[i].transform.localPosition.x, sacs[i].transform.localPosition.y, parties[j].transform.gameObject.transform.localPosition.z),
                                                    voyageAToB[j]
                                                    );
                                            }
                                        }
                                        if (parties[j].gameObject.tag == "Triangle" && sacs[i].GetComponent<CouleurSac>().indexShape == 3)
                                        {
                                            if (sacs[i].transform.GetChild(sacs[i].GetComponent<CouleurSac>().indexShape).gameObject.activeSelf)
                                            {
                                                voyageAToB[j] += speed;
                                                parties[j].transform.gameObject.transform.localPosition = Vector3.Lerp
                                                    (
                                                    parties[j].transform.gameObject.transform.localPosition,
                                                    new Vector3(sacs[i].transform.localPosition.x, sacs[i].transform.localPosition.y, parties[j].transform.gameObject.transform.localPosition.z),
                                                    voyageAToB[j]
                                                    );
                                            }
                                        }
                                    }
                                }
                            }
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
                    sacs.Clear();
                    cibles.Clear();
                    aUneCible.Clear();
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
                    homingFunctionCalled = false;
                }
            }
        }
    }

    public void HomingFunction()
    {
        homingFunctionCalled = true;
    }
}

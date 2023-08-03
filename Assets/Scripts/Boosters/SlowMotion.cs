using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    public Button boutonReference;
    public float timer;
    public float timerLimit;
    public float cooldown;
    public float cooldownLimit;
    public bool slowMotionFunctionCalled;
    public NewColors newColorsReference;
    [HideInInspector]
    public RigibodyManager[] listOfParties;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

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

                GetComponent<Button>().onClick.AddListener(SlowMotionFunction);
            }
        }

        if (slowMotionFunctionCalled)
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
                listOfParties = FindObjectsOfType<RigibodyManager>();

                if (listOfParties.Length > 0)
                {
                    for (int i = 0; i < listOfParties.Length; ++i)
                    {
                        if (!listOfParties[i]._collision)
                        {
                            var pos = listOfParties[i].gameObject.transform.localPosition;
                            pos.y += speed;
                            listOfParties[i].gameObject.transform.localPosition = pos;
                        }
                    }
                }

                GetComponent<Button>().interactable = false;
                timer += Time.deltaTime;

                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100 - 100 * (timer / timerLimit));
            }
            if (timer >= timerLimit)
            {
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
                    slowMotionFunctionCalled = false;
                }
            }
        }
    }

    public void SlowMotionFunction()
    {
        slowMotionFunctionCalled = true;
    }
}

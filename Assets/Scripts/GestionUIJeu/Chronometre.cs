using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometre : MonoBehaviour
{
    public ButtonPlay _play;
    public GameObject selectionNiveaux;

    //[HideInInspector]
    public float startingTimer;
    [HideInInspector]
    public float timer;
    [HideInInspector]
    public bool isGameOver;
    [HideInInspector]
    public bool hasStarted;

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted && !isGameOver)
        { timer = startingTimer; hasStarted = true; }

        if (!_play.boutonActif && !selectionNiveaux.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer >= 100)
            {
                GetComponent<Text>().text = "Timer : " + Mathf.Round(timer) + "s";
            }
            if (timer >= 10 && timer < 100)
            {
                GetComponent<Text>().text = "Timer : 0" + Mathf.Round(timer) + "s";
            }
            if (timer > 0 && timer < 10)
            {
                GetComponent<Text>().text = "Timer : 00" + Mathf.Round(timer) + "s";
            }
            if (timer <= 0)
            {
                timer = 0;
                GetComponent<Text>().text = "Timer : 000s";
                hasStarted = false;
                isGameOver = true;
            }
        }
    }
}

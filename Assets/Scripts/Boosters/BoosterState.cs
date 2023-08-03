using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterState : MonoBehaviour
{
    public bool boosterAchete;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Button>().IsInteractable() && boosterAchete)
        {
            var colors = GetComponent<Button>().colors;
            colors.disabledColor = new Color(0, 1, 0.5f, 1);
            GetComponent<Button>().colors = colors;
        }
    }
}

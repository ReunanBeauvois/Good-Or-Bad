using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterPrices : MonoBehaviour
{
    public bool onePrice;

    public int uniquePrice;
    public List<int> prices;

    public Button boutonReference;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onePrice)
        {
            GetComponent<Text>().text = uniquePrice + " G";
        }
        if (!onePrice)
        {
            if (boutonReference != null)
            {
                if (boutonReference.GetComponent<NewColors>())
                {
                    GetComponent<Text>().text = prices[boutonReference.GetComponent<NewColors>().niveauAchat] + " G";
                }
            }
        }
    }
}

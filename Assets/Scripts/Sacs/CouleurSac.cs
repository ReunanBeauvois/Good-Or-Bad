using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouleurSac : MonoBehaviour
{
    public ButtonPlay _play;
    public GameObject selectionNiveaux;

    public Chronometre _chrono;

    public List<Material> materiaux;

    [HideInInspector]
    public bool setStartMaterial;

    [HideInInspector]
    public int indexMateriel;
    [HideInInspector]
    public float timer;
    public float timerLimit;
    public bool canMove;
    public float speedMove;
    [HideInInspector]
    public float timerMove;
    [HideInInspector]
    public bool goToAPosition;
    [HideInInspector]
    public bool goToBPosition;
    public Vector2 aPosition;
    public Vector2 bPosition;

    public bool colorChanges;
    public bool oneColor;
    public bool specialBag;
    public int indexShape;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (!goToAPosition && !goToBPosition) { goToBPosition = true; }

            if (goToAPosition && !goToBPosition)
            {
                timerMove -= Time.deltaTime * speedMove;
            }
            if (!goToAPosition && goToBPosition)
            {
                timerMove += Time.deltaTime * speedMove;
            }

            if (timerMove >= 1)
            {
                goToAPosition = true;
                goToBPosition = false;
            }
            if (timerMove <= 0)
            {
                goToAPosition = false;
                goToBPosition = true;
            }

            transform.localPosition = Vector3.Lerp(new Vector3(aPosition.x, aPosition.y, transform.localPosition.z), new Vector3(bPosition.x, bPosition.y, transform.localPosition.z), timerMove);
        }

        if (!_chrono.isGameOver)
        {
            if (!_play.boutonActif && !selectionNiveaux.activeSelf)
            {
                if (!setStartMaterial)
                {
                    if (materiaux.Count > 0)
                    {
                        transform.GetComponent<MeshRenderer>().materials[0].color = materiaux[indexMateriel].color;
                    }

                    if (specialBag)
                    {
                        if (transform.childCount > 0)
                        {
                            indexShape = Random.Range(0, transform.childCount);

                            for (int i = 0; i < transform.childCount; ++i)
                            {
                                if (i == indexShape)
                                {
                                    transform.GetChild(i).transform.gameObject.SetActive(true);
                                }
                                if (i != indexShape)
                                {
                                    transform.GetChild(i).transform.gameObject.SetActive(false);
                                }
                            }
                        }
                    }

                    setStartMaterial = true;
                }

                if (timer < timerLimit)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= timerLimit)
                {
                    if (specialBag)
                    {
                        if (transform.childCount > 0)
                        {
                            indexShape = Random.Range(0, transform.childCount);

                            for (int i = 0; i < transform.childCount; ++i)
                            {
                                if (i == indexShape)
                                {
                                    transform.GetChild(i).transform.gameObject.SetActive(true);
                                }
                                if (i != indexShape)
                                {
                                    transform.GetChild(i).transform.gameObject.SetActive(false);
                                }
                            }
                        }
                    }

                    if (!colorChanges && !oneColor)
                    {
                        indexMateriel = 0;
                    }
                    if (colorChanges && !oneColor)
                    {
                        indexMateriel = Random.Range(0, materiaux.Count);
                    }

                    if (!oneColor)
                    { transform.GetComponent<MeshRenderer>().materials[0].color = materiaux[indexMateriel].color; }

                    timer = 0;
                }
                if (oneColor)
                {
                    transform.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                }
            }
        }
    }
}

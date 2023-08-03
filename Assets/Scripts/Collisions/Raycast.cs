using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Raycast : MonoBehaviour
{
    [HideInInspector]
    public Ray ray;
    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public bool CollisionRencontre;
    public GameObject objetATester;
    public ButtonPlay _play;
    public GameObject objetSujetRaycast;

    public Chronometre _chrono;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_chrono.isGameOver)
        {
            if (!_play.boutonActif)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit) && objetSujetRaycast == null)
                {
                    if (hit.collider.tag == "Plateau")
                    {
                        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                        {
                            CollisionRencontre = true;
                            objetSujetRaycast = hit.collider.gameObject;
                        }
                    }
                }

                if (objetSujetRaycast != null)
                {
                    if (objetSujetRaycast.TryGetComponent<Rigidbody>(out Rigidbody _r))
                    {
                        if (_r != null)
                        {
                            _r.useGravity = false;
                        }
                    }

                    var rot = objetSujetRaycast.transform.localEulerAngles;

                    //Debug.Log("Mouse X : " + ((Input.mousePosition.x - (Screen.width / 2)) / 196.5f) + " -- Y : " + ((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4));

                    if (((Input.mousePosition.x - (Screen.width / 2)) / 196.5f) < objetSujetRaycast.GetComponent<EditXAndYRaycast>().x)
                    {
                        rot.z = -(((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) + objetSujetRaycast.GetComponent<EditXAndYRaycast>().y);

                        if (objetSujetRaycast.transform.parent.transform.localPosition.x >= 0)
                        {
                            rot.z = Mathf.Clamp(rot.z, -40, 40);
                        }
                        if (objetSujetRaycast.transform.parent.transform.localPosition.x < 0)
                        {
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) < objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.transform.rotation.z < -0.9f)
                                {
                                    rot.z = Mathf.Clamp(rot.z, -180, -140);
                                }
                            }
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) < -objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.transform.rotation.w > 0.9f)
                                {
                                    rot.z = Mathf.Clamp(rot.z, 0, 40);
                                }
                            }
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) > objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.transform.rotation.z < -0.9f)
                                {
                                    rot.z = Mathf.Clamp(rot.z, -220, -180);
                                }
                            }
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) > -objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.GetComponent<EditXAndYRaycast>().y < 0)
                                {
                                    rot.z = Mathf.Clamp(rot.z, -40, 0);
                                }
                                if (objetSujetRaycast.GetComponent<EditXAndYRaycast>().y > 0 && objetSujetRaycast.transform.parent.transform.localPosition.y < 0)
                                {
                                    rot.z = Mathf.Clamp(rot.z, -40, 0);
                                }
                            }
                        }
                    }
                    if (((Input.mousePosition.x - (Screen.width / 2)) / 196.5f) > objetSujetRaycast.GetComponent<EditXAndYRaycast>().x)
                    {
                        rot.z = +(((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) + objetSujetRaycast.GetComponent<EditXAndYRaycast>().y);

                        if (objetSujetRaycast.transform.parent.transform.localPosition.x >= 0)
                        {
                            rot.z = Mathf.Clamp(rot.z, -40, 40);
                        }
                        if (objetSujetRaycast.transform.parent.transform.localPosition.x < 0)
                        {
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) < objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.transform.rotation.z > 0.9f)
                                {
                                    rot.z = Mathf.Clamp(rot.z, 140, 180);
                                }
                            }
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) < -objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.transform.rotation.w > 0.9f)
                                {
                                    rot.z = Mathf.Clamp(rot.z, -40, 0);
                                }
                            }
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) > objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.transform.rotation.z > 0.9f)
                                {
                                    rot.z = Mathf.Clamp(rot.z, 180, 220);
                                }
                            }
                            if (((((Input.mousePosition.y - (Screen.height / 2)) / 25) + 7) * 4) > -objetSujetRaycast.GetComponent<EditXAndYRaycast>().y)
                            {
                                if (objetSujetRaycast.GetComponent<EditXAndYRaycast>().y < 0)
                                {
                                    rot.z = Mathf.Clamp(rot.z, 0, 40);
                                }
                                if (objetSujetRaycast.GetComponent<EditXAndYRaycast>().y > 0 && objetSujetRaycast.transform.parent.transform.localPosition.y < 0)
                                {
                                    rot.z = Mathf.Clamp(rot.z, 0, 40);
                                }
                            }
                        }
                    }

                    objetSujetRaycast.transform.localEulerAngles = rot;
                }

                if (!CollisionRencontre)
                {
                    if (objetSujetRaycast != null)
                    {
                        if (objetSujetRaycast.TryGetComponent<Rigidbody>(out Rigidbody _r))
                        {
                            if (_r != null)
                            {
                                _r.useGravity = true;
                            }
                        }
                    }
                }

                if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
                {
                    CollisionRencontre = false;
                    objetSujetRaycast = null;
                }
            }
        }
    }
}

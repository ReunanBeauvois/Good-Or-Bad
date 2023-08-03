using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyManager : MonoBehaviour
{
    private GameObject objet;
    public Score _score;
    public bool _collision;
    public bool _sacAtteint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Plateau")
        {
            _collision = true;
            objet = collision.collider.gameObject;
        }
        if (collision.collider.tag == "Sac")
        {
            _score.objetDansUnSac = gameObject;
            _score.sac = collision.collider;
            _sacAtteint = true;
        }
        if (collision.collider.tag == "Bordure")
        {
            if (TryGetComponent<Rigidbody>(out Rigidbody _r))
            {
                var velocity = _r.velocity;
                velocity.x = -velocity.x;
                _r.velocity = velocity;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Plateau")
        {
            _collision = false;
            objet = null;
        }

        if (TryGetComponent<Rigidbody>(out Rigidbody _r))
        {
            _r.useGravity = true;
        }
    }

    private void Update()
    {
        if (_collision)
        {
            if (TryGetComponent<Rigidbody>(out Rigidbody _r))
            {
                if (objet != null)
                {
                    var velocity = _r.velocity;

                    if (objet.transform.localEulerAngles.z > 0 && objet.transform.localEulerAngles.z < 30)
                    {
                        velocity.x = -1.25f;
                    }
                    if (objet.transform.localEulerAngles.z < 360 && objet.transform.localEulerAngles.z > 330)
                    {
                        velocity.x = +1.25f;
                    }

                    _r.velocity = velocity;
                }
            }
        }

        if (!_collision)
        {
            if (TryGetComponent<Rigidbody>(out Rigidbody _r))
            {
                _r.useGravity = true;

                var velocity = _r.velocity;

                if (_r.velocity.y > 0)
                {
                    _r.velocity = -_r.velocity;
                }

                _r.velocity = velocity;
            }
        }
    }
}

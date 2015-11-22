using UnityEngine;
using System.Collections;

public class LimbScript : MonoBehaviour
{
    float maxVelocity;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            GetComponent<HingeJoint2D>().enabled = false;
            transform.parent = null;
        }
    }
}

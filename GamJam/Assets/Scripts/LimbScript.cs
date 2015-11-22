using UnityEngine;
using System.Collections;

public class LimbScript : MonoBehaviour
{
    public float maxVelocity;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player" && collision.relativeVelocity.magnitude > maxVelocity)
        {
            GetComponent<HingeJoint2D>().enabled = false;
            transform.parent = null;
        }
    }
}

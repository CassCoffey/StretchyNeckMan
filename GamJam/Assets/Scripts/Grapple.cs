using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour
{
    public static bool attached = false;

    public float force;

    public GameObject torso;
    public GameObject neckStart;
    public GameObject particle;

    private GameObject origin;
    private Vector2 headLoc;
    private float percent;
    private float goalTime;
    private float startTime;

    private Transform originalParent;

	// Use this for initialization
	public void Shoot (float angle)
    {
        originalParent = transform.parent;

        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * force, ForceMode2D.Impulse);
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "grapple")
        {
            attached = true;
            transform.parent = hit.transform;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().isKinematic = true;
            torso.GetComponent<SpringJoint2D>().enabled = true;
            torso.GetComponent<SpringJoint2D>().distance = Vector2.Distance(neckStart.transform.position, transform.position)/4f;

            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }

    public void ReturnToStart(GameObject goal, float time)
    {
        headLoc = transform.position;
        startTime = Time.time;
        goalTime = startTime + time;
        origin = goal;
        percent = 0f;

        transform.parent = null;

        StartCoroutine(ReturnCoroutine());
    }

    IEnumerator ReturnCoroutine()
    {
        while (true)
        {
            if (percent <= 1f)
            {
                percent = (Time.time - startTime) / (goalTime - startTime);

                transform.position = Vector2.Lerp(headLoc, origin.transform.position, percent);

                yield return new WaitForFixedUpdate();
            }
            else
            {
                attached = false;
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Collider2D>().isTrigger = false;
                transform.parent = originalParent;
                torso.GetComponent<SpringJoint2D>().distance = 1;
                torso.GetComponent<SpringJoint2D>().enabled = true;

                yield break;
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour
{
    public float maxScale;
    public float minScale;

	// Use this for initialization
	void Start ()
    {
        float scale = Random.Range(minScale, maxScale);

        transform.localScale = new Vector3(scale, scale, 1);
	}
}

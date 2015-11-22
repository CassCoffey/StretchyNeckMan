using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
    public GameObject dino;
	public float followSpeed;
	public float offset;

    private float startTime;
    private float endTime;
    private float intensity;
    private Vector3 original;
    private bool shaking = false;

    // Update is called once per frame
    void FixedUpdate ()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x + offset, followSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (Camera.main.WorldToScreenPoint(dino.transform.position).x >= 0)
        {
            transform.position += new Vector3(dino.transform.position.x - Camera.main.ScreenToWorldPoint(Vector3.zero).x, 0, 0);
        } 

        if (shaking)
        {
            transform.position += new Vector3(Random.Range(-intensity, intensity), 0, 0);

            if (Time.time > endTime)
            {
                shaking = false;
            }
        }
    }

    // Use this for initialization
    public void Shake(float intense, float length)
    {
        startTime = Time.time;
        endTime = startTime + length;
        intensity = intense;

        original = transform.position;

        shaking = true;
    }

    IEnumerator ShakeRoutine()
    {
        while (true)
        {
            transform.position = new Vector3(original.x + Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), -10);

            if (Time.time > endTime)
            {
                transform.position = new Vector3(original.x, 0, -10);
                yield break;
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }
}

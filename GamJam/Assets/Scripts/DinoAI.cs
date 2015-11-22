using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

	public GameObject player;
	public GameObject target;
	public GameObject currentTarget;
	public GameObject laserStart;
	public int timeScaling;
	private bool shooting;
	private bool shotFired;
	private bool targetAcquired;
	private float playerDistance;
	private float laserDecrease = 0;
	private float laserTime = 0;

	public float shootFrequency = 5;
	public float frequencyTime = 0;	
	public float targetDelay = 2;
	public float shootDelay = 5;
	public float shootTime = 0; 

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
        if (player != null)
        {
            if (targetAcquired)
            {
                GetComponent<LineRenderer>().SetPosition(0, laserStart.transform.position);
                GetComponent<LineRenderer>().SetPosition(1, 50 * ((currentTarget.transform.position - Vector3.forward) - laserStart.transform.position).normalized + laserStart.transform.position);
                GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(Vector2.Distance(currentTarget.transform.position, laserStart.transform.position), 1);
            }
            else
            {
                GetComponent<LineRenderer>().SetPosition(0, laserStart.transform.position);
                GetComponent<LineRenderer>().SetPosition(1, 50 * ((player.transform.position - Vector3.forward) - laserStart.transform.position).normalized + laserStart.transform.position);
                GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(Vector2.Distance(player.transform.position, laserStart.transform.position), 1);
            }
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (player != null)
        {
            if (shooting)
            {
                GetComponent<LineRenderer>().enabled = true;
                shootTime += Time.deltaTime;
                if (shootTime >= targetDelay && !targetAcquired)
                {
                    currentTarget = (GameObject)GameObject.Instantiate(target, player.transform.position, Quaternion.identity);
                    Destroy(currentTarget, shootDelay - targetDelay);
                    currentTarget.transform.parent = transform;
                    targetAcquired = true;
                }
                if (shootTime >= shootDelay - 1 && !shotFired)
                {
                    laserTime = 0;
                    shotFired = true;
                    currentTarget.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    GetComponent<LineRenderer>().SetColors(new Color(1, 1, 1, 1), new Color(1, 1, 1, 1));
                    GetComponent<LineRenderer>().SetWidth(1f, 1.7f);
                    Camera.main.GetComponent<CameraScript>().Shake(0.2f, 1f);
                }
                if (shootTime >= shootDelay - 1)
                {//While big laser is out
                    GetComponent<LineRenderer>().SetColors(new Color(1, 1, 1, 1 - 0.3f * laserTime), new Color(1, 1, 1, 1 - 0.3f * laserTime));
                    GetComponent<LineRenderer>().SetWidth(1f - 0.5f * laserTime, 1.7f);
                    laserTime += Time.deltaTime;
                    RaycastHit2D[] beam = Physics2D.RaycastAll(laserStart.transform.position, (currentTarget.transform.position - laserStart.transform.position).normalized);
					for(int i = 0; i < beam.Length; i++){
						if (beam[i].collider != null && beam[i].collider.tag == "Player")
                    	{
                        	print(beam[i].collider);
                        	if (beam[i].collider.transform.name == "Body")
                        	{
                            	beam[i].collider.gameObject.GetComponent<TorsoScript>().Pop();
                        	}
                        	else if (beam[i].collider.transform.name != "Head")
                        	{
                            	beam[i].collider.gameObject.GetComponent<LimbScript>().LimbExplode();
                        	}
                    	}
					}
                }
                if (shootTime >= shootDelay)
                {
                    shooting = false;
                    targetAcquired = false;
                    shootTime = 0;
                    frequencyTime = 0;
                    GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
                    GetComponent<LineRenderer>().SetColors(new Color(1, 1, 1, 0.4f), new Color(1, 1, 1, 0.4f));
                    GetComponent<LineRenderer>().enabled = false;
                }
            }
            else
            {
                frequencyTime += Time.deltaTime;
                if (frequencyTime >= shootFrequency)
                {
                    laserStart.GetComponent<AudioSource>().Play();
                    GetComponent<AudioSource>().PlayDelayed(shootDelay - 1);
                    shooting = true;
                    shotFired = false;
                }
            }
            playerDistance = -1 * (transform.position.x - player.transform.position.x);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3 + playerDistance / 5 + Time.deltaTime / timeScaling, 0);
        }
        else
        {
            shooting = false;
            targetAcquired = false;
            shootTime = 0;
            frequencyTime = 0;
            GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
            GetComponent<LineRenderer>().SetColors(new Color(1, 1, 1, 0.4f), new Color(1, 1, 1, 0.4f));
            GetComponent<LineRenderer>().enabled = false;
        }
	}
}

using UnityEngine;
using System.Collections;

public class FireTripleShot : MonoBehaviour 
{
	
	public GameObject bullet;
	
	public float fireDelay = 10.0f;
	private float delay = 0.3f;
	private float nextFireTime;
	private float force = 100;
	private Transform m_myTransform;
	
	
	void Awake()
	{
	
		m_myTransform = transform;
		
	}
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if ( Input.GetButton("Fire1") && Time.time > nextFireTime )
		{
			nextFireTime = Time.time + fireDelay;
			//Debug.Log ( "FIRING " );
			
			Fire ();
			
			
		}
		
		
		
		
	}
	
	
	void Fire()
	{
	
		
		GameObject clone = ( GameObject )Instantiate( bullet , m_myTransform.position, m_myTransform.rotation );
		
		Debug.Log ( "FIRING " + m_myTransform.name );
	
	}


}

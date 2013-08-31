using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

	public GameObject rocket;
	public GameObject simpleGun;
	
	public float fireDelay = 10.0f;
	private float delay = 0.3f;
	private float nextFireTime;
	private float force = 100;
	private Transform m_myTransform;
	
	public int lifeTime; 
	
	
	void Awake()
	{
	
		m_myTransform = transform;
		simpleGun.SetActive( false );
		
	}
	
	
	// Use this for initialization
	void Start () 
	{
	
		StartCoroutine( "CountDown" );
	
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
	
		
		GameObject clone = ( GameObject )Instantiate( rocket, m_myTransform.position, m_myTransform.rotation );
		
		
		
		Debug.Log ( "FIRING " + m_myTransform.name );
	
	}
	
	
	IEnumerator CountDown()
	{
		int count = 0;
		
		
		while( count < lifeTime )
		{
		
			Debug.Log ( "Grenade Launcher Time Left: " + (lifeTime - count) );
			yield return new WaitForSeconds( 1.0f );
		    count++;
		
		}
		
		gameObject.SetActive( false );
		
		simpleGun.SetActive( true );
		
		
	}

}

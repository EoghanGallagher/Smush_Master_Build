using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 150;
	public GameObject detonator; 
	public float damageAmount = 100;
	
	private Transform m_MyTransform;
	
	
	void Awake()
	{
	
		m_MyTransform = transform;
		
	}
	
	// Use this for initialization
	void Start () 
	{
	
	 	
		
		rigidbody.AddRelativeForce( Vector3.forward * speed );
		
		
	}
	

	

	void OnTriggerEnter( Collider other )
	{
		
	
	  Debug.Log ( "Bullet Hit " + other.name );
		
	  if( other.tag == Tags.enemy )
	  {
	
			//Messenger.Broadcast<GameObject , Transform>( "SpawnExplosion", detonator, m_MyTransform );
			Messenger.Broadcast<float>( other.gameObject,  "Damage" , damageAmount);
	  
			CleanUp ();
			
	  }
		
	  if( other.tag == Tags.wall )
	  {
	
			CleanUp ();
	  
	  }
		
	
	}
	
	void CleanUp()
	{
		
		Debug.Log ( "Cleanup" );
		
		Destroy(gameObject);	
	
	}
	
	
	
}

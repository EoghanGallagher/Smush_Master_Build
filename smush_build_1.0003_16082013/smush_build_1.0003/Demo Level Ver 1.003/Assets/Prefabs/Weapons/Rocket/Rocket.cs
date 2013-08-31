using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	
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
	  		//CheckForEnemiesInRange();
			
			
	  }
		
	  if( other.tag == Tags.wall )
	  {
	        CheckForEnemiesInRange();
			Messenger.Broadcast<GameObject , Transform>( "SpawnExplosion", detonator, m_MyTransform );
			
			CleanUp ();
	  
	  }
		
	
	}
	
	void CheckForEnemiesInRange(  )
	{
		
		Collider[] colliders;
		
		float radius = 1.5F;
		
        float power = 100.0F;
		
		
		Debug.Log ( "DAMAGE CALLED" );
    
        Vector3 explosionPos = transform.position;
        colliders = Physics.OverlapSphere(explosionPos, radius);
        
		foreach (Collider hit in colliders) 
		{
            if ( !hit )
			{
				Debug.Log ( "NO HIT" );
				return;
			}
            
            if ( hit.rigidbody )
			{
				
				Debug.Log( "Enemies HIT" );
				
				
				if( hit.gameObject.tag == Tags.enemy )
				{
					//hit.gameObject.SendMessage( "Damage" , damageAmount ) ;
					Messenger.Broadcast<float>( hit.gameObject,  "Damage" , damageAmount);
					hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 10.0F);
				}
			
			}
			else
			{
			
				//Ignore
				
			}
			
                
				
				
				
				
				
				
				
			}
        }
    
	
	
	void CleanUp()
	{
		
		Debug.Log ( "Cleanup" );
		
		Destroy(gameObject);	
	
	}
	
	

}

using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
public Vector3 targetPosition;
	
	private RaycastHit hit;
	private Vector3 up;
	
	
	public GameObject detonator;
	
	private Transform m_MyTransform;
	private float damageAmount = 20;
	
	void Start()
	{
		
		m_MyTransform = transform;
	
	}
	
	

	
	void CleanUp()
	{
		Destroy(gameObject);	
	}
	
	
	void OnTriggerEnter( Collider other )
	{
	
		Debug.Log ( " HIT Test " + other.name );
		
		 Messenger.Broadcast<GameObject , Transform>( "SpawnExplosion", detonator, m_MyTransform );
		
		CleanUp ();
		
	}
	
	
	void OnCollisionEnter( Collision other )
	{
	
		 Debug.Log ( " HIT COLLISION " + other.gameObject.name );
		
		 if( other.gameObject.tag == Tags.floor  || other.gameObject.tag == Tags.enemy )
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
    
	
}
	
	
	



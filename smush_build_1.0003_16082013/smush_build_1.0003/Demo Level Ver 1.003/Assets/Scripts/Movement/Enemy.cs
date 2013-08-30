using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	
	
	public float health; 
	
	public int scoreValue;
	
	
	public GameObject detonator;
	
	private Transform m_MyTransform; 
	
	public bool _inRange =  false;
	
	void Awake()
	{
		
	   Messenger.AddListener<float>( gameObject ,"Damage", Damage ); 
	   Messenger.AddListener<float>( "Damage1", Damage1 ); 
	   Messenger.AddListener( gameObject , "RangeCheck", RangeCheck ); 
		
	}
	

	void OnDestroy()
	{
	
		
	 	Messenger.RemoveListener<float>( gameObject, "Damage", Damage );
		Messenger.RemoveListener<float>( "Damage1", Damage1 );
		Messenger.RemoveListener( gameObject , "RangeCheck", RangeCheck ); 
	
	}
	
	// Use this for initialization
	void Start () 
	{
	
	
		m_MyTransform = transform;
		
		
	}
	
	
	
	
	public void Damage( float damageAmount )
	{
		
			
		 //Debug.Log( "Damage Called. Reduce health of " + transform.name + " by " + damageAmount );
		 
		
	           // Messenger.Broadcast<GameObject , Transform>( "SpawnExplosion", detonator, m_MyTransform );
				
				Messenger.Broadcast<int>( "ManageScore", scoreValue );
				
				
				
				
				Destroy ( this.gameObject );
				//gameObject.SetActive( false );
				
	
	}
	
	public void Damage1( float damageAmount )
	{
		
			
		 //Debug.Log( "Damage Called. Reduce health of " + transform.name + " by " + damageAmount );
		 
		
	           // Messenger.Broadcast<GameObject , Transform>( "SpawnExplosion", detonator, m_MyTransform );
				//SendMessage( "SpawnExplosion", detonator, m_MyTransform  );
				
		        //BroadcastMessage("ManageScore", scoreValue, SendMessageOptions.DontRequireReceiver );
		       
		        if( _inRange )
				{
		
		        	Messenger.Broadcast<int>( "ManageScore", scoreValue );
					Destroy ( this.gameObject );
				}	
				
				//gameObject.SetActive( false );
				
	
	}
	
	
	void RangeCheck()
	{
	
		Debug.Log( " Range Check Called " );
		_inRange = true;
		
	}
	
	

	
	void OnTriggerEnter( Collider other )
	{
	
	   if( other.tag == Tags.player )
	   {
			Debug.Log ( "HIT: " + other.name );
		
			Messenger.Broadcast( "KillPlayer" );
	   }
		
	   if( other.tag == Tags.floor)
	   {
			
			Debug.Log ( "HIT: " + other.name );
		
			//Messenger.Broadcast( "KillPlayer" );
	   }
	
	}
	

	
	
	
	
	
}

using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {

	
	
	
	void OnEnable()
	{
		
	   Messenger.AddListener< GameObject, Transform >( "SpawnExplosion", SpawnExplosion ); 
		
	}
	
	
	void OnDisable()
	{
	
		
	 	Messenger.RemoveListener<GameObject, Transform >( "SpawnExplosion", SpawnExplosion ); 
	
	}
	
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	
	
	
	//Used for explosion effects
	//Pass it an explosion type and target
	
	void SpawnExplosion( GameObject currentDetonator , Transform target )
	{
	
		
		Debug.Log ( "BOOM !" );
		
		
		if( currentDetonator )
		{
			Instantiate ( currentDetonator, target.position, target.rotation );
			
			
		}
		else
		{
		
			Debug.Log( "NO EXPLOSION" );
			
		}
		
	}
	
	
}

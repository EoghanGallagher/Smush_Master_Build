using UnityEngine;
using System.Collections;

public class RayCastCollision : MonoBehaviour {

	private RaycastHit hit;
	private Vector3 up;
	
	// Use this for initialization
	void Start () 
	{
	
		up = transform.TransformDirection( Vector3.up );
		
	}
	
	void Update()
	{
	
		if( Physics.Raycast( transform.position, -up, out hit, 10 ))
		{
		
			Debug.Log ( " HHIIIITTT" );
			
		}
		
	}
}

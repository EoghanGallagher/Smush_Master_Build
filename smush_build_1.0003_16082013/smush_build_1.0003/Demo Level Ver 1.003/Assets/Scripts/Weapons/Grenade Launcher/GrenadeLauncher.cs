using UnityEngine;
using System.Collections;

public class GrenadeLauncher : MonoBehaviour {

	
	public float fireDelay = 10.0f;
	private float delay = 0.3f;
	public GameObject grenade;
	
	
	public float firingAngle = 45.0f;
    public float gravity = 9.8f;
	
	private Transform m_myTransform;
	public Transform Target;
	
	
	private float nextFireTime;
	
	
	void Awake()
	{
	
		m_myTransform = transform;
		
	}
	
	// Use this for initialization
	void Start () 
	{
		
		//StartCoroutine( "SimulateProjectile" );
	
	}
	

	void Update()
	{
	
		
		if ( Input.GetButton("Fire1") && Time.time > nextFireTime )
		{
			nextFireTime = Time.time + fireDelay;
			Debug.Log ( "FIRING " );
			
			LaunchGrenade();
		}
		
	
	}
		
	/* LaunchGrenade()
	{
		
			
		GameObject cloneGrenade = (GameObject) Instantiate( grenade, m_myTransform.position, m_myTransform.rotation );
		
		cloneGrenade.rigidbody.position = m_myTransform.position;
		cloneGrenade.rigidbody.rotation = m_myTransform.rotation;
		
		cloneGrenade.rigidbody.AddRelativeForce( Vector3.forward * 100 );
		
		yield return new WaitForSeconds( 0.25f );
		
		
		
		
		
		
			
	}*/
	
	
	private void LaunchGrenade()
	{
	
		StartCoroutine( "SimulateProjectile" );
		
	}
	
	IEnumerator SimulateProjectile()

    {

        
	
				GameObject cloneGrenade = (GameObject) Instantiate( grenade, m_myTransform.position, m_myTransform.rotation );
		
	
		
        		// Move projectile to the position of throwing object + add some offset if needed.

        		cloneGrenade.transform.position = m_myTransform.position + new Vector3(0, 0.0f, 0);

       

        		// Calculate distance to target

        		float target_Distance = Vector3.Distance(cloneGrenade.transform.position, Target.position);

 

        		// Calculate the velocity needed to throw the object to the target at specified angle.

        		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

 

        		// Extract the X & Y componenent of the velocity

        		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);

        		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

 

        		// Calculate flight time.

        		float flightDuration = target_Distance / Vx;

   

        		// Rotate projectile to face the target.

        		cloneGrenade.transform.rotation = Quaternion.LookRotation( Target.position - cloneGrenade.transform.position );

       

        		float elapse_time = 0;

 

        		while (elapse_time < flightDuration)

        		{

             
					if( cloneGrenade )
					{
						cloneGrenade.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
					}
			
           

            		elapse_time += Time.deltaTime;

 

            		yield return null;

        		}
		
		 	
				// Short delay added before Projectile is thrown 

				yield return new WaitForSeconds( fireDelay );

		}
			
		

	
}

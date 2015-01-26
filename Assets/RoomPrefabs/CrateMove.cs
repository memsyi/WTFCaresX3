using UnityEngine;
using System.Collections;

public class CrateMove : MonoBehaviour 
{
	private float bounceRate = 100;
	// Use this for initialization
	public float pushPower = 2.0F;
	void OnControllerColliderHit(ControllerColliderHit hit) 
	{

		if(hit.transform.tag == "Pet")
			return;
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}

	void OnCollisionEnter(Collision  col)
	{
		Debug.Log(col.transform.gameObject.name);

		if( col.transform.gameObject.name == "PetDogg" )
		 {

		
			col.transform.GetComponent<NavMeshAgent>().Stop();
			col.transform.GetComponent<NavMeshAgent>().ResetPath();
			
			col.transform.rigidbody.AddForce( new Vector3( 0, 0, -col.transform.forward.z * bounceRate),
			                       ForceMode.Impulse );

			if( col.transform.GetComponent<NavMeshMovement>() == null )
				return;
			
			col.transform.GetComponent<NavMeshMovement> ().bouncedAway = true;

		}
	}
}

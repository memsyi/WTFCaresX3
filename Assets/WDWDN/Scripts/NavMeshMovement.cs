using UnityEngine;
using System.Collections;

public class NavMeshMovement : MonoBehaviour 
{
	NavMeshAgent agent;
	public Camera petCam;
	public bool bouncedAway = false;
	public float bounceTimer = .2f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if( bouncedAway == false )
		{
			if( rigidbody.angularVelocity != Vector3.zero )
				rigidbody.angularVelocity = Vector3.zero;
			
			if( rigidbody.velocity != Vector3.zero )
				rigidbody.velocity = Vector3.zero;
		}

		if( bouncedAway == true )
		{
			bounceTimer -= Time.deltaTime;
			if(bounceTimer <= 0)
			{
				rigidbody.angularVelocity = Vector3.zero;
				rigidbody.velocity = Vector3.zero;
				bounceTimer = .2f;
				bouncedAway = false;
			}
		}

		if (Input.mousePosition.x < Screen.width / 2 || Input.mousePosition.x > Screen.width || 
		    Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
			return;

		if( Input.GetMouseButtonDown(0) )
		{
			Ray ray = petCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			RaycastHit[] hits = Physics.RaycastAll(ray, 20000.0f);

			Debug.DrawRay( ray.origin, ray.direction * 20000.0f, Color.red );

			if( hits.Length == 0 )
				return;

			RaycastHit firstHit = hits[hits.Length-1];

			//Debug.Log(firstHit.transform.name);

			if( firstHit.transform.gameObject.layer == LayerMask.NameToLayer ("Ground") )
			{
				agent.SetDestination (firstHit.point);
			}
		}
	}
}

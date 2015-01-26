using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	public bool isOpen = false;
	public float doorTimer = 4;
	public string keyRequired;
	public float bounceRate = 1;
	public GameObject stopper;

	void Update()
	{
		if( !isOpen )
		{
			Collider[] hits = Physics.OverlapSphere(transform.position, 5.0f);

			foreach( Collider col in hits )
			{
				if( col.transform.gameObject.tag == "Pet" )
				{
					// check if holding the right key
					if( col.transform.gameObject.GetComponent<PickUpAction>().m_Item == null )
					{
						NavMeshAgentBounce(col.transform.gameObject);
						break;
					}

					if( col.transform.gameObject.GetComponent<PickUpAction>().m_Item != null )
					{
						if( col.transform.gameObject.GetComponent<PickUpAction>().m_Item.name != keyRequired )
						{
							NavMeshAgentBounce(col.transform.gameObject);
							break;
						}
					}
				}
			}
		}

		else if( isOpen )
		{
			if( stopper != null )
				Destroy(stopper);
			doorTimer -= Time.deltaTime;

			if( doorTimer <= 0 )
			{
				transform.parent.GetComponent<Animator>().SetBool("open", false);
				doorTimer = 4;
				isOpen = false;
			}
		}
	}

	void NavMeshAgentBounce(GameObject obj)
	{
		obj.GetComponent<NavMeshAgent>().Stop();
		obj.GetComponent<NavMeshAgent>().ResetPath();
		
		obj.rigidbody.AddForce( new Vector3( 0, 0, -obj.transform.forward.z * bounceRate),
		                                            ForceMode.Impulse );

		if( obj.GetComponent<NavMeshMovement>() == null )
			return;

		obj.GetComponent<NavMeshMovement> ().bouncedAway = true;
	}

	void OnTriggerEnter(Collider col)
	{
		if( col.transform.gameObject.tag == "Pet" ||
		    col.transform.gameObject.tag == "Person" )
		{
			if( col.transform.gameObject.GetComponent<PickUpAction>().m_Item == null )
				return;

			if( col.transform.gameObject.GetComponent<PickUpAction>().m_Item.name == keyRequired )
			{
				//Debug.Log ("door hit");
				transform.parent.GetComponent<Animator>().SetBool("open", true);
				isOpen = true;
			}
		}
	}
}

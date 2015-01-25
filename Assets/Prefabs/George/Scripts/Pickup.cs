using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour 
{
	public bool m_bIsHeld = false;

	float m_fGCountDown;

	public const float CoolDown = 3.0f;

	public bool m_bIsGravity = true;
	// Use this for initialization
	void Start () 
	{
		if (rigidbody == null) 
		{
			Debug.Log("Adding a ridid body becuase it didnt have one");
				Rigidbody r = gameObject.AddComponent<Rigidbody>();
		}
		if(transform.collider== null)
		{
			Collider c = gameObject.AddComponent<Collider>();
			c.isTrigger = true;
		}

		
		m_fGCountDown = CoolDown;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_bIsGravity) 
		{
			m_fGCountDown -= Time.deltaTime;

			if(m_fGCountDown < 0)
			{
				rigidbody.useGravity = false;
				rigidbody.isKinematic = true;
				collider.isTrigger = true;

				m_bIsGravity = false;

				m_fGCountDown = CoolDown;
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		//Debug.Log (other.name);

		if(m_bIsHeld == true)
			return;

		if(other.tag == "Person" ||other.tag == "Pet")
		{
			other.GetComponent<PickUpAction>().Notified(this);
		}
	}
}
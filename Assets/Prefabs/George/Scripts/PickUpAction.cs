using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PickUpAction : MonoBehaviour 
{
	public Transform m_HoldLocation;

	string tag; 

	public Pickup m_Item;
	public bool m_amHolding = false;


	public const float TIMER = 3f;
	public float m_fCoolDown;

	public bool m_bIsActionReady = true;

	void Start () 
	{
		m_fCoolDown = TIMER;

		tag = transform.root.tag;

		if(m_HoldLocation == null)
			Debug.LogError("Need To add in a transform GameObject to m_holdLocation");

	}
	
	// Update is called once per frame

	void Update()
	{
		if (!m_bIsActionReady) 
		{
			m_fCoolDown -= Time.deltaTime;

			if(m_fCoolDown < 0)
			{
				m_bIsActionReady = true;
				m_fCoolDown = TIMER;
			}
		}
	}

	void LateUpdate () 
	{

		if (m_Item != null) 
		{
			if( m_amHolding && m_Item.m_bIsHeld && m_bIsActionReady)
			{
				if(ControlerWrapper.Get().X_Hit(0)&& tag == "Person")
				{
					DropItem(tag);
				}

				if(Input.GetMouseButton(1)&& tag == "Pet")
				{
					DropItem(tag);
				}
			}
		}
	}

	public void Notified(Pickup item)
	{

		print("Can Pick Up");
		if (tag == "Person") 
		{
			if(ControlerWrapper.Get().X_Hold(0)&& m_bIsActionReady )
			{
				PickUpItem(item);
			}
		}
		if (tag == "Pet") 
		{
			//Right Click
			if(Input.GetMouseButton(1))
			{
				PickUpItem(item);
			}
		}
	}

	void  PickUpItem(Pickup item)
	{

		m_bIsActionReady = false;
		item.transform.parent = m_HoldLocation;
		item.transform.localPosition = m_HoldLocation.localPosition;
		m_Item = item;
		item.m_bIsHeld = true;
		m_amHolding = true;
	}



	void  DropItem(string tag)
	{
		if(m_Item.transform.root.tag == tag)
		{
			m_bIsActionReady = false;
			m_Item.transform.parent = null;
			m_Item.m_bIsHeld = false;

			m_amHolding = false;

			m_Item.transform.rigidbody.useGravity = true;
			m_Item.rigidbody.isKinematic = false;
			m_Item.collider.isTrigger = false;
			m_Item.m_bIsGravity = true;

			m_Item = null;
		}
	}
}

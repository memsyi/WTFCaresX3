using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	public bool isOpen = false;
	public float doorTimer = 2;
	public string keyRequired;

	void Update()
	{
		if( isOpen )
		{
			doorTimer -= Time.deltaTime;

			if( doorTimer <= 0 )
			{
				transform.parent.GetComponent<Animator>().SetBool("open", false);
				doorTimer = 2;
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if( col.transform.gameObject.name == "PetDogg" ||
		    col.transform.gameObject.name == "Person" )
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

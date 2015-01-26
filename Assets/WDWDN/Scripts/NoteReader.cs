using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class NoteReader : MonoBehaviour 
{
	public GameObject note;
	public bool readNote = false;

	void Update()
	{
		Collider[] hits = Physics.OverlapSphere (transform.position, 10.0f);

		foreach( Collider col in hits )
		{
			if( col.transform.gameObject.name == "Person" )
			{
				if (ControlerWrapper.Get ().X_Hit (0)) 
				{
					note.SetActive(!note.activeInHierarchy);
				}
			}
		}

		if( hits.Length == 0 )
		{
			if (ControlerWrapper.Get ().X_Hit (0) || ControlerWrapper.Get ().X_Hold (0)) 
			{
				if( note.activeInHierarchy == true )
				{
					note.SetActive(false);
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class InteractiveObj : MonoBehaviour 
{
	public GameObject guiPopUp;
	public GameObject label;
	public GameObject objectUI;

	void Start()
	{
		label.GetComponent<UILabel> ().text = transform.name;
	}

	void Update()
	{
		guiPopUp.transform.position = new Vector3( transform.position.x + 20,
		                                           transform.position.y,
		                                           transform.position.z - 40);
	}

	void OnMouseOver()
	{
		guiPopUp.GetComponent<Animator> ().SetBool ("mouseOverItem", true);
	}

	void OnMouseExit()
	{
		guiPopUp.GetComponent<Animator> ().SetBool ("mouseOverItem", false);
	}
}

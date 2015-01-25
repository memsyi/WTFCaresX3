using UnityEngine;
using System.Collections;

public class InteractiveObj : MonoBehaviour 
{
	public GameObject guiPopUp;
	public GameObject label;
	public GameObject objectUI;

	void Start()
	{
		label.GetComponent<UILabel> ().text = transform.parent.name;
	}

	void Update()
	{
		guiPopUp.transform.position = transform.position;
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

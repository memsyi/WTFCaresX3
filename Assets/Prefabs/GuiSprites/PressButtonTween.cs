using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PressButtonTween : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Notify()
	{
		gameObject.SetActive (false);
	}
}

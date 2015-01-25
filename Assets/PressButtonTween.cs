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
		//while(true)
		{
			Debug.Log("Doing");

		if(ControlerWrapper.Get().X_Hit(0)|| ControlerWrapper.Get().X_Hold(0))
		{
				Debug.Log("BREAKING!!!");
				return;
			}


		}
	}
}

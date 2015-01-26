using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown(KeyCode.Escape) )
			Application.LoadLevel("WhatDoWeDoNow2");
	}
}

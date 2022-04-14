///////////////////////////////////////////////////////////////////////
//                                                   41 Post                                       //
// Created by DimasTheDriver on July/28/2012                                    //
// Part of 'Unity: Capturing audio from a microphone' post.                          		 		 //
// Available at:     http://www.41post.com/?p=4884                              //
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class BackToPost : MonoBehaviour 
{
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width-110,Screen.height-40,100,30),"Back to post..."))
		{
			Application.OpenURL("http://www.41post.com/?p=4884");
			
		}
	}
}

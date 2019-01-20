using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

	void Start()
	{
		Handheld.PlayFullScreenMovie("UrsaIntro.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
}

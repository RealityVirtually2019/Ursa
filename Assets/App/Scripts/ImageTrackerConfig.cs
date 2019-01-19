using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ImageTrackerConfig : MonoBehaviour, ITrackableEventHandler {

	public TrackableBehaviour imageTracker;

	public Text imageTrackerText;

	// Use this for initialization
	void Start () {

		if (imageTracker) 
		{
			imageTracker.RegisterTrackableEventHandler(this);
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTrackableStateChanged(

		TrackableBehaviour.Status previousStatus,

		TrackableBehaviour.Status newStatus)

	{

		if (newStatus == TrackableBehaviour.Status.DETECTED ||

			newStatus == TrackableBehaviour.Status.TRACKED ||

			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)

		{

			// When target is found

			imageTrackerText.text = "Cereal Found";

		}

		else

		{

			// When target is lost

			imageTrackerText.text = "Cereal NOT Found";

		}

	}
}

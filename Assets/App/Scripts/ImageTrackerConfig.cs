using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System;

public class ImageTrackerConfig : MonoBehaviour, ITrackableEventHandler {

	public Action TrackingDetected;
	public Action TrackingLost;

	public TrackableBehaviour imageTracker;
	public GameObject[] trackerObjects;
	public string trackerText;
	public bool isTracked;

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

			OnTrackingDetected ();

		}

		else

		{

			// When target is lost

			OnTrackingLost ();

		}

	}


	public void OnTrackingDetected()
	{
		isTracked = true;


		if (TrackingDetected != null)
			TrackingDetected ();

	}

	public void OnTrackingLost()
	{
		isTracked = false;


		if (TrackingLost != null)
			TrackingLost ();


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

[SerializeField]
public class ImageTrackerIndividual
{
	public ImageTrackerConfig imageTracker;
	public Text trackerText;
}


public class ImageTrackerManager : MonoBehaviour {

	public ImageTrackerConfig[] imageTrackers;

	public Text imageTrackerName;
	public string currentTrackerName;

	public GameObject viewFinder;
	public InformationPanelManager infoPanelManger;


	void OnEnable()
	{
		foreach (var tracker in imageTrackers)
		{
			tracker.TrackingDetected += ChangeTrackerLabel;
			tracker.TrackingLost += EnableViewFinder;
		}
	}

	void OnDisable()
	{
		foreach (var tracker in imageTrackers)
		{
			tracker.TrackingDetected -= ChangeTrackerLabel;
			tracker.TrackingLost -= EnableViewFinder;
		}
	}


	void ChangeTrackerLabel()
	{
		var trackerFound = false;

		for (int i = 0; i < imageTrackers.Length; i++) 
		{
			if (imageTrackers[i].isTracked) 
			{
				//imageTrackerName.text = "a tracker is active";

				imageTrackerName.text = imageTrackers [i].trackerText;
				currentTrackerName = imageTrackers [i].trackerText;

				//SetCurrentTracked (imageTrackerName.text);

				viewFinder.SetActive (false);
				trackerFound = true;
			}

		}

		if (!trackerFound)
			viewFinder.SetActive (true);
	}


	void EnableViewFinder()
	{
		if (!infoPanelManger.infoShow)
			viewFinder.SetActive (true);
	}
		





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnEnable : MonoBehaviour {

	public string sceneToLoad;


	void OnEnable()
	{
		SceneManager.LoadScene (sceneToLoad);
	}
}

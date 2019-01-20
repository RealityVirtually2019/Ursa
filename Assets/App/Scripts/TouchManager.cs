using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Input.GetTouch example.
//
// Attach to an origin based cube.
// A screen touch moves the cube on an iPhone or iPad.
// A second screen touch reduces the cube size.

public class TouchManager : MonoBehaviour
{
	private Vector3 position;
	private float width;
	private float height;

	public bool isTouching;

	public Text raycastText;

	Touch touch;

	public InformationPanelManager infoPanelManager;
	public ImageTrackerManager imageTrackerManager;

	void Awake()
	{
//		width = (float)Screen.width / 2.0f;
//		height = (float)Screen.height / 2.0f;
//
//		// Position used for the cube.
//		position = new Vector3(0.0f, 0.0f, 0.0f);
	}

	void Start()
	{
		//StartCoroutine (WaitForTouch());
	}

//	void OnGUI()
//	{
//		// Compute a fontSize based on the size of the screen width.
//		GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);
//
//		GUI.Label(new Rect(20, 20, width, height * 0.25f),
//			"x = " + position.x.ToString("f2") +
//			", y = " + position.y.ToString("f2"));
//	}

	void Update()
	{
		// Handle screen touches.
		if (Input.touchCount > 0) {

            //raycastText.text = "Finger on screen";

            if (!isTouching)// && !infoPanelManager.infoShow)
            {
				touch = Input.GetTouch (0);

				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;

                // if we hit something and we are not currently showing some information on screen
				if (Physics.Raycast(ray, out hit))
				{
					var gO = hit.collider.gameObject;

					raycastText.text = "Hit something, don't know what!";

					if (gO.tag == "ImageTarget")
					{
						if (gO.GetComponent<ImageTrackerConfig> () != null) 
						{
							//string text = gO.GetComponent<ImageTrackerConfig> ().trackerText;
							raycastText.text = gO.GetComponent<ImageTrackerConfig>().trackerText;

                            infoPanelManager.ActivatePanel(raycastText.text);
							infoPanelManager.InfoPanelShow ();

							isTouching = true;
						}
					}
				}





			}



			// Move the cube if the screen has the finger moving.
			if (touch.phase == TouchPhase.Moved) {
				Vector2 pos = touch.position;
				pos.x = (pos.x - width) / width;
				pos.y = (pos.y - height) / height;
				position = new Vector3 (-pos.x, pos.y, 0.0f);

				// Position the cube.
				transform.position = position;
			}

			if (Input.touchCount == 2) {
				touch = Input.GetTouch (1);

				if (touch.phase == TouchPhase.Began) {
					// Halve the size of the cube.
					transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
				}

				if (touch.phase == TouchPhase.Ended) {
					// Restore the regular size of the cube.
					transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				}
			}
		} else 
		{
			isTouching = false;
			raycastText.text = "Finger off screen";

		}
	}

	IEnumerator WaitForTouch()
	{
		while (Input.touchCount == 0 || (Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Began))
		{
			infoPanelManager.InfoPanelShow ();
		}

		yield return null;
	}

	void RaycastForward()
	{
//		// Construct a ray from the current touch coordinates
//		Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
//		// Create a particle if hit
//		if (Physics.Raycast(ray))
//			Instantiate(particle, transform.position, transform.rotation);   
	}

}

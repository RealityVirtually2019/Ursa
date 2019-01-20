using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Panel
{
    public GameObject panelObj;
    public string panelName;
}

public class InformationPanelManager : MonoBehaviour {

    public List<Panel> panels = new List<Panel>();

	public bool infoShow;
	public bool infoHide = true;

	public Text yPos;
	public Text panelNameText;


	public Transform infoStartTransform;
	public Transform infoEndTransform;

	void OnEnable()
	{
		//SwipeDetector.SwipeDown += InfoPanelShow;
		//SwipeDetector.SwipeUp += InfoPanelHide;

        SwipeDetector.SwipeRight += InfoPanelHide;

    }

	void OnDisable()
	{
        //SwipeDetector.SwipeDown -= InfoPanelShow;
        //SwipeDetector.SwipeUp += InfoPanelHide;

        SwipeDetector.SwipeRight -= InfoPanelHide;


    }


    // Use this for initialization
    void Start ()
    {

        infoHide = true;
        infoShow = false;

        //transform.position = infoEndTransform.position;

    }

    void Update () {

		if (infoShow) 
		{
			transform.position = Vector3.Lerp(transform.position, infoEndTransform.transform.position, Time.deltaTime * 5F);
			//transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -1280, 0), Time.deltaTime * 1.5F);
		}

		if (infoHide) 
		{
			transform.position = Vector3.Lerp(transform.position, infoStartTransform.transform.position, Time.deltaTime * 5F);
			//transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 1280, 0), Time.deltaTime * 1.5F);

		}

		//yPos.text = transform.position.y.ToString ();
			
		
	}

	public void InfoPanelShow()
	{
		infoShow = true;
		infoHide = false;
		//transform.position = Vector3.Lerp(transform.position, new Vector3(0, -2560, 0), Time.deltaTime * 1.5F);
	}

	public void InfoPanelHide()
	{
		infoHide = true;
		infoShow = false;
	}

    public void ActivatePanel(string name)
    {
		panelNameText.text = name;

        foreach (var p in panels)
        {
            if (p != null && p.panelName == name)
            {
                p.panelObj.SetActive(true);
				panelNameText.text = p.panelName;
            }
            else
            {
                p.panelObj.SetActive(false);
            }
        }
    }



		
		
}

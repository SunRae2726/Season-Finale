using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectibleManager : MonoBehaviour {

	List<GameObject> collectibles;
	bool dontSwitchScene = false;

	public GameObject objectToEnableOnWin;
	public bool restartLevelOnWin = false;

	// Use this for initialization
	void Start () {

		if (objectToEnableOnWin != null)
			objectToEnableOnWin.SetActive (false);

		collectibles =  new List<GameObject>();

		object[] allObjects = FindObjectsOfTypeAll(typeof(GameObject)) ;
		foreach(object thisObject in allObjects)
		{
			if (((GameObject) thisObject).activeInHierarchy && ((GameObject) thisObject).GetComponent<Collectible>() != null)
			{
				collectibles.Add((GameObject) thisObject);
			}
		}

		dontSwitchScene = collectibles.Count == 0;
	}

	// Update is called once per frame
	void Update () 
	{
		int nonNullCollectibles = 0;
		foreach(GameObject go in this.collectibles)
		{
			if (go != null)
			{
				nonNullCollectibles++;
			}
		}


		if (nonNullCollectibles == 0 && !dontSwitchScene)
		{
			if (objectToEnableOnWin != null)
				objectToEnableOnWin.SetActive (true);

			if (restartLevelOnWin)
				Invoke ("Restart", 5);

			dontSwitchScene = true;
		}
	}

	public void Restart() {
		Application.LoadLevel (0);
	}

}


using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class MenuOptionController :  MonoBehaviour, IGvrGazeResponder {



	bool isLooking;
	float optionTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isLooking) {
			optionTimer += Time.deltaTime;
			if (this.gameObject.transform.position.x > 2.5) {
				this.gameObject.transform.position -= this.gameObject.transform.forward * 0.2f;
			}

			if (optionTimer > 2.0f) 
			{
				LoadLevel ();
			}

		} else {
			optionTimer = 0;
			if (this.gameObject.transform.position.x < 4)
			{
				this.gameObject.transform.position += this.gameObject.transform.forward*0.2f;
			}

		}
	}

	void LoadLevel ()
	{
//		float fadeTime = GameObject.FindGameObjectWithTag ("SceneController").GetComponent <Fader> ().BeginFade(1);
//		yield return new WaitForSeconds (1);
		SceneManager.LoadScene("PrimaryScene");
	}

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		isLooking = true;
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		isLooking = false;
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	/// If the Cardboard viewer is triggered while looking at the backdrop, rotate the active/falling block
	public void OnGazeTrigger() {
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour {

	GameObject primaryCrystal;
	CrystalController crystalController;

	GameObject frozenOrb;
	GameObject orbitCrystals;

	// these are the components of the FrozenOrb game object, will scale these up later
	GameObject energy, energyCentral, dust, smoke, frozen;


	float sceneTimer = 0f;

	private float strobeTimer = 0f;
	public float spinRate = 10;

	// Use this for initialization
	void Awake () {
		primaryCrystal = GameObject.FindGameObjectWithTag ("PrimaryCrystal");
		crystalController = primaryCrystal.GetComponent <CrystalController> ();
	
		orbitCrystals = GameObject.FindGameObjectWithTag ("OrbitCrystals");

		frozenOrb = GameObject.FindGameObjectWithTag ("FrozenOrb");


		EstablishReferencesToFrozenOrb ();
		frozenOrb.SetActive (false);
	}

	void EstablishReferencesToFrozenOrb ()
	{
		energy = GameObject.FindGameObjectWithTag ("Energy");
		energyCentral = GameObject.FindGameObjectWithTag ("EnergyCentral");
		dust = GameObject.FindGameObjectWithTag ("Dust");
		frozen = GameObject.FindGameObjectWithTag ("Frozen");
		smoke = GameObject.FindGameObjectWithTag ("Smoke");
	}

	void Start()
	{
//		InvokeRepeating("changeCrystalColors", 2.0f, 2.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		strobeTimer += Time.deltaTime;
		sceneTimer += Time.deltaTime;

	
		if (sceneTimer < 18) 
		{
		  primaryCrystal.transform.Rotate (Vector3.right * spinRate * Time.deltaTime, Space.Self);
		} 
		if (sceneTimer >= 18)
		{
		 primaryCrystal.transform.Rotate(Vector3.up * spinRate * Time.deltaTime, Space.Self);
		}
		if (sceneTimer >= 34)
		{
			frozenOrb.SetActive (true);
		}
		if (sceneTimer >= 51 && strobeTimer  <= 85.5)
		{
			StrobePrimaryCrystal ();

			if ( primaryCrystal.transform.position.x < 1.1)
			{
				primaryCrystal.transform.Translate(Vector3.right * Time.deltaTime * 0.1f, Space.World);
			}
				
			orbitCrystals.transform.Rotate(Vector3.right * spinRate * Time.deltaTime);

			if (orbitCrystals.transform.position.x < 1.5)
			{
				orbitCrystals.transform.Translate(Vector3.right * Time.deltaTime * 0.45f);

			}
		}
		if (sceneTimer >= 85 && sceneTimer < 119)
		{
			LazerLightShow ("Initialize");
			StrobePrimaryCrystal ();
			orbitCrystals.transform.Rotate(new Vector3(1,1,1) * 5* spinRate * Time.deltaTime);
		}
		if (sceneTimer >= 119)
		{
			StrobePrimaryCrystal ();
			orbitCrystals.transform.Rotate(new Vector3(1,1,1) * 5* spinRate * Time.deltaTime);
			shrinkCrystals ();
			LazerLightShow ("Deactivate");
		}
		if (sceneTimer >= 134)
		{
			SceneManager.LoadScene("StartMenu");
		}
	}

	void shrinkCrystals ()
	{
		if (primaryCrystal.transform.localScale.x > 0)
		{
			primaryCrystal.transform.localScale -= new Vector3 (1, 1, 1) * 0.01f;
		}
		if (orbitCrystals.transform.localScale.x > 0)
		{
			orbitCrystals.transform.localScale -= new Vector3 (1, 1, 1) * 0.01f;
		}
	}

	// increases the scale of each component of the frozen orb;
	void LazerLightShow (string action)
	{   
		scaleLightShowObject (action, energy);
		scaleLightShowObject  (action, energyCentral);
		scaleLightShowObject  (action, frozen);
		scaleLightShowObject  (action, dust);
		scaleLightShowObject  (action, smoke);
	}

	void scaleLightShowObject  (string action, GameObject orbObject)
	{
		
		if (action == "Initialize") {
			if (orbObject.transform.localScale.x < 2)
			{
				orbObject.transform.localScale += new Vector3(0.1F, 0.1F, 0.1f);
			}
		}
		if (action == "Deactivate") {
			if (orbObject.transform.localScale.x > .3)
			{
				orbObject.transform.localScale -= new Vector3(1F, 1F, 1f) * 0.01f;
			}
		}

	}

	void StrobePrimaryCrystal () 
	{
		if (strobeTimer > 1) {
			crystalController.changeColor ();
			strobeTimer = 0;
		}
	}
}

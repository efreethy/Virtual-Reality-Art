using UnityEngine;
using System.Collections;

public class CrystalController : MonoBehaviour {
	
	public float changeInterval = 10.0F;
	public Material[] materials;
	private MeshRenderer rend;
	private AudioSource mainMusic;
	// Use this for initialization
	void Awake () {
		rend = GetComponent<MeshRenderer> ();
		rend.enabled = true;
		mainMusic = this.GetComponent <AudioSource> ();
	}

	void OnBecameVisible ()
	{
		mainMusic.Play ();
	}
	
	public void changeColor ()
	{
		int idx = Random.Range (0, (materials.Length - 1));
		rend.sharedMaterial = materials[idx];
	}
}

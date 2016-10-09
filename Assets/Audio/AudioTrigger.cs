using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {

	public AudioClip FullClip;
	public AudioSource Button;

	// Use this for initialization
	void Start () {
		Button = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider hit)
	{
        Debug.Log("Collision Enter " + hit.gameObject.tag + " " + gameObject.tag);
        if (hit.gameObject.tag == gameObject.tag) {
			Button.Play ();
		}
	}
}
using UnityEngine;
using System.Collections;

public class SpherePlacementLogic : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip toBell;
    public AudioClip toClap;
    public AudioClip toHat;
    public AudioClip toKick;
    public GameObject winAnimation;
    public bool inRightPosition = false;
    private float bellTime;
    private float clapTime;
    private float hatTime;
    private float kickTime;
    private Rigidbody rb;
    public bool inPlay = false;
  
    // Use this for initialization
    void Start () {
        bellTime = toBell.length;
        clapTime = toClap.length;
        hatTime = toHat.length;
        kickTime = toKick.length;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(audioSource.time >= 6f && inPlay )
        {
            Debug.Log("Firing in here");
            audioSource.time = Time.time % 6f;
            audioSource.Play();
        }
	}
    void OnTriggerEnter(Collider other)
    {
    
        Debug.Log("Sphere is entering the light collider");
        switch (other.tag)
        {
            case "bell":
                audioSource.clip = toBell;
                audioSource.time = Time.time % 6f;
                Debug.Log(bellTime);
                audioSource.Play();
                inPlay = true;
         
                break;
            case "clap":
                audioSource.clip = toClap;
                audioSource.time = Time.time % 6f;
                inPlay = true;
                audioSource.Play();
             
                break;
            case "hat":
                audioSource.clip = toHat;
                audioSource.time = Time.time % 6f;
                inPlay = true;
                audioSource.Play();
            
                break;
            case "kick":
                audioSource.clip = toKick;
                audioSource.time = Time.time % 6f;
                inPlay = true;
                audioSource.Play();
            
                break;
        }
        if(other.tag == gameObject.tag)
        {
            inRightPosition = true;
            winAnimation.SetActive(true);

        }
        
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exiting colldier! "+other.tag);
        if (other.tag == "kick" || other.tag == "hat" || other.tag == "kick" || other.tag == "bell")
        {
            
            audioSource.Stop();
            audioSource.time = 0f;
            inPlay = false;
            inRightPosition = false;
       
            winAnimation.SetActive(false);
        }
    }
}

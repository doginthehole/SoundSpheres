using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundOnHit : MonoBehaviour
{
    public GameObject tag;

    public AudioSource source;
    AudioSource audioS;
    // Use this for initialization
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider hit)
    {
       
        Debug.Log("HIT! "+hit.gameObject.tag + " Object " + gameObject.tag);
        if (hit.gameObject.tag == "Player")
        {
            
            source.Play();
        }
    }

}
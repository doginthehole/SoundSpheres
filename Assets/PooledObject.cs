using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroy", 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}

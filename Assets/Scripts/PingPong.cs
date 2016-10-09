using UnityEngine;
using System.Collections;

public class PingPong : MonoBehaviour {
    public int xSwing, ySwing, zSwing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((Mathf.PingPong(Time.time, xSwing)), (Mathf.PingPong(Time.time, ySwing)), (Mathf.PingPong(Time.time, zSwing)));
    }
}

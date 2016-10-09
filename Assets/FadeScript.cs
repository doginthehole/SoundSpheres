using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SteamVR_Fade.Start(Color.black, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Fade.Start(Color.clear, 6);
    }
}
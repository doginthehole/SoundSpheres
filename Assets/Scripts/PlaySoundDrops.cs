using UnityEngine;
using System.Collections;

public class PlaySoundDrops : MonoBehaviour {
    public int[] rainDrops;
    public float bpm = 40;
    private float beatIntervalInSeconds;
    public GameObject beatLight1;
    private float beatLight1Intensity;
    public GameObject beatLight2;
    private float beatLight2Intensity;
    public GameObject beatLight4;
    private float beatLight4Intensity;
    public float lightIntensity = 3f;
    private float nextBeatTime = 0;
    private float previousBeatTime = 0;
    private int currentBeat = 0;
    private int totalBeats = 0;
    private bool twoBeatOn = false;
    private bool oneBeatOn = false;
    private bool fourBeatOn = false;
	// Use this for initialization
	void Start () {
        beatIntervalInSeconds = 1 / (bpm / 60);
        //InvokeRepeating("CheckBeat", 0, beatsPerSecond);
       
    }

    // Update is called once per frame
    void Update () {
        if (Time.timeSinceLevelLoad >= nextBeatTime)
        {
            GameObject obj;
            beatLight1Intensity = beatLight1.GetComponent<Light>().intensity;
            beatLight2Intensity = beatLight2.GetComponent<Light>().intensity;
            beatLight4Intensity = beatLight4.GetComponent<Light>().intensity;
            totalBeats++;
            if (currentBeat >= rainDrops.Length)
            {
                Debug.Log(rainDrops.Length);
                currentBeat = 0;
            }
            switch (rainDrops[currentBeat])
            {

                
                case 1:
                    twoBeatOn = false;
                    oneBeatOn = true;
                    fourBeatOn = false;
                    beatLight1.GetComponent<Light>().intensity = lightIntensity;
                    //Debug.Log("{TIME,BEAT}:" + Time.timeSinceLevelLoad + " ," + currentBeat+" total beat"+totalBeats);
                    previousBeatTime = nextBeatTime;
                    //Instantiate(rainDropOneBeat, spawnPoint.transform);
                    break;
                case 2:
                    twoBeatOn = true;
                    oneBeatOn = false;
                    fourBeatOn = false;
                    beatLight2.GetComponent<Light>().intensity = lightIntensity;
                    //Debug.Log("{TIME,BEAT}:" + Time.timeSinceLevelLoad + " ," + currentBeat + " total beat" + totalBeats);
                    previousBeatTime = nextBeatTime;
                    break;
                case 3:
                    break;
                case 4:
                    twoBeatOn = false;
                    oneBeatOn = false;
                    fourBeatOn = true;
                    beatLight4.GetComponent<Light>().intensity = lightIntensity;
                    //Debug.Log("{TIME,BEAT}:" + Time.timeSinceLevelLoad + " ," + currentBeat + " total beat" + totalBeats);
                    previousBeatTime = nextBeatTime;
                    break;
                default:
                    //Debug.Log("{TIME,BEAT}:" + Time.timeSinceLevelLoad + " ," + currentBeat + " total beat" + totalBeats);
                    break;

            }
            
            nextBeatTime += beatIntervalInSeconds;
            currentBeat++;
            
         

        }

        if (oneBeatOn)
        {
            //Debug.Log((Time.time - previousBeatTime) / beatIntervalInSeconds);
            beatLight1.GetComponent<Light>().intensity = Mathf.Lerp(lightIntensity, 0f, (Time.time - previousBeatTime) / beatIntervalInSeconds);
            beatLight2.GetComponent<Light>().intensity = 0f;
            beatLight4.GetComponent<Light>().intensity = 0f;
        }
        if (twoBeatOn)
        {

            beatLight1.GetComponent<Light>().intensity = 0f;
            beatLight2.GetComponent<Light>().intensity = Mathf.Lerp(lightIntensity, 0f, (Time.time - previousBeatTime) / (beatIntervalInSeconds * 2f));
            beatLight4.GetComponent<Light>().intensity = 0f;
        }
        if (fourBeatOn)
        {

            beatLight1.GetComponent<Light>().intensity = 0f;
            beatLight4.GetComponent<Light>().intensity = Mathf.Lerp(lightIntensity, 0f, (Time.time - previousBeatTime) / (beatIntervalInSeconds * 4f));
            beatLight2.GetComponent<Light>().intensity = 0f;
        }
    }

    void CheckBeat()
    {
       
    }
}

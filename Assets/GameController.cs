using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    public static GameController gameController;
    public SpherePlacementLogic kickSphere;
    public SpherePlacementLogic clapSphere;
    public SpherePlacementLogic hatSphere;
    public SpherePlacementLogic bellSphere;
    public AudioSource WinSong;
    public GameObject winEffect;
    void Awake()
    {
        gameController = this;
    }
    void Start()
    {


        StartCoroutine(GameLoop());

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGameRestart()
    {
       // SceneManager.LoadScene("TomSoundSphere");
    }

    void OnGameOver()
    {

    }

    void OnGameWin()
    {
        winEffect.SetActive(true);
        Debug.Log("YOU WIN!!");
        WinSong.Play();
        OnGameRestart();
    }


    private IEnumerator RoundPlaying()
    {
        while (!hatSphere.inRightPosition||!clapSphere.inRightPosition||!kickSphere.inRightPosition||!bellSphere.inRightPosition)
        {
            //Debug.Log("{hatSphere,clapSphere,kickSphere,bellSphere}"+ hatSphere.inRightPosition+ clapSphere.inRightPosition + kickSphere.inRightPosition + bellSphere.inRightPosition);
            yield return null;
        }
        OnGameWin();
    }

    private IEnumerator GameLoop()
    {
        yield return RoundPlaying();
        //OnGameRestart();
    }
}

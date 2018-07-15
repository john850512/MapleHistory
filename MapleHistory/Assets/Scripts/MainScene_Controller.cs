using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene_Controller : MonoBehaviour {
    public GameObject Loading;
    public Text loadText;
    public Image loadImage;
    public GameObject BackgroundMusic;
    public  static bool music_is_play_flag = false;
    private GameObject clone; //DontDestroyOnLoad

    public AudioSource audio_Click;

	// Use this for initialization
	void Start () {
        if (!music_is_play_flag)
        {
            clone = Instantiate(BackgroundMusic, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(clone); 
            music_is_play_flag = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeScene_To_ChooseChapterScene() {
        audio_Click.Play();
        StartCoroutine("DelayFunction_Start", 0.1);   
    }
    public void ChangeScene_To_EndScene()
    {
        audio_Click.Play();
        StartCoroutine("DelayFunction_End", 0.1);      
    }
    IEnumerator DelayFunction_Start(float Count) //ChangeScene_To_ChooseChapterScene
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        //And here goes your method of resetting the game...
        SceneManager.LoadScene("Anim_From_Main_To_Choose");
        yield return null;
    }
    IEnumerator DelayFunction_End(float Count) //ChangeScene_To_EndScene
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        //And here goes your method of resetting the game...
        SceneManager.LoadScene("Anim_EndScene");
        yield return null;
    }
}

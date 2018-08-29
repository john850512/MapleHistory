using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseChapterScene_Controller : MonoBehaviour {
    public Animator ChapterList;
    public AudioSource audio_RollDown;
    public AudioSource audio_RollUp;
    public AudioSource audio_Click;
    public AudioSource audio_GameIn;
    // 點擊聲音特效
    private bool Anim_flag;
    private int Anim_CH;

    public Button btn_GameIn;
    private int Chapter_Num;

    // background music-detect
    public GameObject BackgroundMusic;
    private GameObject audioPlayer; // holds a reference to the audio player
    public string BackgroundMusic_name = "BackgroundMusic"; //用字串紀錄vackground music的prefeb名稱，到時要改比較方便

    

	// Use this for initialization
	void Start () {
        Anim_CH = -1;
        Chapter_Num = -1;
        btn_GameIn.gameObject.SetActive(false);

        // background music-detect
        audioPlayer = GameObject.Find(BackgroundMusic_name+"(Clone)");
        if (audioPlayer == null) //if DontDestroyOnLoad Object doesnt exist
        {
            audioPlayer = Instantiate(BackgroundMusic, transform.position, transform.rotation) as GameObject;
            audioPlayer.GetComponent<AudioSource>().Play();
            MainScene_Controller.music_is_play_flag = true;
            DontDestroyOnLoad(audioPlayer); 
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void check_anim_parameters(bool Anim_flag, int Anim_CH, int CH)
    {
        //Debug.Log(CH);
        if (Anim_CH == -1)//第一次的時候要執行張開動畫
        {
            Chapter_Num = CH;
            btn_GameIn.gameObject.SetActive(true);
            ChapterList.SetInteger("CH", CH);
            ChapterList.SetBool("Play", true);
            audio_RollDown.Play();
        }
        else if (Anim_CH == CH) //相同章節的張開縮和判斷
        {
            if (Anim_flag == false)
            {
                Chapter_Num = CH;
                btn_GameIn.gameObject.SetActive(true);
                ChapterList.SetBool("Play", true);
                audio_RollDown.Play();
            }
            else
            {
                btn_GameIn.gameObject.SetActive(false);
                ChapterList.SetBool("Play", false);
                ChapterList.SetInteger("CH", -1);
                audio_RollUp.Play();
            }
        }
        else //轉換到不同章節的時候也要馬上執行張開動畫
        {
            btn_GameIn.gameObject.SetActive(true);
            Chapter_Num = CH;
            ChapterList.SetInteger("CH", CH);
            audio_RollDown.Play();
        }
    }

    public void ClickChapterListBtn(int CH) {
        Anim_flag = ChapterList.GetBool("Play");
        Anim_CH = ChapterList.GetInteger("CH");
        check_anim_parameters(Anim_flag, Anim_CH, CH);
    }

    public void ReturnMainScene()
    {
        audio_Click.Play();
        StartCoroutine("DelayFunction",0.1);
        
    }
    public void ChangeChapterScene()
    {
        audio_Click.Play();
        audio_GameIn.Play();
        StartCoroutine("Load_Chpater");


    }
    IEnumerator DelayFunction(float Count)
    {
        yield return new WaitForSeconds(3); //Count is the amount of time in seconds that you want to wait.
        //And here goes your method of resetting the game...
        SceneManager.LoadScene("Anim_From_Choose_To_Main");
        yield return null;
    }

    IEnumerator Load_Chpater()
    {
        yield return new WaitForSeconds(1); //Count is the amount of time in seconds that you want to wait.
        //And here goes your method of resetting the game...
        Destroy(audioPlayer);
        SceneManager.LoadScene("Chapter" + Chapter_Num);
        yield return null;
    }
}

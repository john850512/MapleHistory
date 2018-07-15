using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseChapterScene_Controller : MonoBehaviour {
    public Animator ChapterList;
    public AudioSource audio_RollDown;
    public AudioSource audio_RollUp;
    public AudioSource audio_Click;
    private bool Anim_flag;
    private int Anim_CH;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void check_anim_parameters(bool Anim_flag, int Anim_CH, int CH)
    {
        if (Anim_CH == -1)//第一次的時候要執行張開動畫
        {
            ChapterList.SetInteger("CH", CH);
            ChapterList.SetBool("Play", true);
            audio_RollDown.Play();
        }
        else if (Anim_CH == CH) //相同章節的張開縮和判斷
        {
            if (Anim_flag == false)
            {
                ChapterList.SetBool("Play", true);
                audio_RollDown.Play();
            }
            else
            {
                ChapterList.SetBool("Play", false);
                ChapterList.SetInteger("CH", -1);
                audio_RollUp.Play();
            }
        }
        else //轉換到不同章節的時候也要馬上執行張開動畫
        {
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
    IEnumerator DelayFunction(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        //And here goes your method of resetting the game...
        SceneManager.LoadScene("Anim_From_Choose_To_Main");
        yield return null;
    }
}

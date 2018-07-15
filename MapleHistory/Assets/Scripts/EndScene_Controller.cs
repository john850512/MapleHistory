using UnityEngine;
using System.Collections;

public class EndScene_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DelayFunction", 2.0);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator DelayFunction(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        //And here goes your method of resetting the game...
        Application.Quit();
        yield return null;
    }
}

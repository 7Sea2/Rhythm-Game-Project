using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class ButtonsScript : MonoBehaviour
{
    public GameObject playButton;

    public void goToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame(){
        Debug.Log("Application has exited");
        Application.Quit();
    }
}

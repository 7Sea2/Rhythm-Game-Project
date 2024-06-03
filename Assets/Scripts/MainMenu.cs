using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class ButtonsScript : MonoBehaviour
{
    public GameObject playButton;

    //Function for making the scene change when you press the button on the main menu
    public void goToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    //Function for exiting the game with a debug log since the game cant exit in unity
    public void exitGame(){
        Debug.Log("Application has exited");
        Application.Quit();
    }
}

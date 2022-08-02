using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour
{

    //managa list of scenes?? 

    public static void OpenGameOver()
    {
        SceneManager.LoadScene("GameOver",  LoadSceneMode.Additive);
    }

    public static void CloseGameOver()
    {
        SceneManager.UnloadSceneAsync("GameOver");
    }
    
    public static void PlayAgain()
    {
        CloseGameOver();
        MaintainBases.NewGame = true;
        CountDown();
    }

    public static void KeepPlaying()
    {
        CloseGameOver();
        CountDown();
    }

    public static void CountDown()
    {
        Debug.Log("Counting Down");
        SceneManager.LoadScene("CountDown", LoadSceneMode.Additive);

        int countLoaded = SceneManager.sceneCount;

        if (SceneManager.GetSceneByName("Home").IsValid())
        {
            SceneManager.UnloadSceneAsync("Home");
        }
        
        if (SceneManager.GetSceneByName("GameOver").IsValid())
        {
            SceneManager.UnloadSceneAsync("GameOver");
        }   

        if (SceneManager.GetSceneByName("Pause").IsValid())
        {
            SceneManager.UnloadSceneAsync("Pause");
        }

    }
    
    public static void CloseCount()
    {
        Debug.Log("Counting Down end");
        SceneManager.UnloadSceneAsync("CountDown");
    }

    public static void OpenHome()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
    }

    public static void CloseHome()
    {
        SceneManager.UnloadSceneAsync("StartScene");
        SceneChange.CountDown();
    }

    public static void OpenHelp()
    {
        SceneManager.LoadScene("Help",  LoadSceneMode.Additive);
    }

    public static void CloseHelp()
    {
        SceneManager.UnloadSceneAsync("Help");
    }

    public static void OpenPause()
    {
        Debug.Log("calling open pause");
        Time.timeScale = 0;
        SceneManager.LoadScene("Pause",  LoadSceneMode.Additive);
    }

    public static void ClosePause()
    {
        SceneManager.UnloadSceneAsync("Pause");
        SceneChange.CountDown();
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings",  LoadSceneMode.Additive);
    }

    public void CloseSettings()
    {
        SceneManager.UnloadSceneAsync("Settings");
    }
}

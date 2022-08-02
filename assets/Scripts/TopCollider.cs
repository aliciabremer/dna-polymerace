using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TopCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collider" + other.transform.childCount);
        int num = other.transform.childCount;
        //if (TutorialManager.firstTime && Score.GetScore() < 4)
        //{

        //}
        if (num < 3)
        {
            GameOver();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    void GameOver()
    {
        MaintainBases.NewGame = true;
        Time.timeScale = 0;
        SceneChange.OpenGameOver();
    }
}

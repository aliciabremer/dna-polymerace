using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CheckFirst : MonoBehaviour
{
    [SerializeField]
    private GameObject introTutorial;

    public Button[] disabledButtons;

    public bool lastScene;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //move this stuff -- need to update when settings change
        //b = GetComponent<"PlayAgain">
        //b = GetComponent<"Home">;


        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            if (lastScene)
            {
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            }

            introTutorial.SetActive(true);

            for (int i = 0; i < disabledButtons.Length; i++)
            {
                disabledButtons[i].interactable = false;
            }
        }
        else
        {
            Debug.Log("NOT First Time Opening");

            introTutorial.SetActive(false);

            for (int i = 0; i < disabledButtons.Length; i++)
            {
                disabledButtons[i].interactable = true;
            }
        }

    }
}

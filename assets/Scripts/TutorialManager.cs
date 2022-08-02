using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    private string[] message;
    public Button[] buttons;
    private int popUpIndex;

    public static bool firstTime;

    private GameObject temp;

    void Awake()
    {
        temp = null;
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            //PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            //Do your stuff here
            firstTime = true;

            //get from language xml files

            message = new string[4];
            message[0] = "Adenine (A) and thymine (T) pair together! So if you see adenine (A), click thymine (T).";
            message[1] = "Similarly, if you see thymine (T) click adenine (A).";
            message[2] = "Cytosine (C) and guanine (G) pair together! So if you see cytosine (C), click guanine (G).";
            message[3] = "Similarly, if you see guanine (G) click cytosine (C).";
        }
        else
        {
            Debug.Log("NOT First Time Opening");

            //Do your stuff here
            firstTime = false;

        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (firstTime && popUpIndex < buttons.Length)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == popUpIndex)
                {
                    Destroy(temp); //fix so don't have to destroy thigns everytime
                    temp = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    temp.transform.SetParent(spawnPoint, false);
                    Text t = temp.GetComponentInChildren(typeof(Text)) as Text;
                    t.text = message[popUpIndex];
                    buttons[popUpIndex].interactable = true;
                }
                else
                {
                    buttons[i].interactable = false;
                }
            }


            if (buttons[popUpIndex].GetComponent<MyButton>().buttonPressed)
            {
                popUpIndex++;
                if (popUpIndex==buttons.Length)
                {
                    Destroy(temp);
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i].interactable = true;
                    }
                }
            }
        }
    }
}

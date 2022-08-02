using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int s = 0;
    private static int best = 0;

    public Lang langClass;

    [SerializeField] 
    private Text scoreDisplay;
    
    [SerializeField]
    private Text bestDisplay;

    void Start()
    {
        langClass = new Lang(Path.Combine(Application.dataPath, "Scripts/lang.xml"),SettingsControl.lang, false);
    }

    void Update()
    {
        scoreDisplay.text = ""+Score.GetScore();
        bestDisplay.text =  langClass.getString("best_text") + Score.GetBest();
    }

    public static int GetScore()
    {
        return s;
    }

    // Update is called once per frame
    public static void UpdateScore()
    {
        s++;
        if (s>best)
            best = s;
    }

    public static void ResetScore()
    {
        s = 0;
    }

    public static int GetBest()
    {
        return best;
    }

    public static void UpdateBest(int b)
    {
        best = b;
    }


}

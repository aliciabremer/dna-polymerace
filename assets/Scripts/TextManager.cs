using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;

    public Lang langClass;

    private bool changedLang = false;

    public bool Changed
    {
        get
        {
            return changedLang;
        }
        set
        {
            changedLang = value;
            RenderText();
        }
    }

    //change things to static kinda...

    void Start()
    {
        RenderText();
    }

    public void RenderText()
    {
        langClass = new Lang(Path.Combine(Application.dataPath, "Scripts/lang.xml"),SettingsControl.lang, false); 
        switch(scene)
        {
            case "home":
                HomeText();
                break;
            case "help":
                HelpText();
                break;
            case "settings":
                SettingsText();
                break;
            case "end":
                EndText();
                break;
            case "pause":
                PauseText();
                break;
        }
    }

    void HomeText()
    {
        if (TutorialManager.firstTime)
        {
            Text tut = GameObject.Find("Info").GetComponent<Text>();
            tut.text = langClass.getString("tutorial_start");
        }
    }

    void HelpText()
    {
        Text helpTitle = GameObject.Find("Help").GetComponent<Text>();
        Text doneText = GameObject.Find("DoneText").GetComponent<Text>();
        Text howToPlay = GameObject.Find("titleText").GetComponent<Text>();
        Text instruct = GameObject.Find("info").GetComponent<Text>();
        
        helpTitle.text = langClass.getString("help_name");
        doneText.text = langClass.getString("done");
        howToPlay.text = langClass.getString("how_to_play");
        instruct.text = langClass.getString("h_game_backstory")+"\n\n"+langClass.getString("h_game_info")+"\n\n"+langClass.getString("h_game_basics")+"\n\n"+langClass.getString("h_game_win");

    }

    void SettingsText()
    {
        //Text settingsTitle = GameObject.Find("Settings").GetComponent<Text>();
        Text doneText = GameObject.Find("DoneText").GetComponent<Text>();
        Text volume = GameObject.Find("VolumeText").GetComponent<Text>();
        Text music = GameObject.Find("MusicText").GetComponent<Text>();
        Text language = GameObject.Find("Lang").GetComponent<Text>(); //finish language stuff
        Text connect = GameObject.Find("ConnectText").GetComponent<Text>();
        Text discord = GameObject.Find("DiscordText").GetComponent<Text>();
        Text email = GameObject.Find("EmailText").GetComponent<Text>();
        Text info = GameObject.Find("InfoText").GetComponent<Text>();
        Text privacy = GameObject.Find("PrivacyText").GetComponent<Text>();
        Text terms = GameObject.Find("TermsText").GetComponent<Text>();

        //settingsTitle.text = langClass.getString("settings_name");
        doneText.text = langClass.getString("done");
        volume.text = langClass.getString("volume");
        music.text = langClass.getString("music");
        language.text = langClass.getString("language");
        connect.text = langClass.getString("connect");
        discord.text = langClass.getString("discord");
        email.text = langClass.getString("email");
        info.text = langClass.getString("s_info");
        privacy.text = langClass.getString("privacy_policy");
        terms.text = langClass.getString("terms_and_conditions");
    }

    void EndText()
    {
        Text scoreText = GameObject.Find("Best").GetComponent<Text>();
        Text playAgain = GameObject.Find("PlayAgainText").GetComponent<Text>();
        Text home = GameObject.Find("HomeText").GetComponent<Text>(); 
    
        scoreText.text = langClass.getString("best_text");
        playAgain.text = langClass.getString("play_again");
        home.text = langClass.getString("home_button");

        if (TutorialManager.firstTime)
        {
            Text tut = GameObject.Find("Info").GetComponent<Text>();
            tut.text = langClass.getString("tutorial_end");
        }
    }

    void PauseText()
    {
        Text pausedText = GameObject.Find("Pause").GetComponent<Text>();
        Text resume = GameObject.Find("ResumeText").GetComponent<Text>();
        Text home = GameObject.Find("HomeText").GetComponent<Text>(); 
        Text settings = GameObject.Find("SettingsText").GetComponent<Text>();
        Text help = GameObject.Find("HelpText").GetComponent<Text>();
        
    
        pausedText.text = langClass.getString("paused");
        resume.text = langClass.getString("resume");
        home.text = langClass.getString("home_button");
        settings.text = langClass.getString("settings_name");
        help.text = langClass.getString("help_name");
    }

    public Lang GetLangClass()
    {
        return langClass;
    }

    //4 --> finish lang.xml :(
    //5 tutorial text
}

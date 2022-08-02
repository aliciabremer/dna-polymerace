using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider mainSlider;

    public Dropdown langControl;

    public List<string> m_DropOptions = new List<string> { "English", "French", "Spanish", "German" };

    public static string lang = "English";

    public static float vol = 0.5f;

    //add buttons for language
    //probably add eventsystem for stuff


    void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        langControl.AddOptions(m_DropOptions);
        langControl.onValueChanged.AddListener(delegate {DropdownValueChanged(langControl); });
    }

    public void ValueChangeCheck()
    {
        vol = mainSlider.value;
        Debug.Log(vol);
    }

    public void DropdownValueChanged(Dropdown change)
    {
        lang = m_DropOptions[change.value];
        //TextManager.Changed = true;
    }
}

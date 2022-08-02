using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text text;

    private CanvasGroup _canvasGroup;

    private Lang langClass; //call lang class from TExt Manager and also fix go and stuff

    private void Awake() 
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        langClass = new Lang(Path.Combine(Application.dataPath, "Scripts/lang.xml"),"English", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Count());
        StartCoroutine(FadeCGAlpha(1f, 0f, 1f));
    }

    // Update is called once per frame
    IEnumerator Count()
    {   
        MaintainBases.NewGame = true;
             
        for (int i = 0; i < 3; i++)
        {
            text.text = "" + (3-i);
            yield return new WaitForSecondsRealtime(1f);
        }

        text.text = langClass.getString("go");
        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1;
    }

    private IEnumerator FadeCGAlpha(float from, float to, float duration) 
    {
        float elaspedTime = 0f;
        while (elaspedTime <= duration) {
            elaspedTime += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(from, to, elaspedTime / duration);
            yield return null;
        }
        _canvasGroup.alpha = to;
        SceneChange.CloseCount();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaintainBases : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform SpawnPointLead = null;

    public Button a_button, c_button, t_button, g_button, pause_b;
    private List<GameObject> b;
    private List<int> bNames;
    
    private Queue<int> add;

    [SerializeField]
    private Text textRef;

    //need to store score

    public GameObject l_adenine;
    public GameObject l_guanine;
    public GameObject l_cytosine;
    public GameObject l_thymine;
    
    public GameObject t_adenine;
    public GameObject t_guanine;
    public GameObject t_cytosine;
    public GameObject t_thymine;

    private static bool _reset = false;

    public static bool NewGame
    {
        get
        {
            return _reset;
        }
        set
        {
            if (_reset == value) return;
            _reset = value;
        }
    }

    //add comments

    void Awake()
    {
        SceneChange.OpenHome();
        Time.timeScale = 0;
    }

    void Start()
    {
        add = new Queue<int>();
        Reset();
        a_button.onClick.AddListener(() => ButtonClicked(0, t_adenine));
        c_button.onClick.AddListener(() => ButtonClicked(2, t_cytosine));
        t_button.onClick.AddListener(() => ButtonClicked(3, t_thymine));
        g_button.onClick.AddListener(() => ButtonClicked(1, t_guanine));
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpriteUp.UpdateSpeed();
        if (MaintainBases._reset)
            Reset();
    }

    void Reset()
    {
        Score.ResetScore(); //may move
        MoveSpriteUp.ResetSpeed();

        foreach (Transform child in SpawnPointLead)
            Destroy(child.gameObject);

        b = new List<GameObject>(); //may need to move
        bNames = new List<int>();

        Debug.Log("tutorial manager first time in start: " + TutorialManager.firstTime);
        if (TutorialManager.firstTime)
        {
            add.Enqueue(0);
            add.Enqueue(3);
            add.Enqueue(2);
            add.Enqueue(1); 
        }

        AddBase();
        MaintainBases.NewGame=false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        AddBase();
    }

    void AddBase()
    {
        int t = 0;
        Debug.Log("# of bases in queue: " + add.Count);
        if (add.Count > 0)
        {
            t = add.Dequeue();
        }
        else
        {
            t = Random.Range(0, 4);
            
        }
        Debug.Log("t is " + t);
        var prefab = l_adenine;
        switch (t)
        {
            case 0:
                prefab = l_adenine;
                break;
            case 1:
                prefab = l_guanine;
                break;
            case 2:
                prefab = l_cytosine;
                break;
            case 3:
                prefab = l_thymine;
                break;
            default:
                prefab = l_adenine;
                break;
        }
        GameObject nitrogen = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        nitrogen.transform.SetParent(SpawnPointLead, false);
        b.Add(nitrogen);
        bNames.Add(t);
        
    }

    void ButtonClicked(int t, GameObject n)
    {
        if (bNames.Count > 0 && b.Count > 0)
        {
            int c = bNames[0];
            bNames.RemoveAt(0);
            GameObject complement = b[0];
            b.RemoveAt(0);
            bool game = false;
            switch (c)
            {
                case 0:
                    if (t!=3)
                        game= true;
                    break;
                case 1:
                    if (t!=2)
                        game = true;
                    break;
                case 2:
                    if (t!=1)
                        game = true;
                    break;
                case 3:
                    if (t!=0)
                        game = true;
                    break;
                default:
                    break;
            }

            if (game)
                GameOver();
            else
            {
                UpdateScore();
                Vector3 pos = new Vector3(2, 0, 0);
                GameObject nitrogen = Instantiate(n, pos, Quaternion.identity) as GameObject;
                nitrogen.transform.SetParent(complement.transform, false);
            }
        }
        else
        {
            GameOver();
        }
        
    }

    void UpdateScore()
    {
        Score.UpdateScore();
        textRef.text = ""+Score.GetScore();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        SceneChange.OpenGameOver();
    }

    void Pause()
    {
        Time.timeScale = 0;
        SceneChange.OpenPause();
    }

}

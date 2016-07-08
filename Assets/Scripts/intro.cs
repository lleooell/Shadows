using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class intro : MonoBehaviour {
    int level;
    public Text cred;
    Vector3 savecred;

    public Image soundbutton;
    public Sprite soundon;
    public Sprite soundoff;
    // Use this for initialization
    void Start () {
        Debug.Log(transform.rotation.ToString("F4"));
        Debug.Log(transform.position);
        level = 1;
        InvokeRepeating("nextplace", 5, 5);
        PlayerPrefs.SetInt("debugmode", 0);
        savecred = cred.transform.localScale;
        cred.transform.localScale = Vector3.zero;
    }

    public void affcred()
    {
        cred.transform.localScale = savecred;
    }

    public void hidecred()
    {
        cred.transform.localScale = Vector3.zero;
    }

    public void nextplace()
    {
        if (level == 1)
        {
            level = 2;
            transform.rotation = new Quaternion(0.0319f, -0.8939f, 0.1405f, 0.4244f);
            transform.position = new Vector3(520.1f, 95.8f, 419.9f);
        }
        else if (level == 2)
        {
            level = 3;
            transform.rotation = new Quaternion(-0.0472f, -0.7866f, -0.0534f, -0.6133f);
            transform.position = new Vector3(612.0f, 89.6f, 360.9f);
        }
        else if (level == 3)
        {
            level = 4;
            transform.position = new Vector3(467.4f, 104.7f, 557.1f);
            transform.rotation = new Quaternion(-0.0833f, 0.2204f, 0.0408f, -0.9710f);
        }
        else if (level == 4)
        {
            level = 1;
            transform.rotation = new Quaternion(-0.0424f, -0.6173f, 0.0146f, -0.7855f);
            transform.position = new Vector3(666.4f, 96.5f, 533.0f);
        }
    }

    public void run()
    {
        Application.LoadLevel("path");
    }
    public void rundebug()
    {
        PlayerPrefs.SetInt("debugmode", 1);
        Application.LoadLevel("path");
    }

    public void sound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            soundbutton.sprite = soundoff;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            PlayerPrefs.SetInt("sound", 1);
            soundbutton.sprite = soundon;
        }
    }

    public void resetsave()
    {
        PlayerPrefs.SetInt("alreadydone", 0);
        PlayerPrefs.SetInt("bestscore1", 0);
        PlayerPrefs.SetInt("bestscore2", 0);
        PlayerPrefs.SetInt("bestscore3", 0);
        PlayerPrefs.SetInt("bestscore4", 0);
    }

    public void exit()
    {
        Application.Quit();
    }

    void Update () {
        if (PlayerPrefs.GetInt("sound") == 1)
            AudioListener.volume = 1;
        else
            AudioListener.volume = 0;
        transform.rotation *= Quaternion.AngleAxis(0.05f, Vector3.up);
    }
}

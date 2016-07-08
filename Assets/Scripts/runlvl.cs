using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class runlvl : MonoBehaviour {
    public string levelname;
    public int lvl;
    public bool ll = false;
    Vector3 scalee;
    public AudioSource audios;
    int count = 20;
    // Use this for initialization
    void Start () {
        scalee = transform.localScale;
    }


    void OnMouseDown()
    {
        ll = true;
        audios.Play();
    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetInt("alreadydone") >= lvl - 1 || lvl == 1 || PlayerPrefs.GetInt("debugmode") == 1)
        {
            transform.localScale = scalee;
            if (ll == true)
            {
                if (count > 0)
                {
                    count--;
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.015f, transform.position.z);
                }
                else
                    Application.LoadLevel(levelname);
            }
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }
}

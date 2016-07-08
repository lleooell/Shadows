using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {
    public Text time;
    float timer;
    public int limitTimeSet;
    public int nbpieces;
    public int lvl;

    public AudioSource appl;
    public AudioSource appllaugh;
    public AudioSource laugh;


    bool firstwin = false;
    bool secondwin = false;

    public ParticleSystem particlewin1;
    public ParticleSystem particlewin2;


    public RectTransform c;
    public Text finaltime;
    public Text score;
    public Text wow;
    public Text bs;
    public Image s1;
    public Image s2;
    public Image s3;
    public Image s4;
    public Image s5;
    public Image winhid;
    Vector3 savecanvas;
    Sprite ww;

    int s;

    int i = 0;
    Vector3 ss = Vector3.zero;
    // Use this for initialization
    void Start () {
        timer = 0;
        savecanvas = c.transform.localScale;
        c.transform.localScale = Vector3.zero;
        ww = winhid.sprite;
    }

    void wowAmazingFunctionToShowYouYourGreatness()
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = timer % 60;
        finaltime.text = "Time : " + ((int)minutes).ToString("00") + ":" + ((int)seconds).ToString("00");
        s = ((limitTimeSet - (int)timer) * 100 / limitTimeSet);
		if (s < 0)
			s = 0;
		if (s > PlayerPrefs.GetInt("bestscore" + lvl))
            PlayerPrefs.SetInt("bestscore" + lvl.ToString(), s);
        score.text = "Score : " + s.ToString() + "%";
        if (s > 95)
            wow.text = "omg you cheat !!!";
        else if (s > 90)
            wow.text = "WOWOWOWOWOWOWOW";
        else if (s > 80)
            wow.text = "Amazing";
        else if (s > 70)
            wow.text = "Well Played !";
        else if (s > 60)
            wow.text = "Not bad at all !";
        else if (s > 50)
            wow.text = "You won !";
        else if (s > 40)
            wow.text = "Almost good";
        else if (s > 30)
            wow.text = "boah..";
        else if (s > 20)
            wow.text = "retry !";
        else if (s > 10)
            wow.text = "Can do better.";
        else
            wow.text = "First try isn't it ?";
        if (s > 30)
            appl.Play();
        else if (s > 0)
            appllaugh.Play();
        else
            laugh.Play();
        bs.text = "best score : " + PlayerPrefs.GetInt("bestscore" + lvl).ToString() + "%";
		if (s >= 50)
			PlayerPrefs.SetInt("alreadydone", lvl);
	}
	
    public void omgYouManagedToPlaceThisPieceCorrectly()
    {
        if (firstwin == false)
            firstwin = true;
        else
            secondwin = true;
        if (nbpieces == 2)
        {
            if (firstwin == true && secondwin == true)
                wowAmazingFunctionToShowYouYourGreatness();
        }
        else
            if (firstwin == true)
                wowAmazingFunctionToShowYouYourGreatness();
    }

    public void retour()
    {
        Application.LoadLevel("path");
    }

	// Update is called once per frame
	void Update () {
        if (nbpieces == 2)
        {
            if (firstwin == false || secondwin == false)
            {
                timer += Time.deltaTime;
                float minutes = Mathf.Floor(timer / 60);
                float seconds = timer % 60;
                time.text = ((int)minutes).ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            else
            {
                if (i < 60)
                {
                    ss.x = (savecanvas.x * i / 60);
                    ss.y = (savecanvas.y * i / 60);
                    ss.z = savecanvas.z;
                    i++;
                }
                else if (i < 230)
                {
                    if (i == 110)
                    {
                        if (s / 20f >= 1f)
                            s1.sprite = ww;
                    }
                    if (i == 140)
                    {
                        if (s / 20f >= 2f)
                            s2.sprite = ww;
                    }
                    if (i == 170)
                    {
                        if (s / 20f >= 3f)
                            s3.sprite = ww;
                    }
                    if (i == 200)
                    {
                        if (s / 20f >= 4f)
                            s4.sprite = ww;
                    }
                    if (i == 229)
                    {
                        if (s / 20f >= 4.8f)
                            s5.sprite = ww;
                        particlewin1.Play();
                        particlewin2.Play();
                    }
                    i++;
                }
				else
				{
					if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
					{
						Application.LoadLevel("path");
					}
				}
                c.transform.localScale = ss;
            }
        }
        else
        {
            if (firstwin == false)
            {
                timer += Time.deltaTime;
                float minutes = Mathf.Floor(timer / 60);
                float seconds = timer % 60;
                time.text = ((int)minutes).ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            else
            {
                if (i < 60)
                {
                    ss.x = (savecanvas.x * i / 60);
                    ss.y = (savecanvas.y * i / 60);
                    ss.z = savecanvas.z;
                    i++;
                }
                else if (i < 230)
                {
                    if (i == 110)
                    {
                        if (s / 20f >= 1f)
                            s1.sprite = ww;
                    }
                    if (i == 140)
                    {
                        if (s / 20f >= 2f)
                            s2.sprite = ww;
                    }
                    if (i == 170)
                    {
                        if (s / 20f >= 3f)
                            s3.sprite = ww;
                    }
                    if (i == 200)
                    {
                        if (s / 20f >= 4f)
                            s4.sprite = ww;
                    }
                    if (i == 229)
                    {
                        if (s / 20f >= 4.8f)
                            s5.sprite = ww;
                        particlewin1.Play();
                        particlewin2.Play();
                    }
                    i++;
                }
				else
				{
					if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
					{
						Application.LoadLevel("path");
					}
				}
                c.transform.localScale = ss;
            }
        }
    }
}

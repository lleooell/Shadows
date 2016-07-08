using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class help : MonoBehaviour {
    public Text one;
    public Text two;
    public Text three;
    public Sprite ori;
    public Sprite sel;
    public Image me;
    Vector3 savescale;
    // Use this for initialization
    void Start () {
        savescale = one.transform.localScale;
        hide_help();
    }

    void OnMouseDown()
    {
        show_help();
    }

    void OnMouseUp()
    {
        hide_help();
    }

    public void overenter()
    {
        me.sprite = sel;
    }

    public void overexit()
    {
        me.sprite = ori;
    }

    public void show_help()
    {
        one.transform.localScale = savescale;
        if (two)
            two.transform.localScale = savescale;
        if (three)
            three.transform.localScale = savescale;
    }

    public void hide_help()
    {
        one.transform.localScale = Vector3.zero;
        if (two)
            two.transform.localScale = Vector3.zero;
        if (three)
            three.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

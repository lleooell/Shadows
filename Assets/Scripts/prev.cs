using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class prev : MonoBehaviour {
    public Camera_movement c;
    public Sprite selc;
    public Sprite ori;
    public Image me;
    // Use this for initialization
    void Start () {
	
	}

    void OnMouseDown()
    {
        c.prevLevel();
    }

    public void selcd()
    {
        me.sprite = selc;
    }
    public void selcn()
    {
        me.sprite = ori;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

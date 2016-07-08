using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class next : MonoBehaviour {
    public Sprite selc;
    public Sprite ori;
    public Image me;
    public Camera_movement c;
    // Use this for initialization
    void Start () {
	
	}

    void OnMouseDown()
    {
        c.nextLevel();
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

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bigonhover : MonoBehaviour {
    Vector3 sc;
	// Use this for initialization
	void Start () {
        sc = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sc = new Vector3(1.2f, 1.2f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sc = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update () {
	    if (sc != transform.localScale)
        {
            Vector3 tmp;
            tmp.x = transform.localScale.x + (sc.x - transform.localScale.x) / 10;
            tmp.y = transform.localScale.y + (sc.y - transform.localScale.y) / 10;
            tmp.z = transform.localScale.z;
            transform.localScale = tmp;
        }
	}
}

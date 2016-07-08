using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class drag : MonoBehaviour {

    // Use this for initialization
    public int rot;
    public Text percent;
    bool selected = false;
    public bool move;
    Vector3 savepos;
    Quaternion saverot;
    public Level1 l;
    bool alreadywin = false;

    void Start () {
        savepos = transform.position;
        saverot = transform.rotation;
        float x = Random.Range(-10,10);
        float y = Random.Range(0, 4);
        if (move == true)
            transform.position = new Vector3(transform.position.x + x/9f, transform.position.y + y/4f, transform.position.z);
		x = Random.Range(50,90);
		transform.rotation *= Quaternion.AngleAxis(x, Vector3.right);
        if (rot == 2)
			transform.rotation *= Quaternion.AngleAxis(x, Vector3.up);
    }

    bool compare_position(Vector3 pos)
    {
        if (pos.x > savepos.x - 0.09f && pos.x < savepos.x + 0.09f)
        {
            if (pos.y > savepos.y - 0.09f && pos.y < savepos.y + 0.09f)
            {
                return true;
            }
        }
        return false;
    }

    bool compare_xy_rotation(float x, float y)
    {
        float angle = Quaternion.Angle(transform.rotation, saverot);
        int p = 100 - ((int)angle) * 100 / 180;
        percent.text = p.ToString() + "%";
        if (angle < 8f)
            return true;
        /*if (x > saverot.x - 0.01f && x < saverot.x + 0.01f)
        {
            if (y > saverot.y - 0.01f && y < saverot.y + 0.01f)
            {
                Debug.Log("rot ok");
                return true;
            }
        }*/
        return false;
    }

    void OnMouseDown()
    {
        selected = true;
    }

    void OnMouseUp()
    {
        selected = false;
    }


    // Update is called once per frame
    void Update () {
        if (compare_xy_rotation(transform.rotation.x, transform.rotation.y) == false || compare_position(transform.position) == false)
        {
            RaycastHit hit;
            if (selected == true)
            {
                if (Input.GetMouseButton(0))
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        float x = -Input.GetAxis("Mouse X");
                        float y = -Input.GetAxis("Mouse Y");
                        float speed = 10;
                        if (!(Input.GetKey(KeyCode.LeftControl)) && !(Input.GetKey(KeyCode.LeftShift)))
                            transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.right);
                        else if (rot == 2 && !(Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.LeftControl)))
                            transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.up);
                        else if (Input.GetKey(KeyCode.LeftShift) && move == true)
                            transform.position -= new Vector3(x / 10, y / 10, 0f);
                    }
                }
            }
        }
        else
        {
            if (alreadywin == false)
            {
                alreadywin = true;
                l.omgYouManagedToPlaceThisPieceCorrectly();
            }
        }
    }
}

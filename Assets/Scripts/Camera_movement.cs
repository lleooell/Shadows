using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Camera_movement : MonoBehaviour {

    Vector3 pos;
    Vector3 destpos;
    int level;
    public Text levelname;



    Quaternion targetRotation;
    float turnSpeed = 0f;
    float turnSpeedChange = 100f;
    Transform rotatingTransform;


    // Use this for initialization
    void Start () {
        pos = transform.position;
        destpos = transform.position;
        targetRotation = transform.rotation;
        level = 1;
        levelname.text = "trunk";
    }

    public void nextLevel()
    {
        if (!cmp(pos, transform.position))
            return;
        if (level == 1)
        {
            level = 2;
            levelname.text = "scop";
            destpos = new Vector3(175.2f, 38.2f, 138.9f);
            targetRotation = new Quaternion(0.1f, -0.8f, 0.2f, 0.5f);
        }
        else if (level == 2)
        {
            level = 3;
            levelname.text = "the answer";
            targetRotation = new Quaternion(0.0514f, 0.9164f, -0.3586f, 0.1703f);
            destpos = new Vector3(320.3f, 40.5f, 132.8f);
        }
        else if (level == 3)
        {
            level = 4;
            levelname.text = "Australie!";
            destpos = new Vector3(154.1f, 32.2f, 318.2f);
            targetRotation = new Quaternion(0.2f, -0.3f, 0.1f, 0.9f);
        }
        else if (level == 4)
        {
            level = 1;
            levelname.text = "trunk";
            targetRotation = new Quaternion(0.2057f, 0.4290f, -0.0913f, 0.8748f);
            destpos = new Vector3(338.3f, 24.1f, 271.1f);
        }
    }

    public void prevLevel()
    {
        if (!cmp(pos, transform.position))
            return;
        if (level == 1)
        {
            level = 4;
            levelname.text = "Australie!";
            destpos = new Vector3(154.1f, 32.2f, 318.2f);
            targetRotation = new Quaternion(0.2f, -0.3f, 0.1f, 0.9f);
        }
        else if (level == 2)
        {
            level = 1;
            levelname.text = "trunk";
            targetRotation = new Quaternion(0.2057f, 0.4290f, -0.0913f, 0.8748f);
            destpos = new Vector3(338.3f, 24.1f, 271.1f);
        }
        else if (level == 3)
        {
            level = 2;
            levelname.text = "scop";
            destpos = new Vector3(175.2f, 38.2f, 138.9f);
            targetRotation = new Quaternion(0.1f, -0.8f, 0.2f, 0.5f);
        }
        else if (level == 4)
        {
            level = 3;
            levelname.text = "the answer";
            targetRotation = new Quaternion(0.0514f, 0.9164f, -0.3586f, 0.1703f);
            destpos = new Vector3(320.3f, 40.5f, 132.8f);
        }
    }

    public void retour()
    {
        Application.LoadLevel("Start");
    }

    bool cmp(Vector3 a, Vector3 b)
    {
        if (a.x < b.x + 1f && a.x > b.x - 1f &&
            a.y < b.y + 1f && a.y > b.y - 1f &&
            a.z < b.z + 1f && a.z > b.z - 1f)
        {
            pos = transform.position;
            return true;
        }
        return false;
    }


    void Update()
    {
        if (!cmp(transform.position, destpos))
        {
            Vector3 coef = new Vector3();
            float dist = destpos.x - pos.x;
            float add = dist / 100f;
            coef.x = add;
            dist = destpos.y - pos.y;
            add = dist / 100f;
            coef.y = add;
            dist = destpos.z - pos.z;
            add = dist / 100f;
            coef.z = add;
            transform.position += coef;
        }
        float angleToTurn = Quaternion.Angle(transform.rotation, targetRotation);
        turnSpeed = Mathf.Min(angleToTurn, turnSpeed + turnSpeedChange * Time.fixedDeltaTime * 1.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Mathf.Clamp01(angleToTurn > 0 ? turnSpeed * Time.fixedDeltaTime * 1.5f/ angleToTurn : 0f));
    }
}

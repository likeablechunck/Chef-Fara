using UnityEngine;
using System.Collections;

public class CockroachHorizontalMovement : MonoBehaviour
{
    Vector3 direction;
    public Vector3 buffer = new Vector3(0.05f, 0, 0);
    public Vector3 originalPosition = new Vector3(-5, .47f, 4.09f);
    public Vector3 leftmostPosition = new Vector3(-6, .47f, 4.09f);
    public Vector3 rightmostPosition = new Vector3(-1, .47f, 4.09f);

    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.position = originalPosition;
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("mouse").GetComponent<PlayerMove>().timeIsUp)
        {
            return;
        }
        Vector3 currentPosition = this.transform.position;
        //it is ok to store the position into a new variable BUT it can be only read and if you want to change it
        //you should tale the origininal gameObject.transform.position
        if (currentPosition.x >= rightmostPosition.x)
        {
            direction = -1 * direction;
            this.transform.position = rightmostPosition - buffer;
        }

        else if (currentPosition.x <= leftmostPosition.x)
        {
            direction = -1 * direction;
            this.transform.position = leftmostPosition + buffer;
        }
        else
        {
            transform.Translate(direction * Time.deltaTime);
        }
    }
}

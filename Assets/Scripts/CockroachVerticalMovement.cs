using UnityEngine;
using System.Collections;

public class CockroachVerticalMovement : MonoBehaviour
{

    Vector3 direction;
    public Vector3 buffer = new Vector3(0, 0, 0.05f);
    public Vector3 originalPosition = new Vector3(-6.11f, .55f, 0);
    public Vector3 bottomMostPosition = new Vector3(-6.11f, 0.55f, -7.24f);
    public Vector3 topMostPosition = new Vector3(-6.11f, 0.55f, -0.45f);

    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.position = originalPosition;
        direction = new Vector3(0, 0, 1);
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
        if (currentPosition.z >= topMostPosition.z)
        {
            direction = -1 * direction;
            this.transform.position = topMostPosition - buffer;
        }

        else if (currentPosition.z <= bottomMostPosition.z)
        {
            direction = -1 * direction;
            this.transform.position = bottomMostPosition + buffer;
        }
        else
        {
            transform.Translate(direction * Time.deltaTime);
        }
    }
}

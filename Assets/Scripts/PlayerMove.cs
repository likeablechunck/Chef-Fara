using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public int speed = 5;
    int objectsPickedUp;
    public int totalTime = 40;
    float timeLeft;
    float timeBarLength;
    public bool timeIsUp = false;

	// Use this for initialization
	void Start ()
    {
        objectsPickedUp = 0;
        timeLeft = totalTime;
	}

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            // halt this game
            timeIsUp = true;
            return;
        }

        if(objectsPickedUp == 5)
        {
            timeIsUp = true;
            return;
        }
        //using Axis to move the player
        this.gameObject.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        /*        if (Input.GetKey(KeyCode.UpArrow))
                {
                    //transform.Rotate(Vector3.forward * Time.deltaTime*180);
                    //transform.Rotate(0, 0, 180);
                    transform.rotation = Quaternion.AngleAxis(180, new Vector3(1, 0, 1));
                }
        */

        //rotating the player so the sprite can face the right direction
/*        Vector3 moveDirection = GetComponent<Rigidbody>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, new Vector3(1, 0, 0));
            //transform.Rotate(0, angle, 0);

        }
*/
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "tomato" || col.gameObject.name == "top_bread"
            || col.gameObject.name == "cheese" || col.gameObject.name == "patty"
            || col.gameObject.name == "bottom_bread")
        {
            objectsPickedUp++;
            Debug.Log("Number of picked up items : " + objectsPickedUp);
            col.gameObject.SetActive(false);
        } else if (col.gameObject.name.Contains("Cockroach"))
        {
            timeLeft = timeLeft - 2.0f;
        }
    }

    //displaying the timer as a healthbar 
    void OnGUI()
    {
        // Make a background box
        if (timeLeft <= 0)
        {
            GUI.Box(new Rect(10, 10, timeBarLength, 20), "");
        }
        else
        {
            timeBarLength = (Screen.width ) * (timeLeft / (float)totalTime);
            GUI.Box(new Rect(10, 10, timeBarLength, 20), "");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public Transform circle;
    public Transform backCircle;
    public Vector3 PointA;
    public Vector3 PointB;
    Vector2 distance;
    public bool isJoystick;
    // Start is called before the first frame update
    void Start()
    {

        isJoystick = true;
        circle.gameObject.SetActive(false);
        backCircle.gameObject.SetActive(false);
        circle.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        backCircle.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x <= (Screen.width / 5) * 2)
            {
                circle.gameObject.SetActive(true);
                backCircle.gameObject.SetActive(true);
                PointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
                circle.transform.position = PointA - new Vector3(0, 0, PointA.z);
                backCircle.transform.position = PointA - new Vector3(0, 0, PointA.z);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            PointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));


        }
        else if (Input.GetMouseButtonUp(0))
        {
            circle.gameObject.SetActive(false);
            backCircle.gameObject.SetActive(false);
            PointB = PointA;
            circle.transform.position = backCircle.transform.position;
        }
        
    }
    private void FixedUpdate()
    {
        if(isJoystick)
        {
            Vector2 offset = PointB - PointA;
            
            distance = Vector2.ClampMagnitude(offset,1f);
            circle.transform.position = backCircle.transform.position + new Vector3(distance.x, distance.y, 0);
        }
    }
}

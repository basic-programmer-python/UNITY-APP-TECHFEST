using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector3 j;

    public Transform circle;
    public Transform outerCircle;
    void Start()
    {
        j = new Vector3(-6, -3, 0);
        circle.transform.position = new Vector3(-6.6f, -2.7f, 0);
        outerCircle.transform.position = j;
        circle.GetComponent<SpriteRenderer>().enabled = true;
        outerCircle.GetComponent<SpriteRenderer>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            //circle.transform.position = pointA * -1;
            //outerCircle.transform.position = pointA * 1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * 1);

            //circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
            circle.transform.position = new Vector2(j.x + direction.x, j.y + direction.y) * 1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 800f;

    public float sidewayForce = 50f;

    public float tilt = 3;

    public Touch oldTouch;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Started");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                oldTouch = t;
            }
            if (t.phase == TouchPhase.Ended)
            {
                rb.AddForce(0, 0, 0, ForceMode.VelocityChange);
            }
            if (t.phase == TouchPhase.Moved && t.position.x > oldTouch.position.x)
            {
                oldTouch = t;
                rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (t.phase == TouchPhase.Moved && t.position.x < oldTouch.position.x)
            {
                oldTouch = t;
                rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void Update()
    {

    }
}

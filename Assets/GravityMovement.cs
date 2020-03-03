using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    public enum type { platformer, topDown };
    public type moveType;
    public float moveSpeed, jumpHeight;
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }

        if (moveType == type.platformer && Input.GetAxisRaw("Vertical") > 0 && onGround)
        {
            Vector3 scaling = transform.localScale;
            scaling.y *= -1;
            transform.localScale = scaling;
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }

    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }
    //             Vector3 scaling = transform.localScale;
    //scaling.y *= -1;
    //        transform.localScale = scaling;
    //        GetComponent<Rigidbody2D>().gravityScale *= -1;
}
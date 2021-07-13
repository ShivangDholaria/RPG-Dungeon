using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private BoxCollider2D boxCollider;

    //Collision detection 
    private RaycastHit2D hit;

    //Player movement variable
    private Vector3 moveDelta;
    [SerializeField]
    private float speed;


    void Start()
    {
        //Getting box collider from the GameObject
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Getting input from user for movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset MoveDelta after each frame
        moveDelta = new Vector3(x, y, 0);

        //Swapping sprite direction for left-rigth movement
        if (moveDelta.x > 0)
            //Right facing direction of sprite
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            //Left facing direction of sprite
            transform.localScale = new Vector3(-1, 1, 1);


        //Getting collision information by casting box
        //Param 1: position - position of origin of box
        //Param 2: size - size of the box
        //Param 3: angle - angle of box
        //Param 4: direction - vector representation of box
        //Param 5: distance - distance to which the box is casted
        //Param 6: layermask - layermask on which to detect collision
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime * speed), LayerMask.GetMask("Actor", "Blocking"));

        //Collision check for movement
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime * speed, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime * speed), LayerMask.GetMask("Actor", "Blocking"));

        //Collision check for movement
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime * speed, 0, 0);
        }    
    
    }
}

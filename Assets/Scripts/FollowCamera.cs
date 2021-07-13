using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Camera target to look at it
    public Transform looAt;

    //View bounds of camera for it to move
    public float bound_X = .15f
                , bound_Y = .05f; 

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //X coordinate postion check of player
        float del_X = looAt.position.x - transform.position.x;

        //X bound check
        if (del_X > bound_X || del_X < -bound_X)
        {
            //Left Rigth direction check
            if (transform.position.x < looAt.position.x)
            {
                delta.x = del_X - bound_X;
            }
            else
                delta.x = del_X + bound_X;
        }

        //Y coordinate postion check of player
        float del_Y = looAt.position.y - transform.position.y;

        //X bound check
        if (del_Y > bound_Y || del_Y < -bound_Y)
        {
            //Left Rigth direction check
            if (transform.position.y < looAt.position.y)
            {
                delta.y = del_Y - bound_Y;
            }
            else
                delta.y = del_Y + bound_Y;
        }

        //Move Camera 
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
   
    private Vector2 direction = Vector2.right;

    private void Update() { 
        
        if(Input.GetKeyDown(KeyCode.W)) {
            if(!(direction == Vector2.down))
                direction = Vector2.up;
        } else if(Input.GetKeyDown(KeyCode.S)) {
            if(!(direction == Vector2.up))
                direction = Vector2.down;
        } else if(Input.GetKeyDown(KeyCode.A)) {
            if(!(direction == Vector2.right))
                direction = Vector2.left;
        } else if(Input.GetKeyDown(KeyCode.D)) {
            if(!(direction == Vector2.left))
                direction = Vector2.right;

        }
        

    }

    private void FixedUpdate() {
        
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
        

    }

}

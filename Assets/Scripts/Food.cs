using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    [SerializeField]
    private BoxCollider2D gridArea;
    private string SNAKE_TAG = "Snake";


    private void Start() {
        
        RandomFoodPosition();

    }

    private void RandomFoodPosition() {

        Bounds bound = this.gridArea.bounds;

        float foodPositionX = Random.Range(bound.min.x, bound.max.x);
        float foodPositionY = Random.Range(bound.min.y, bound.max.y);

        this.transform.position = new Vector3(Mathf.Round(foodPositionX), Mathf.Round(foodPositionY), 0.0f );

    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if((collider.tag == SNAKE_TAG)) {

            RandomFoodPosition();

        }
        
    }
    
}

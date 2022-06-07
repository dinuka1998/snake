using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{

    [SerializeField]
    private BoxCollider2D gridArea;

    [SerializeField]
    private Text scoreCout;
    private string SNAKE_TAG = "Snake";

    private int score = 0;


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
            CalculateScore();

        }
        
    }

    private void CalculateScore() {

        score++;
        scoreCout.text = score.ToString();

    }

    public int GetScore() {

        return score;

    }
    
}

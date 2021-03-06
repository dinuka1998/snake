using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
   
    private Vector2 direction = Vector2.right;
    [SerializeField]
    private List<Transform> segments;
    [SerializeField]
    private Transform segmentPrefab;
    [SerializeField]
    private GameObject snaketail;
    private string FOOD_TAG = "Food";
    private string OBSTACLE_TAG = "Obstacle";
    private bool isGameOver = false;
    [SerializeField]
    private Text gameOverScore;
    [SerializeField]
    private GameObject gameOverUI;

    

    private Food food;

    private void Awake() {
        
        food = FindObjectOfType<Food>();
        gameOverUI.SetActive(false);

    }
    

    private void Start() {
    
        segments = new List<Transform>();
        segments.Add(this.transform);
        Transform tail = Instantiate(snaketail.transform);
        tail.transform.position = segments[segments.Count -1].position;
        segments.Add(tail.transform);
        
    }

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

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        
        if(!isGameOver){

            this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f

        );

        }
        
        

    }

    private  void Grow() {

        if(!snaketail)
            Destroy(snaketail);
        else{
           
            Transform tempTail = segments[segments.Count -1];
            segments.RemoveAt(segments.Count -1);
             Destroy(tempTail.gameObject);
        }
        
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count -1].position;
        Transform tail = Instantiate(snaketail.transform);
        tail.position = segments[segments.Count -1].position;
        segments.Add(segment);
        segments.Add(tail.transform);

        

    }


    private void OnTriggerEnter2D(Collider2D collider) {

        if((collider.tag == FOOD_TAG)) {

            Grow();

        }
        else if (collider.tag == OBSTACLE_TAG) {
            GameOver();
        }
        
    }

    private void GameOver() {

            isGameOver = true;
            gameOverUI.SetActive(true);
            gameOverScore.text = ("Score : " + food.GetScore().ToString());

    }

}

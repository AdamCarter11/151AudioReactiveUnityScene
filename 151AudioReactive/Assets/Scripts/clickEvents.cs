using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickEvents : MonoBehaviour
{
    public static int score = 0;
    public static Text scoreText;
    private bool canPlayerHit = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        /*
        if(other.gameObject.CompareTag("SpawnedObject") && Input.GetKeyDown(KeyCode.Space)){
            print("HIT");
            score++;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        */
    }
}

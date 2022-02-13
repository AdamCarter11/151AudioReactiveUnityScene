using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickEvents : MonoBehaviour
{
    public static int score = 0;
    public int multiplier = 0;
    public int maxMultiplier = 8;
    public static Text scoreText;
    public static Text multiplierText;
    private bool canPlayerHit = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        multiplierText = GameObject.Find("Multipier").GetComponent<Text>();
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

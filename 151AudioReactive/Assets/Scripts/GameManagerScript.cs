using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public int multiplier = 1;
    public int maxMultiplier = 8;
    public static Text scoreText;
    public static Text multiplierText;

    public bool hit = false;
    public bool attemptedHit = false; 

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        multiplierText = GameObject.Find("Multiplier").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // checking if the player pressed space, and missed; decreasing score if so
        // not sure if this works 100% correctly, as it relies on this update() running before the notes' update()
        if (attemptedHit && !hit)
        {
            incrementScore(-1);
            resetMultiplier();
        }
        attemptedHit = false;
        hit = false;
    }

    // increments Score by x
    public void incrementScore(int x)
    {
        score += x;
        scoreText.text = "Score: " + score;
    }

    // increments Multiplier by x, unless it would exceed maxMultiplier
    public void incrementMultiplier(int x)
    {
        if (multiplier < maxMultiplier)
        {
            multiplier += x;
            multiplierText.text = "Multiplier: x" + multiplier ;
        }
    }

    // sets score back to 0
    public void resetMultiplier()
    {
        multiplier = 1;
        multiplierText.text = "Multiplier: x" + multiplier;
    }

}

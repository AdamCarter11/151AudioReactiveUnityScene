using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedObject : MonoBehaviour
{
    private GameObject objectToMoveTo;
    private GameManagerScript GM;
    private float speed = .01f;
    private float startTime;
    private float tripLength;
    private bool canPlayerHit = false;
    // Start is called before the first frame update
    void Start()
    {
        // acquiring GameplayManager
        GM = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        objectToMoveTo = GameObject.FindGameObjectWithTag("target");
        if(objectToMoveTo == null){
            Destroy(gameObject);
        }
        startTime = Time.time;
        tripLength = Vector3.Distance(transform.position, objectToMoveTo.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distCov = (Time.time - startTime) * speed;
        float partOfTrip = distCov / tripLength;

        transform.position = Vector3.Lerp(transform.position, objectToMoveTo.transform.position, partOfTrip);

        if(canPlayerHit && Input.GetKeyDown(KeyCode.Space)){
            print("HIT");
            GM.incrementScore(1 * GM.multiplier);
            GM.incrementMultiplier(1);
            GM.hit = true;
            Destroy(gameObject);
        } 

        // this should probably be integrated into the other if statement, but it'd be confusing and I'm lazy
        if (Input.GetKeyDown(KeyCode.Space) && !canPlayerHit)
        {
            GM.attemptedHit = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("target")){
            GM.incrementScore(-1);
            GM.resetMultiplier();
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("area")){
           canPlayerHit = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("area")){
            canPlayerHit = false;
        }
    }
}

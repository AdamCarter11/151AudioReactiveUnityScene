using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedObject : MonoBehaviour
{
    private GameObject objectToMoveTo;
    private float speed = .01f;
    private float startTime;
    private float tripLength;

    // Start is called before the first frame update
    void Start()
    {
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
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("target")){
            Destroy(gameObject);
        }
    }
    
}

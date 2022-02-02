using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : AudioEvents
{
    private int whereToSpawn = 0;
    private Vector3 spawnVec;
    [SerializeField] private GameObject objectToSpawn;
    void Start()
    {
        
    }

    
    public override void UpdateEffects()
	{
		base.UpdateEffects();

		if (beat) return;
    }

    public override void OnBeat(){
        base.OnBeat();

        if(whereToSpawn == 0){
            spawnVec = new Vector3(-11, 0, 1);
        }
        else if(whereToSpawn == 1){
            spawnVec = new Vector3(0, 4.5f, 1);
        }
        else if(whereToSpawn == 2){
            spawnVec = new Vector3(11, 0, 1);
        }
        else{
            spawnVec = new Vector3(0, -4.5f, 1);
        }

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnVec, Quaternion.identity);
        whereToSpawn++;
        if(whereToSpawn>3){
            whereToSpawn = 0;
        }
    }
}

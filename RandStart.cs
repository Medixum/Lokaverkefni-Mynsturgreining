using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandStart : MonoBehaviour //skrifað af ChatGPT
{
    public Transform objectToPlace; // the object to place on the unit circle
    

    public void Randomize()
    {        
	    
            float angle = Random.Range(0f, 2f * Mathf.PI); // generate a random angle in radians
	    
            Vector3 place = new Vector3(Mathf.Cos(angle)*50, 8, Mathf.Sin(angle)*50); // calculate position on unit circle
            objectToPlace.localPosition = place; // place the object at the random position
        
    }
}
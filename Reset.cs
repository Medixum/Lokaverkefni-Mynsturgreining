using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject[] hlutar;
    public Vector3[] Stadsett;
    public Quaternion[] Snuning;
    public bool test;
    public bool started = true;
    
    
    
    void Start()
    {
	if(started){
	    started = false;
	    Stadsett = new Vector3[hlutar.Length];
	    Snuning = new Quaternion[hlutar.Length];
            for(int i = 0; i < hlutar.Length; i++) {
	        Stadsett[i] = hlutar[i].transform.localPosition;
	        Snuning[i] = hlutar[i].transform.localRotation; 
	    }
	}
    }

    void Update(){ 
	if(test){
	    endursett();
	    test = false; 
	}
    }    
    public void endursett()
    {
	for(int i = 0; i < hlutar.Length; i++){
	    
	    hlutar[i].transform.localPosition = Stadsett[i];
	    hlutar[i].transform.localRotation = Snuning[i];
	}
    }
}

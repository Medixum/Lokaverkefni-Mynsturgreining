using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Linq;
using System;
public class Walker : Agent
{
    public GameObject Labbari;
    private Movement movement;
    private Observer observer;
    private RandStart randStart;
    private Reset reset;
    public float[] gildi;
    public float[] control;
    public bool end = false; 
    private float[] oldGildi;
    private int timi = 0;

    
    public override void Initialize()
    {
	  observer = Labbari.GetComponent<Observer>();
        movement = Labbari.GetComponent<Movement>();
        randStart = Labbari.GetComponent<RandStart>();
	  reset = Labbari.GetComponent<Reset>();
        oldGildi = new float[52];
	  oldGildi = observer.ObservationSpace;
	
        base.Initialize();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        gildi = observer.ObservationSpace;
        sensor.AddObservation(gildi);
	  sensor.AddObservation(oldGildi);
	  sensor.AddObservation(timi);
	  oldGildi=gildi;
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float mark = 0;
	float fall = 0;
        control = actions.ContinuousActions.Array;
        movement.motorSpeeds = control;
        if (gildi[51] < 8) //markmiði náð
	{ 
            mark = 10000;
	    end = true;
	    print("MARK!");
        } else 
	{
            mark = 0;
        }
	if (gildi[4] < 4) // hrasaði
	{ 
            fall = -100;
	    end = true;
	    
        } else 
	{
            fall = 0;
        }
	
	timi++;
	if (timi > 3000) { end = true;}
        float verd = (100-gildi[51]) + mark + fall;
	
        SetReward(verd);
	if (end){ EndEpisode(); }
    }
    public override void OnEpisodeBegin() 
    { 
      timi = 0;
	oldGildi = observer.ObservationSpace;
	end = false;
	reset.endursett();
	randStart.Randomize();
	float[] myArray = new float[15];
	Array.Fill(myArray, 0f);
	movement.motorSpeeds = myArray;
    }
}
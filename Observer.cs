using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour //gert með chatGPT
{
    public GameObject[] gameObjects;
    public float[] ObservationSpace;

    void Update()
    {
        int numObjects = gameObjects.Length;
        int numCoordinates = 3; // x, y, z
        ObservationSpace = new float[numObjects * numCoordinates + 1];

        for (int i = 0; i < numObjects; i++)
        {
            Vector3 position = gameObjects[i].transform.localPosition;
            int startIndex = i * numCoordinates;

            ObservationSpace[startIndex] = position.x;
            ObservationSpace[startIndex + 1] = position.y;
            ObservationSpace[startIndex + 2] = position.z;
        }

        float distance = Vector3.Distance(gameObjects[0].transform.localPosition, gameObjects[numObjects - 1].transform.localPosition);
        ObservationSpace[numObjects * numCoordinates] = distance;
    }
}
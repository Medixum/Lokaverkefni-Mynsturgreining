using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour //made with ChatGPT 
{
    public GameObject[] objects;
    private HingeJoint[][] joints;
    [SerializeField] public float[] motorSpeeds;

    private void Start()
    {
        joints = new HingeJoint[objects.Length][];
        for (int i = 0; i < objects.Length; i++)
        {
            joints[i] = objects[i].GetComponents<HingeJoint>();
        }

        motorSpeeds = new float[CountJoints()];
    }

    private void Update()
    {
        int k = 0;
        for (int i = 0; i < joints.Length; i++)
        {
            for (int j = 0; j < joints[i].Length; j++)
            {
                if (joints[i][j] != null)
                {
                    JointMotor motor = joints[i][j].motor;
                    motor.targetVelocity = Mathf.Clamp(motorSpeeds[k]*720f, -720f, 720f);
                    joints[i][j].motor = motor;
                    k++;
                }
            }
        }
    }

    public int CountJoints()
    {
        int count = 0;
        for (int i = 0; i < joints.Length; i++)
        {
            for (int j = 0; j < joints[i].Length; j++)
            {
                if (joints[i][j] != null)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class IK_Manager : MonoBehaviour
{
    public RobotJoint[] joints;
    public Transform target;
    private float error = 0.0059f;
    
    private void Start()
    {
        Vector3 endEffectorPos = ForwardKinematics(new float[4] { -86.4f, 40.66f, -80.9f, 0 });
        float distance = Vector3.Distance(target.position, endEffectorPos);        

        if (distance <= error)
        {
            Debug.Log("Touching target");
        }
        else
        {
            Debug.Log("Not touching target");
        }
    }

    public Vector3 ForwardKinematics(float[] angles)
    {
        Vector3 prevPoint = joints[0].transform.position;
        Quaternion rotation = Quaternion.identity;
        for (int i = 1; i < joints.Length; i++)
        {
            // Rotates around a new axis
            rotation *= Quaternion.AngleAxis(angles[i - 1], joints[i - 1].Axis);
            Vector3 nextPoint = prevPoint + rotation * joints[i].StartOffset;

            prevPoint = nextPoint;
        }
        return prevPoint;
    }
}


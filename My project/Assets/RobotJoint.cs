using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotJoint : MonoBehaviour
{
    public Vector3 Axis;
    [HideInInspector] public Vector3 StartOffset;
    void Awake()
    {
        StartOffset = transform.localPosition;
    }
}

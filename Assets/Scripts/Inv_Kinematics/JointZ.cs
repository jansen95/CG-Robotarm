using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointZ : MonoBehaviour
{
    public JointZ m_child;

    public JointZ GetChild()
    {
        return m_child;
    }

    public void Rotate(float _angle)
    {
        transform.Rotate(Vector3.forward * _angle);
    }
}

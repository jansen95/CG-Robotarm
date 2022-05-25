using UnityEngine;

public class IKManagerZ : MonoBehaviour
{
    public JointZ m_root;

    public JointZ m_end;

    public GameObject m_target;

    public float m_threshold = 0.05f;

    public float m_rate = 5f;
    
    float CalculateSlope(JointZ _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_end.transform.position, m_target.transform.position);
        
        _joint.Rotate(deltaTheta);

        float distance2 = GetDistance(m_end.transform.position, m_target.transform.position);
        
        _joint.Rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }
    
    private void Update()
    {
        if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
        {
            JointZ current = m_root;
            while (current != null)
            {
                float slope = CalculateSlope(current);
                current.Rotate(-slope * m_rate);
                current = current.GetChild();
            }
        }
    }
    
    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }
}

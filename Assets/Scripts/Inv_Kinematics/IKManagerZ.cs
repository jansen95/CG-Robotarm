using UnityEngine;

namespace Inv_Kinematics
{
    public class IKManagerZ : MonoBehaviour
    {
        public JointZ root;

        public JointZ end;

        public GameObject target;

        public float threshold = 0.05f;

        public float rate = 5f;
    
        float CalculateSlope(JointZ joint)
        {
            float deltaTheta = 0.01f;
            float distance1 = GetDistance(end.transform.position, target.transform.position);
        
            joint.Rotate(deltaTheta);

            float distance2 = GetDistance(end.transform.position, target.transform.position);
        
            joint.Rotate(-deltaTheta);

            return (distance2 - distance1) / deltaTheta;
        }
    
        private void Update()
        {
            if (GetDistance(end.transform.position, target.transform.position) > threshold)
            {
                JointZ current = root;
                while (current != null)
                {
                    float slope = CalculateSlope(current);
                    current.Rotate(-slope * rate);
                    current = current.GetChild();
                }
            }
        }
    
        float GetDistance(Vector3 point1, Vector3 point2)
        {
            return Vector3.Distance(point1, point2);
        }
    }
}

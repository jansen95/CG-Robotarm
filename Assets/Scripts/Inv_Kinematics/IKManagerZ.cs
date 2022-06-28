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
        
        public GameObject cameraSensor;

        public CameraSensor _cameraSensor;
        
        public Vector3 _soldierCoordinates;
        
        
        
        float CalculateSlope(JointZ joint)
        {
            float deltaTheta = 0.01f;
            float distance1 = GetDistance(end.transform.position, _soldierCoordinates);
        
            joint.Rotate(deltaTheta);

            float distance2 = GetDistance(end.transform.position, _soldierCoordinates);
        
            joint.Rotate(-deltaTheta);

            return (distance2 - distance1) / deltaTheta;
        }
        
        private void Start()
        {
            cameraSensor = GameObject.Find("Robot Camera");
            _cameraSensor = cameraSensor.GetComponent<CameraSensor>();
            _soldierCoordinates = _cameraSensor.soldierCoordinates;
        }
    
        private void Update()
        {
            _soldierCoordinates = _cameraSensor.soldierCoordinates;
            if (GetDistance(end.transform.position, _soldierCoordinates) > threshold)
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

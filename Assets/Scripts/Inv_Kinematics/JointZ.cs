using UnityEngine;

namespace Inv_Kinematics
{
    public class JointZ : MonoBehaviour
    {
        public JointZ child;
        public float minRotation;
        public float maxRotation;
        
        public JointZ GetChild()
        {
            return child;
        }

        public void Rotate(float angle)
        {
            transform.Rotate(Vector3.forward * angle);
            Vector3 currentRotation = transform.localRotation.eulerAngles;
            currentRotation.z = Mathf.Clamp(ConvertToAngle180(currentRotation.z), minRotation, maxRotation);
            transform.localRotation = Quaternion.Euler (currentRotation);
        }
        
        public static float ConvertToAngle180(float input)
        {       
            while (input > 360)
            {
                input = input - 360;
            } 
            while (input < -360)
            {
                input = input + 360;
            }
            if (input > 180)
            {
                input = input - 360;        
            }
            if (input < -180)
                input = 360+ input;
            return input;
        }
    }
}

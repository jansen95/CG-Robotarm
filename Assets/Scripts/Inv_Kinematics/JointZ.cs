using UnityEngine;

namespace Inv_Kinematics
{
    public class JointZ : MonoBehaviour
    {
        public JointZ child;

        public JointZ GetChild()
        {
            return child;
        }

        public void Rotate(float angle)
        {
            transform.Rotate(Vector3.forward * angle);
        }
    }
}

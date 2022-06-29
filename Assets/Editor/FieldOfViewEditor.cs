using Camera_Sensor;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfViewEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            FieldOfView fov = (FieldOfView)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);


            var eulerAngles = fov.transform.eulerAngles;
            Vector3 viewAngle01 = DirectionFromAngle(eulerAngles.y, -fov.angle / 2);
            Vector3 viewAngle02 = DirectionFromAngle(eulerAngles.y, fov.angle / 2);

            Handles.color = Color.yellow;
            var transform = fov.transform;
            var position = transform.position;
            Handles.DrawLine(position, position + viewAngle01 * fov.radius);
            var transform1 = fov.transform;
            var position1 = transform1.position;
            Handles.DrawLine(position1, position1 + viewAngle02 * fov.radius);

            if (fov.canSeePlayer)
            {
                Handles.color = Color.green;
                Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
            }
        }

        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}

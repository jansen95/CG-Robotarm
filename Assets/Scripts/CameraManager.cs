
using UnityEngine;


[ExecuteInEditMode]
public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera robotCameraChris;
    public Camera robotCameraAlex;
    
    public bool usingRobotCameraChris;
    public bool usingRobotCameraAlex;

    
    // Update is called once per frame
    void Update()
    {
        if (usingRobotCameraAlex.Equals(true))
        {
            mainCamera.enabled = false;
            robotCameraAlex.enabled = true;
            robotCameraChris.enabled = false;
            usingRobotCameraChris = false;
        }
        if (usingRobotCameraAlex.Equals(false))
        {
            robotCameraAlex.enabled = false;
            mainCamera.enabled = true;
        }
        if (usingRobotCameraChris.Equals(true))
        {
            mainCamera.enabled = false;
            robotCameraChris.enabled = true;
            robotCameraAlex.enabled = false;
            usingRobotCameraAlex = false;
        }
        if (usingRobotCameraChris.Equals(false))
        {
            robotCameraChris.enabled = false;
            mainCamera.enabled = true;
        }
    }
}

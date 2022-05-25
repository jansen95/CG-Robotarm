
using UnityEngine;


[ExecuteInEditMode]
public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera robotCamera;

    public bool usingRobotCamera;
    

    
    // Update is called once per frame
    void Update()
    {
        if (usingRobotCamera.Equals(true))
        {
            mainCamera.enabled = false;
            robotCamera.enabled = true;
        }
        if (usingRobotCamera.Equals(false))
        {
            robotCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}

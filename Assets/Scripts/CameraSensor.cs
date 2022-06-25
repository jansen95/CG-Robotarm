using System.Collections;
using UnityEngine;

public class CameraSensor : MonoBehaviour
{
    private Camera _cam;
    private Texture2D _tex;
    
    private static T[,] Make2DArray<T>(T[] input, int height, int width)
    {
        T[,] output = new T[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                output[i, j] = input[i * width + j];
            }
        }
        return output;
    }
    
    IEnumerator RecordFrame()
    {
        _tex = ScreenCapture.CaptureScreenshotAsTexture();
        yield return new WaitForEndOfFrame();
    }
   
    private Vector3 GetRobotCoordinates()
    {
        LateUpdate();
        int sourceMipLevel = 0;
        Color[] pixels = _tex.GetPixels(sourceMipLevel);
        var pixelCoords = Make2DArray(pixels, 84, 84);
        
        for (int i = 0; i < 84; i++)
        {
            for (int k = 0; k < 84; k++)
            {   
                if (pixelCoords[i,k] != Color.black)
                {
                    // Debug.Log(pixelCoords[i,k]);
                    // Debug.Log("Pixel coordinate: x: " + i + "y: " + k);
                    
                    Vector2 pixel2DCoord = new Vector2(i,k);
                    Vector3 screenPoint = new Vector3(pixel2DCoord.x, pixel2DCoord.y, _cam.farClipPlane);
                    RaycastHit hit;
                    Ray ray = _cam.ScreenPointToRay(screenPoint);
                    
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
                    
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider)
                        {
                            Debug.Log("Hit at: " + hit.point);
                            return hit.point;
                        }
                    }
                }
            }
        }
        return new Vector3(0, 0, 0);
    }
    
    public void LateUpdate()
    {
        StartCoroutine(RecordFrame());
    }
    
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        GetRobotCoordinates();
    }
}
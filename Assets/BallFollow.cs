using UnityEngine;

public class BallFollow : MonoBehaviour
{
    public Transform target;
    public Transform axis1;
    public Transform axis2;
    public Transform axis8;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
/*
        Vector3 rotationMask = new Vector3(0, 1, 0);
        Vector3 lookAtRotation = Quaternion.LookRotation(target.position - axis8.position, Vector3.up).eulerAngles;
        axis2.transform.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation, rotationMask));
        */
    }
}

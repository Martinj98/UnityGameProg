
using UnityEngine;
using System.Collections;
 
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraController : MonoBehaviour
{

    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 100f;
    public float ySpeed = 360f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    //private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        ///x and y are flipped because the mouse moves in 2d space
        x = angles.y;
        y = angles.x;
        //rigidbody = GetComponent<Rigidbody>();

        //// Make the rigid body not change rotation
        //if (rigidbody != null)
        //{
        //    rigidbody.freezeRotation = true;
        //}
    }

    void LateUpdate()
    {
        //If the right mouse-button is held rotate the camera bases on X and Y mouse positions
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }
        //follow the target if assigned
        if (target)
        {
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            ///Use raycasts to disable looking through objects
            //RaycastHit hit;
            //if (Physics.Linecast(target.position, transform.position, out hit))
            //{
            //    distance -= hit.distance;
            //}
    
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;

            //Set player to rotate on the y axis
            target.transform.rotation = Quaternion.Euler(0, x, 0);

        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}

using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    // Camera Position and Angle
    public Transform player_transform;
    public Vector3 offset_cam_pos;

    // Camera Angle
    public float xSpeed = 200.0f;
    public float ySpeed = 200.0f;

    private float currentDistance;
    private float desiredDistance;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;

    public float mouseSensitivity = 5f;
    public float moveSpeed = 2f;
    public float smooth = 5.0f;
    private float xDeg = 0.0f;
    private float yDeg = 0.0f;

    public int yMinLimit = -80;
    public int yMaxLimit = 80;

    public float zoom;
    public float zoomSpeed = 1;

    public float zoomMin = 2f;
    public float zoomMax = 10f;
    public float zoomDampening = 5.0f;

    void Start()
    {
        transform.position = new Vector3(player_transform.position.x + 0.0f, player_transform.position.y + 1.5f, player_transform.position.z);
    }



    void Update() {
        transform.position = new Vector3(player_transform.position.x + 0.0f, player_transform.position.y + 1.5f, zoom - 8);

        // Smoothly tilts a transform towards a target rotation.
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            xDeg += Input.GetAxis("Mouse X") * mouseSensitivity;
            yDeg -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            // set camera rotation 
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;

            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;
        }

        CameraZoom();
        Debug.Log("Camera Position" + transform.position + " Camera Angle: " + player_transform.rotation);

    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    void CameraZoom() {
        // Zooming ---- > UPDATES Z_POS ** 
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if(zoom < zoomMin){
            zoom = zoomMin;
        }

        if (zoom > zoomMax){
            zoom = zoomMax;
        }

    }
}

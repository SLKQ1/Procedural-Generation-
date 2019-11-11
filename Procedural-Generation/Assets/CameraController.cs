using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 40f;
    // var for mouse panning
    public float panBorderThickness = 10f;
    // scroll var
    public float scrollSpeed = 20f;
    public float rotationSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        // cur pos of camera
        Vector3 pos = transform.position;

        // moving forward  
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime; 
        }
        // moving back 
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys

        // getting scroll position
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // changing y with scroll var
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 100f; 

        // updating cur position
        transform.position = pos;
        transform.eulerAngles = rotation;

    }
}

using UnityEngine;
using UnityEngine.SocialPlatforms;

public class cameraRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    
    public GameObject playerBody;
    
    private float xRotation = 0f;

    void Start()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.transform.Rotate(Vector3.up * mouseX);
    }
}

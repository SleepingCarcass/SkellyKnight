using UnityEngine;
using UnityEngine.SocialPlatforms;

public class cameraRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    
    public GameObject playerBody;

    void Start()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        
        transform.Rotate(Vector3.left * mouseY);
        playerBody.transform.Rotate(Vector3.up * mouseX);
    }
}

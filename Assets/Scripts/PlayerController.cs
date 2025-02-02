using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float health = 100f;
    private Rigidbody playerRb;

    public GameObject weapon;
    public GameObject weaponSlot;
    public GameObject playerCamera;
    public GameObject healthPoint;
    private Animator _animator;

    public WeaponScript weaponScript; 
    //private  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _animator = gameObject.GetComponent<Animator>();
        weaponScript = weapon.GetComponent<WeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
        transform.Translate(Vector3.right * horizontal);
        transform.Translate(Vector3.forward * vertical);
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (health > 100f)
        {
            health = 100f;
        }

        if (health < 0)
        {
            health = 0;
        }
    }

    void LateUpdate()
    {
        Quaternion offsetSwordRotation = playerCamera.transform.rotation;
        weaponSlot.transform.rotation = offsetSwordRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPoint"))
        {
            health += 20f;
            Destroy(other.gameObject);
        }
    }
}

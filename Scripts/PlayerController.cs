using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 100f;
    public InputAction moveAction;
    public InputAction interactAction;
    private Vector2 moveInput;
    public float xMax = 245.0f;
    public float xMin = 56.0f;
    public float zMax = 156.0f;
    public float zMin = -4.0f;
    private GameObject currentPassenger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        interactAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);

        if (interactAction.WasPressedThisFrame())
        {
            Debug.Log("E'ye basıldı");
        }

        if(transform.position.x > xMax){
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }
        if(transform.position.x < xMin){
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }
        if(transform.position.z > zMax){
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }
        if(transform.position.z < zMin){
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin); 
        } 
        if(interactAction.WasPressedThisFrame() && currentPassenger != null){
            Destroy(currentPassenger);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Temas etti: " + other.name);

        if (other.CompareTag("Passenger"))
        {
            Debug.Log("Passenger bulundu");
            currentPassenger = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Passenger"))
        {
            Debug.Log("Passenger ayrıldı");
            currentPassenger = null;
        }
    }
}

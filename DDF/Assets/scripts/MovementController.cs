using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    public PlayerInput Input;
    private InputAction _move;
    public float movespeed;

    private InputAction _jump;
    public float jumpforce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 1000;

    private Rigidbody _rigidbody;
    private bool _isGrounded;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _move = Input.actions["Move"];
        _jump = Input.actions["Jump"];

        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody != null )
        {
            Debug.LogError("Не на земле");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputMove = _move.ReadValue<Vector2>();
        var move = new Vector3(inputMove.x, 0,inputMove.y) * movespeed * Time.deltaTime;

        transform.Translate(move);

        _isGrounded = Physics.CheckSphere(groundCheck.position,groundCheckRadius,groundLayer);

        if (_jump.triggered && _isGrounded ) { 
            _rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        
        
        
        
        
        
        }










    }
    
}

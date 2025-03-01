using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    private float _horizontDirection;
    private float _verticalDirection;

    private Vector3 _movement;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horizontDirection = Input.GetAxis(Horizontal);
        _verticalDirection = Input.GetAxis(Vertical);

        _movement = transform.forward * _verticalDirection + transform.right * _horizontDirection;

        _characterController.Move(_movement * _speed * Time.fixedDeltaTime);
    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    private int SpaceInputOnDown = 1;
    private int SpaceInputOff = 0;


    [SerializeField] private float _speed;
    [SerializeField] private float _speedJump;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private float _zInput;
    private float _xInput;
    private int _spaceInput;
    private int _cashSpaceInput;
    private float _deadzone = 0.05f;
    private float _rayToGround = 1f;
    private Vector3 _starPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _starPosition = transform.position; 
    }

    private void Update()
    {
        _zInput = Input.GetAxis("Vertical");
        _xInput = Input.GetAxis("Horizontal");
        _spaceInput = Input.GetKeyDown(KeyCode.Space) ? SpaceInputOnDown : SpaceInputOff;

        if(_spaceInput == SpaceInputOnDown)
            _cashSpaceInput = _spaceInput;
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(_zInput) > _deadzone)
        {
            _rigidbody.AddForce(Vector3.forward * _speed * _zInput);
        }

        if(Mathf.Abs(_xInput) > _deadzone)
        {
            _rigidbody.AddForce(Vector3.right * _rotationSpeed * _xInput);
        }

        if(_cashSpaceInput == SpaceInputOnDown)
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector3.up * _speedJump, ForceMode.Impulse);

            }
            _cashSpaceInput = SpaceInputOff;
        }
    }

    public void RestartBall()
    {
        transform.position = _starPosition;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _rayToGround);
    }
}

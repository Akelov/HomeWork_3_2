using UnityEngine;

public class Jumper : MonoBehaviour
{
    private int SpaceInputOnDown = 1;
    private int SpaceInputOff = 0;

    [SerializeField] private float _speedJump;

    private Rigidbody _rigidbody;
    private int _spaceInput;
    private int _cashSpaceInput;
    private float _rayToGround = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _spaceInput = Input.GetKeyDown(KeyCode.Space) ? SpaceInputOnDown : SpaceInputOff;

        if (_spaceInput == SpaceInputOnDown)
            _cashSpaceInput = _spaceInput;
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        if (_cashSpaceInput == SpaceInputOnDown)
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector3.up * _speedJump, ForceMode.Impulse);

            }
            _cashSpaceInput = SpaceInputOff;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _rayToGround);
    }
}

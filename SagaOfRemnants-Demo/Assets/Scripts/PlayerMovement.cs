using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector3 _change;

    public float MoveSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Reset change in position to 0
        _change = Vector2.zero;

        //Get new inputs and normalize
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");
        _change.Normalize();

        MovePlayer();
    }

    private void MovePlayer()
    {
        if(_change != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position + _change * MoveSpeed * Time.deltaTime);

            //Animations if moving
            _animator.SetFloat("MoveX", _change.x);
            _animator.SetFloat("MoveY", _change.y);
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            //Animations if not moving
            _animator.SetBool("IsMoving", false);
        }
    }
}

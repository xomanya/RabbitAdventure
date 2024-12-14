using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody _rigidbody;
    public Animator animator;
    public float rotationSpeed = 4;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Move(movement);
        
        Vector3 velocity = _rigidbody.velocity;
        float speed = velocity.x + velocity.z;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        
        if ((Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f))
        {
            if (Input.GetAxis("Vertical") >= 0)
                transform.Rotate(new Vector3(0, moveHorizontal * rotationSpeed, 0));
            else
                transform.Rotate(new Vector3(0, -moveHorizontal * rotationSpeed, 0));

        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 velocity = direction * moveSpeed;
        _rigidbody.velocity = new Vector3(velocity.x, 0 , velocity.z);
    }
}

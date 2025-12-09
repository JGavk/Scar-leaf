using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;     
    [SerializeField] private float gravity = 20f;    
    
    private CharacterController cc; 
    public SpriteRenderer sr;
    [SerializeField] private Animator anim;

    private Vector3 moveDirection; 

    void Start()
    {
        cc = GetComponent<CharacterController>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (cc == null) Debug.LogError("CharacterController component is missing!");
        if (sr == null) Debug.LogError("SpriteRenderer component is missing!");
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (cc.isGrounded)
        {
            moveDirection = new Vector3(x, 0, y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
            moveDirection.y = -gravity * Time.deltaTime; 

        }
        else
        {

            moveDirection.x = x * speed;
            moveDirection.z = y * speed;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        cc.Move(moveDirection * Time.deltaTime);

        if (x < 0)
        {
            sr.flipX = true;
        }
        else if (x > 0)
        {
            sr.flipX = false;
        }

        if (anim != null)
        {
  
            bool isMoving = Mathf.Abs(x) > 0.01f || Mathf.Abs(y) > 0.01f;
            anim.SetBool("isRunning", isMoving);
        }
    }
}
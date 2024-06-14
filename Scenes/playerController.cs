using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    new Rigidbody2D rb;
    Animator animator;
    Vector2 velocity;
    public float moveSpeed = 1.0f;
    public float jumpForce = 10f; // 점프할 때 적용되는 힘
    public Transform groundCheck; // 지면 체크를 위한 위치
    public float groundCheckRadius = 0.2f; // 지면 체크를 위한 원의 반경
    public LayerMask groundLayer; // 지면으로 인식할 레이어
    private bool isGrounded;
    [SerializeField]GameObject bodyObject;
    

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = bodyObject.GetComponent<Animator>();
    }

    void Update()
    {
        float _hozInput = Input.GetAxisRaw("Horizontal"); //-1~1 를 왔다 갔다 함
        velocity = new Vector2(_hozInput, 0).normalized * moveSpeed;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(velocity.x!=0){
            animator.SetBool("isWalk",true);
        }
        else{
            animator.SetBool("isWalk",false);
        }

        if(_hozInput > 0){
            transform.rotation = Quaternion.Euler(0,0,0);

        }
        else if(_hozInput < 0){
            transform.rotation = Quaternion.Euler(0,180,0);       
        }

        bool checkJump = animator.GetBool("isJumping");
        if (isGrounded && !checkJump)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            animator.SetBool("notDowned",false);

        }
        
        else if (rb.velocity.y < 0)
        {
            // 하강 상태
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            animator.SetBool("notDowned",true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            animator.SetTrigger("Jump"); // 점프 애니메이션 트리거
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
                animator.SetBool("notDowned",true);
            }
        }

        
       



    }

    void FixedUpdate(){
        rb.velocity = new Vector2(velocity.x,rb.velocity.y);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

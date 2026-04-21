using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 기본 세팅")]
    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    private bool isGround = false;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask structureLayer;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        // 바닥 체크
        isGround = Physics.CheckSphere(groundCheck.position, 0.125f, structureLayer);

        if (isGround == true)
        {
            Debug.Log("바닥 감지");
        }
        
        Movement(inputX);
        Jump();
        

        if (!Input.GetButton("Horizontal")) return;
        Flip(inputX);
    }

    void Movement(float inputX)
    {
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("isMove", true);
        }
        ;

        rigid.linearVelocityX = inputX * moveSpeed;

        if (Input.GetButtonUp("Horizontal"))
        {
            anim.SetBool("isMove", false);
            rigid.linearVelocityX = 0;
        }
    }

    /* 플레이어 움직였을 때 뒤집을 함수
     * 반대로 움직이면 spriter 의 flip 을 작동할 것.
     */
    void Flip(float inputX)
    {
        if (inputX > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    void Jump()
    {
        /* 
         * 점프 관련 로직 구현
         * Jump 키에 할당된 버튼으로 점프.
         * AddForce 를 사용하여 JumpPower 만큼 뛰어오를 것임.
         */
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJump", true);
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}

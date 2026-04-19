using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 기본 세팅")]
    public float moveSpeed = 5f;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rigid.linearVelocityX = inputX * moveSpeed;
    }
}

using UnityEngine;

public class Checker : MonoBehaviour
{
    public State CurrentState { get; private set; }

    public Transform groundPos;
    public Transform wallPos;
    public float groundRadius = 0.2f;
    public Vector2 wallBoxSize = new Vector2(0.5f, 1f);

    public enum State { Ground, Wall, None }

    State CheckState()
    {
        bool isGround = Physics2D.OverlapCircle(groundPos.position, groundRadius, LayerMask.GetMask("Ground"));
        bool isWall = Physics2D.OverlapBox(wallPos.position, wallBoxSize, LayerMask.GetMask("Ground"));
        if (isGround) return State.Ground;
        if (isWall) return State.Wall;

        return State.None;
    }

    private void FixedUpdate()
    {
        State state = CheckState();
        
        switch (state)
            {
            case State.Ground:   break;
            case State.Wall: break;
            case State.None:  break;
        }
    }

    /* 기즈모를 그려서 벽이랑 바닥 감지하는 부위 확인
     * 사용법: OnDrawGizmos 함수를 void 로 선언하면 됨.
     * (Update 에 넣지 않아도 되는 이유는 얘 자체가 Update처럼 계속 호출됨.)
     * 함수 안에 Gizmos.DrawWire(도형이름)(위치, 크기); 로 선언하면 됨.
     */
    private void OnDrawGizmos()
    {
        if (groundPos == null || wallPos == null) return;
        Gizmos.DrawWireSphere(groundPos.position, groundRadius);
        Gizmos.DrawWireCube(wallPos.position, wallBoxSize);
    }
}

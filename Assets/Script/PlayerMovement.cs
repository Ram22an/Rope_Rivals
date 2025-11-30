using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private float Speed = 6f;
    private float jump = 12f;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private Transform GroundCheck;
    private float GroundCheckRadius = 0.2f;
    [SerializeField] private Rigidbody2D rb;
    private bool IsGrounded;
    private float InputX;
    #endregion

    #region Functions
    private void Update()
    {
        InputX = 0;
        if (UnityEngine.Input.GetKey(KeyCode.A)) InputX = -1;
        if (UnityEngine.Input.GetKey(KeyCode.D)) InputX = 1;
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundMask);
        if(Input.GetKey(KeyCode.W) && IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity= new Vector2(InputX* Speed, rb.linearVelocity.y);
    }
    private void OnDrawGizmosSelected()
    {
        if (GroundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
        }
    }
    #endregion
}

using UnityEngine;

public class BoxDrag : MonoBehaviour
{
    Rigidbody2D rb;
    bool dragging = false;

    [Header("Configura��o de suavidade")]
    [Range(0.01f, 1f)]
    public float smoothFactor = 0.2f; // menor = mais suave

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        dragging = true;
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.freezeRotation = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        rb.gravityScale = 0.7f;
        rb.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Suaviza o movimento
            Vector2 newPos = Vector2.Lerp(rb.position, mousePos, smoothFactor);
            rb.MovePosition(newPos);
        }
    }
}
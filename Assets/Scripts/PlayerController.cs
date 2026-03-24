using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] float acceleration = 20f;     // Força de aceleração ao apertar D
    [SerializeField] float brakeStrength = 4f;     // Força base do freio ao apertar A
    [SerializeField] float maxSpeed = 8f;          // Velocidade máxima do carrinho

    [Header("Peso")]
    public float realWeight = 0f;        // Peso atual carregado no carrinho

    Rigidbody2D rb;

    float targetVelocity;

    void Start()
    {
        // Pega o Rigidbody2D do carrinho
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Movimento acontece no FixedUpdate (física)
        Move();
        rb.linearVelocity = new Vector2(targetVelocity, rb.linearVelocity.y);
    }

    void Move()
    {
        // Pega a velocidade horizontal atual do carrinho
        float velocity = rb.linearVelocity.x;

        // =============================
        // FATOR DE ACELERAÇÃO PELO PESO
        // =============================
        // Quanto maior o peso, menor a aceleração
        // Esse cálculo nunca chega a zero, então o carrinho sempre anda
        float accelFactor = 1f / (1f + realWeight * 0.05f);

        // =============================
        // FATOR DE FREIO EXPONENCIAL
        // =============================
        // Aqui usamos peso² para deixar a frenagem muito mais forte com peso alto
        // Quanto maior o peso, menor a capacidade de frear
        float brakeFactor = 1f / (1f + realWeight * realWeight * 0.002f);

        // =============================
        // ACELERAR (TECLA D)
        // =============================
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Aumenta a velocidade gradualmente
            // O peso diminui a aceleração
            velocity += acceleration * accelFactor * Time.fixedDeltaTime;
        }

        // =============================
        // FREAR (TECLA A)
        // =============================
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Interpola a velocidade atual até zero
            // Quanto maior o peso, menor o efeito do freio
            velocity = Mathf.Lerp(
                velocity,                                       // velocidade atual
                0f,                                             // queremos ir até zero
                brakeStrength * brakeFactor * Time.fixedDeltaTime // intensidade do freio
            );
        }

        // =============================
        // LIMITA A VELOCIDADE
        // =============================
        // Impede o carrinho de ir pra trás e limita velocidade máxima
        velocity = Mathf.Clamp(velocity, 0, maxSpeed);

        targetVelocity = velocity;
    }
}
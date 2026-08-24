using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(Launch), 1f); // Запуск через 1 секунду
    }

    void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        Vector2 direction = new Vector2(x, 1f).normalized;
        rb.linearVelocity = direction * speed;
    }
    
    void FixedUpdate()
    {
        // Если мяч вообще стоит (например, до запуска), ничего не делаем
        if (rb.linearVelocity == Vector2.zero) return;

        // normalized возвращает вектор длиной ровно 1 (чистое направление).
        // Умножаем его на нашу скорость — получаем идеальный вектор полета!
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }
}

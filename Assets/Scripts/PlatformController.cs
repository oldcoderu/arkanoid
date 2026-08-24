using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    
    // Ссылка на сгенерированный класс настроек ввода
    private PlatformControls controls; 
    private float moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Инициализируем наш класс ввода
        controls = new PlatformControls();

        // Подписываемся на события чтения значения (возвращает от -1 до 1)
        controls.Platform.Move.performed += ctx => moveInput = ctx.ReadValue<float>();
        
        // Когда кнопка отпущена, обнуляем ввод
        controls.Platform.Move.canceled += ctx => moveInput = 0f;
    }

    // Обязательно включаем и выключаем карту ввода
    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void FixedUpdate()
    {
        // Применяем скорость. В Unity 6 используем linearVelocity
        rb.linearVelocity = new Vector2(moveInput * speed, 0f);
    }
}

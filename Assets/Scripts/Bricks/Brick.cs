using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject afterDestroyEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            //создаём объект с анимацией эффекта в позции кирпича
            //P.S проблема была в том что мы на уроке
            //создавали префаб дочерним кирпичику и соотвественно они оба дестроились)))
            Instantiate(afterDestroyEffect, gameObject.transform.position, gameObject.transform.rotation);

            //Так же тут ты можешь прописать свою логику которая будет срабатывать при уничтожении кирпичика

            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Apple : MonoBehaviour
{
    private Transform tr;
    private Main main;

    void Start()
    {
                main = GameObject.Find("spawn").GetComponent<Main>();  

        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 0.12f, 0f);

        if (tr.position.y < -9f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "basket")
        {
            main.ScoreAdd();
            Destroy(gameObject);
        }
    }
}

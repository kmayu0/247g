using UnityEngine;

public class Knife : MonoBehaviour
{
    private Main main; 
    private Transform tr;

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
            Destroy(gameObject);
            Destroy(collision.gameObject);
            main.gameOver = true;
        }
    }
}

using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    public float speed = 0;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }  

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "WallBlue")
        {
            GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            StartCoroutine(WaitAfter(-1));
        }
        else if(col.gameObject.name == "WallRed")
        {
            GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            StartCoroutine(WaitAfter(1));
        }
        if (col.gameObject.name == "RacketLeft")
        {
            Vector2 yforce = col.gameObject.GetComponent<Rigidbody2D>().velocity/2;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + yforce;
        }
        if (col.gameObject.name == "RacketRight")
        {
            Vector2 yforce = col.gameObject.GetComponent<Rigidbody2D>().velocity / 2;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + yforce;
        }
    }

    IEnumerator WaitAfter(float red)
    {
        Vector2 dir = new Vector2(red, 0).normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSecondsRealtime(1);
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
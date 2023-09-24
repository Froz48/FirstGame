using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    [SerializeField] CircleCollider2D mine;
    [SerializeField] SpriteRenderer circle;
    int speed;
    float maxtime;
    float timer;
    int i;
    bool spawning;


    void Awake()
    {
        spawning = true;
        circle.transform.localScale = new Vector3(0f, 0f, 0f);
        i = 0;
        speed = 20;
        maxtime = 0.1f;
        mine.radius = 0;
        timer = maxtime;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (i < speed)
            {
               
                timer = maxtime;
                circle.transform.localScale = new Vector3(circle.transform.localScale.x + 0.03f, circle.transform.localScale.y + 0.03f, circle.transform.localScale.z);
                i++;
            }

            else 
            { 
                mine.radius = 0.5f;
                spawning = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject == Hero.Instance.gameObject)&&(!spawning))
        {
            Debug.Log("collision from mine");
            Hero.Instance.GetDamage();
            Destroy(this.gameObject);
        }
        if ((!collision.gameObject.CompareTag("Mine"))&&(!spawning))
        {
            Destroy(this.gameObject);
        }
    }
}

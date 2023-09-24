using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstacles : MonoBehaviour
{
    
    private float speed;
    [SerializeField] private string direction;
    private Vector3 dir;

    private void Start()
    {
        if (!(
            (PlayerPrefs.HasKey("Obs_Speed"))
            ))
        {
            PlayerPrefs.SetFloat("Obs_Speed", 3f);
        }
        speed = PlayerPrefs.GetFloat("Obs_Speed");
       
        if ((direction == "Left")|| (direction == "Right")) dir = transform.right;
        else if ((direction == "Up") || (direction == "Down")) dir = transform.up;
    }

    private void Update()
    {
       Move();
    }

    private void Move()
    {
        if ((direction == "Left") || (direction == "Down"))
            transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed * Time.deltaTime);
        else if ((direction == "Right")|| (direction == "Up"))
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Debug.Log("Collision obstacle");
            Hero.Instance.GetDamage();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }

    }

}

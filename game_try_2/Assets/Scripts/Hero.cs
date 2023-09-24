using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public static Hero Instance { get; set; }
    private float speed;
    [SerializeField] Text hp;
    private int health;
    private float immune_time = 2f;
    private float timer = 0;
    [SerializeField] SpriteRenderer diamond;

    private void Awake()
    {
        Instance = this;
        if (!(
            (PlayerPrefs.HasKey("Player_Speed")) &&
            (PlayerPrefs.HasKey("Player_Health"))
            ))
        {
            PlayerPrefs.SetFloat("Player_Speed", 3f);
            PlayerPrefs.SetFloat("Player_Health", 4f);
        }
        health = (int)PlayerPrefs.GetFloat("Player_Health");
        speed = PlayerPrefs.GetFloat("Player_Speed");

        hp.text = health.ToString();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal")) RunRight();
        if (Input.GetButton("Vertical")) RunUp();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Hero.Instance.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 255, 0);
            }
        
        }
        
    }

    public void GetDamage()
    {
        if (timer <= 0)
        {
            health--;
            hp.text = health.ToString();
            if (health < 1)
            {
                hp.text = "0";
                SceneManager.LoadScene(2);
            }
            timer = immune_time;
            Hero.Instance.GetComponentInChildren<SpriteRenderer>().color = new Color(50, 250, 50);
        }
    }

    private void RunRight()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    private void RunUp()
    {
        Vector3 dir = transform.up * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
}

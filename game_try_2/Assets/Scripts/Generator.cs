using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject gameobject;
    [SerializeField] Vector2 range;
    [SerializeField] Transform spawnpos;
    float spawntime;
    int spawncount;
    [SerializeField] string orient;

    void Start()
    {
        if (!(
            (PlayerPrefs.HasKey("Obs_Count")) &&
            (PlayerPrefs.HasKey("Obs_Speed_Spawn"))
            ))
        {
            PlayerPrefs.SetFloat("Obs_Count", 4);
            PlayerPrefs.SetFloat("Obs_Speed_Spawn", 4);
        }
        spawntime = PlayerPrefs.GetFloat("Obs_Speed_Spawn");
        spawncount = (int)PlayerPrefs.GetFloat("Obs_Count");
        StartCoroutine(Generate());
    }

    IEnumerator Generate()  
    {
        yield return new WaitForSeconds(Random.Range(1,spawntime*2));
        Vector2 oldpos = new Vector2(-100, -100);
            if (orient == "Vertical")
            {
                int x = Random.Range((int)(Mathf.Ceil(spawncount/2f)), spawncount);
                for (int i = 0; i < x; i++) 
                {
                    bool flag = false;
                    while (flag == false)
                    {
                        Vector3 tmppos = new Vector3(0, Random.Range(-range.y, range.y));
                        if (Mathf.Abs(tmppos.y - oldpos.y) > 4)
                        {
                            Vector2 pos = spawnpos.position + tmppos;
                            oldpos = pos;
                            Instantiate(gameobject, pos, Quaternion.identity);
                            flag = true;
                        }
                    }
                }
            }
            else if (orient == "Horizontal")
            {
                int x = Random.Range(1, (int)(spawncount*1.6));
                for (int i = 0; i < x; i++)
                {
                    bool flag = false;
                    while (flag == false)
                    {
                        Vector3 tmppos = new Vector3(Random.Range(-range.x, range.x), 0);
                        if (Mathf.Abs(tmppos.x - oldpos.x) > 10)
                        {
                            Vector2 pos = spawnpos.position + tmppos;
                            oldpos = pos;
                            Instantiate(gameobject, pos, Quaternion.identity);
                            flag = true;
                        }
                    }
                }
            }
        Repeat();
    }

   void Repeat()
    {
        StartCoroutine(Generate());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            if (orient == "Vertical") 
            {
                Hero.Instance.transform.position = new Vector3 (-Hero.Instance.transform.position.x, Hero.Instance.transform.position.y, Hero.Instance.transform.position.z);
            }
            else if (orient == "Horizontal")
            {
                Hero.Instance.transform.position = new Vector3(Hero.Instance.transform.position.x, -Hero.Instance.transform.position.y, Hero.Instance.transform.position.z);
            }
        }

    }
}

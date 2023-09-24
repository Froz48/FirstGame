using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] GameObject gameobject;
    [SerializeField] Transform spawnpos;
    [SerializeField] Transform spawnpos2;
    float spawntime;
    int max_mines_per_spawn;

    void Start()
    {
        if (!(
            (PlayerPrefs.HasKey("Mines_Count")) &&
            (PlayerPrefs.HasKey("Mines_Speed"))
            ))
        {
            PlayerPrefs.SetFloat("Mines_Count", 3f);
            PlayerPrefs.SetFloat("Mines_Speed", 3f);
        }
        max_mines_per_spawn = (int)PlayerPrefs.GetFloat("Mines_Count");
        spawntime = PlayerPrefs.GetFloat("Mines_Speed");
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(Random.Range(1, spawntime * 2));
        int x = Random.Range(max_mines_per_spawn/2, max_mines_per_spawn);
        for (int i = 0; i <= x; i++)
        {
            Vector2 pos = new Vector2(Random.Range(spawnpos.position.x, spawnpos2.position.x), Random.Range(spawnpos.position.y, spawnpos2.position.y));
            Instantiate(gameobject, pos, Quaternion.identity);
        }
        Repeat();
    }
    void Repeat()
    {
        StartCoroutine(Generate());
    }
}

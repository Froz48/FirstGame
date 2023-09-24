using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_sliders : MonoBehaviour
{
    [SerializeField] Slider Obs_Speed;
    [SerializeField] Slider Obs_Count;
    [SerializeField] Slider Obs_Speed_Spawn;
    [SerializeField] Slider Player_Speed;
    [SerializeField] Slider Player_Health;
    [SerializeField] Slider Mines_Count;
    [SerializeField] Slider Mines_Speed;

    void Start()
    {
        if (!(
            (PlayerPrefs.HasKey("Obs_Speed")) &&
            (PlayerPrefs.HasKey("Obs_Count")) &&
            (PlayerPrefs.HasKey("Obs_Speed_Spawn")) &&
            (PlayerPrefs.HasKey("Player_Speed")) &&
            (PlayerPrefs.HasKey("Player_Health")) &&
            (PlayerPrefs.HasKey("Mines_Count")) &&
            (PlayerPrefs.HasKey("Mines_Speed"))
            ))
        {
            PlayerPrefs.SetFloat("Obs_Speed", 3f);
            PlayerPrefs.SetFloat("Obs_Count", 3f);
            PlayerPrefs.SetFloat("Obs_Speed_Spawn", 3f);
            PlayerPrefs.SetFloat("Player_Speed", 3f);
            PlayerPrefs.SetFloat("Player_Health", 4f);
            PlayerPrefs.SetFloat("Mines_Count", 3f);
            PlayerPrefs.SetFloat("Mines_Speed", 3f);
        } 
        Obs_Speed.value = PlayerPrefs.GetFloat("Obs_Speed");
        Obs_Count.value = PlayerPrefs.GetFloat("Obs_Count");
        Obs_Speed_Spawn.value = PlayerPrefs.GetFloat("Obs_Speed_Spawn");
        Player_Speed.value = PlayerPrefs.GetFloat("Player_Speed");
        Player_Health.value = PlayerPrefs.GetFloat("Player_Health");
        Mines_Count.value = PlayerPrefs.GetFloat("Mines_Count");
        Mines_Speed.value = PlayerPrefs.GetFloat("Mines_Speed");
    }

    public void Set_Obs_Speed()
    {
        PlayerPrefs.SetFloat("Obs_Speed", Obs_Speed.value);
    }

    public void Set_Obs_Count()
    {
        PlayerPrefs.SetFloat("Obs_Count", Obs_Count.value);
    }

    public void Set_Obs_Speed_Spawn()
    {
        PlayerPrefs.SetFloat("Obs_Speed_Spawn", Obs_Speed_Spawn.value);
    }

    public void Set_Player_Speed()
    {
        PlayerPrefs.SetFloat("Player_Speed", Player_Speed.value);
    }

    public void Set_Player_Health()
    {
        PlayerPrefs.SetFloat("Player_Health", Player_Health.value);
    }

    public void Set_Mines_Count()
    {
        PlayerPrefs.SetFloat("Mines_Count", Mines_Count.value);
    }

    public void Set_Mines_Speed()
    {
        PlayerPrefs.SetFloat("Mines_Speed", Mines_Speed.value);
    }

    

}

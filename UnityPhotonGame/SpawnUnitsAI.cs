using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnUnitsAI : MonoBehaviour
{
    public List<GameObject> units;
    public Transform spawnPoint;
    public List<Button> spawnButtons;

    private void Awake()
    {

    }

    public void OnSpawn_Unit1()
    {
        spawnButtons[0].interactable = false;
        Instantiate(units[0], spawnPoint.position, Quaternion.identity);
    }

    public void OnSpawn_Unit2()
    {
        spawnButtons[1].interactable = false;
        Instantiate(units[1], spawnPoint.position, Quaternion.identity);
    }

    public void OnSpawn_Unit3()
    {
        spawnButtons[2].interactable = false;
        Instantiate(units[2], spawnPoint.position, Quaternion.identity);
    }
}
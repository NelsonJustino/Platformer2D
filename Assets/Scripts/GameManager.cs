using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Core.Singleton;
public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject player;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }
    
    public void SpawnPlayer()
    {
        _currentPlayer = Instantiate(player);
        _currentPlayer.transform.position = startPoint.transform.position;
    }

}

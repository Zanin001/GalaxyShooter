using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Maneger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject EnemyShipPrefab;

    [SerializeField]
    private GameObject[] powerup;

    private GameManager _gameManager;
    private UIManager _uiManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (_gameManager.gameOver == false)
        {
            int nbEnemies = Mathf.RoundToInt(0.03f * _gameManager.dificult);
            for (int i = 0; i < nbEnemies; i++)
            {
                Debug.Log(nbEnemies);
                Instantiate(EnemyShipPrefab, new Vector3(Random.Range(-6.80f, 6.80f), 6.23f, 0), Quaternion.identity);
            }
            if (_gameManager.isCoopMode == false)
            {
                yield return new WaitForSeconds(3.0f);
            }
            else if (_gameManager.isCoopMode == true)
            {
                yield return new WaitForSeconds(2.5f);
            }
        }
    }

    IEnumerator PowerUpSpawn()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPower = Random.Range(0, 3);
            Instantiate(powerup[randomPower], new Vector3(Random.Range(-6.80f, 6.80f), 6.23f, 0), Quaternion.identity);
            if (_gameManager.isCoopMode == false)
            {
                yield return new WaitForSeconds(6.0f);
            }
            else if (_gameManager.isCoopMode == true)
            {
                yield return new WaitForSeconds(4.0f);
            }
        }
    }

}

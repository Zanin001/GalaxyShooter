using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnPrefab;
    [SerializeField]
    public bool isCoopMode = false;
    public bool gameOver = true;
    public bool deadP1 = false;
    public bool deadP2 = false;
    public int dificult = 20;
    public int enemyDead = 1;
    public GameObject player;
    public GameObject player_1;
    public GameObject player_2;
    [SerializeField]
    public GameObject button;



    [SerializeField]
    private GameObject _pauseMenu;
    private UIManager _uiManager;
    private Spawn_Maneger _spawnManeger;
    private Animator _pauseAnimator;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManeger = GameObject.Find("Spawn_Maneger").GetComponent<Spawn_Maneger>();
        _pauseAnimator = GameObject.Find("Pause_Menu_Painel").GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                dificult = 20;
                Time.timeScale = 1;
                if (isCoopMode == false)
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                else if (isCoopMode == true)
                {
                    deadP1 = false;
                    deadP2 = false;
                    Instantiate(player_1, new Vector3(-3.18f, -2.39f, 0), Quaternion.identity);
                    Instantiate(player_2, new Vector3(3.92f, -2.39f, 0), Quaternion.identity);
                }
                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManeger.StartSpawnRoutines();
                
            }

        }
        if (isCoopMode == true)
        {
            if (deadP1 == true && deadP2 == true)
            {
                gameOver = true;
                _uiManager.ShowTitleScreen();
                _uiManager.CheckForBestScoreCoop();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu.SetActive(true);
            _pauseAnimator.SetBool("isPaused", true);
            Time.timeScale = 0;
        }
    }


    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void UpdateDificult()
    {
        enemyDead++;
        dificult++;
    }


}

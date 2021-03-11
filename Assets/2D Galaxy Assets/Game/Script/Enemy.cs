using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private float _live = 2;

    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    private UIManager _uiManager;

    [SerializeField]
    private AudioClip _clip;

    private GameManager _gameManager;
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.gameOver == true)
        {
            DestroyEnemy();
        }

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -6.07f)
        {
            transform.position = new Vector3(Random.Range(-6.80f, 6.80f), 6.23f, 0);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (_live == 0)
        {
            DestroyEnemy();
            _uiManager.UpdateScore();
            _gameManager.UpdateDificult();
        }


        if (other.tag == "laser")
        {
            Destroy(other.gameObject);  
            _live--;
        }

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            DestroyEnemy();
            _uiManager.UpdateScore();
            _gameManager.UpdateDificult();
            player.Damage();
        }

    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);  
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private int powerupID;
    //0 = Triple shoot 1 = speed boost 2 = shields
    [SerializeField]
    private AudioClip _clip;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (_gameManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    player.SpeedBoostOn();
                }
                else if (powerupID == 2)
                {
                    player.ShieldOn();
                }
            }

            StartCoroutine(player.TripleShootStop());

            Destroy(this.gameObject);
        }
    }
}

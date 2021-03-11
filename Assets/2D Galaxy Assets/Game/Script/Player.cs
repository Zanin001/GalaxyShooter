using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public bool TripleShoot = false;
    public bool SpeedBoost = false;
    public bool Shield = false;
    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;
    public bool isPlayerOneDead = false;
    public bool isPlayerTwoDead = false;

    private int hitCount = 0;

    [SerializeField]
    private GameObject _Shield;

    [SerializeField]
    private GameObject _ExplosionPrefab;

    [SerializeField]
    private GameObject _TripleShootPrefab;

    [SerializeField]
    private GameObject _lazerPrefab;

    [SerializeField]
    private int _PlayerOneLive = 3;
    private int _PlayerTwoLive = 3;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    [SerializeField]
    public float _speed = 5.0f;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private Spawn_Maneger _spawnManager;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject[] _engines;

    
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager != null)
        {
            _uiManager.UpdateLives(_PlayerOneLive);
            _uiManager.UpdateLives2(_PlayerTwoLive);
        }
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _audioSource = GetComponent<AudioSource>();
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.isCoopMode == false)
        {
            SinglePlayerMoviment();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        if(isPlayerOne == true)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        else if (isPlayerTwo == true)
        {
            Movement2();
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
            if (Time.time > _canFire)
            {
                _audioSource.Play();
                if (TripleShoot == true)
                {
                    Instantiate(_TripleShootPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(_lazerPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                }    
                _canFire = Time.time + _fireRate;

            }

    }

    private void SinglePlayerMoviment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(SpeedBoost == true)
        {
            transform.Translate(Vector3.right * _speed * 2f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * 2f * verticalInput * Time.deltaTime);

        }
        else if (SpeedBoost == false)
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        }

    }
    private void Movement()
    {
        if (SpeedBoost == true) {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime * 2f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 8.6f)
        {
            transform.position = new Vector3(-8.6f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.6f)
        {
            transform.position = new Vector3(8.6f, transform.position.y, 0);
        }

    }

    private void Movement2()
    {
        if (SpeedBoost == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime * 2f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 8.6f)
        {
            transform.position = new Vector3(-8.6f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.6f)
        {
            transform.position = new Vector3(8.6f, transform.position.y, 0);
        }

    }

    public void Damage()
    {
        if (Shield == true)
        {
            Shield = false;
            _Shield.SetActive(false);
            return;
        }
        hitCount++;
        if (hitCount == 1)
        {
            _engines[0].SetActive(true);
        }
        else if(hitCount == 2)
        {
            _engines[1].SetActive(true);
        }

        
        if(isPlayerOne == true)
        {
            _PlayerOneLive--;
            _uiManager.UpdateLives(_PlayerOneLive);
        }
        else if(isPlayerTwo == true)
        {
            _PlayerTwoLive--;
            _uiManager.UpdateLives2(_PlayerTwoLive);
        }
        
        if(_gameManager.isCoopMode == false)
        {
            if (_PlayerOneLive == 0)
            {
                Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
                StartCoroutine(LoadMenu());
                Destroy(this.gameObject);
                _gameManager.gameOver = true;
                _uiManager.ShowTitleScreen();
                _uiManager.CheckForBestScore();
                
            }
        }
        else if(_gameManager.isCoopMode == true)
        {
            if(_PlayerOneLive == 0)
            {
                _gameManager.deadP1 = true;
                Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
                StartCoroutine(LoadMenu());
                Destroy(this.gameObject);
                
            }
            else if(_PlayerTwoLive == 0)
            {
                _gameManager.deadP2 = true;
                Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
                StartCoroutine(LoadMenu());
                Destroy(this.gameObject);
            }
        }

    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(02);
        SceneManager.LoadScene(3);
    }



    public void TripleShotPowerupOn()
    {
        TripleShoot = true;
        StartCoroutine(TripleShootStop());
    }

   public IEnumerator TripleShootStop()
    {
        yield return new WaitForSeconds(6.0f);

        TripleShoot = false;
    }

    public void SpeedBoostOn()
    {
        SpeedBoost = true;
        StartCoroutine(SpeedBoostStop());
    }

    public IEnumerator SpeedBoostStop()
    {
        yield return new WaitForSeconds(6.0f);
        SpeedBoost = false;
    }

    public void ShieldOn()
    {
        Shield = true;
        _Shield.SetActive(true);
    }



}

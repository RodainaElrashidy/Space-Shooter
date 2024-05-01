using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aestroid_Info : MonoBehaviour
{
    //Inspector
    [SerializeField] private AsteroidSO _asteroidSO;
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] GameObject[] goalsPos;

    //Variables
    private int _waveNum;
    private int _bulletsNeeded;
    private float _speed;
    int rand;
    //Vector2 goalPos = new Vector2(-1, 0.5f);
    Vector2[] goalsPos = { new Vector2(-1, 0.5f), new Vector2(-1, -0.5f) };

    //Properties
    public int WaveNum { get => _waveNum; set => _waveNum = value; }
    public int BulletsNeeded { get => _bulletsNeeded; set => _bulletsNeeded = value; }
    public float Speed { get => _speed; set => _speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        WaveNum = _asteroidSO.WaveNum;
        BulletsNeeded = _asteroidSO.BulletsNeeded;
        Speed = _asteroidSO.Speed;

        rand = Random.Range(0, goalsPos.Length);
    }

    private void Update()
    {
        CheckPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameConst.slowAsteroidPowerUpAcquired)
            _speed *= 0.5f;
        rb.velocity = goalsPos[rand] * _speed;
    }

    void CheckPosition()
    {
        if(transform.position.x < -10 || transform.position.x > 11 || transform.position.y > 7 || transform.position.y < -7)
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Listiening To")]
    [SerializeField] public VoidEventsChannelSO OnPlayerHit;
    [SerializeField] Image[] _hearts;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject healthPowerUp;
    GameObject obj;
    
    private void Start()
    {
        GameConst.counter = _hearts.Length - 1;
    }

    private void Update()
    {
        if (GameConst.healthPowerUpAcquired)
        {
            ResetHealth();
        }
    }

    private void OnEnable()
    {
        OnPlayerHit.OnEventRaised += PlayerHit;
    }

    private void OnDisable()
    {
        OnPlayerHit.OnEventRaised -= PlayerHit;
    }

    public void PlayerHit()
    {
        //Debug.Log(this.name + ": Player got hit");
        if (GameConst.counter > 0)
        {
            _hearts[GameConst.counter].color = new Color(_hearts[GameConst.counter].color.r, _hearts[GameConst.counter].color.g, _hearts[GameConst.counter].color.b, 0);

            GameConst.Player.SetActive(false);

            obj = Instantiate(explosion, GameConst.Player.transform.position, Quaternion.identity);
            obj.GetComponent<Animator>().Play("Explosion_Asteroid_wave1");

            Invoke("DeleteObj", 0.3f);
            Invoke("Respawn", 0.3f);
            
            GameConst.counter--;
            if (GameConst.counter == 1)
            {
                ShowPowerUps();
            }
        }
        else if (GameConst.counter == 0)
        {
            _hearts[0].color = new Color(_hearts[0].color.r, _hearts[0].color.g, _hearts[0].color.b, 0);
            GameConst.Player.SetActive(false);

            obj = Instantiate(explosion, GameConst.Player.transform.position, Quaternion.identity);
            obj.GetComponent<Animator>().Play("Explosion_Asteroid_wave1");

            Invoke("DeleteObj", 0.3f);
            //Button to restart the scene
        }
    }

    private void DeleteObj()
    {
        Destroy(obj);
    }

    private void Respawn()
    {
        GameConst.RespawnPlayer();
    }
    public void ShowPowerUps()
    {
        healthPowerUp.SetActive(true);
        healthPowerUp.transform.position = transform.position;
    }

    private void ResetHealth()
    {
        GameConst.counter = _hearts.Length - 1;
        for(int i=0; i< _hearts.Length; i++)
        {
            _hearts[i].color = new Color(_hearts[i].color.r, _hearts[i].color.g, _hearts[i].color.b, 255);
        }
        GameConst.healthPowerUpAcquired = false;
    }
}

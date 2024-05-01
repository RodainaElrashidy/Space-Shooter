using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Broadcasting On")]
    [SerializeField] public VoidEventsChannelSO OnPlayerHit;

    //spaceship
    [SerializeField] Rigidbody2D rb;
    //[SerializeField] Animator anim;
    //bullets
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Transform shipRespawnPoint;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Collider2D _collider2D;
    
    public float bulletSpeed;

    private Vector2 movementVector;
    public float speed;
    

    private void Start()
    {
        GameConst.ShipRespawnPoint = shipRespawnPoint;
        GameConst.Player = gameObject;
    }
    private void Update()
    {
        if (GameConst.justRespawned)
        {
            StartCoroutine(PlayerState());
        }
    }

    private void OnFire()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,Quaternion.identity, this.transform);
        if (GameConst.bulletPowerUpAcquired)
            bullet.GetComponent<SpriteRenderer>().color = Color.red;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    private void OnMovement(InputValue value)
    {
        Vector2 val = value.Get<Vector2>();
        movementVector = new Vector2(val.x, val.y);
    }

    private void FixedUpdate()
    {
        if (movementVector != Vector2.zero)
        {
            rb.velocity = speed * movementVector;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == GameConst.aestroidTagagName)
        {
            OnPlayerHit.RaiseEvent();
        }
    }

    private IEnumerator PlayerState()
    {
        yield return new WaitForSeconds(2);
        _spriteRenderer.color = Color.white;
        _collider2D.enabled = true;
        GameConst.justRespawned = false;
    }
}

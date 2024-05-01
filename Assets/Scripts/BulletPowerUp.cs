using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPowerUp : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Rigidbody2D rb;

    private void Update()
    {
        moveSprite();
    }

    void moveSprite()
    {
        rb.velocity = Vector2.left * 2;

        if (transform.position.x < -10 || transform.position.x > 11 || transform.position.y > 7 || transform.position.y < -7)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConst.playerTagagName)
        {
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 255);
            ChaneBullets();
            gameObject.SetActive(false);
        }
    }

    private void ChaneBullets()
    {
        GameConst.bulletPowerUpAcquired = true;
    }
}

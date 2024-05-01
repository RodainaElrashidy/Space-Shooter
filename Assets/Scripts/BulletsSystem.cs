using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSystem : MonoBehaviour
{
    [Header("Broadcasting On")]
    [SerializeField] public VoidEventsChannelSO OnPlayerScored;

    [SerializeField] GameObject explosion;
    //int bulletcount;
    GameObject obj;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == GameConst.aestroidTagagName)
        {
            OnPlayerScored.RaiseEvent();
            gameObject.SetActive(false);

            if (GameConst.bulletPowerUpAcquired)
            {
                WithPowerUP(other);
            }
            else
            {
                NoPowerUP(other);
            }

            //if(other.GetComponent<Aestroid_Info>().BulletsNeeded > 1)
            //{
            //    other.GetComponent<Aestroid_Info>().BulletsNeeded--;
            //}
            //else if(other.GetComponent<Aestroid_Info>().BulletsNeeded == 1)
            //{
            //    other.gameObject.SetActive(false);
            //    obj = Instantiate(explosion, other.transform.position, Quaternion.identity);
            //    obj.GetComponent<Animator>().Play("Explosion_Asteroid_wave1");
            //    Invoke("DeleteObj", 0.30f);
            //}
            
        }
    }

    private void NoPowerUP(Collider2D other)
    {
        if (other.GetComponent<Aestroid_Info>().BulletsNeeded > 1)
        {
            other.GetComponent<Aestroid_Info>().BulletsNeeded--;
        }
        else if (other.GetComponent<Aestroid_Info>().BulletsNeeded == 1)
        {
            other.gameObject.SetActive(false);
            obj = Instantiate(explosion, other.transform.position, Quaternion.identity);
            obj.GetComponent<Animator>().Play("Explosion_Asteroid_wave1");
            Invoke("DeleteObj", 0.30f);
        }
    }

    private void WithPowerUP(Collider2D other)
    {
       
            other.gameObject.SetActive(false);
            obj = Instantiate(explosion, other.transform.position, Quaternion.identity);
            obj.GetComponent<Animator>().Play("Explosion_Asteroid_wave1");
            Invoke("DeleteObj", 0.30f);
        
    }

    private void DeleteObj()
    {
        Destroy(obj);
    }
}

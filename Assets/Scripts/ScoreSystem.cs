using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [Header("Listiening To")]
    [SerializeField] public VoidEventsChannelSO OnPlayerScored;

    [Header("References")]
    [SerializeField] private TMP_Text scoreField;
    [SerializeField] GameObject bulletPowerUp;
    [SerializeField] GameObject slowPowerUp;
    [SerializeField] Image achievment_One;
    [SerializeField] Image achievment_Two;
    [SerializeField] GameObject restartBttnPanel;

    private int score =0;
    private bool bulletPowerUpShown = false;
    private bool slowPowerUpShown = false;

    private void Start()
    {
        //GameConst.score = score;
    }

    private void Update()
    {
        GameConst.score = score;
    }

    private void OnEnable()
    {
        OnPlayerScored.OnEventRaised += IncreaseScore;
    }

    private void OnDisable()
    {
        OnPlayerScored.OnEventRaised -= IncreaseScore;
    }

    public void IncreaseScore()
    {
        score += 10;
        scoreField.text = "Score: " + score;
        if (GameConst.score > 250 && !bulletPowerUpShown)
        {
            ShowBulletPowerUp();
            bulletPowerUpShown = true;
        }

        if (GameConst.score > 300 && !slowPowerUpShown)
        {
            ShowSlowPowerUp();
            slowPowerUpShown = true;
        }

        if(GameConst.score > 400)
        {
            ShowScoreAchievment();
        }

        if(GameConst.score > 500)
        {
            ShowWinAchievment();
            ShowButton();
        }
    }

    public void ShowBulletPowerUp()
    {
        bulletPowerUp.SetActive(true);
        bulletPowerUp.transform.position = transform.position;
    }
    public void ShowSlowPowerUp()
    {
        slowPowerUp.SetActive(true);
        slowPowerUp.transform.position = transform.position;
    }

    public void ShowWinAchievment()
    {
        achievment_One.color = new Color(achievment_One.color.r, achievment_One.color.g, achievment_One.color.b, 255);
        GameConst.stopGame = true;
    }

    public void ShowScoreAchievment()
    {
        achievment_Two.color = new Color(achievment_Two.color.r, achievment_Two.color.g, achievment_Two.color.b, 255);
    }

    private void ShowButton()
    {
        if (GameConst.stopGame == true)
        {
            restartBttnPanel.SetActive(true);
            GameConst.stopGame = false;
            GameConst.bulletPowerUpAcquired = false;
            GameConst.slowAsteroidPowerUpAcquired=false;
            GameConst.healthPowerUpAcquired = false;
        }
    }
}

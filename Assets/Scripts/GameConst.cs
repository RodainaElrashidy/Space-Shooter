using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public static class GameConst
{
    public static string aestroidTagagName = "Asteroid";
    public static string playerTagagName = "Player";
    public static int counter;
    public static int score;
    public static bool justRespawned = false;
    public static bool healthPowerUpAcquired = false;
    public static bool bulletPowerUpAcquired = false;
    public static bool slowAsteroidPowerUpAcquired = false;
    public static bool stopGame = false;

    private static Transform shipRespawnPoint;
    private static GameObject player;

    public static Transform ShipRespawnPoint { get => shipRespawnPoint; set => shipRespawnPoint = value; }
    public static GameObject Player { get => player; set => player = value; }

    public static void RespawnPlayer()
    {
        Player.transform.position = ShipRespawnPoint.position;
        Player.SetActive(true);
        Player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<SpriteRenderer>().color = Color.cyan;
        justRespawned = true;
    }

}

using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    void Start ()
    {
        // static money can carry on from 1 scene to another.
        // so if the player is broke, he will start off with no money left if we don't reset Money here.
        Money = startMoney;
        Lives = startLives;
    }
}

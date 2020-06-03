using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static bool playTurn;
    private static bool actionTurn;
    private static float startTime;

    private static Vector3 nextMove;

    public static bool PlayTurn { get => playTurn; set => playTurn = value; }
    public static bool ActionTurn { get => actionTurn; set => actionTurn = value; }
    public static float StartTime { get => startTime; set => startTime = value; }
    public static Vector3 NextMove { get => nextMove; set => nextMove = value; }

    private void Start()
    {
        nextMove = new Vector3(0, 0, 0);
    }
    public void EndPlayTurn()
    {
        playTurn = false;
        actionTurn = true;
        startTime = Time.time;
        
        //bekleme zamanı eklenecek, hareketler skiller vurulacak
        //playturne geçilecek
    }
}

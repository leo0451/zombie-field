using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static bool playTurn;
    private static bool moveTurn;
    private static bool skillTurn;
    private static float startTime;


    //Bu değişkenlerle turnlerin ne kadar süreceği belirlenecek
    private static float playTurnTime = 1;
    private static float moveTurnTime = 1;
    private static float skillTurnTime = 1;
    

    private static Vector3 nextMove;

    public static bool PlayTurn { get => playTurn; set => playTurn = value; }
    public static float StartTime { get => startTime; set => startTime = value; }
    public static Vector3 NextMove { get => nextMove; set => nextMove = value; }
    public static bool MoveTurn { get => moveTurn; set => moveTurn = value; }
    public static bool SkillTurn { get => skillTurn; set => skillTurn = value; }

    private void Start()
    {
        nextMove = new Vector3(0, 0, 0);
    }

    private void Update()
    {
       
    }

    public void EndTurn()
    {
        EndPlayTurn();

        StartCoroutine(SkillTurnTimer(skillTurnTime));

    }
    
    void EndPlayTurn()
    {
        playTurn = false;
        skillTurn = true;
        moveTurn = false;

        Debug.Log("playturn ends");
       
    } 

    IEnumerator SkillTurnTimer (float turnTime)
    {
        yield return new WaitForSeconds(turnTime);
        playTurn = false;
        skillTurn = false;
        moveTurn = true;

        Debug.Log("skillturn ends");

        StartCoroutine(MoveTurnTimer(moveTurnTime));
    }


    IEnumerator MoveTurnTimer(float turnTime)
    {
        yield return new WaitForSeconds(turnTime);
        playTurn = true;
        skillTurn = false;
        moveTurn = false;

        Debug.Log("moveturn ends");
    }


}

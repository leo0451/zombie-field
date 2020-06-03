using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public int currentPlatforType;

    private static Vector3 platformSize;
    private static LinkedList<Vector3> positionOfObstacles;
    private static float squarSize;
    private static int numberOfObstacles;

    
    public static float SquarSize { get => squarSize; }

    private void Awake()
    {
        setPlatformProperties(currentPlatforType);
    }


    //bu metot daha sonra düzenlenecek platform özellikleri dosyadan çekilecek
    void setPlatformProperties(int platformType)
    {

    switch (platformType)
        {
            case 1:
                platformSize = new Vector3(30f, 0, 30f);
                positionOfObstacles = null;
                numberOfObstacles = 0;
                squarSize = 2;
                break;
        }
        
    }
}

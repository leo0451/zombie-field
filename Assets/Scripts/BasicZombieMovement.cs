using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BasicZombieMovement : MonoBehaviour
{
    //zombinin harekete başladığı pozisyon
    Vector3 startPosition;

    //zombinin sıradaki hareketi
    Vector3 nextDestination;

    //action turn de bir kere çalışacak kod parçası için gösterici
    bool turnFlag;

    //zombinin alacağı mesafe
    float journeyLength;

    //zombinin hızı
    float speed;

  
    void Start()
    {
        turnFlag = true;
    }

    
    void Update()
    { 
        //tek sefer çalışacak kodlar
        //nextdestination hesaplaması
        if (turnFlag)
        {
            
            //action turnde ilk pozisyon ayarlanıyor
            startPosition = transform.position;

            nextDestination = CalculateNextDestination(startPosition, TurnManager.NextMove);

            journeyLength = Vector3.Distance(startPosition, nextDestination);
                    
            turnFlag = false;
        }

        //interpolarasyonla zombi konumu ve hareketi hesaplanması
        ZombieBasicMove(nextDestination,startPosition, 2f, journeyLength);

    }


    void ZombieBasicMove(Vector3 nextDestination, Vector3 startPosition, float speed, float jLength)
    {

        float distCovered;  
        float fractionOfJourney;       

        distCovered = (Time.time - TurnManager.StartTime) * speed;
        fractionOfJourney = distCovered / jLength;


        transform.position = Vector3.Lerp(startPosition, nextDestination, fractionOfJourney);
    }

    Vector3 CalculateNextDestination(Vector3 currentPosition, Vector3 victimPosition)
    {

        Vector3 nextDestination;

        //gidilecek yol vektörü
        Vector3 stepSize;

        //karakter ve zombi arası mesafe
        Vector3 distance;

        float absDistanceX;
        float absDistanceZ;
        float stepSizeX ;
        float stepSizeZ ;


        distance = victimPosition - currentPosition;   

        absDistanceX = Math.Abs(distance.x);
        absDistanceZ = Math.Abs(distance.z);

        stepSizeX = distance.x / absDistanceX;
        stepSizeZ = distance.z / absDistanceZ;

        stepSize.x = stepSizeX * PlatformManager.SquarSize;
        stepSize.z = stepSizeZ * PlatformManager.SquarSize;
        stepSize.y = 0;
  
        nextDestination = currentPosition + stepSize;

        return nextDestination;
    }
}

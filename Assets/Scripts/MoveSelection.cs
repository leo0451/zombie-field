using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelection : MonoBehaviour
{
    public GameObject leftSign;
    public GameObject rightSign;
    public GameObject upSight;
    public GameObject downSign;

    // Start is called before the first frame update
    void Start()
    {
        leftSign.SetActive(false);
        rightSign.SetActive(false);
        upSight.SetActive(false);
        downSign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //android builde göre refoctor edilecek
        //yada crossplatforma göre inputlar ayarlanacak

        if (Input.GetKey("left"))
        {
            leftSign.SetActive(true);
            rightSign.SetActive(false);
            upSight.SetActive(false);
            downSign.SetActive(false);
            TurnManager.NextMove = leftSign.transform.position;
        }
        else if(Input.GetKey("right"))
        {
            leftSign.SetActive(false);
            rightSign.SetActive(true);
            upSight.SetActive(false);
            downSign.SetActive(false);
            TurnManager.NextMove = rightSign.transform.position;
        }
        else if (Input.GetKey("up"))
        {
            leftSign.SetActive(false);
            rightSign.SetActive(false);
            upSight.SetActive(true);
            downSign.SetActive(false);
            TurnManager.NextMove = upSight.transform.position;
        }
        else if (Input.GetKey("down"))
        {
            leftSign.SetActive(false);
            rightSign.SetActive(false);
            upSight.SetActive(false);
            downSign.SetActive(true);
            TurnManager.NextMove = downSign.transform.position;
        }
    }
}

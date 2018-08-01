using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public GameObject leftFist;
    public GameObject rightFist;
    public float range = 10;
    public bool isLPunching = false;
    public bool isRPunching = false;
    public Vector3 lStart;
    public Vector3 rStart;
    public float lhitTime = 0;
    public float rhitTime = 0;


    private void Awake()
    {
        lStart = leftFist.transform.localPosition;
        rStart = rightFist.transform.localPosition;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer();

        if (Input.GetKeyDown(KeyCode.Mouse0) && lhitTime <= 0)
            isLPunching = true;
        if (Input.GetKeyDown(KeyCode.Mouse1))
            isRPunching = true;

        if (isLPunching == true)
        {
            lhitTime = 0.1f;
            leftFist.transform.Translate(0, 0, range);
            isLPunching = false;
        }

        if (isLPunching == false && lhitTime <= 0f)
        {
            leftFist.transform.localPosition = lStart;
        }


        if (isRPunching == true)
        {
            rhitTime = 0.1f;
            rightFist.transform.Translate(0, 0, range);
            isRPunching = false;
        }

        if (isRPunching == false && rhitTime <= 0f)
        {
            rightFist.transform.localPosition = rStart;
        }
    }

    private void timer()
    {
        if (lhitTime > 0)
        {
            lhitTime -= Time.deltaTime;
        }
        if (rhitTime > 0)
        {
            rhitTime -= Time.deltaTime;
        }
    }

}







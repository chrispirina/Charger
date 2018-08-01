using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.3f;
    public Vector3 mousePos;
    public Transform gameObjectToRotate;
    public float charge = 0;
    public float chargelimit = 4;
    public float chargespeed = 0.5f;
    public Vector3 startPos;
    public Vector3 endPos;
    public float distcovered;
    public float fracJourney;

    Vector3 middleOfScreen;

    // Use this for initialization
    void Start()
    {
        middleOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

    }


    // Update is called once per frame
    void Update()
    {

        /*transform.LookAt(Input.mousePosition.x);
        Cursor.visible = true;
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - transform.position.y, Camera.main.transform.position.z));
            transform.LookAt(mousePos);
        }*/
         



        Vector3 camVec = Input.mousePosition - middleOfScreen;
        Vector3 flipped = new Vector3(camVec.x, 0.0f, camVec.y);
        gameObjectToRotate.LookAt(flipped);
    





        //MOVEMENT
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, 0, speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, 0, -speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(speed, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-speed, 0, 0);



        if (Input.GetKey(KeyCode.Space) && charge < chargelimit)
        {
            charge += Time.deltaTime * chargespeed;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            startPos = transform.position;
            float zStartPosMod = startPos.z += charge;
            Vector3 endPos = new Vector3(startPos.x, startPos.y, zStartPosMod);
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
            charge = 0f;
            print(endPos);
            print(startPos.x);  
        }


    }
    
    


}

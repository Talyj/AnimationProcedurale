using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //Camera mouse
    Vector3 Angles;
    private float sensitivityX = 10;
    private float sensitivityY = 10;
    
    //Movement
    private static Vector3 lastDirectionIntent;
    private float speed = 10;
    
    //TP
    public Transform[] tps;
    
    //Rendu
    public GameObject bigChunk;

    void Update()
    {
        CameraMovement();
        KeyboardMovement();
        Teleport();
        ChangeScene();
        Quit();
        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void FixedUpdate()
    {
        gameObject.transform.localPosition += lastDirectionIntent * (Time.deltaTime * speed);
    }

    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    private void CameraMovement()
    {
        float rotationY = Input.GetAxis("Mouse Y")*sensitivityX;
        float rotationX = Input.GetAxis("Mouse X")*sensitivityY;
        if(rotationY>0)
            Angles = new Vector3(Mathf.MoveTowards(Angles.x, -80, rotationY), Angles.y + rotationX, 0);
        else
            Angles = new Vector3(Mathf.MoveTowards(Angles.x, 80, -rotationY), Angles.y + rotationX, 0);
        gameObject.transform.localEulerAngles = Angles;
    }

    private void KeyboardMovement()
    {
        // Get key down (Z,Q,S,D) 
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.position -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            gameObject.transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= transform.forward * Time.deltaTime * speed;
        }

        //left shift up, ctrl down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }

    private void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Scene1":
                    SceneManager.LoadScene("Scene2");
                    break;
                case "Scene2":
                    SceneManager.LoadScene("Scene1");
                    break;
            }
        }
    }

    private void activeOrNot(GameObject objectToSet)
    {
        if (objectToSet.activeSelf)
        {
            objectToSet.SetActive(false);
        }
        else
        {
            objectToSet.SetActive(true);
        }
    }

    private void Teleport()
    {
        if (tps.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                gameObject.transform.position = tps[0].position;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gameObject.transform.position = tps[1].position;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                gameObject.transform.position = tps[2].position;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                gameObject.transform.position = tps[3].position;
            }

            if (SceneManager.GetActiveScene().name == "Scene1")
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
                {
                    activeOrNot(bigChunk);
                }   
            }
        }
    }
}

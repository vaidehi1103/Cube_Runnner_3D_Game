using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float dodgeSpeed; //decide the speed with player can dodge
    public float maxX;

    float xInput;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        xInput = Input.GetAxis("Horizontal"); //take input from horizontal axis

        TouchInput();

        transform.Translate(xInput * dodgeSpeed * Time.deltaTime , 0, 0); //to move the player

        float limitedX = Mathf.Clamp(transform.position.x, -maxX, maxX);

        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
    }

    void TouchInput()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;

            float middle = Screen.width / 2;
            if(touchPos.x < middle)
            {
                xInput = -1;
            }
            else if (touchPos.x > middle)
            {
                xInput = 1;
            }
        }
    }
    private void OnTriggerEnter (Collider col) //name of the collider is col
    {
        if(col.gameObject.tag == "Enemy") //checking  if gameobject is collided with other gameobject tagged enemy
        {
            GameManager.instance.Restart();
        }
    }
}

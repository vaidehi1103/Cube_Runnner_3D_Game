using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed; //value by which enemy will come towards the players
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(0,0, speed* Time.deltaTime);  

      if(transform.position.z < -10f)  //when enemy's position is goes beyond less than -10 the enemy will be destroyed
      {
            GameManager.instance.ScoreUp();

            Destroy(gameObject);
      }
    }
}

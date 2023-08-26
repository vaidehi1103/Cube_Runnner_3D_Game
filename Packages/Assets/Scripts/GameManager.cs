using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //functions in this script can be used by other scripts as well

    public GameObject enemy; //reference to enemy game object
    public Transform spawnPoint; //position where we will spawn our enemies
    public float maxSpawnPointX; //max left and right position for spawning the enemies
    public GameObject menuPanel;
    
    bool gameStarted = false;

    int score = 0;
    int highScore = 0;
    
    public Text ScoreText;
    public Text highScoreText;

    
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("highScore")) //to check weather any highscore has been created if yes then assign it to to highScore variable
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = "HIGH SCORE:" + highScore.ToString();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !gameStarted)
        {
            menuPanel.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(true); //after the game starts then display the score text

             StartCoroutine("SpawnEnemies");
             gameStarted = true;
        }
        
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            Spawn();
        }
    }

    public void Spawn()
    {
        float randomSpawnX = Random.Range(-maxSpawnPointX, maxSpawnPointX); //random position for spawning the enemy

        Vector3 enemySpawnPos = spawnPoint.position; // creating new variable and assigning it to default spawn position

        enemySpawnPos.x = randomSpawnX; //assigning the above variable to the random generated variable

        Instantiate(enemy,enemySpawnPos, Quaternion.identity);


    }

    public void Restart()
    {
        if(score> highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("highScore", highScore);
        }
        SceneManager.LoadScene(0); //which screen to load
    }

    public void ScoreUp()
    {
        score++;
        ScoreText.text = score.ToString(); //to display the score through the ui element
    }

}

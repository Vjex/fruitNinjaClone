using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int Score = 0;
    public int highScore = 0;
    public Text scoreText;
    public Text highScoreText;


    [Header("Game Over")]
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;
    public GameObject gameOverPanel;


    //These Are The Varibles related To Adding Sound To Each Slice.
    [Header("Game Sound")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;




    //Initially On Awake Game Over Panel Hide 
    private void Awake()
    {
        gameOverPanel.SetActive(false);


        //Initialising Audio Source.
        audioSource = GetComponent<AudioSource>();
        //Get The High Score Saved In Player Prefs
        getHighScore();

    }

    //Get The Locally Saved High Score  And Set The Text Of Initial High Score.
    private void getHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "Best : " + highScore.ToString();

    }

    //method To be Called From Fruit Script To Increase The Score.
    public void IncreaseTheScore(int points)
    {
        //Increase The Score through the Points Given In Each Cut Of A Fruit.
        Score +=points;

        //Set The New Score Text Allong With That 
        scoreText.text = Score.ToString();

        //Change The High Score and Corresponding Text And Save it Locally of It Is Greater Than The Previous High Score.
        if(Score > highScore)
        {
            //Save The High Locally To Player Prefs Jsut Like Shared Preferences.
            PlayerPrefs.SetInt("HighScore", Score);

            //Change The High Score And It UI Text .
            highScore = Score;
            highScoreText.text = "Best : " + highScore.ToString();
        }
    }

    //method To be Called From Bomb Script To stop The Game.
    public void StopTheGame()
    {
        //Default Value is i Which Means game Is Running Normally and Here Set to 0 means Stop the Game Execution Time and will lead to stop/Pause the Game there.
        Time.timeScale = 0;

        //Now Show the GameOver Panel 
        gameOverPanel.SetActive(true);

        //Set The Score Achieved To The Game Over Panel Score Text.
        gameOverScoreText.text = "Score : " + Score.ToString() ;
        
        //Set The  High Score Achieved To The Game Over Panel High Score Text.
        gameOverHighScoreText.text = "High Score : " + highScore.ToString() ;

       
    }

    //method To be Called From Bomb Script To stop The Game.
    public void RestartTheGame()
    {
        //Set The Score and Score text Var to Initail Value Back
        Score = 0;
        scoreText.text = Score.ToString();


        

        //Now Hide the GameOver Panel 
        gameOverPanel.SetActive(false);

        //Remove All The Game Object Which Not Needed For that We Have Created / added a tag to each Elemnt like Bomb ,  Every Fruit Prefabs i.e Interactable 
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        //Default Value is i Which Means game Is Running Normally and Here Set to 0 means Stop the Game Execution Time and will lead to stop/Pause the Game there.
        Time.timeScale = 1;

    }


    //Method To Be Called From Fruit Script To Play A Random Slice Sound On Each Slice.
    public void PlayRandomSliceSound()
    {
        //get the Random Sound File From Array
        AudioClip randomSound = sliceSounds[Random.Range(0,sliceSounds.Length)];

        //Play The Sound Only Once Complete.
        audioSource.PlayOneShot(randomSound);
    }
}

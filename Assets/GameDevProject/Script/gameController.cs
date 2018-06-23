using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
	
	public static gameController current;
	public int pointsForGoodGhost;
	public int pointsForBadGhost;
	public int pointsForBonus;
	public GameObject currWindowPanel;
	public GameObject endGamePanel;
	int gameScore;

	public int GetScore(){
		return gameScore;
	}

	public void AddToGameScore(int pointsToAdd){
		gameScore += pointsToAdd;
		Text scoreText = GameObject.FindGameObjectWithTag ("GameScoreText").GetComponent<Text> ();
		scoreText.text = gameScore.ToString ().PadLeft(4,'0');
	}

	// Use this for initialization
	void Awake(){
		current = this;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseGame(){
		Time.timeScale = 0f;
	}

	public void ResumeGame(){
		Time.timeScale = 1.0f;
	}

	public void EndGame(){
		currWindowPanel.SetActive (false);
		endGamePanel.SetActive (true);
		GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>().text = GetScore().ToString().PadLeft(4,'0');
	}
	public void ToMainMenu(){
		ResumeGame ();
		SceneManager.LoadScene ("GameMenu");
	}
		
	void saveScore(){
		
	}
}

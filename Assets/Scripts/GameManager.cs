using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject playButton;
	public GameObject airplane;
	public GameObject enemySpawner;
	public GameObject gameOverSprite;    // GameOver Img
	public GameObject userScore;    // Score UI
	public GameObject gameTimer;   
	public GameObject gameTitle;
	public GameObject settings;

	public enum GameStates {
		Opening, GamePlay, GameOver
	}

	GameStates gameStates;
	// Use this for initialization
	void Start () {
	}
	
	void UpdateGameStates () {
		switch(gameStates) {
		case GameStates.GameOver:
		
			gameTimer.GetComponent<TimeCounter>().stopTimeCounter();
			
			enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawn();
			
			gameOverSprite.SetActive(true);
			
			Invoke("SetGameStateToOpening", 8f);
			break;
		case GameStates.GamePlay:
		
			userScore.GetComponent<GameScore> ().Score = 0;
			
			settings.SetActive(false);
			playButton.SetActive (false);
			gameTitle.SetActive (false);
			
			airplane.GetComponent<UserControll>().Init();
			
			enemySpawner.GetComponent<EnemySpawner>().StartEnemySpawn();
		
			gameTimer.GetComponent<TimeCounter>().startTimeCounter();

			break;
		case GameStates.Opening:
		
			gameOverSprite.SetActive (false);

			settings.SetActive (true);
			playButton.SetActive (true);
			gameTitle.SetActive (true);
			break;
		}
	}
    public void Settings()
    {
        settings.SetActive(true);
    }

    public void SetGameState(GameStates state) {
		gameStates = state;
		UpdateGameStates ();
	}


	public void StartGamePlay() {
		gameStates = GameStates.GamePlay;
		UpdateGameStates ();
	}

	
	public void SetGameStateToOpening() {
		SetGameState (GameStates.Opening);
	}
}

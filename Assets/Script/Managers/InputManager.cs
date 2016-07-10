using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	#region Singleton
	private static InputManager m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
	}
	#endregion Singleton

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		switch (GameStateManager.getGameState ()) {
		case GameState.Menu:
			UpdateMenuState();
			break;
		case GameState.Playing:
			UpdatePlayingState();
			break;
		case GameState.Pause:
			UpdatePauseState();
			break;
		case GameState.GameOver:
			UpdateGameOverState();
			break;
		}
	}

	void UpdateMenuState(){
		if(Input.GetKeyDown(KeyCode.Return)){
			GameStateManager.setGameState (GameState.Playing);
			Application.LoadLevelAsync ("LevelScene");
		}
	}

	void UpdatePlayingState(){
		bool doSmth = false;
		if(Input.GetKeyDown("p")){
			Debug.Log("PAUSE ! ");
			GameStateManager.setGameState(GameState.Pause);
		}

		if(Input.GetKeyDown("z") || Input.GetKeyDown("w")|| Input.GetKeyDown(KeyCode.Space)){
			PlayerManager.m_instance.UP();
			doSmth = true;
		}
		
		if(Input.GetKey("q") || Input.GetKey("a")){
			PlayerManager.m_instance.LEFT();
			doSmth = true;
		}
		
		if(Input.GetKey("s")){
			PlayerManager.m_instance.DOWN ();
			doSmth = true;
		}
		
		if(Input.GetKey("d")){
			PlayerManager.m_instance.RIGHT();
			doSmth = true;
		}
		if(Input.GetKeyDown("e")){
			PlayerManager.m_instance.ChangeWorld();
			doSmth = true;
		}

		if(!doSmth)
			PlayerManager.m_instance.Default();
	}

	void UpdatePauseState(){
		if(Input.GetKeyDown("p")){
			Debug.Log("DÉPAUSE ! ");
			GameStateManager.setGameState(GameState.Playing);
		}
	}

	void UpdateGameOverState(){

	}

}

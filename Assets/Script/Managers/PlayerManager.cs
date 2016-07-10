using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	#region Singleton
	public static PlayerManager m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_instance = this;
		}else{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
		m_swanController = GetComponentInChildren<SwanController>();
	}
	#endregion Singleton

	SwanController m_swanController;

	public Camera lightCamera;

	// Use this for initialization
	void Start () {
		GameStateManager.onChangeStateEvent += handleChangeGameState;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void handleChangeGameState(GameState newState){
		Debug.Log ("PLAYER SEE THE NEW STATE : " + newState);
	}

	#region Intéraction
	public void UP(){
		Debug.Log("UP ! ");
		m_swanController.Move (0, false, true);
	}

	public void DOWN(){
		Debug.Log("DOWN ! ");
	}

	public void LEFT(){
		Debug.Log("LEFT ! ");
		m_swanController.Move (-1, false, false);
	}

	public void RIGHT(){
		Debug.Log("RIGHT ! ");
		m_swanController.Move (1, false, false);
	}

	public void ChangeWorld() {
		if (lightCamera.enabled) {
			lightCamera.enabled = false;
		} else {
			lightCamera.enabled = true;
		}
			
	
	}
	public void Default(){
		m_swanController.Move (0, false, false);
	}
	#endregion Intéraction

	void OnDestroy(){
		GameStateManager.onChangeStateEvent -= handleChangeGameState;
	}
}

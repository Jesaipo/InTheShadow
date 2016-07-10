using UnityEngine;
using System.Collections;

public class FinishCondition : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("ICI");
		if (other.tag == "End")
		{
			Application.LoadLevelAsync ("GameOverScene");
			Debug.Log ("FIN");
		}
	}
}

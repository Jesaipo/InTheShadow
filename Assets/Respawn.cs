using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Death")
		{
			this.transform.position = GameObject.FindGameObjectWithTag ("Respawn").transform.position;
		}
	}
}

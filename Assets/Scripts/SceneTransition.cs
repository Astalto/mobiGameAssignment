using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	public void OnButtonPress (){
		Application.LoadLevel("Game");
	}
}

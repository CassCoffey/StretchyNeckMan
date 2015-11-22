using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void ChangeMenu(string menu){
		if (menu == "instructions") {
			transform.FindChild ("MainMenu").gameObject.SetActive(false);
			transform.FindChild ("Instructions").gameObject.SetActive(true);
		}
		if (menu == "mainmenu") {
			transform.FindChild ("Instructions").gameObject.SetActive(false);
			transform.FindChild ("MainMenu").gameObject.SetActive(true);
		}
	}

	public void StartGame(){
		Application.LoadLevel ("Default");
	}
}

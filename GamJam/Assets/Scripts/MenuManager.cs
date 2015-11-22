using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject[] Snow = new GameObject[4];

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		if (Snow [0] != null) {
			for(int i = 0; i < Snow.Length; i++){
				Snow[i].transform.localScale += new Vector3(0, 0.003F, 0);
			}
		}
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

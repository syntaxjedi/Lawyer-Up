using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUpgrades : MonoBehaviour {
	bool move = false;
	bool up;
	float directionUp;
	float directionDown;
	int speed = 8;
	public GameObject studyButton;
	public GameObject news;
	public GameObject upgrades;

	Vector3 startPosition;
	// Use this for initialization
	void Start () {
		directionUp = Mathf.Sign (83 - transform.position.y);
		directionDown = Mathf.Sign (-139 - transform.position.y);
		//startPosition = new Vector3(transform.position.x, transform.position.y);
		startPosition = transform.position;
	}

	public void upgradesFront(){
		upgrades.transform.SetSiblingIndex (1);
	}

	public void newsFront(){
		news.transform.SetSiblingIndex (1);
	}

	public void showHide(){
		if (!up) {
			up = true;
			move = true;
		} else {
			up = false;
			move = true;
		}
	}

	public void isHidden(){
		if (!up) {
			up = true;
			move = true;
		}
	}

	void Update(){
		if (up && move) {
			Vector2 movePos = new Vector2(transform.position.x, transform.position.y + directionUp * (speed * Time.deltaTime));
			transform.position = movePos;
			if (transform.position.y >= studyButton.transform.position.y) {
				move = false;
			}
		} else if (!up && move) {
			Vector2 movePosDown = new Vector2(transform.position.x, transform.position.y + directionDown * (speed * Time.deltaTime));
			//Debug.Log ("Current Position: " + transform.position);
			if (transform.position.y <= startPosition.y + 0.2) {
				move = false;
			}
			transform.position = movePosDown;
		}
	}
}

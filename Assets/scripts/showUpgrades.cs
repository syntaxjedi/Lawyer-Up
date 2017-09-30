using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUpgrades : MonoBehaviour {
	bool move = false;
	bool up;
	bool buttonRotate;
	bool rotUp;
	float directionUp;
	float directionDown;
	float height;
	int speed = 8;
	public GameObject studyButton;
	public GameObject news;
	public GameObject upgrades;
	public GameObject skills;
	public GameObject showButton;
	public GameObject folder;
	Vector3 startPosition;
	Vector3 rotBut;

	void Start () {
		directionUp = Mathf.Sign (83 - transform.position.y);
		directionDown = Mathf.Sign (-139 - transform.position.y);
		//startPosition = new Vector3(transform.position.x, transform.position.y);
		rotBut = showButton.transform.eulerAngles;
		startPosition = transform.position;
		height = folder.GetComponent<RectTransform> ().rect.height;
	}

	public void upgradesFront(){
		upgrades.transform.SetSiblingIndex(2);
	}

	public void newsFront(){
		news.transform.SetSiblingIndex(2);
	}

	public void skillsFront(){
		skills.transform.SetSiblingIndex(2);
	}

	public void showHide(){
		if (!up) {
			up = true;
			move = true;
			buttonRotate = true;
			rotUp = true;
		} else {
			//showButton.transform.Rotate(Vector3.forward * 180);
			up = false;
			move = true;
			buttonRotate = true;
			rotUp = false;
		}
	}

	public void isHidden(){
		if (!up) {
			up = true;
			move = true;
			buttonRotate = true;
			rotUp = true;
		}
	}

	void Update(){
		if (up && move) {
			Vector2 movePos = new Vector2(transform.position.x, transform.position.y + directionUp * (speed * Time.deltaTime));
			transform.position = movePos;

			/*
			showButton.transform.Rotate (0, 0, 180 * Time.deltaTime);
			if (showButton.transform.eulerAngles.z >= 359) {
				showButton.transform.eulerAngles.Set (showButton.transform.eulerAngles.x, showButton.transform.eulerAngles.y, 360);
			}
			*/

			if (transform.position.y >= 0) {
				move = false;
			}
		} else if (!up && move) {
			Vector2 movePosDown = new Vector2(transform.position.x, transform.position.y + directionDown * (speed * Time.deltaTime));
			//Debug.Log ("Z Angle: " + showButton.transform.eulerAngles.z);

			/*
			showButton.transform.Rotate (0, 0, 180 * Time.deltaTime);
			Debug.Log ("Z Angle: " + showButton.transform.eulerAngles.z);
			if (showButton.transform.eulerAngles.z >= 180) {
				showButton.transform.eulerAngles.Set (showButton.transform.eulerAngles.x, showButton.transform.eulerAngles.y, 180);
			}
			*/

			if (transform.position.y <= startPosition.y + 0.2) {
				move = false;
			}
			transform.position = movePosDown;
		}

		if (buttonRotate) {
			showButton.transform.Rotate (0, 0, 170 * Time.deltaTime);
			if (showButton.transform.eulerAngles.z >= 180 && showButton.transform.eulerAngles.z < 183 && !rotUp) {
				buttonRotate = false;
				rotBut.z = 180;
				showButton.transform.eulerAngles = rotBut;
			} else if (showButton.transform.eulerAngles.z >= 357 && showButton.transform.eulerAngles.z < 360 && rotUp) {
				buttonRotate = false;
				rotBut.z = 360;
				showButton.transform.eulerAngles = rotBut;
			}
		}

	}
}

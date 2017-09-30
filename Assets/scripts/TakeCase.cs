using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakeCase : MonoBehaviour {

	float _sp;
	float _payout;
	int _oHealth;
	int _oHealthMax;
	int _pHealth = 100;
	int _pHealthMax = 100;
	float attack;
	float oAttack;
	float pHit;
	float oHit;
	bool win;

	public GameObject warning;
	public GameObject textUpdate;
	public GameObject cashDisplay;
	public GameObject pointsDisplay;
	public GameObject oHealth;
	public GameObject pHealth;
	public GameObject oHitText;
	public GameObject pHitText;
	public Slider oHealthBar;
	public Slider pHealthBar;
	public GameObject mainWindow;
	public GameObject courtRoom;

	points studyPoints = new points();
	cash newCash = new cash();
	private IEnumerator cr;

	void Start () {
		
	}

	public void sp(float sp){
		_sp = sp;
	}

	public void payout(float payout){
		_payout = payout;
	}

	public void otherHealth(int oH){
		_oHealthMax = oH;
	}

	public void calculateCase(){
		if (studyPoints.score > 0) {

			mainWindow.SetActive (false);
			courtRoom.SetActive (true);

			_oHealth = _oHealthMax;
			_pHealth = _pHealthMax;
			oHealthBar.maxValue = _oHealthMax;
			pHealthBar.maxValue = _pHealthMax;
			oHealthBar.value = _oHealthMax;
			pHealthBar.value = _pHealthMax;
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHealth, _oHealth + "/" + _oHealthMax);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHealth, _pHealth + "/" + _pHealthMax);

			//D20 roll for attack
			oAttack = Random.Range(1, 20) + 1;

			if (studyPoints.score < (_sp/2)) {
				//1D6 for base attack
				attack = Random.Range(1, 10) + 1;
				Debug.Log ("Dice Roll: " + attack);

			} else if(studyPoints.score >= (_sp/2) && studyPoints.score < _sp){
				//2D6
				attack = Random.Range(1, 10) + Random.Range(1, 10) + 2;
				Debug.Log ("Dice Roll: " + attack);

			}else if (studyPoints.score >= _sp) {
				//3D6
				attack = Random.Range(1, 10) + Random.Range(1, 10) + Random.Range(1, 10) + 3;
				Debug.Log ("Dice Roll: " + attack);
			}
			studyPoints.score -= _sp;
			if (studyPoints.score <= 0) {
				studyPoints.score = 0;
			}
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pointsDisplay, "Study Points: " + studyPoints.score);
			cr = LawyerBattle();
			StartCoroutine (cr);
		}else if (studyPoints.score <= 0) {
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (warning, "Not Enough SP!");
			textUpdate.GetComponent<textUpdateRemote> ().warningBool = true;
		}
	}

	void outcome(){
		if (win) {
			courtRoom.SetActive (false);
			mainWindow.SetActive (true);
			StopCoroutine(cr);
			newCash.money += _payout;
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (warning, "You Won!");
			textUpdate.GetComponent<textUpdateRemote> ().warningBool = true;
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (cashDisplay, "Cash: $" + newCash.money);

		} else if (!win) {
			courtRoom.SetActive (false);
			mainWindow.SetActive (true);
			StopCoroutine(cr);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (warning, "You Lost!");
			textUpdate.GetComponent<textUpdateRemote> ().warningBool = true;
		}
	}

	IEnumerator LawyerBattle(){
		Time.timeScale = 0;
		while (_oHealth > 0 || _pHealth > 0) {

			yield return new WaitForSecondsRealtime (0.25f);
			pHit = Random.Range (0, 100);
			oHit = Random.Range(0, 20);

			if (attack >= _sp) {
				pHit = _sp;
			}

			if (pHit >= 10) {
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHitText, "Hit!");
				_oHealth = _oHealth - Mathf.CeilToInt (attack);
				if (_oHealth <= 0) {
					_oHealth = 0;
				}
				oHealthBar.value = _oHealth;
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHealth, _oHealth + "/" + _oHealthMax);
			} else if (pHit < 50) {
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHitText, "Miss!");
			}

			if (_oHealth <= 0) {
				yield return new WaitForSecondsRealtime (0.5f);
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHitText, "");
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHitText, "");
				win = true;
				Time.timeScale = 1;
				_pHealthMax = 100;
				outcome ();

			}

			yield return new WaitForSecondsRealtime (0.5f);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHitText, "");
			yield return new WaitForSecondsRealtime (0.25f);

			if (oHit >= 5) {
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHitText, "Hit!");
				_pHealth = _pHealth - Mathf.CeilToInt (oAttack);
				if (_pHealth <= 0) {
					_pHealth = 0;
				}
				pHealthBar.value = _pHealth;
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHealth, _pHealth + "/" + _pHealthMax);
			} else if (oHit < 5) {
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHitText, "Miss!");
			}

			yield return new WaitForSecondsRealtime (0.5f);
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHitText, "");
			yield return new WaitForSecondsRealtime (0.25f);

			if (_pHealth <= 0) {
				yield return new WaitForSecondsRealtime (0.5f);
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHitText, "");
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHitText, "");
				win = false;
				Time.timeScale = 1;
				_pHealthMax = 100;
				outcome ();
			}
		}
	}

}

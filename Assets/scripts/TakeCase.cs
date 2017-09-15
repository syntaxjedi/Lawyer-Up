using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakeCase : MonoBehaviour {

	float first;
	float second;
	float third;
	float fourth;

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

			first = _sp / 2;
			second = first / 2;
			third = first + second;
			fourth = first - second;
			/*Debug.Log ("first: " + first);
			Debug.Log ("third: " + third);
			Debug.Log ("fourth: " + fourth);*/

			oAttack = Random.Range (third, fourth);

			if (studyPoints.score < (_sp/2)) {
				attack = Random.Range (1, (_sp/2));

			} else if(studyPoints.score >= (_sp/2) && studyPoints.score < _sp){
				attack = Random.Range((_sp/2), _sp);

			}else if (studyPoints.score >= _sp) {
				attack = _sp;
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
			yield return new WaitForSecondsRealtime (1);
			pHit = Random.Range (studyPoints.score, _sp);
			oHit = 5;
			if (attack >= _sp) {
				pHit = _sp;
			}
			if (pHit >= 10) {
				_oHealth = _oHealth - Mathf.CeilToInt(attack);
				if (_oHealth <= 0) {
					_oHealth = 0;
				}
				oHealthBar.value = _oHealth;
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (oHealth, _oHealth + "/" + _oHealthMax);
			}

			if (oHit >= 5) {
				_pHealth = _pHealth - Mathf.CeilToInt(oAttack);
				if (_pHealth <= 0) {
					_pHealth = 0;
				}
				pHealthBar.value = _pHealth;
				textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pHealth, _pHealth + "/" + _pHealthMax);
			}

			yield return new WaitForSecondsRealtime (1);

			if (_oHealth <= 0) {
				win = true;
				Time.timeScale = 1;
				_pHealthMax = 100;
				outcome ();

			} else if (_pHealth <= 0) {
				win = false;
				Time.timeScale = 1;
				_pHealthMax = 100;
				outcome ();
			}
		}
	}

}

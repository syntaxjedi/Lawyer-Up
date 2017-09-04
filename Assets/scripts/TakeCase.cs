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
			oAttack = Random.Range (1, _sp);
			if (studyPoints.score < _sp) {
				attack = Random.Range ((studyPoints.score % _sp), _sp);
			} else if (studyPoints.score >= _sp) {
				attack = _sp;
			}
			//studyPoints.score = studyPoints.score - _sp;
			studyPoints.score -= _sp;
			if (studyPoints.score <= 0) {
				studyPoints.score = 0;
			}
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (pointsDisplay, "Study Points: " + studyPoints.score);
			Debug.Log ("Attack Power: " + attack);
			//pHealth.SetActive (true);
			//oHealth.SetActive (true);
			cr = LawyerBattle();
			StartCoroutine (cr);
		}else if (studyPoints.score <= 0) {
			textUpdate.GetComponent<textUpdateRemote> ().loseBool = false;
			textUpdate.GetComponent<textUpdateRemote> ().warningBool = true;
			Debug.Log ("Time Scale: " + Time.timeScale);
		}
	}

	void outcome(){
		if (win) {
			courtRoom.SetActive (false);
			mainWindow.SetActive (true);
			StopCoroutine(cr);
			//pHealth.SetActive (false);
			//oHealth.SetActive (false);
			newCash.money += _payout;
			textUpdate.GetComponent<textUpdateRemote> ().valueDisplay (cashDisplay, "Cash: $" + newCash.money);
		} else if (!win) {
			courtRoom.SetActive (false);
			mainWindow.SetActive (true);
			StopCoroutine(cr);
			//pHealth.SetActive (false);
			//oHealth.SetActive (false);
			textUpdate.GetComponent<textUpdateRemote> ().loseBool = true;
		}
	}

	IEnumerator LawyerBattle(){
		Time.timeScale = 0;
		while (_oHealth > 0 || _pHealth > 0) {
			yield return new WaitForSecondsRealtime (1);
			pHit = Random.Range (studyPoints.score, _sp);
			oHit = 5;
			if (studyPoints.score >= _sp) {
				pHit = _sp;
			}
			Debug.Log ("pHit: " + pHit);
			Debug.Log ("oHit: " + oHit);
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

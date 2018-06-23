using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenZoneController : MonoBehaviour {
	public AudioClip goToHeavenSound;
	AudioSource goToHeavenSource;
	int score = 0;
	// Use this for initialization
	void Start () {
		goToHeavenSource = this.gameObject.AddComponent<AudioSource> ();
		goToHeavenSource.clip = goToHeavenSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("BadGhost")) {
			SendToHeaven (collider, gameController.current.pointsForBadGhost);
		} else if (collider.CompareTag ("GoodGhost")) {
			SendToHeaven (collider, gameController.current.pointsForGoodGhost);
		}
		else if(collider.CompareTag("BonusGhost")){
			SendToHeaven (collider, gameController.current.pointsForBonus);
		}

	/*	if (collider.CompareTag ("BadGhost") || collider.CompareTag ("GoodGhost")) {
			Destroy (collider.gameObject);
			if(!goToHeavenSource.isPlaying)
				goToHeavenSource.Play ();
		}*/
	//	score++;
	}

	void SendToHeaven(Collider2D collider,int points){
		Destroy (collider.gameObject);
		if(SoundManager.Instance.isSoundOn() && !goToHeavenSource.isPlaying)
			goToHeavenSource.Play ();
		gameController.current.AddToGameScore (points);
	}
}

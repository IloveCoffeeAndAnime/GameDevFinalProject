using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {
	public AudioClip goingTohevenSound;
	AudioSource soundSource;
	string tagToDestroyGood = "GoodGhost";
	string tagToDestroyBad = "BadGhost";
	// Use this for initialization
	void Start () {
		soundSource = this.gameObject.AddComponent<AudioSource> ();
		soundSource.clip = goingTohevenSound;
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag (tagToDestroyGood)) {
			SendToGate (collider,gameController.current.pointsForGoodGhost);
		}
		else if(collider.CompareTag (tagToDestroyBad)){
			SendToGate (collider,gameController.current.pointsForBadGhost);
		}
	}
	void SendToGate(Collider2D collider,int points){
		Destroy(collider.gameObject);
		gameController.current.AddToGameScore (points);
		if(SoundManager.Instance.isSoundOn() && !soundSource.isPlaying)
			soundSource.Play ();
	}
}

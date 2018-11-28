using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour {

    public Text goldLabel;
    public Text waveLabel;

    public GameObject[] nextWaveLabels;
    public bool gameOver = false;

    private int gold;
    private int wave;

    void Start () {
        Gold = 1000;
        Wave = 0;
	}
	
	void Update () {
		
	}

	public int Gold {
		get {
			return gold;
		}

		set {
			gold = value;
			goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
		}
	}

    public int Wave {
        get {
            return wave;
        }

        set {
            wave = value;

            if (!gameOver) {
                for (int i = 0; i < nextWaveLabels.Length; i++) {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }

            //waveLabel.text = "WAVE: " + (wave + 1);
            waveLabel.GetComponent<Text>().text = "WAVE: " + wave;
        }
    }

}

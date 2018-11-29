using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour {

    public Text goldLabel;
    public Text waveLabel;
    public Text healthLabel;

    public GameObject[] nextWaveLabels;
    public GameObject[] healthIndicator;

    public bool gameOver = false;

    private int gold;
    private int wave;
    private int health;

    void Start () {
        Gold = 1000;
        Wave = 0;
        Health = 5;
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

            waveLabel.text = "WAVE: " +  (wave + 1);
        }
    }

    public int Health {
        get {
            return health;
        }
        set {
            if (value < health) {
                Camera.main.GetComponent<CameraShake>().Shake();
           
            }

            health = value;
            healthLabel.text = "HEALTH: " + health;
           
            if (health <= 0 && !gameOver) {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }

            for (int i = 0; i < healthIndicator.Length; i++) {
                if (i < Health) {
                    healthIndicator[i].SetActive(true);
                }

                else {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }

}

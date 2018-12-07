using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    private float originalScale;

    private GameManagerBehavior gameManager;

    public float baseHealth = 150;


    // Use this for initialization
    void Start () {
        originalScale = gameObject.transform.localScale.x;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        maxHealth = (float)(baseHealth * (1 + Mathf.Pow((gameManager.Wave - 1), 2)) * .7);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update () {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}

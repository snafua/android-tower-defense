using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    public float speed = 10;
    public int damage;

    private GameManagerBehavior gameManager;

    private float distance;
    private float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }

    // Update is called once per frame
    void Update () {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition)) {
            if (target != null) {
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar>();

                healthBar.currentHealth -= Mathf.Max(damage, 0);

                if (healthBar.currentHealth <= 0) {
                    Destroy(target);
                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    gameManager.Gold += 50;
                }
            }

            Destroy(gameObject);
        }
    }
}

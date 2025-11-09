using System;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Transform playerTransform;
    private bool shouldMove;
    public void StartMovingTowards(Transform plTransform) {
        this.playerTransform = plTransform;
        shouldMove = true;
    }

    private void Update() {
        if(!playerTransform || !shouldMove) {
            return;
        }
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        float speed = 2f;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Enemy collided with Player!");
            GameManager.PlayerHealth -= 1;
            Destroy(gameObject);
        }
    }
}


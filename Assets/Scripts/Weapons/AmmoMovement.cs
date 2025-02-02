using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMovement : MonoBehaviour
{
    [SerializeField] LayerMask hitable;
    [SerializeField] float speed = 35;
    [SerializeField] int power = 5;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SelfDestruct), 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PopUpScreen.Instance.gameObject.activeSelf) {
            return;
        }

        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        CheckCollision();
    }

    private void CheckCollision()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f, hitable)) {
            return;
        }

        if (hit.collider.CompareTag("Laser")) {
            // Ignore colliding lasers
            return;
        }

        if (hit.collider.CompareTag("Enemy")) {
            var enemy = hit.collider.GetComponent<IEnemy>();
            enemy.TakeDamage(power);
        }

        if (hit.collider.CompareTag("Player")) {
            HealthManager.Instance.TakeDamage(power);
        }

        SelfDestruct();
    }

    void SelfDestruct() {
        Destroy(gameObject); 
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Monster") {
            health -= damage;
        }
    }

    private void Update() {
        if (health <= 0) {
            SceneManager.LoadScene("Culling 2");
        }
    }
}

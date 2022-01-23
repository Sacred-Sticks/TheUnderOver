using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damage;
    Camera deathcam;
    NavMeshAgent monsterAgent;
    private void Awake()
    {
        deathcam = GameObject.Find("deathcam").GetComponent<Camera>();
        monsterAgent = GameObject.Find("Ceratoferox").GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Monster") {
            health -= damage;
        }
    }

    private void Update() {
        if (health <= 0) {
            

            Invoke("DeathRoutine",0f);
            
        }
    }

    void DeathRoutine()
    {
        // switch camera to close up of monster and change monster animation into killing blow
        monsterAgent.enabled = false;
            deathcam.enabled = true;
        Invoke("WaitToSwap", 4f);

    }

    void WaitToSwap()
    {
        Debug.Log("Invoking swap");
        SceneManager.LoadScene("Culling 2");
    }
}

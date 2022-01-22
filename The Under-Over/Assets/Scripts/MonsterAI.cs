using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    public float atkRange;
    [SerializeField] Transform playerDummy;
    NavMeshAgent nma;
    void Start()
    {
        TryGetComponent<Animator>(out anim);
        TryGetComponent<NavMeshAgent>(out nma);
        InvokeRepeating("NavTick", 1f, 1f);
    }

    void NavTick()
    {
        nma.SetDestination(playerDummy.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerDummy.position) <= atkRange)
            anim.SetBool("inRange", true);
        else
            anim.SetBool("inRange", false);
    }
}

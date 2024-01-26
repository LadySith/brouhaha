using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(AgentLinkMover))]
public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public float UpdateRate = 0.1f;
    public float attackDistance = 3f;
    public Transform player;
    public Animator animator;
    private AgentLinkMover linkMover;

    private Coroutine FollowCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        linkMover = GetComponent<AgentLinkMover>();

        linkMover.OnLinkStart += HandleLinkStart;
        linkMover.OnLinkEnd += HandleLinkEnd;
    }

    public void StartChasing()
    {
        if (FollowCoroutine == null)
        {
            FollowCoroutine = StartCoroutine(FollowTarget());
        }
        else
        {
            Debug.LogWarning("Called StartChasing on Enemy that is already chasing! This is likely a bug in some calling class!");
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);

        while (gameObject.activeSelf)
        {
            enemy.SetDestination(player.position);
            yield return Wait;
        }
    }

    private void HandleLinkStart()
    {
        animator.SetTrigger("Jump");
    }

    private void HandleLinkEnd()
    {
        animator.SetTrigger("Landed");
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        if (Vector3.Magnitude(enemy.velocity) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (enemy.remainingDistance < attackDistance)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Kill()
    {
        animator.enabled = false;
        enemy.enabled = false;
    }
}

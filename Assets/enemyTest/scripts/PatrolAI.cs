using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAI : MonoBehaviour
{
    public PatrolPoint[] patrolPoints;

    private NavMeshAgent agent;
    private PatrolPoint currentPoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPoint();
    }

    private void Update()
    {
        if (currentPoint == null)
            return;

        // Перевіряємо, чи NPC знаходиться в радіусі поточної точки
        Collider[] hits = Physics.OverlapSphere(
            currentPoint.transform.position,
            currentPoint.radius);

        foreach (Collider hit in hits)
        {
            if (hit.transform == transform)
            {
                GoToRandomPoint();
                break;
            }
        }
    }

    private void GoToRandomPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        int index;

        do
        {
            index = Random.Range(0, patrolPoints.Length);
        }
        while (patrolPoints.Length > 1 && patrolPoints[index] == currentPoint);

        currentPoint = patrolPoints[index];
        agent.SetDestination(currentPoint.transform.position);
    }

    // Для зручності в редакторі показує радіус точки
    private void OnDrawGizmosSelected()
    {
        if (currentPoint == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(currentPoint.transform.position, currentPoint.radius);
    }
}
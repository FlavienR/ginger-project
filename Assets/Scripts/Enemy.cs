using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    // Use this for initialization
    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        _agent.SetDestination(Player.Instance.transform.position);
    }
}

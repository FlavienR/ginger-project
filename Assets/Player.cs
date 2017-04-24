using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Player : MonoBehaviour
{
    // Static singleton instance
    private static Player _instance;
    private Vector3 _newPos;
    private GameObject _crossHair;
    private NavMeshAgent _agent;

    // Static singleton property
    public static Player Instance
    {
        get { return _instance ?? (_instance = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Player>()); }
    }

    // Use this for initialization
    private void Start()
    {
        name = "Player";
        _agent = gameObject.AddComponent<NavMeshAgent>();
        _agent.speed = 4f;
        GetComponent<Renderer>().material.color = Color.blue;
        InitCrossHair();
    }

    private void InitCrossHair()
    {
        _crossHair = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _crossHair.GetComponent<Renderer>().material.color = Color.green;
        _crossHair.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void MoveTo(Vector3 position)
    {
        if (_agent)
            _agent.SetDestination(position);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "TerrainPlane")
            {
                _crossHair.transform.position = hit.point;
            }
            if (Input.GetMouseButton(0))
                _newPos = _crossHair.transform.position;
        }
        MoveTo(_newPos);
    }
}


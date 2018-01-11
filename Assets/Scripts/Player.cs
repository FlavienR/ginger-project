using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Player : MonoBehaviour
{
    // Static singleton instance
    private static Player _instance;

    public bool IsBuilding;

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

    // Update is called once per frame
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "TerrainPlane" && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _crossHair.transform.position = hit.point;
                if (!IsBuilding)
                {
                    _newPos = hit.point;
                }
            }
        }
        MoveTo(_newPos);
    }
    
    public void BuildCurrentObject()
    {
        _crossHair.gameObject.transform.SetParent(null);
        ExitBuildingMode();
    }

    public void CancelBuilding()
    {
        Destroy(_crossHair.gameObject);
        ExitBuildingMode();
    }

    private void ExitBuildingMode()
    {
        InitCrossHair();
        IsBuilding = false;
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

    public void ChangeCrossHairBuild(GameObject prefab)
    {
        Destroy(_crossHair.gameObject);
        _crossHair = Instantiate(prefab);
        IsBuilding = true;
    }
}


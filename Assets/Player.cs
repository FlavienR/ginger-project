using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // Static singleton instance
    private static Player _instance;

    private Vector3 _newPos;
    private GameObject _crossHair;
    private NavMeshAgent _agent;
    private bool _isBuilding;

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

    public void ChangeCrossHairBuild(GameObject prefab)
    {
        GameObject.Destroy(_crossHair.gameObject);
        _crossHair = Instantiate(prefab);
        _isBuilding = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "TerrainPlane")
            {
                _crossHair.transform.position = hit.point;
            }
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _newPos = _crossHair.transform.position;
            }else if (Input.GetMouseButtonUp(0))
            {
                if (_isBuilding && !EventSystem.current.IsPointerOverGameObject())
                {
                    // Le fais de réassigner le crosshair, fais perdre le focus sur l'objet et ne suis plus la souris
                    InitCrossHair();
                    _isBuilding = false;
                }
            }
        }
        MoveTo(_newPos);
    }
}


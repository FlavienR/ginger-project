using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Static singleton instance
    private static Player instance;

    private Vector3 newPos;
    private GameObject crossHair;

    // Static singleton property
    public static Player Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Player>()); }
    }

    // Use this for initialization
    void Start()
    {
        name = "Player";
        newPos = Vector3.zero;
        GetComponent<Renderer>().material.color = Color.blue;
        crossHair = GameObject.CreatePrimitive(PrimitiveType.Cube);
        crossHair.GetComponent<Renderer>().material.color = Color.green;
        crossHair.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
                crossHair.transform.position = hit.point;
            }
            if (Input.GetMouseButton(0))
                newPos = crossHair.transform.position;
        }
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
    }
}


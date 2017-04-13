using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{
    // Static singleton instance
    private static GameManager instance;

    // Static singleton property
    public static GameManager Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = new GameObject("GameManagerObject").AddComponent<GameManager>()); }
    }

    void Start()
    {
        Player.Instance.gameObject.transform.position = Vector3.zero;
    }

    void Update()
    {

    }
}

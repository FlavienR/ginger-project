using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{
    // Static singleton instance
    private static GameManager instance;
	GameObject housePlayer;

    // Static singleton property
    public static GameManager Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = new GameObject("GameManagerObject").AddComponent<GameManager>()); }
    }

    void Start()
    {
		Init ();
		Vector3 pos = new Vector3 (Random.Range (0, 10), 0, Random.Range (0, 10));
		SetSpawn (pos);
		EnemyManager.Instance.StartSpawning ();
    }

	void Init(){
		Player.Instance.transform.position = Vector3.zero;
		housePlayer = Instantiate(Resources.Load ("Prefab/HousePrefab") as GameObject);
	}

	void SetSpawn(Vector3 pointToSpawn){
		pointToSpawn.y = 2.60f;
		housePlayer.transform.position = pointToSpawn;
		Player.Instance.MoveTo (pointToSpawn/2f);
	}

    void Update()
    {

    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static singleton instance
    private static GameManager _instance;
	private GameObject _housePlayer;

    // Static singleton property
    public static GameManager Instance
    {
        get { return _instance ?? (_instance = new GameObject("GameManagerObject").AddComponent<GameManager>()); }
    }

    private void Start()
    {
		Init ();
		Vector3 pos = new Vector3 (Random.Range (0, 10), 0, Random.Range (0, 10));
		SetSpawn (pos);
		EnemyManager.Instance.StartSpawning ();
    }

    private void Init(){
		Player.Instance.transform.position = Vector3.zero;
		_housePlayer = Instantiate(Resources.Load ("Prefab/HousePrefab") as GameObject);
	}

    private void SetSpawn(Vector3 pointToSpawn){
		pointToSpawn.y = 2.60f;
		_housePlayer.transform.position = pointToSpawn;
		Player.Instance.MoveTo (pointToSpawn/2f);
	}

    private void Update()
    {
    }
}

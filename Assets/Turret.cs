using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float speed = 10f;

    private GameObject _target = null;
    private Transform _canon;
    private Vector3 _lastKnownPosition = Vector3.zero;
    private Quaternion _lookAtRotation;

    public float fieldOfView = 60f;
    public float rangeOfView = 10f;

    // Use this for initialization
    private void Start()
    {
        _canon = transform.FindChild("Canon");
    }

    // Update is called once per frame
    private void Update()
    {
        TargetNearestEnemy();
        if (_target)
        {
            if (_lastKnownPosition != _target.transform.position)
            {
                _lastKnownPosition = _target.transform.position;
                _lookAtRotation = Quaternion.LookRotation(_lastKnownPosition - _canon.transform.position);
            }

            if (_canon.transform.rotation != _lookAtRotation)
            {
                _canon.transform.rotation = Quaternion.RotateTowards(_canon.transform.rotation, _lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    private void TargetNearestEnemy()
    {
        for (int i = 0; i < EnemyManager.Instance.listEnemies.Count; i++)
        {
            GameObject enemy = EnemyManager.Instance.listEnemies[i];
            if(Vector3.Distance(transform.position, enemy.transform.position) < rangeOfView)
            {
                SetTarget(enemy);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}

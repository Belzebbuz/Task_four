using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeController : MonoBehaviour {

    [SerializeField] private float LifeTime = 10f;

    private float _lifeTimer;

    private void OnEnable()
    {
        _lifeTimer = LifeTime;
    }

    private void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0f)
        {
            //gameObject.DestroyOrMoveToPool();
            Destroy(gameObject);
        }
    }
}

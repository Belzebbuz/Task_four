using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour 
{ 
	[SerializeField] private LevelConfig startLevel;
    [SerializeField] private float spawnRange;

    private List<LevelConfig.PrefabData> _objects = new List<LevelConfig.PrefabData>();

    private void Start()
    {
        _objects.Clear();
        _objects.AddRange(startLevel.Objects);
    }

    private void ObjectsSpawn(LevelConfig level)
    {
        int i = 0;
        while (i < _objects.Count)
        {
            var obj = _objects[i];
            if (SpawnRange(obj.Position))
            {
                var go = Instantiate(obj.Prefab, obj.Position, Quaternion.identity);
                var weaponPlace = go.GetComponent<WeaponPlace>();
                if (weaponPlace!= null)
                {
                    weaponPlace.StartedWeaponPrefab = obj.MeleeWeapon;
                }
                _objects.RemoveAt(i);
                continue;
            }
            ++i;
        }
    }

    private void Update()
    {
        ObjectsSpawn(startLevel);
    }

    private bool SpawnRange(Vector3 spawnPoint)
    {
        float dist = Vector3.Distance(spawnPoint, Player.Instance.transform.position);
        return dist < spawnRange;
    }
}

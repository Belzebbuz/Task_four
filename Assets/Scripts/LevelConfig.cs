using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelConfig : ScriptableObject 
{
	[System.Serializable]
	public struct PrefabData
	{
		public GameObject Prefab;
        public Vector3 Position;
        public MeleeWeapon MeleeWeapon;
        //public Transform Transform;
	}

	public PrefabData[] Objects;
}

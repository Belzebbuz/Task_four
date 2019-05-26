using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour {

    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float timeShoot;

    private float _timerShoot = 0;
    private Bullet _bullet;

    private void Update()
    {
        if (_timerShoot >= 0)
            _timerShoot -= Time.deltaTime;
        Shoot();
    }

    public void Shoot()
    {
        if(_timerShoot <= 0)
        {
            if (_prefabBullet != null)
            {
                Instantiate(_prefabBullet, transform.position, transform.rotation).GetComponent<Bullet>();

                var particle = transform.GetComponent<ParticleSystem>();
                if (particle != null)
                    particle.Play();
            }

            _timerShoot = timeShoot;
        }
    }
}

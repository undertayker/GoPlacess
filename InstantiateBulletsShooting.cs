using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _quantityBullet;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] GameObject _prefab;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = true;

        while (isWork)
        {
            var vectorDirection = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vectorDirection, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = vectorDirection;
            newBullet.GetComponent<Rigidbody>().velocity = vectorDirection * _quantityBullet;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
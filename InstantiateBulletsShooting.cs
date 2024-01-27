using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _quantityBullet;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private GameObject _prefab;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(Bullet—reation());
    }

    private IEnumerator Bullet—reation()
    {
        bool isWork = true;

        while (isWork)
        {
            var vectorDirection = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vectorDirection, Quaternion.identity);

            newBullet.transform.up = vectorDirection;
            newBullet.GetComponent<Rigidbody>().velocity = vectorDirection * _quantityBullet;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ship : Player
{
    [SerializeField] private float _speed = 1;

    private Rigidbody _rigidbody;
    private Planet _plane;
    private Renderer _renderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Planet planet = collision.gameObject.GetComponent<Planet>();
        if (planet && planet == _plane)
        {
            planet.Attack(PlayerId, PlayerColor);

            Ships.Instance.ReturnShip(this);
        }
    }

    public void FlyTo(Planet target)
    {
        gameObject.SetActive(true);
        _plane = target;
        transform.LookAt(_plane.transform.position);
        StartCoroutine(Flying());
    }

    private IEnumerator Flying()
    {
        while (true)
        {
            _rigidbody.velocity = (_plane.transform.position - transform.position).normalized * _speed;
            yield return null;
        }
    }

    protected override void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }
}

using UnityEngine;

[RequireComponent(typeof(PlanetText))]
[RequireComponent(typeof(Base))]
public class Planet : Player
{
    [SerializeField] private float _selectSize;
    public bool Selected { get => _selected; }
    public int ShipCount { get => _base.Count; }

    private Vector3 _scale;
    private Vector3 _selectedScale;
    private Base _base;
    private bool _selected;
    private Renderer _renderer;

    private void Awake()
    {
        _base = GetComponent<Base>();
        _base.enabled = false;
        _scale = transform.localScale;
        _selectedScale = _scale * _selectSize;
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _base = GetComponent<Base>();
        _base.enabled = false;
        _scale = transform.localScale;
        _selectedScale = _scale * _selectSize;
        _renderer = GetComponent<Renderer>();
    }

    public void Select()
    {
        _selected = true;
        transform.localScale = _selectedScale;
    }

    public void UnSelect()
    {
        _selected = false;
        transform.localScale = _scale;
    }

    public void Deploy(Planet target)
    {
        if (target != this) _base.Deploy(target);
    }

    public void Attack(int id, Color color)
    {
        if (_base.Count < 0) SetPlayer(id, color);
        else
        if (id == PlayerId) _base.Add();
        else _base.Kill();
    }

    protected override void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }
}
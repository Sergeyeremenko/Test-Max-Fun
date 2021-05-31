using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Base), typeof(Planet))]

public class PlanetText : MonoBehaviour
{
    [SerializeField] private Text _text;

    private Base _base;
    private Planet _planet;

    private void Start()
    {
        _base = GetComponent<Base>();
        _planet = GetComponent<Planet>();

        UpdateText();
    }

    private void FixedUpdate()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (_planet.PlayerId == 0 || _planet.PlayerId == 1)
        {
            _text.text = _base.Count.ToString();
        }
        else
        {
            _text.text = "";
        }
    }
}

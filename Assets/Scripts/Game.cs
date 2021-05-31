using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private int _playerCount = 3;
    [SerializeField] private float _playersRefill = 0.2f;
    [SerializeField] private int _playersStartShips = 50;
    [SerializeField] private ColorPallete _colorPallete;

    private List<Planet> _planets;

    private void Start()
    {
        _planets = GeneratorPlanets.Instance.Planets;

        for (int i = 1; i <= _playerCount; i++)
        {
            int playerPlanet = Random.Range(0, _planets.Count);

            _planets[playerPlanet].SetPlayer(i, _colorPallete.GetColor(i - 1));

            _planets[playerPlanet].GetComponent<Base>().SetDefault(_playersRefill, _playersStartShips);

            if (i > 1)
            {
                Bot simpleBot = gameObject.AddComponent<Bot>();
                simpleBot.Init(i);
            }

            _planets.RemoveAt(playerPlanet);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void OnValidate()
    {
        if (_playerCount < 1) _playerCount = 1;
        int planetCount = FindObjectOfType<GeneratorPlanets>().PlanetCount;
        if (_playerCount > planetCount) _playerCount = planetCount;
        if (_playerCount > _colorPallete.Length) _playerCount = _colorPallete.Length;
    }
}
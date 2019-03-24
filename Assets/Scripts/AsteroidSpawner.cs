using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject asteroidPrefab;

    float radius;
	// Use this for initialization
	void Start () {

        radius = asteroidPrefab.GetComponent<CircleCollider2D>().radius;
        Instantiate(asteroidPrefab).GetComponent<Asteroid>().Initializer(Directions.Right, new Vector2(ScreenUtils.ScreenLeft + radius, 0));
        Instantiate(asteroidPrefab).GetComponent<Asteroid>().Initializer(Directions.Left, new Vector2(ScreenUtils.ScreenRight - radius, 0));
        Instantiate(asteroidPrefab).GetComponent<Asteroid>().Initializer(Directions.Up, new Vector2(0, ScreenUtils.ScreenBottom + radius));
        Instantiate(asteroidPrefab).GetComponent<Asteroid>().Initializer(Directions.Down, new Vector2(0, ScreenUtils.ScreenTop - radius));
    }
	
}

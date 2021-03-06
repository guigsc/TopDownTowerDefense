using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Enemy[] _enemyPrefabs;
    [SerializeField] private float _spawnRate;

    private float _radius = 20f;
    private float _spawnHeight = 2f;
    private float _nextSpawn;
    
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;

            var enemyIndex = Random.Range(0, 2);

            var _enemyGO = Instantiate(_enemyPrefabs[enemyIndex], GetSpawnPosition(), _enemyPrefabs[enemyIndex].transform.rotation);
            _enemyGO.GetComponent<Renderer>().material.color = Random.ColorHSV();

        }
    }

    private Vector3 GetSpawnPosition()
    {
        var spawnPoint = Random.insideUnitCircle * _radius;
        
        while (Vector3.Distance(spawnPoint, transform.position) < _radius * 0.85)
        {
            spawnPoint = Random.insideUnitCircle * _radius;
        }

        return new Vector3(spawnPoint.x, _spawnHeight, spawnPoint.y);
    }
}

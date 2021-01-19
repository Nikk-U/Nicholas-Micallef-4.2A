using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemuSpawner : MonoBehaviour
{
    [SerializeField] List<WC> waveConfigScript;

    int startingWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigScript[startingWave];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnAllEnemiesInWave(WC wC)
    {
      var newEnemy = Instantiate(
            wC.GetEnemyPrefab(),
            wC.GetWaypoints()[0].transform.position,
            Quaternion.identity);
        newEnemy.GetComponent<ObstaclePathing>().SetWaveConfig(wC);

        yield return new WaitForSeconds(wC.GetTimeBetweenSpawns());
    }

    private IEnumerator SpawnAllWves()
    {
        foreach(WC currentWave in waveConfigScript)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}



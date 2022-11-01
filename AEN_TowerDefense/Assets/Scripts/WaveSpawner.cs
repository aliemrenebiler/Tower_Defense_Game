using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveIndexText;
    public Text countdownText;

    public float waveTimeLength = 10f;
    public float cooldownTimeLength = 5f;
    public float spawnDelay = 0.5f;

    public int waveIndex;
    private float countdown;
    private bool cooldownIsActive;

    void Start()
    {
        waveIndex = 0;
        waveIndexText.text = "Cooldown";
        cooldownIsActive = true;
        countdown = 3f;
    }

    void Update()
    {
        if(!GameManager.gameStarted || GameManager.gameIsOver){
            return;
        }
        if (countdown <= 0)
        {
            cooldownIsActive = !cooldownIsActive;
            if (cooldownIsActive)
            {
                PlayerStats.rounds = waveIndex;
                waveIndexText.text = "Cooldown";
                countdown = cooldownTimeLength;
            }
            else
            {
                waveIndex++;
                waveIndexText.text = "Wave #" + waveIndex.ToString();
                StartCoroutine(SpawnWave());
                countdown = waveTimeLength;
            }
        }

        if (cooldownIsActive)
        {
            countdownText.text = "Next wave in " + ((int)countdown + 1).ToString();
        }
        else
        {
            countdownText.text = "The wave ends in " + ((int)countdown + 1).ToString();
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

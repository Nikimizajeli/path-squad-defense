using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompletedCanvas;
    [SerializeField] float waitBeforeNextScene = 3f;
    
    [Header("debug")]
    [SerializeField] int numberOfAttackers = 0;
    [SerializeField] bool levelTimerFinished = false;

    private void Start()
    {
        levelCompletedCanvas.SetActive(false);
    }

    IEnumerator HandleWinCondition()
    {
        GetComponent<AudioSource>().Play();

        levelCompletedCanvas.SetActive(true);

        yield return new WaitForSeconds(waitBeforeNextScene);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
    
}

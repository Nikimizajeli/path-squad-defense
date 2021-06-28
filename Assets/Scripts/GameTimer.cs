using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelDuration = 10;
    Slider slider;
    bool triggeredLevelFinished = false;

    void Start()
    {
        levelDuration += PlayerPrefsController.GetDifficulty() * levelDuration;
        slider = GetComponent<Slider>();
        slider.maxValue = levelDuration;
    }

    void Update()
    {
        if (triggeredLevelFinished) { return; }
        slider.value += Time.deltaTime;
        if(slider.value >= levelDuration)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;

        }
    }
}

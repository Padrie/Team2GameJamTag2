using UnityEngine;
using UnityEngine.UI;
using MyBox;
using System;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public Image faithMeter;
    public Image deadScreen;

    public static event Action OnFaithFull;


    private void OnEnable()
    {
        EnemyAI.OnPlayerDied += DeadScreen;
        SmallEnemyAI.OnEnemyDied += UpdateFaith;
    }

    private void OnDisable()
    {
        EnemyAI.OnPlayerDied -= DeadScreen;
        SmallEnemyAI.OnEnemyDied -= UpdateFaith;
    }

    public void UpdateFaith()
    {
        faithMeter.fillAmount += .34f;

        if (faithMeter.fillAmount == 1)
        {
            OnFaithFull?.Invoke();
        }
    }

    public void DeadScreen()
    {
        deadScreen.gameObject.SetActive(true);
    }
}

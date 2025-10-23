using System.Collections;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;

    [SerializeField] float time;
    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int milliseconds;

    [SerializeField] bool state = true;

    private void OnEnable()
    {
        EventManager.Subscribe(Condition.START, Execute);
        EventManager.Subscribe(Condition.PAUSE, Pause);
        EventManager.Subscribe(Condition.EXIT, Pause);
    }

    void Execute()
    {
        StartCoroutine(Measure());
    }

    void Pause()
    {
        state = false;
    }

    void Exit()
    {
        timeText.text = "Game Over";
    }

    public IEnumerator Measure()
    {
        while(state)
        {
            if (time <= 0)
            {
                EventManager.Publish(Condition.EXIT);

                yield break;
            }


            time -= Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            milliseconds = (int)(time * 100) % 100;

            timeText.text = string.Format("{0:02} : {1:02} : {2:02}", minute, second, milliseconds);

            yield return null;
        }
    }

    private void OnDisable()
    {
        EventManager.UnSubscribe(Condition.START, Execute);
        EventManager.UnSubscribe(Condition.PAUSE, Pause);
        EventManager.UnSubscribe(Condition.EXIT, Pause);

    }


}

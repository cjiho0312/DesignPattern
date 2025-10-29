using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject OriginalRobot;
    private int time;

    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while (true)
        {
            GameObject r = Instantiate(OriginalRobot);

            r.SetActive(true);

            time = Random.Range(1, 6);

            yield return CoroutineManager.WaitForSecond(time);
        }
    }
}

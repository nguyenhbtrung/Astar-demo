using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficUpdater : MonoBehaviour
{
    List<bool> isIncreases;

    private void Awake()
    {
        isIncreases = new List<bool>();
    }

    private void Start()
    {
        foreach (var trafficLevel in Astar.trafficLevelList)
        {
            isIncreases.Add(false);
        }
        StartCoroutine(UpdateTrafficLevel());
    }

    IEnumerator UpdateTrafficLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(40);
            for (int i = 0; i < Astar.trafficLevelList.Count; i++)
            {
                if (Astar.trafficLevelList[i] == 1)
                {
                    isIncreases[i] = true;
                }
                if (Astar.trafficLevelList[i] == 4)
                {
                    isIncreases[i] = false;
                }
                if (isIncreases[i])
                {
                    Astar.trafficLevelList[i]++;
                }
                else
                {
                    Astar.trafficLevelList[i]--;
                }
            }
        }
    }
}

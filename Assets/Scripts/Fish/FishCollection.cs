using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishCollection : MonoBehaviour
{
    [SerializeField]
    internal FishScriptObject[] FishPool;
    [SerializeField]
    internal List<FishScriptObject> CollectedFish;
    float[] table;

    private void Start()
    {
        table = new float[FishPool.Length];
        FishPool = FishPool.OrderByDescending(x => x.DropRate).ToArray();
        for (int i = 0; i < FishPool.Length; i++)
        {
            table[i] = FishPool[i].DropRate;
        }
        CollectedFish = new List<FishScriptObject>();
    }

    public void AddFishToCollecttion(FishScriptObject fish)
    {
        CollectedFish.Add(fish);
    }

    public FishScriptObject GetRandomFish()
    {
        float total = 0;
        foreach (float chance in table)
        {
            total += chance;
        }
        float randomNumber = Random.Range(0, total);
        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                var fish = FishPool[i];
                return fish;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
        return FishPool[0];
    }
}

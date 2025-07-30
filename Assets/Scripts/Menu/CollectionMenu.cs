using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CollectionMenu : MonoBehaviour
{
    [SerializeField]
    FishCollection fishCollection;
    [SerializeField]
    GameObject Collection;
    [SerializeField]
    CollectionItem ItemPrefab;
    [SerializeField]
    List<CollectionItem> Items;

    private void Start()
    {
        FillCollection();
    }
    public void FillCollection()
    {
        foreach (var fish in fishCollection.FishPool)
        {
            var item = Instantiate(ItemPrefab, Collection.transform);
            item.name = fish.Name;
            item.ItemImage.sprite = fish.Sprite;
            Items.Add(item);
        }
    }

    public void SetUnlockedCollection()
    {
        foreach (var item in Items)
        {
            if (fishCollection.CollectedFish.Find(f => f.name == item.name) != null)
            {
                item.ItemImage.color = Color.white;
            }
            else
            {
                item.ItemImage.color = Color.black;
            }
        }
    }
}

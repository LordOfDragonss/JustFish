using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    [SerializeField]
    HashSet<string> collectedFishNames;

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
            item.fishName = fish.Name;
            item.ItemImage.sprite = fish.Sprite;
            Items.Add(item);
        }
    }

    public void SetUnlockedCollection()
    {
        collectedFishNames = new HashSet<string>(fishCollection.CollectedFish.Select(f => f.Name));

        foreach (var item in Items)
        {
             item.ItemImage.color = collectedFishNames.Contains(item.fishName) ? Color.white : Color.black;
        }
    }

    public void OpenCollection()
    {
        SetUnlockedCollection();
        AudioManager.instance.Play("OpenChest");
    }

    public void CloseCollection()
    {
        AudioManager.instance.Play("CloseChest");
    }
}

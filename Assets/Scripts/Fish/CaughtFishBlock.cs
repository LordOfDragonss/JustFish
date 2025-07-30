using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MenuBasic))]
public class CaughtFishBlock : MonoBehaviour
{
    [SerializeField]
    private Image FishImageColor,FishImageBlack;
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI Description;
    [SerializeField]
    private TextMeshProUGUI Size;
    [SerializeField]
    private TextMeshProUGUI Weight;

    [SerializeField]
    private MenuBasic menu;

    private void Start()
    {
        menu = GetComponent<MenuBasic>();
    }


    public void CloseScreen()
    {
        StartCoroutine(menu.HideAnim());
    }

    public void FillBlock(FishScriptObject fish)
    {
        if (fish == null) return;
        FishImageColor.sprite = fish.Sprite;
        FishImageBlack.sprite = fish.Sprite;
        Name.text = fish.Name;
        Description.text = fish.Description;
        Size.text = $"Size: {fish.Size:F1}Cm"; // e.g., "Size 12.3Cm"
        Weight.text = $"Weight: {fish.Weight:F1}Kg";
        menu.Show();
    }

}

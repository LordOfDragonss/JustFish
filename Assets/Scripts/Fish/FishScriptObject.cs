using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "ScriptableObjects/Fish", order = 1)]
public class FishScriptObject : ScriptableObject
{

    public string Name;
    public string Description;
    public Sprite Sprite;
    [Range(0,100)]
    [Tooltip("chance of fishing this fish")]
    public float DropRate; //chance of fishing this fish
    [Range(0.1f, 500)]
    [Tooltip("Weight in KG")]
    public float Weight; //weight in KG
    [Range(1,300)]
    [Tooltip("Size in CM")]
    public float Size;//size in CM
    [Range(0, 10)]
    [Tooltip("The push back the fish gives")]
    public float Strength; //The push back the fish gives
}

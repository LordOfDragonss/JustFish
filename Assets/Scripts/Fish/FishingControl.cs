using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FishingControl : MonoBehaviour
{
    public float FishingStrength;
    public float CatchingSpeed;
    PlayerInput input;
    InputAction FishAction;
    [SerializeField]
    FishCollection FishCollection;
    [SerializeField]
    private CaughtFishBlock caughtScreen;

    [SerializeField]
    MenuBasic FishingMinigame;

    [SerializeField]
    Slider CatchingSlider;

    float catchingAnimationDelay = 2f;

    [Range(0, 100)]
    float CatchPercentage;
    public bool isInMinigame = false;
    public bool isInFishCaughtScreen = false;
    private float caughtScreenTimer = 0f;

    [SerializeField]
    Animator caughscreenAnimator;

    FishScriptObject ActiveFish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        FishAction = input.actions["fish"];
    }

    public void StopMinigame()
    {

        isInMinigame = false;
        FishingMinigame.Hide();
    }

    public void CloseCaughtScreen()
    {

        caughtScreen.CloseScreen();
        isInFishCaughtScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (EventSystem.current.currentSelectedGameObject != null) return;
        }

        if (FishAction.WasPressedThisFrame() && !isInMinigame && !isInFishCaughtScreen)
        {
            Fish();
        }
        else if (FishAction.WasPressedThisFrame() && isInMinigame)
        {
            IncreaseCatchingSlider(FishingStrength);
        }
        else if (FishAction.WasPressedThisFrame() && caughtScreenTimer >= catchingAnimationDelay && isInFishCaughtScreen)
        {
            CloseCaughtScreen();
        }

        if (isInFishCaughtScreen)
        {
            caughtScreenTimer += Time.deltaTime;

        }

        if (isInMinigame)
        {
            MinigameUpdate();
        }
    }

    public void MinigameUpdate()
    {
        CatchPercentage = CatchingSlider.value;
        if (CatchPercentage >= 100)
        {
            FishCaught(ActiveFish);
            StopMinigame();
            return;
        }
        if (CatchPercentage <= 0)
        {
            FishLost();
            StopMinigame();
            return;
        }
        DecreaseCatchingSlider(ActiveFish.Strength * Time.deltaTime);
    }

    public void Fish()
    {
        ActiveFish = FishCollection.GetRandomFish();
        StartFishingMinigame(ActiveFish);
    }

    public void StartFishingMinigame(FishScriptObject fish)
    {
        CatchPercentage = 50;
        CatchingSlider.value = CatchPercentage;
        isInMinigame = true;
        FishingMinigame.Show();
    }

    public void IncreaseCatchingSlider(float value)
    {
        CatchingSlider.value += value;
    }

    public void DecreaseCatchingSlider(float value)
    {
        CatchingSlider.value -= value;
    }

    public void FishCaught(FishScriptObject fish)
    {
        Debug.Log("[FishControl] Congratulations you caught a " + fish.name);
        caughtScreenTimer = 0;
        isInFishCaughtScreen = true;
        caughtScreen.FillBlock(fish);
        FishCollection.AddFishToCollecttion(fish);
    }

    public void FishLost()
    {
        Debug.Log("Fish has been lost");
    }
}

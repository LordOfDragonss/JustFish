using UnityEngine;

public class MenuBasic : MonoBehaviour
{
    public bool StartHidden = true;
    private bool visible;

    private void Awake()
    {
        if (StartHidden)
        {
            gameObject.SetActive(false);
        }
    }
    public void ToggleVisibility()
    {
        visible = !visible;
        gameObject.SetActive(visible);
    }
}

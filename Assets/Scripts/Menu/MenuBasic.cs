using System.Collections;
using UnityEngine;

public class MenuBasic : MonoBehaviour
{
    public bool StartHidden = true;
    public GameObject menuGroup;
    private bool visible;
    [SerializeField]
    Animator animator;

    private void Awake()
    {
        if (StartHidden)
        {
            visible = false;
            menuGroup.SetActive(visible);
        }
    }

    public void Show()
    {
        Debug.Log("Showing " + gameObject.name);
        visible = true;
        menuGroup.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("Hiding " + gameObject.name);
        visible = false;
        menuGroup.SetActive(false);
    }

    public IEnumerator HideAnim()
    {
        animator.SetTrigger("FlyOut");
        yield return new WaitForSeconds(2f);
        Debug.Log("Hiding " + gameObject.name);
        visible = false;
        menuGroup.SetActive(false);
    }

    public void ToggleVisibility()
    {
        visible = !visible;
        menuGroup.SetActive(visible);
    }
}

using System.Collections;
using UnityEngine;

public class MenuBasic : MonoBehaviour
{
    public bool StartHidden = true;
    public GameObject menuGroup;
    private bool visible;
    [SerializeField]
    Animator animator;
    [SerializeField]
    CollectionMenu collectionMenu;

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
        if (animator != null)
        {
            StartCoroutine(HideAnim());
        }
        else
        {
            visible = false;
            menuGroup.SetActive(false);
        }

    }

    public IEnumerator HideAnim()
    {
        animator.SetTrigger("FlyOut");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Hiding " + gameObject.name);
        visible = false;
        menuGroup.SetActive(false);
    }

    public void ToggleVisibility()
    {
        visible = !visible;
        if (!visible)
        {
            StartCoroutine(HideAnim());
        }
        else
        {
            menuGroup.SetActive(visible);
            if (collectionMenu != null) collectionMenu.SetUnlockedCollection();
        }
    }
}

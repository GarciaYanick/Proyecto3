using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Animator animator;

    public AnimationClip flipClip;
    public AnimationClip reverseClip;

    public GameObject panelPunto1;
    public GameObject panelPunto2;
    public GameObject panelPunto3;

    public GameObject pabloShopPanel;
    public GameObject pabloProfilePanel;
    public GameObject maliciaShopPanel;
    public GameObject maliciaProfilePanel;

    [SerializeField]public GameObject currentPanel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadStartAnimationTransition()
    {
        StartCoroutine(LoadStartAnimation());
    }

    public void LoadReverseAnimationTransition()
    {
        StartCoroutine(LoadReverseAnimation());
    }

    IEnumerator LoadStartAnimation()
    {

        Debug.Log("XD");

        animator.SetTrigger("StartGame");

        yield return new WaitForSeconds(flipClip.length + 0.1f);
    }

    IEnumerator LoadReverseAnimation()
    {
        Debug.Log("Reverse");
        animator.SetTrigger("BackToMenu");

        yield return new WaitForSeconds(reverseClip.length + 0.1f);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadBuyPanel()
    {
        
    }

    public void ActiveInventoryPanel()
    {
        StartCoroutine(SetInventoryPanelActive());
    }

    public void CloseBook()
    {
        StartCoroutine(CloseBookCoroutine());
    }

    IEnumerator SetInventoryPanelActive()
    {
        yield return new WaitForSeconds(0.5f);

        panelPunto1.SetActive(true);
    }


    IEnumerator CloseBookCoroutine()
    {
        yield return new WaitForSeconds(0.3f);

        panelPunto1.SetActive(false);
        panelPunto2.SetActive(false);
        panelPunto3.SetActive(false);
    }




}

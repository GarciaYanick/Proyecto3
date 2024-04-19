using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Animator animator;

    public AnimationClip flipClip;
    public AnimationClip reverseClip;

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





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Animator animator;

    public AnimationClip clip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadAnimationTransition()
    {
        StartCoroutine(LoadAnimation());
    }

    IEnumerator LoadAnimation()
    {
        animator.SetTrigger("StartGame");

        yield return new WaitForSeconds(clip.length + 0.1f);
    }



}

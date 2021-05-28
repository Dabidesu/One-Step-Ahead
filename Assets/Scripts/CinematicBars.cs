using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBars : MonoBehaviour
{
    public static CinematicBars Instance { get; private set; }

    [SerializeField] private GameObject cinematicBarContainer;
    //[SerializeField] public Animator animatorzxc;

    void Start()
    {
        CinematicBars.Instance.ShowBars();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    public void ShowBars()
    {
        cinematicBarContainer.SetActive(true);
    }

    public void HideBars()
    {
        if (cinematicBarContainer.activeSelf)
            StartCoroutine(DisableAfterHide());
    }

    private IEnumerator DisableAfterHide()
    {
        //animatorzxc.SetTrigger("HideBars");

        yield return new WaitForSeconds(0.5f);

        cinematicBarContainer.SetActive(false);
    }
}

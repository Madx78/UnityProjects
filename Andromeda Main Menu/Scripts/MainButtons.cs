using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    [Header("Animation delay")]
    [SerializeField]
    private float _delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimation());
    }


    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.GetComponent<Animator>().SetTrigger("MainButtonsAnimation");
    }
}

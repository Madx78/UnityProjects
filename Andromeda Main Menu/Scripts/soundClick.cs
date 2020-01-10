using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundClick : MonoBehaviour
{
    [SerializeField]
    private Slider _volumeControler;

    [SerializeField]
    private float _coef = 0.2f;
    private float _volume;

 
    // Update is called once per frame
    void Update()
    {

    
        ClickVolume();
    }

     public void ClickSound() {

        gameObject.GetComponent<AudioSource>().Play();
    }

    public void ClickVolume()
    {

        _volume = _volumeControler.value * _coef;

        gameObject.GetComponent<AudioSource>().volume = _volume;
    }






}

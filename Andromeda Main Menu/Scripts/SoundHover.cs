using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHover : MonoBehaviour
{
    [SerializeField]
    private Slider _volumeControler;

    [SerializeField]
    private float _coef = 0.14f;
    private float _volume;


    // Update is called once per frame
    void Update()
    {


        HoverVolume();
    }

    public void HoverSound()
    {

        gameObject.GetComponent<AudioSource>().Play();
    }

    public void HoverVolume()
    {

        _volume = _volumeControler.value * _coef;

        gameObject.GetComponent<AudioSource>().volume = _volume;
    }






}
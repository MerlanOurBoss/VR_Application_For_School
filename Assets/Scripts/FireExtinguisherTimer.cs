using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FireExtinguisherTimer : MonoBehaviour
{
    [SerializeField] Text _text;
    private float _remain = 100f;
    [SerializeField] ParticleSystem _smoke;

    private void Update()
    {
        if(_remain > 0)
        {
            if (_smoke.isPlaying == true)
            {
                _remain = _remain - 0.1f;
                _text.text = Math.Round((double)_remain,0).ToString() + " %";
            }
        }
        else
        {
            _smoke.Stop();
        }
        
    }

}

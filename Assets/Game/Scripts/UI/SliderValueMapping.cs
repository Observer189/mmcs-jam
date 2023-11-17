using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Меняет содержимое дочернего текстового объекта в зависимости от значения слайдера
public class SliderValueMapping : MonoBehaviour
{
    protected TextMeshProUGUI textRend;
    protected Slider slider;
    public enum RoundType //Тип округления
    {
        None, Floor, Round, Ceil
    }

    public RoundType roundType;
    protected virtual void Awake()
    {
        textRend = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponent<Slider>();
    }
    

    public virtual void UpdateText() //Вызывать при событии сдвига ползунка
    {
        switch (roundType)
        {
            case RoundType.None: textRend.text = (slider.value).ToString(); break;
            case RoundType.Floor: textRend.text = Mathf.Floor(slider.value).ToString(); break;
            case RoundType.Round: textRend.text = Mathf.Round(slider.value).ToString(); break;
            case RoundType.Ceil: textRend.text = Mathf.Ceil(slider.value).ToString(); break;
        }
        
    }
}

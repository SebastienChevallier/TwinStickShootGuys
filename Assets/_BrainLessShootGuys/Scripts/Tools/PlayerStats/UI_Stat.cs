using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stat : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;
    private PairStat _stat;

    public void SetupStat(PairStat stat)
    {
        _stat = stat;
        text.text = _stat._Stat.ToString() + $" : {_stat._Value}";
        slider.value = _stat._Value;
    }

    public void ChangeSlider(Single value)
    {
        _stat._Value = value;
        text.text = _stat._Stat.ToString() + $" : {_stat._Value}";
    }

}

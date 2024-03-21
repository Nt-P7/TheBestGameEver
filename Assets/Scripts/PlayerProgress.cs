using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransfrom;
    public TextMeshProUGUI LevelValueTMP;

    private int _LevelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Start()
    {
        DrawUI();
    } 

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            _LevelValue += 1;
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void DrawUI()
    {
        experienceValueRectTransfrom.anchorMax = new Vector2(_experienceCurrentValue / _experienceCurrentValue, 1);
        LevelValueTMP.text = _LevelValue.ToString();
    }
    
}   

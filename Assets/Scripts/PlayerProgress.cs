using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;

    public RectTransform experienceValueRectTransfrom;
    public TextMeshProUGUI LevelValueTMP;

    private int _LevelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Start()
    {
        SetLevel(_LevelValue);
        DrawUI();
    } 

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_LevelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _LevelValue = value;

        var currentlevel = levels[_LevelValue - 1];
        _experienceTargetValue = currentlevel.experienceForTheNextLevel;
        GetComponent<FireballCaster>().damage = currentlevel.fireballDamage;

        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.damage = currentlevel.grenadeDamage;

        if (currentlevel.grenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
    }

    private void DrawUI()
    {
        experienceValueRectTransfrom.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        LevelValueTMP.text = _LevelValue.ToString();
    }
    
}   

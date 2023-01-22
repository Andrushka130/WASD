using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    public int level;
    public float currentExp;
    public float requiredExp;

    private float lerpTimer;
    private float delayTimer;

    [Header("UI")]
    public Image expBar;
    // Start is called before the first frame update
    void Start()
    {
        expBar.fillAmount = currentExp / requiredExp;
        requiredExp = CalculateRequiredExp();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        UpdateExp();
        GainExperience(20);
        if (currentExp > requiredExp)
            LevelUp();
    }

    public void UpdateExp()
    {
        float expFraction = currentExp / requiredExp;
        float expFillAmount = expBar.fillAmount;

        if(expFillAmount < expFraction)
        {
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 3;
            expBar.fillAmount = Mathf.Lerp(expFillAmount, expFraction, percentComplete); 
        }
    }

    public void GainExperience(float expGained)
    {
        currentExp += expGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        expBar.fillAmount = 0f;
        currentExp = Mathf.RoundToInt(currentExp - requiredExp);
        requiredExp = CalculateRequiredExp();
    }

    private int CalculateRequiredExp()
    {
        int solveForRequiredExp = 40;
        for(int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredExp += (int)Mathf.Floor(solveForRequiredExp * 2 - 30);
        }
        return solveForRequiredExp;
    }
}

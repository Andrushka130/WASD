using UnityEngine;
using UnityEngine.UI;

public class ExpSystem : MonoBehaviour
{
    public int level;
    public int skillPoints;
    public float currentExp;
    public float requiredExp;

    [Header("UI")]
    public Image expBar;
 
    void Start()
    {
        currentExp = 0;
        requiredExp = CalculateRequiredExp();
        expBar.fillAmount = currentExp / requiredExp;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Experience"))
        {
            GainExperience(5);
            UpdateExp();
            if (currentExp > requiredExp)
                LevelUp();
            Destroy(collider.gameObject);
        }
    }

    public void UpdateExp()
    {
        float expFraction = currentExp / requiredExp;
        float expFillAmount = expBar.fillAmount;

        if(expFillAmount < expFraction)
        {
            expBar.fillAmount = expFraction;
        }
    }

    public void GainExperience(float expGained)
    {
        currentExp += expGained;
    }

    public void LevelUp()
    {
        level++;
        skillPoints++;
        expBar.fillAmount = 0f;
        currentExp = Mathf.RoundToInt(currentExp - requiredExp);
        requiredExp = CalculateRequiredExp();
        UpdateExp();
    }

    public void SpentSkillPoints()
    {
        skillPoints--;
    }

    private int CalculateRequiredExp()
    {
        int solveForRequiredExp = 40;
        for(int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredExp = (int)Mathf.Floor(solveForRequiredExp * 2 - 30);
        }
        return solveForRequiredExp;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт улучшения навыков персонажа,
/// крепится к панеле Skills (SkillsBar)
/// </summary>

public class SkillsController : MonoBehaviour {

    public Text scopeInfo;

    public Image statusSpeed;    
    public Text speedText;

    public Image statusJump;
    public Text jumpText;

    public Image statusAttackDamage;
    public Text attackDamageText;

    private float speedSkills = 3.0f;
    private int speedStage = 0;

    private float jumpSkills = 85;
    private int jumpStage = 0;

    private float attackDamageSkills = 1;
    private int attackDamageStage = 0;

    public int scopeSkills = 0;

    private SaveController saveController;

    // Стартовые значения переменных
	void Start ()
    {
        saveController = FindObjectOfType<SaveController>();

        // Проверка сохраненного счета
        if (saveController.sv.scopes < 1)
        {
            saveController.sv.scopes = scopeSkills;
        }
        else
        {
            scopeSkills = saveController.sv.scopes;         
        }

        // Проверка сохраненной скорости
        if (saveController.sv.speedPlayer < 1)
        {
            saveController.sv.speedPlayer = speedSkills;
        }
        else
        {
            speedSkills = saveController.sv.speedPlayer;
        }

        // Проверка сохраненной высоты прыжка
        if (saveController.sv.jumpForcePlayer < 1)
        {
            saveController.sv.jumpForcePlayer = jumpSkills;
        }
        else
        {
            jumpSkills = saveController.sv.jumpForcePlayer;
        }

        // Проверка сохраненного наносимого урона
        if (saveController.sv.attackDamagePlayer < 1)
        {
            saveController.sv.attackDamagePlayer = attackDamageSkills;
        }
        else
        {
            attackDamageSkills = saveController.sv.attackDamagePlayer;
        }
    }

    // Вызывается при закрытии панельки
    private void OnDisable()
    {
        if (saveController.sv.scopes < 1)
        {
            scopeSkills = 0;
        }
        else
        {
            scopeSkills = saveController.sv.scopes;
        }

        speedSkills = saveController.sv.speedPlayer;
        jumpSkills = saveController.sv.jumpForcePlayer;
        attackDamageSkills = saveController.sv.attackDamagePlayer;
    }

    void FixedUpdate ()
    {
        scopeInfo.text = ScopesFormat(scopeSkills);

        statusSpeed.fillAmount = (speedSkills - 3) * 1.7f;        
        speedStage = (int)((speedSkills - 3) / 0.2f);
        speedText.text = speedStage + "/3";

        statusJump.fillAmount = (jumpSkills - 85) * 0.165f;
        jumpStage = (int)((jumpSkills - 85) / 2);
        jumpText.text = jumpStage + "/3";

        statusAttackDamage.fillAmount = (attackDamageSkills - 1) * 0.5f;
        attackDamageStage = (int)((attackDamageSkills - 1) / 1);
        attackDamageText.text = attackDamageStage + "/2";
    }

    // Увеличение скорости персонажа
    public void UpSpeedSkills()
    {
        if ((speedSkills < 3.6f) && (scopeSkills - 150 > 0))
        {
            speedSkills += 0.2f;
            scopeSkills -= 150;
        }
    }

    // Уменьшение скорости персонажа
    public void DownSpeedSkills()
    {
        if ((speedSkills > 3.0f) && (speedSkills > saveController.sv.speedPlayer))
        {
            speedSkills -= 0.2f;
            scopeSkills += 150;
        }
    }

    // Увеличение высоты прыжка
    public void UpJumpSkills()
    {
        if ((jumpSkills < 91f) && (scopeSkills - 100 > 0))
        {
            jumpSkills += 2;
            scopeSkills -= 100;
        }
    }

    // Уменьшение высоты прыжка
    public void DownJumpSkills()
    {
        if ((jumpSkills > 85f) && (jumpSkills > saveController.sv.jumpForcePlayer))
        {
            jumpSkills -= 2;
            scopeSkills += 100;
        }
    }

    // Увеличение наносимого урона
    public void UpAttackDamageSkill()
    {
        if ((attackDamageSkills < 3f) && (scopeSkills - 250 > 0))
        {
            attackDamageSkills += 1;
            scopeSkills -= 250;
        }
    }

    // Уменьшение наносимого урона
    public void DownAttackDamageSkill()
    {
        if ((attackDamageSkills > 1) && (attackDamageSkills > saveController.sv.attackDamagePlayer))
        {
            attackDamageSkills -= 1;
            scopeSkills += 250;
        }
    }


    // Передача параметров в скрипт сохранения
    public void SetToSave()
    {
        saveController.sv.scopes = scopeSkills;

        saveController.sv.speedPlayer = speedSkills;
        saveController.sv.jumpForcePlayer = jumpSkills;
        saveController.sv.attackDamagePlayer = attackDamageSkills;
    }

    // Вывод счета в формате "000000"
    private string ScopesFormat(int value)
    {
        string scopeString = value.ToString();
        while (scopeString.Length < 6)
        {
            scopeString = "0" + scopeString;
        }
        return scopeString;
    }
}

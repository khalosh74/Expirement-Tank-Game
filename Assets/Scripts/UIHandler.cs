using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject speedIcon, FirRateIcon, attackDamgeIcon;
    [SerializeField] private List<GameObject> hearts = new List<GameObject>();
    [SerializeField] private Player player;
    private Weapon playerWeapon;

    void Start()
    {
        upgradePanel.SetActive(false);
    }
    void Update()
    {
        ShieldBar();
        XPBar();
        LevelText();
    }
    private void ShieldBar()
    {
        shieldSlider.value = player.getShield()/100f;
        if (player.getHearts() == hearts.Count)
        {
            return;
        }
        else
        {
            hearts[hearts.Count - 1].SetActive(false);
            hearts.Remove(hearts[hearts.Count - 1]);
        }
    }
    private void XPBar()
    {
        xpSlider.value = player.XPProcentTllNextLevel();
    }
    private void LevelText()
    {
        levelText.text = "Level " + player.getLevel().ToString();
    }

    public void ShowUpgradePanel()
    {
        playerWeapon = player.GetComponentInChildren<Weapon>();
        PauseGame();
        upgradePanel.SetActive(true);
    }
    public void HideUpgradePanel()
    {
        ResumeGame();
        upgradePanel.SetActive(false);
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void AssaignUpgradeButtons()
    {
        for(int i=0; i < buttons.Length; i++)
        {
            var x = i;
            buttons[i].onClick.AddListener(() => doTask(x));
            ShowIcons(x);
        }
    }
    public void doTask(int index)
    {
        switch ((Upgrades)index)
        {
            case Upgrades.Speed:
                player.setSpeed(2);
                break;
            case Upgrades.AttackDamge:
                break;
            case Upgrades.FireRate:
                playerWeapon.setAttackSpeed(0.9f);
                break;
        }
    }
    private void ShowIcons(int index)
    {
        switch ((Upgrades)index)
        {
            case Upgrades.Speed:
                Instantiate(speedIcon, buttons[index].gameObject.transform);
                break;
            case Upgrades.AttackDamge:
                Instantiate(attackDamgeIcon, buttons[index].gameObject.transform);
                break;
            case Upgrades.FireRate:
                Instantiate(FirRateIcon, buttons[index].gameObject.transform);
                break;
        }
    }


    //Upgrades upgrade in (Upgrades[])Enum.GetValues(typeof(Upgrades))
}

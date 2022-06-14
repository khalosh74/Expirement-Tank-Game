using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private List<GameObject> hearts = new List<GameObject>();
    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

}

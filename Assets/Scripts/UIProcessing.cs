﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIProcessing : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI WaveCounterText;
    private TextMeshProUGUI HealthText;
    private TextMeshProUGUI MoneyText;
    private RectTransform TowerSelectPanel;
    private Stats stats;
    private GameObject SelectedPlatform;
    private RectTransform InfoPanel;
    private RectTransform StatsPanel;


    void Awake()
    {
        WaveCounterText = GameObject.Find("WaveCounterText").GetComponent<TextMeshProUGUI>();
        HealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        MoneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        TowerSelectPanel = GameObject.Find("TowerSelectPanel").GetComponent<RectTransform>();
        TowerSelectPanel.gameObject.SetActive(false);
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();

        InfoPanel = GameObject.Find("InfoPanel").GetComponent<RectTransform>();
        StatsPanel = GameObject.Find("StatsPanel").GetComponent<RectTransform>();

        InfoPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WaveCounterText.SetText("Wave: " + GameObject.FindObjectOfType<WaveSpawn>().GetWave().ToString());
        HealthText.SetText("Health: " + GameObject.FindObjectOfType<FinalPoint>().GetHP().ToString());
        MoneyText.SetText("Money: " + stats.GetMoney());


    }

    public void ShowTowerSelect(GameObject selectedPlatform)
    {
        TowerSelectPanel.gameObject.SetActive(true);
        SelectedPlatform = selectedPlatform;
    }
    public void HideTowerSelect()
    {
        SelectedPlatform = null; 
        TowerSelectPanel.gameObject.SetActive(false);
    }

    public void ShowInfoTower(Tower tower)
    {
        InfoPanel.gameObject.SetActive(true);
        GameObject.Find("TowerDescriptionText").GetComponent<TextMeshProUGUI>().SetText(tower.GetComponent<Tower>().Description);
        GameObject.Find("TowerNameText").GetComponent<TextMeshProUGUI>().SetText(tower.GetComponent<Tower>().Name);

    }

    public void HideInfoTower()
    {
        InfoPanel.gameObject.SetActive(false);
    }

    public void ShowStatsTower(Tower tower)
    {
        StatsPanel.gameObject.SetActive(true);
        GameObject.Find("TowerStatsText").GetComponent<TextMeshProUGUI>().SetText($"Level: {tower.GetComponent<Tower>().GetLevel().ToString()} \r\n " +
            $"Damage: {tower.GetComponent<Tower>().GetDamage().ToString()}");
        GameObject.Find("TowerStatsNameText").GetComponent<TextMeshProUGUI>().SetText(tower.GetComponent<Tower>().Name);
    }

    public void HideStatsTower()
    {
        StatsPanel.gameObject.SetActive(false);
    }

    public void SelectedCommonTower()
    {
        if (stats.GetMoney() >= 10)
        {
            SelectedPlatform.GetComponent<TowerPlatform>().Place(0);
            TowerSelectPanel.gameObject.SetActive(false);
        }
    }

    public void SelectedAOETower()
    {
        if (stats.GetMoney() >= 50)
        {
            SelectedPlatform.GetComponent<TowerPlatform>().Place(1);
            TowerSelectPanel.gameObject.SetActive(false);

        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarrotManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI carrotsText;

    [Header("Data")]
    [SerializeField] private double totalCarrotsCount;
    [SerializeField] private int carrotIncrement;
    private void Awake()
    {
        LoadData();
        InputManager.onCarrotClicked += CarrotClickedCallback;
    }
    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
    }

    private void CarrotClickedCallback()
    {
        totalCarrotsCount += carrotIncrement;
        UpdateCarrotsText();         
        SaveData();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotsCount.ToString();
    }
    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }
    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);
        UpdateCarrotsText();
    }
}

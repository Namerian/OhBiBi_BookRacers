﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public static string DATAPATH { get { return Application.persistentDataPath + "/BookRacers"; } }

    //===============================================================================
    //
    //===============================================================================

    [SerializeField]
    private PlayerData _playerData;

    [SerializeField]
    private List<PilotData> _pilotDataList;

    [SerializeField]
    private List<BookData> _bookDataList;

    [SerializeField]
    private List<LevelData> _levelDataList;

    //===============================================================================
    // PROPERTIES
    //===============================================================================

    public PlayerData PlayerData { get { return _playerData; } }

    public List<PilotData> PilotData { get { return _pilotDataList; } }

    public List<BookData> BookData { get { return _bookDataList; } }

    public List<LevelData> LevelData { get { return _levelDataList; } }

    public RaceReport LastRaceReport { get; set; }

    //===============================================================================
    // MONOBEHAVIOUR METHODS
    //===============================================================================

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!Directory.Exists(DATAPATH))
        {
            Directory.CreateDirectory(DATAPATH);
        }

        LoadData();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    //private void OnDestroy()
    //{
    //    if (Instance == this)
    //        SaveData();
    //}

    //private void OnApplicationPause(bool pause)
    //{
    //    if (Instance == this)
    //        SaveData();
    //}

    //private void OnApplicationQuit()
    //{
    //    if (Instance == this)
    //        SaveData();
    //}

    //===============================================================================
    // METHODS
    //===============================================================================

    private void LoadData()
    {
        _playerData.Load();

        foreach (PilotData pilot in _pilotDataList)
        {
            pilot.Load();
        }

        foreach (BookData book in _bookDataList)
        {
            book.Load();
        }

        foreach (LevelData level in _levelDataList)
        {
            level.Load();
        }
    }

    public void SaveData()
    {
        if (!Directory.Exists(DATAPATH))
        {
            Directory.CreateDirectory(DATAPATH);
        }

        _playerData.Save();

        foreach (PilotData pilot in _pilotDataList)
        {
            pilot.Save();
        }

        foreach (BookData book in _bookDataList)
        {
            book.Save();
        }

        foreach (LevelData level in _levelDataList)
        {
            level.Save();
        }
    }
}

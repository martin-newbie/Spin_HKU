using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    public float best_record;

    public float background_volume;
    public float effect_volume;

    public string path;

    StatusSave Data = new StatusSave();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        path = Application.persistentDataPath + "./PlayerStatus.json";
        if (File.Exists(path))
        {
            LoadData();
        }
    }

    void SaveData()
    {
        Data.best_record = best_record;
        Data.background_volume = background_volume;
        Data.effect_volume = effect_volume;

        string json_save = JsonUtility.ToJson(Data, true);
        File.WriteAllText(path, json_save);
    }

    void LoadData()
    {
        string json_save = File.ReadAllText(path);
        Data = JsonUtility.FromJson<StatusSave>(json_save);

        best_record = Data.best_record;
        background_volume = Data.background_volume;
        effect_volume = Data.effect_volume; 
    }

    private void OnDestroy()
    {
        SaveData();
    }
}

public class StatusSave
{
    public float best_record;
    public float background_volume;
    public float effect_volume;
}

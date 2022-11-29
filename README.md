# SlotMachine 3X3


## Learn to use
* Dotween
* ScriptableObject

### 程式方面
```csharp
 public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + SAVE_DIRECTORY;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FILE_NAME, json);

        GUIUtility.systemCopyBuffer = dir + FILE_NAME;

        return true;
    }

    public static PlayerData LoadGame()
    {
        string fullPath = Application.persistentDataPath + SAVE_DIRECTORY + FILE_NAME;

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            CurrentSaveData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            SaveGame();
        }
        return CurrentSaveData;
    }
```
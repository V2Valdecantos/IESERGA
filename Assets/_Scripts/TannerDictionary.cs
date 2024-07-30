using System.Collections.Generic;
using UnityEngine;

public class TannerDictionary : MonoBehaviour
{
    private Dictionary<string, string> tannerDictionary;

    private void Awake()
    {
        LoadTannerStagesFromJson();
    }

    void Start()
    {
        foreach (var data in tannerDictionary)
        {
            Debug.Log(data.Value);
        }
    }

    private void LoadTannerStagesFromJson()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Tanner_Dictionary");

        if (!jsonTextFile)
        {
            Debug.LogError("Tanner_Dictionary.json file not found!");
            return;
        }

        string jsonString = jsonTextFile.text;
        TannerData data = JsonUtility.FromJson<TannerData>(jsonString);

        tannerDictionary = new Dictionary<string, string>
        {
            { TannerStrings.Boys_Genetalia_Stage_1, data.Boys_Genetalia_Stage_1 },
            { TannerStrings.Boys_Genetalia_Stage_2, data.Boys_Genetalia_Stage_2 },
            { TannerStrings.Boys_Genetalia_Stage_3, data.Boys_Genetalia_Stage_3 },
            { TannerStrings.Boys_Genetalia_Stage_4, data.Boys_Genetalia_Stage_4 },
            { TannerStrings.Boys_Genetalia_Stage_5, data.Boys_Genetalia_Stage_5 },
            { TannerStrings.Girls_Breasts_Stage_1, data.Girls_Breasts_Stage_1 },
            { TannerStrings.Girls_Breasts_Stage_2, data.Girls_Breasts_Stage_2 },
            { TannerStrings.Girls_Breasts_Stage_3, data.Girls_Breasts_Stage_3 },
            { TannerStrings.Girls_Breasts_Stage_4, data.Girls_Breasts_Stage_4 },
            { TannerStrings.Girls_Breasts_Stage_5, data.Girls_Breasts_Stage_5 },
            { TannerStrings.Pubic_Hair_Stage_1, data.Pubic_Hair_Stage_1 },
            { TannerStrings.Pubic_Hair_Stage_2, data.Pubic_Hair_Stage_2 },
            { TannerStrings.Pubic_Hair_Stage_3, data.Pubic_Hair_Stage_3 },
            { TannerStrings.Pubic_Hair_Stage_4, data.Pubic_Hair_Stage_4 },
            { TannerStrings.Pubic_Hair_Stage_5, data.Pubic_Hair_Stage_5 },
            { TannerStrings.Boys_Other_Symptoms_Stage_1, data.Boys_Other_Symptoms_Stage_1 },
            { TannerStrings.Boys_Other_Symptoms_Stage_2, data.Boys_Other_Symptoms_Stage_2 },
            { TannerStrings.Boys_Other_Symptoms_Stage_3, data.Boys_Other_Symptoms_Stage_3 },
            { TannerStrings.Boys_Other_Symptoms_Stage_4, data.Boys_Other_Symptoms_Stage_4 },
            { TannerStrings.Boys_Other_Symptoms_Stage_5, data.Boys_Other_Symptoms_Stage_5 },
            { TannerStrings.Girls_Other_Symptoms_Stage_1, data.Girls_Other_Symptoms_Stage_1 },
            { TannerStrings.Girls_Other_Symptoms_Stage_2, data.Girls_Other_Symptoms_Stage_2 },
            { TannerStrings.Girls_Other_Symptoms_Stage_3, data.Girls_Other_Symptoms_Stage_3 },
            { TannerStrings.Girls_Other_Symptoms_Stage_4, data.Girls_Other_Symptoms_Stage_4 },
            { TannerStrings.Girls_Other_Symptoms_Stage_5, data.Girls_Other_Symptoms_Stage_5 }
        };
    }

    [System.Serializable]
    private class TannerData
    {
        public string Boys_Genetalia_Stage_1;
        public string Boys_Genetalia_Stage_2;
        public string Boys_Genetalia_Stage_3;
        public string Boys_Genetalia_Stage_4;
        public string Boys_Genetalia_Stage_5;
        public string Girls_Breasts_Stage_1;
        public string Girls_Breasts_Stage_2;
        public string Girls_Breasts_Stage_3;
        public string Girls_Breasts_Stage_4;
        public string Girls_Breasts_Stage_5;
        public string Pubic_Hair_Stage_1;
        public string Pubic_Hair_Stage_2;
        public string Pubic_Hair_Stage_3;
        public string Pubic_Hair_Stage_4;
        public string Pubic_Hair_Stage_5;
        public string Boys_Other_Symptoms_Stage_1;
        public string Boys_Other_Symptoms_Stage_2;
        public string Boys_Other_Symptoms_Stage_3;
        public string Boys_Other_Symptoms_Stage_4;
        public string Boys_Other_Symptoms_Stage_5;
        public string Girls_Other_Symptoms_Stage_1;
        public string Girls_Other_Symptoms_Stage_2;
        public string Girls_Other_Symptoms_Stage_3;
        public string Girls_Other_Symptoms_Stage_4;
        public string Girls_Other_Symptoms_Stage_5;
    }
}

[System.Serializable]
public class TannerStrings
{
    public const string Boys_Genetalia_Stage_1 = "Boys_Genetalia_Stage_1";
    public const string Boys_Genetalia_Stage_2 = "Boys_Genetalia_Stage_2";
    public const string Boys_Genetalia_Stage_3 = "Boys_Genetalia_Stage_3";
    public const string Boys_Genetalia_Stage_4 = "Boys_Genetalia_Stage_4";
    public const string Boys_Genetalia_Stage_5 = "Boys_Genetalia_Stage_5";
    public const string Girls_Breasts_Stage_1 = "Girls_Breasts_Stage_1";
    public const string Girls_Breasts_Stage_2 = "Girls_Breasts_Stage_2";
    public const string Girls_Breasts_Stage_3 = "Girls_Breasts_Stage_3";
    public const string Girls_Breasts_Stage_4 = "Girls_Breasts_Stage_4";
    public const string Girls_Breasts_Stage_5 = "Girls_Breasts_Stage_5";
    public const string Pubic_Hair_Stage_1 = "Pubic_Hair_Stage_1";
    public const string Pubic_Hair_Stage_2 = "Pubic_Hair_Stage_2";
    public const string Pubic_Hair_Stage_3 = "Pubic_Hair_Stage_3";
    public const string Pubic_Hair_Stage_4 = "Pubic_Hair_Stage_4";
    public const string Pubic_Hair_Stage_5 = "Pubic_Hair_Stage_5";
    public const string Boys_Other_Symptoms_Stage_1 = "Boys_Other_Symptoms_Stage_1";
    public const string Boys_Other_Symptoms_Stage_2 = "Boys_Other_Symptoms_Stage_2";
    public const string Boys_Other_Symptoms_Stage_3 = "Boys_Other_Symptoms_Stage_3";
    public const string Boys_Other_Symptoms_Stage_4 = "Boys_Other_Symptoms_Stage_4";
    public const string Boys_Other_Symptoms_Stage_5 = "Boys_Other_Symptoms_Stage_5";
    public const string Girls_Other_Symptoms_Stage_1 = "Girls_Other_Symptoms_Stage_1";
    public const string Girls_Other_Symptoms_Stage_2 = "Girls_Other_Symptoms_Stage_2";
    public const string Girls_Other_Symptoms_Stage_3 = "Girls_Other_Symptoms_Stage_3";
    public const string Girls_Other_Symptoms_Stage_4 = "Girls_Other_Symptoms_Stage_4";
    public const string Girls_Other_Symptoms_Stage_5 = "Girls_Other_Symptoms_Stage_5";
}

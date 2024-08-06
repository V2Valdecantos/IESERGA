using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> entries;
    private Dictionary<EvidenceReason, GameObject> dictionaryEntries;

    private class DictionaryEntry
    {
        public GameObject obj;
        public bool isActive;
    }


    private void Awake()
    {
        PopulateDictionary();
    }

    private void OnEnable()
    {
        ModularPart.OnPartHit += AddDictionaryEntry;
    }

    private void OnDisable()
    {
        ModularPart.OnPartHit -= AddDictionaryEntry;
    }

    private void PopulateDictionary()
    {
        int index = 0;
        dictionaryEntries = new Dictionary<EvidenceReason, GameObject>();
        foreach (GameObject entry in entries)
        {
            dictionaryEntries[(EvidenceReason)index] = entry;
            index++;
        }
    }

    public void AddDictionaryEntry(Sprite sprite, EvidenceReason reason)
    {
        dictionaryEntries[reason].SetActive(true);
    }
}

public enum EvidenceReason : int
{
    NONE = -1,

    BOYS_GENETALIA_STAGE_1,
    BOYS_PUBIC_HAIR_STAGE_1,

    BOYS_GENETALIA_STAGE_2,
    BOYS_PUBIC_HAIR_STAGE_2,
    BOYS_HEIGHT_STAGE_2,

    BOYS_GENETALIA_STAGE_3,
    BOYS_PUBIC_HAIR_STAGE_3,
    BOYS_VOICE_STAGE_3,
    BOYS_ACNE_STAGE_3,

    BOYS_GENETALIA_STAGE_4,
    BOYS_PUBIC_HAIR_STAGE_4,
    BOYS_ARMPIT_STAGE_4,
    BOYS_VOICE_STAGE_4,

    BOYS_GENETALIA_STAGE_5,
    BOYS_PUBIC_HAIR_STAGE_5,
    BOYS_FACIAL_HAIR_STAGE_5,

    GIRLS_BREASTS_STAGE_1,
    GIRLS_PUBIC_HAIR_STAGE_1,

    GIRLS_BREASTS_STAGE_2,
    GIRLS_PUBIC_HAIR_STAGE_2,
    GIRLS_HEIGHT_STAGE_2,

    GIRLS_BREASTS_STAGE_3,
    GIRLS_PUBIC_HAIR_STAGE_3,
    GIRLS_ACNE_STAGE_3,

    GIRLS_BREASTS_STAGE_4,
    GIRLS_PUBIC_HAIR_STAGE_4,
    GIRLS_MENARCHE_STAGE_4,
    GIRLS_ARMPIT_STAGE_4,

    GIRLS_BREASTS_STAGE_5,
    GIRLS_PUBIC_HAIR_STAGE_5
}

public enum TannerStages : int
{
    NONE = -1,
    STAGE_1 = 0,
    STAGE_2,
    STAGE_3,
    STAGE_4,
    STAGE_5
}

public enum ModelType : int
{
    NONE = -1,
    MALE_ZOOMED = 0,
    MALE_BLURRED,
    MALE_NORMAL,
    FEMALE_ZOOMED,
    FEMALE_BLURRED,
    FEMALE_NORMAL,
}

[System.Serializable]
public class TannerStrings
{
    public const string Boys_Genetalia_Stage_1 = "Boys_Genetalia_Stage_1";
    public const string Boys_Pubic_Hair_Stage_1 = "Boys_Pubic_Hair_Stage_1";

    public const string Boys_Genetalia_Stage_2 = "Boys_Genetalia_Stage_2";
    public const string Boys_Pubic_Hair_Stage_2 = "Boys_Pubic_Hair_Stage_2";
    public const string Boys_Height_Stage_2 = "Boys_Height_Stage_2";

    public const string Boys_Genetalia_Stage_3 = "Boys_Genetalia_Stage_3";
    public const string Boys_Pubic_Hair_Stage_3 = "Boys_Pubic_Hair_Stage_3";
    public const string Boys_Voice_Stage_3 = "Boys_Voice_Stage_3";
    public const string Boys_Acne_Stage_3 = "Boys_Acne_Stage_3";

    public const string Boys_Genetalia_Stage_4 = "Boys_Genetalia_Stage_4";
    public const string Boys_Pubic_Hair_Stage_4 = "Boys_Pubic_Hair_Stage_4";
    public const string Boys_Armpit_Stage_4 = "Boys_Armpit_Stage_4";
    public const string Boys_Voice_Stage_4 = "Boys_Voice_Stage_4";

    public const string Boys_Genetalia_Stage_5 = "Boys_Genetalia_Stage_5";
    public const string Boys_Pubic_Hair_Stage_5 = "Boys_Pubic_Hair_Stage_5";
    public const string Boys_Facial_Hair_Stage_5 = "Boys_Facial_Hair_Stage_5";

    public const string Girls_Breasts_Stage_1 = "Girls_Breasts_Stage_1";
    public const string Girls_Pubic_Hair_Stage_1 = "Girls_Pubic_Hair_Stage_1";

    public const string Girls_Breasts_Stage_2 = "Girls_Breasts_Stage_2";
    public const string Girls_Pubic_Hair_Stage_2 = "Girls_Pubic_Hair_Stage_2";
    public const string Girls_Height_Stage_2 = "Girls_Height_Stage_2";

    public const string Girls_Breasts_Stage_3 = "Girls_Breasts_Stage_3";
    public const string Girls_Pubic_Hair_Stage_3 = "Girls_Pubic_Hair_Stage_3";
    public const string Girls_Acne_Stage_3 = "Girls_Acne_Stage_3";

    public const string Girls_Breasts_Stage_4 = "Girls_Breasts_Stage_4";
    public const string Girls_Pubic_Hair_Stage_4 = "Girls_Pubic_Hair_Stage_4";
    public const string Girls_Menarche_Stage_4 = "Girls_Menarche_Stage_4";
    public const string Girls_Armpit_Stage_4 = "Girls_Armpit_Stage_4";

    public const string Girls_Breasts_Stage_5 = "Girls_Breasts_Stage_5";
    public const string Pubic_Hair_Stage_5 = "Pubic_Hair_Stage_5";
}

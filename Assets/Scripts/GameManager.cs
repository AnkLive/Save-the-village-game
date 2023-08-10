using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [field: SerializeField] public GameData Data { get; set; }

    [field: SerializeField] public GameObject GameOverScreen { get; set; }

    [field: SerializeField] public ImageTimer HarvestTimer { get; set; }
    [field: SerializeField] public ImageTimer EatingTimer { get; set; }

    [field: SerializeField] public Image RaidTimerImg { get; set; }
    [field: SerializeField] public Image PeasantTimerImg { get; set; }
    [field: SerializeField] public Image WarriorTimerImg { get; set; }

    [field: SerializeField] public Button WarriorButton { get; set; }
    [field: SerializeField] public Button PeasantButton { get; set; }

    [field: SerializeField] public Text PeasantText { get; set; }
    [field: SerializeField] public Text WarriorText { get; set; }
    [field: SerializeField] public Text EatingText { get; set; }

    private void Start() 
    {
        UpdateText();
        Data.RaidTimer = Data.RaidMaxTime;
    }

    private void Update() 
    {
        FoodCycle();
        TimerCreate(Data.PeasantTimer, PeasantTimerImg, Data.PeasantCreateTime, Data.PeasantCount, PeasantButton);
        TimerCreate(Data.WarriorTimer, WarriorTimerImg, Data.WarriorCreateTime, Data.WarriorsCount, WarriorButton);
        UpdateText();
        GameOver();
    }

    public void TimeToRaid() 
    {
        Data.RaidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = Data.RaidTimer / Data.RaidMaxTime;
        if(Data.RaidTimer <= 0)
        {
            Data.RaidTimer = Data.RaidMaxTime;
            Data.WarriorsCount -= Data.NextRaid;
            Data.NextRaid += Data.RaidIncrease;
        }
    }

    public void OnClickCreatePeasant() => CreateCharapter(Data.WheatCount, Data.PeasantCost, Data.PeasantTimer, Data.PeasantCreateTime, PeasantButton);
    public void OnClickCreateWarrior() => CreateCharapter(Data.WheatCount, Data.WarriorCost, Data.WarriorTimer, Data.WarriorCreateTime, WarriorButton);

    public void TimerCreate(float Timer, Image TimerImg, float CreateTime, int Count, Button ButtonCreate)
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
            TimerImg.fillAmount =Timer / CreateTime;
        }
        else if(Timer > -1) 
        {
            TimerImg.fillAmount = 1;
            ButtonCreate.interactable = true;
            Count++;
            Timer = -2;
        }
    }
    public void CreateCharapter(int WheatCount, int Cost, float Timer, float CreateTime, Button ButtonCreate) 
    {
        WheatCount -= Cost;
        Timer = CreateTime;
        ButtonCreate.interactable = false;
    }

    private void FoodCycle()
    {
        if(HarvestTimer.Tick)
            Data.WheatCount += Data.PeasantCount * Data.WheatPerPeasant;
        if(EatingTimer.Tick)
            Data.WheatCount -= Data.WarriorsCount * Data.WheatToWarrriors;
    }

    private void UpdateText() 
    {
        PeasantText.text = Data.PeasantCount.ToString();
        WarriorText.text = Data.WarriorsCount.ToString();
        EatingText.text = Data.WheatCount.ToString();
    }

    private void GameOver() 
    {
        if(Data.WarriorsCount == 0 || Data.WheatCount == 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }

}

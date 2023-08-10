using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

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

    [field: SerializeField] public int PeasantCount { get; set; }
    [field: SerializeField] public int WarriorsCount{ get; set; }
    public int WheatCount;

    [field: SerializeField] public int WheatPerPeasant{ get; set; }
    [field: SerializeField] public int WheatToWarrriors{ get; set; }

    [field: SerializeField] public int PeasantCost{ get; set; }
    [field: SerializeField] public int WarriorCost{ get; set; }

    [field: SerializeField] public float PeasantCreateTime{ get; set; }
    [field: SerializeField] public float WarriorCreateTime{ get; set; }
    [field: SerializeField] public float RaidMaxTime{ get; set; }

    [field: SerializeField] public int RaidIncrease{ get; set; }
    [field: SerializeField] public int NextRaid{ get; set; }

    [field: SerializeField] public float PeasantTimer { get; set; } = -2;
    [field: SerializeField] public float WarriorTimer { get; set; } = -2;
    [field: SerializeField] public float RaidTimer { get; set; }

    private void Start() 
    {
        UpdateText();
        RaidTimer = RaidMaxTime;
    }

    private void Update() 
    {
        Debug.Log(PeasantTimer);
        FoodCycle();
        TimerCreatePeasant();
        TimerCreateWarrior();
        UpdateText();
        TimeToRaid();
        GameOver();
    }

    private void TimeToRaid() 
    {
        RaidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = RaidTimer / RaidMaxTime;
        if(RaidTimer <= 0)
        {
            RaidTimer = RaidMaxTime;
            WarriorsCount -= NextRaid;
            NextRaid += RaidIncrease;
        }
    }

    private void TimerCreatePeasant()
    {
        if(PeasantTimer > 0)
        {
            PeasantTimer -= Time.deltaTime;
            PeasantTimerImg.fillAmount = PeasantTimer / PeasantCreateTime;
        }
        else if(PeasantTimer > -1) 
        {
            PeasantTimerImg.fillAmount = 1;
            PeasantButton.interactable = true;
            PeasantCount++;
            PeasantTimer = -2;
        }
    }

    private void TimerCreateWarrior()
    {
        if(WarriorTimer > 0)
        {
            WarriorTimer -= Time.deltaTime;
            WarriorTimerImg.fillAmount = WarriorTimer / WarriorCreateTime;
        }
        else if(WarriorTimer > -1) 
        {
            WarriorTimerImg.fillAmount = 1;
            WarriorButton.interactable = true;
            WarriorsCount++;
            WarriorTimer = -2;
        }
    }

    public void CreatePeasant() 
    {
        WheatCount -= PeasantCost;
        PeasantTimer = PeasantCreateTime;
        PeasantButton.interactable = false;
    }

    public void CreateWarrior() 
    {
        WheatCount -= WarriorCost;
        WarriorTimer = WarriorCreateTime;
        WarriorButton.interactable = false;
    }

    private void FoodCycle()
    {
        if(HarvestTimer.Tick)
            WheatCount += PeasantCount * WheatPerPeasant;
        if(EatingTimer.Tick)
            WheatCount -= WarriorsCount * WheatToWarrriors;
    }

    private void UpdateText() 
    {
        PeasantText.text = PeasantCount.ToString();
        WarriorText.text = WarriorsCount.ToString();
        EatingText.text = WheatCount.ToString();
    }

    private void GameOver() 
    {
        if(WarriorsCount < 0 || WheatCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }

}

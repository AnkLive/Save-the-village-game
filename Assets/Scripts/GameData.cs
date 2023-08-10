using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData", order = 0)]
public class GameData : ScriptableObject 
{

    [field: SerializeField] public int PeasantCount { get; set; }
    [field: SerializeField] public int WarriorsCount{ get; set; }
    [field: SerializeField] public int WheatCount{ get; set; }

    [field: SerializeField] public int WheatPerPeasant{ get; set; }
    [field: SerializeField] public int WheatToWarrriors{ get; set; }

    [field: SerializeField] public int PeasantCost{ get; set; }
    [field: SerializeField] public int WarriorCost{ get; set; }

    [field: SerializeField] public float PeasantCreateTime{ get; set; }
    [field: SerializeField] public float WarriorCreateTime{ get; set; }
    [field: SerializeField] public float RaidMaxTime{ get; set; }

    [field: SerializeField] public int RaidIncrease{ get; set; }
    [field: SerializeField] public int NextRaid{ get; set; }

    public float PeasantTimer { get; set; } = -2;
    public float WarriorTimer { get; set; } = -2;
    public float RaidTimer { get; set; }

}

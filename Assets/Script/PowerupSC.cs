using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSC", menuName = "PowerupSO")]
public class PowerupSC : ScriptableObject
{
    [SerializeField] string powerupType; 
    [SerializeField] float valueChange; 
    [SerializeField] float time; 

    public string GetPowerupType { get { return powerupType; } }
    public float GetValueChange { get { return valueChange; } }
    public float GetTime { get { return time; } }

}

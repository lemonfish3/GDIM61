using UnityEngine;

[CreateAssetMenu(fileName = "PowerUps", menuName = "PowerUps/PowerUps")]
public class PowerUps : ScriptableObject
{
    public string powerUpName;
    public float duration;
    public float cooldown;
    public Sprite icon;
    public KeyCode key;
}

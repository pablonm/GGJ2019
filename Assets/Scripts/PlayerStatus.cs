using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float health = 100f;
    public float stamina = 100f;
    public int batteries = 0;
    public float currentBatery = 100f;
    public bool running = false;
    public bool recharging = false;
    public bool usingFlashlight = false;
}

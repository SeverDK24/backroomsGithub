using UnityEngine.UI;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    public Image staminbar;
    public Player player;
    void Start()
    {
        
    }

    
    void Update()
    {
        staminbar.fillAmount = player.stamina / player.maxStamina;

    }
}

using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void MaxHealthValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
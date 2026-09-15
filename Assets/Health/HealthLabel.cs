using UnityEngine;
using UnityEngine.UI;

public class HealthLabel : MonoBehaviour
{
    [SerializeField] RawImage[] healthIcons;

    private void Start()
    {
        SetHealth(3);
    }
    public void SetHealth(int currentHealth) // current health = 2 max 3
    {
        for(int i = 0; i < healthIcons.Length; i++)
        {
            RawImage icon = healthIcons[i];
            if(i < currentHealth)
            {
                icon.color = Color.red;
            }
            else
            {
                icon.color = Color.black;
            }
        }
    }
}

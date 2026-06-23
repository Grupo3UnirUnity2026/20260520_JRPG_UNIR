using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    int currentLives = 3;

    public void LoseLife()
    {
        currentLives--;

        switch (currentLives)
        {
            case 2:
                heart3.SetActive(false);
                break;

            case 1:
                heart2.SetActive(false);
                break;

            case 0:
                heart1.SetActive(false);
                break;
        }
    }

    public void HealLife()
    {
        if (currentLives >= 3)
            return;

        currentLives++;

        switch (currentLives)
        {
            case 1:
                heart1.SetActive(true);
                break;

            case 2:
                heart2.SetActive(true);
                break;

            case 3:
                heart3.SetActive(true);
                break;
        }
    }

    public void UpdateHearts(float currentLife, float maxLife)
    {
        // actualizar corazones aquí
    }

}

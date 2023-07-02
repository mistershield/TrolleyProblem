using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerValue = 5f; // Starting timer value
    public float maxTimerValue = 5f; // Maximum timer value
    public RectTransform barSize;

    private float initialBarWidth;

    private void Start()
    {
        initialBarWidth = barSize.sizeDelta.x;
    }

    private void Update()
    {
        if(barSize.sizeDelta.x > 0)
        {
            // Decrement timer based on elapsed time
            timerValue -= Time.deltaTime;

            // Calculate the new width of the timer bar
            float newWidth = initialBarWidth * (timerValue / maxTimerValue);
            barSize.sizeDelta = new Vector2(newWidth, barSize.sizeDelta.y);
        }     
        else
        {
            //GameManager.DefaulChoice();
            Debug.Log("Times up");
        }
    }
}


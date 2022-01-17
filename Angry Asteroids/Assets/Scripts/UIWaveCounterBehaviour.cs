using UnityEngine;
using UnityEngine.UI;
public class UIWaveCounterBehaviour : MonoBehaviour
{
    public Text WaveCounterText;

    public void UpdateWaveCounterText(int waveNumber)
    {
        WaveCounterText.text = waveNumber.ToString();
    }
}

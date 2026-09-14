using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompletePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("LEVEL COMPLETE!");

            levelCompletePanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
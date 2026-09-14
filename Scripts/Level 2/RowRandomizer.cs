using UnityEngine;

public class RowRandomizer : MonoBehaviour
{
    public StepBlock[] blocks;

    void Start()
    {
        // Make all blocks fake
        foreach (StepBlock block in blocks)
        {
            block.isSafe = false;
        }

        // Choose one random safe block
        int randomIndex = Random.Range(0, blocks.Length);

        blocks[randomIndex].isSafe = true;
    }
}
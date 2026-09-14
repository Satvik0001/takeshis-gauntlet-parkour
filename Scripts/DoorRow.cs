using UnityEngine;

public class DoorRow : MonoBehaviour
{
    public Door[] doors;

    public int correctDoors = 1;

    void Start()
    {
        foreach (Door door in doors)
            door.isCorrect = false;

        int selected = 0;

        while (selected < correctDoors)
        {
            int random = Random.Range(0, doors.Length);

            if (!doors[random].isCorrect)
            {
                doors[random].isCorrect = true;
                selected++;
            }
        }
    }
}
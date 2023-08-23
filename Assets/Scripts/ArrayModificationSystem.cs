using UnityEngine;
using System.Collections.Generic;
public class ArrayModificationSystem : MonoBehaviour
{
    public Book destinationObjects;
    public Sprite[] ruina1Objects;
    public Sprite[] ruina2Objects;

    public int[] counters = new int[8];
    public Sprite[] countersSprites;
    public void Start()
    {
        countersSprites = destinationObjects.bookPages;
        counters = new int[countersSprites.Length];
        for (int i = 0; i < countersSprites.Length; i++)
        {
            counters[i] = 1;
        }
    }

    public void IncrementCounter(int index)
    {
        counters[index]++;

        UpdateObjectAtIndex(index);

    }

    private void UpdateObjectAtIndex(int index)
    {

        if (index < 0 || index >= counters.Length)
        {
            Debug.LogError("Invalid index.");
            return;
        }

        Sprite objectToInstantiate = GetObjectForCounter(counters[index], index);

        if (objectToInstantiate != null)
        {
            countersSprites[index] = objectToInstantiate;
        }
    }

    private Sprite GetObjectForCounter(int counter, int index)
    {
        if (index < 0 || index >= countersSprites.Length)
        {
            Debug.LogWarning("Invalid index.");
            return null;
        }

        Sprite objectToInstantiate = null;

        if (counters[index] > 0)
        {
            switch (index)
            {
                case 1:
                    objectToInstantiate = ruina1Objects[counter];
                    break;
                case 2:
                    objectToInstantiate = ruina2Objects[counter];
                    break;

                default:
                    Debug.LogWarning("No object assigned for counter value: " + counter);
                    break;
            }
        }

        return objectToInstantiate;
    }
}

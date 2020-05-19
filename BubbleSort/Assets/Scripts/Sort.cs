using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort
{
    float temp=0;
    int c = 0;
    bool sorted = false;
    public float[] Sorter(float[] inputs)
    {
        while (!sorted)
        {
            c = 0;
            for (int i = 1; i < inputs.Length; i++)
            {
                if (inputs[i - 1] <= inputs[i])
                {
                    continue;
                }
                else
                {
                    temp = inputs[i];
                    inputs[i] = inputs[i - 1];
                    inputs[i - 1] = temp;
                }
                c++;
            }
            if (c == 0)
            {
                sorted = true;
            }
        }
        return inputs;
    }
}

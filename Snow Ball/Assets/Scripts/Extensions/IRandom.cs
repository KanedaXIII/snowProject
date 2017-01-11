using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandom
{

    float Next();
    double NextDouble();
    int Next(int size);
    int Next(int low, int high);

}

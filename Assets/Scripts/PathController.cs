using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public List<Transform> activePath = new List<Transform>();

    public List<Transform> GetActivePath(){
        return activePath;
    }
}
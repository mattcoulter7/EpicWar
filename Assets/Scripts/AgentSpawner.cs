using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public float interval = 1;
    public GameObject spawnPrefab;
    public Transform spawnPosition;
    private float _nextActionTime = 0.0f;
    private PathController _pc;
    private List<GameObject> _usedAgents = new List<GameObject>();
    private List<GameObject> _pooledAgents = new List<GameObject>();
    
    void Start(){
        _pc = Camera.main.GetComponent<PathController>();
    }
    private GameObject SpawnObject(){
        GameObject obj = Instantiate(spawnPrefab,spawnPosition);
        FollowPath fp = obj.GetComponent<FollowPath>();
        fp.SetPath(_pc.GetActivePath());
        return obj;
    }
    void Update()
    {
        if (Time.time > _nextActionTime)
        {
            _nextActionTime += interval;
            SpawnObject();
        }
    }
}

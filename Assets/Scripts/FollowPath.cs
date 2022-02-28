using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public List<Transform> path = new List<Transform>();
    public float speed = 10f;
    public Vector3 com;
    public bool following = true;
    private Rigidbody _rb;
    private int _activeNoteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _rb.centerOfMass = com;
    }

    public void SetPath(List<Transform> _path){
        foreach (Transform t in _path){
            path.Add(t);
        }
    }
    private Transform GetCurrentNode(){
        return path[_activeNoteIndex];
    }
    private bool NodeReached(Transform node){
        Vector3 toNode = node.position - transform.position;
        return toNode.magnitude < 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (!following) return;
        if (path.Count == 0) return;

        Transform node = GetCurrentNode();
        Vector3 toNode = node.position - transform.position;
        toNode.Normalize();
        
        _rb.velocity = toNode * speed;
        
        if (NodeReached(node)){
            _activeNoteIndex+=1;
            if (_activeNoteIndex > path.Count - 1){
                Destroy(gameObject);
            }
        }
    }
}

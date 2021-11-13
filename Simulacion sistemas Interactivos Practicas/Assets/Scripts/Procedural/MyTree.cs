using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTree : MonoBehaviour
{
    [SerializeField]int counter;
    [SerializeField] GameObject prefab_branch;
    private Queue<GameObject> fronteir = new Queue<GameObject>();
    [Range(0, 1)]
    [SerializeField]float reduction_x_lvl = 0.6f;
    [SerializeField] float root_length;
    [SerializeField] float rotation;
    // Start is called before the first frame update
    void Start()
    {
       GameObject root = Instantiate(prefab_branch, transform);
        SetLengthBranch(root, root_length);
       fronteir.Enqueue(root);
        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prev_prefab,float relative_angle)
    {
       

            GameObject newbranch = Instantiate(prefab_branch, transform);
            newbranch.transform.position = prev_prefab.transform.position + (prev_prefab.transform.up*GetBranchLength(prev_prefab));
            newbranch.transform.rotation = prev_prefab.transform.rotation * Quaternion.Euler(0, 0, relative_angle);
 
       
        return newbranch;
    }
    private void GenerateTree()
    {
        if (counter == 0) return;
        List<GameObject> new_nodes= new List<GameObject>();
        while (fronteir.Count > 0)
        {
            GameObject prev_mod = fronteir.Dequeue();
            var left = CreateBranch(prev_mod, Random.Range(0,rotation));
            var right = CreateBranch(prev_mod, Random.Range(0, -rotation));
            SetLengthBranch(left, GetBranchLength(prev_mod) - reduction_x_lvl);
            SetLengthBranch(right, GetBranchLength(prev_mod) - reduction_x_lvl);
            new_nodes.Add(left);
            new_nodes.Add(right);
        }
        foreach (var nodes in new_nodes)
        {
            fronteir.Enqueue(nodes);
        }
        counter--;
        GenerateTree();
    }
    private void SetLengthBranch(GameObject branch, float length)
    {
        Transform line = branch.transform.GetChild(0);
        Transform head = branch.transform.GetChild(1);

        line.localScale = new Vector3(line.localScale.x, length, line.localScale.z);
        line.localPosition = new Vector3(line.localPosition.x, length/2, line.localPosition.z);
        head.localPosition = new Vector3(head.localPosition.x, length, head.localPosition.z);
    }
    private float GetBranchLength(GameObject branch)
    {
        Transform line = branch.transform.GetChild(0);
        return line.localScale.y;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private int _width = 3;
    private int _heigh = 3;
    [SerializeField] private Node _nodePrefab;
    public int[,] slotSize = new int[3, 3];
    [SerializeField] List<Node> _nodeList;
    [SerializeField] List<int> normalList = new List<int>();
    private void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        _nodeList = new List<Node>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _heigh; y++)
            {
                var node = Instantiate(_nodePrefab, new Vector2(x, y), Quaternion.identity);
                _nodeList.Add(node);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int q = 0;
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _heigh; y++)
                {
                    slotSize[x, y] = _nodeList[q].GetValue();
                    q++;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _heigh; y++)
                {
                    Debug.Log($"x{x},y{y}={slotSize[x, y]}");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            JudgeNormal();
        }
    }


    public void JudgeNormal()
    {
        for (int i = 0; i < 3; i++)
        {
            if (slotSize[i, 0] == slotSize[i, 1] && slotSize[i, 0] == slotSize[i, 2])
            {
                normalList.Add(slotSize[i, 0]);
            }
            if (slotSize[0, i] == slotSize[1, i] && slotSize[0, i] == slotSize[2, i])
            {
                normalList.Add(slotSize[0, i]);
            }
        }
        if (slotSize[0, 0] == slotSize[1, 1] && slotSize[0, 0] == slotSize[2, 2])
        {
            normalList.Add(slotSize[0, 0]);
        }
        if (slotSize[2, 0] == slotSize[1, 1] && slotSize[2, 0] == slotSize[0, 2])
        {
            normalList.Add(slotSize[2, 0]);
        }
    }

    public void JudgeTest()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _heigh; y++)
            {
                int r;
                r = slotSize[x, y];
            }
        }
    }


}


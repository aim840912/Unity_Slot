using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 尚未用到
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
}

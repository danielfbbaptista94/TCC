﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    public void DontDestroyMethod()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}

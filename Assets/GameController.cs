using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] private BulletSetting[] bulletSettings;
    private Coroutine coroutineDeceleration;

    public BulletSetting[] GetBulletSettings => bulletSettings;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartDeceleration()
    {
        if (coroutineDeceleration != null)
            StopCoroutine(coroutineDeceleration);
        coroutineDeceleration = StartCoroutine((Deceleration()));
    }
    
    private IEnumerator Deceleration()
    {
        while (Time.timeScale > 0.5f)
        {
            Time.timeScale -= 0.1f;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        
        while (Time.timeScale < 1f)
        {
            Time.timeScale += 0.1f;
            yield return null;
        }
        
        Time.timeScale = 1f;
        coroutineDeceleration = null;
    }
}

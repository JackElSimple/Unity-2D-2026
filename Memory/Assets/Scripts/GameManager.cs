using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel; // Necesario para ReadOnlyCollection
using UnityEngine;
using UnityEngine.SceneManagement;

// Eliminamos Unity.VisualScripting para evitar conflictos con 'Singleton'
public class GameManager : MonoBehaviour
{
    // Implementación simple de Singleton manual para evitar errores de herencia
    public static GameManager Instance { get; private set; }

    [SerializeField] private Sprite[] cardFaces;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
    }
    public ReadOnlyCollection<Sprite> CardSprites
    {
        get
        {
            return Array.AsReadOnly(cardFaces ?? new Sprite[0]);
        }
    }

    private void Awake()
    {
        // Lógica de Singleton estándar
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public float interLevelWaitTime = 3f;
    public void GoToNextLevel(float waitTime = -1)
    {
        
    if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("YOU WIN!");
        }
        else
        {
            if (waitTime < 0) waitTime = interLevelWaitTime;

            Debug.Log("Prepare for next level!");
            StartCoroutine(WaitAndLoadNextScene(waitTime));
        }
    }
    private IEnumerator WaitAndLoadNextScene(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
/*
 using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Sprite[] cardFaces;
    public ReadOnlyCollection<Sprite> cardSprites
    {
        get
        {
            return Array.AsReadOnly<Sprite>(cardFaces);
        }
    }
}
*/
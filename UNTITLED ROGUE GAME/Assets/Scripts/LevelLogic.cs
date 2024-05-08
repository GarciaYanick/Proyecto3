using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{

    [SerializeField] private List<GameObject> _enemies;
    public EventHandler OnEnemiesKilled; 
    // Start is called before the first frame update
    void Start()
    {
   
    }

    private void Update()
    {
        if (_enemies.Count <= 0)
        {
            OnEnemiesKilled?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.Instance.currentLevel++;
            GameManager.Instance.LevelChange();
            collision.gameObject.transform.position = new Vector2(0, 0);
        }
    }
}

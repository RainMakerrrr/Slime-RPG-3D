using System.Collections;
using Logic;
using Logic.Health;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const float LoadSceneDelay = 2f;
    
    private IDamageable _player;
    private WayPointHolder _wayPointHolder;
    
    public void Construct(IDamageable player, WayPointHolder wayPointHolder)
    {
        _player = player;
        _wayPointHolder = wayPointHolder;
        
        _player.Died += OnPlayerDied;
        _wayPointHolder.ReachAllPoints += OnReachAllPoint;
    }

    private void OnDestroy()
    {
        _player.Died -= OnPlayerDied;
        _wayPointHolder.ReachAllPoints -= OnReachAllPoint;
    }

    private void OnPlayerDied(GameObject player)
    {
        Debug.Log("YOU WIN");
        StartCoroutine(LoadSceneWithDelay());
    }

    private void OnReachAllPoint()
    {
        Debug.Log("YOU LOSE");
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(LoadSceneDelay);

        SceneManager.LoadScene(0);
    }
}
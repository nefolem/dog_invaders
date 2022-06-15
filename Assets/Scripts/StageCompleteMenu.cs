using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCompleteMenu : MonoBehaviour
{
    public GameObject stageCompleteMenu;

    void Update()
    {
        if (GameController.stageComplete)
        {
            StartCoroutine(StageCompleteCoroutine());
        }
    }

    IEnumerator StageCompleteCoroutine()
    {
        yield return new WaitForSeconds(2);
        StageComplete();
    }

    private void StageComplete()
    {
        stageCompleteMenu.SetActive(true);
        Time.timeScale = 0f;
        GameController.stageComplete = false;
    }

    public void Restart()
    {
        //gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;

    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoStage1 : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameStart"); // �� �̸� �����ϱ�
    }
}

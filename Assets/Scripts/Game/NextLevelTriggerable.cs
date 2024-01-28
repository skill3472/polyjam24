using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTriggerable : MonoBehaviour, ITriggerable
{
	public string nextSceneName;
	
	public void TriggerEffect(GameObject sender) => SceneManager.LoadScene(nextSceneName);
}
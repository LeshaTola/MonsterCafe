using UnityEngine.SceneManagement;

public static class Loader
{
	public enum Scene
	{
		GameScene,
		LoadingScene
	}

	private static Scene loadingScene;

	public static void Load(Scene loadingScene)
	{
		Loader.loadingScene = loadingScene;
		SceneManager.LoadScene(Scene.LoadingScene.ToString());
	}

	public static void LoadCallBackScene()
	{
		SceneManager.LoadScene(loadingScene.ToString());
	}
}

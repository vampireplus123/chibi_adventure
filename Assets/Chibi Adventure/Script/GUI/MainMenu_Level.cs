using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Level : MonoBehaviour {
    public int worldNumber = 0;
    public int levelNumber = 0;

    public string loadscene = "Level Name";

    public Text TextLevel;
    public GameObject Locked;

    // Time to wait for interstitial ad (in seconds)
    public float adDuration = 3.0f;

    void Start() {
        var levelReached = PlayerPrefs.GetInt(worldNumber.ToString(), 1);
        if (levelNumber <= levelReached && worldNumber <= PlayerPrefs.GetInt(GlobalValue.WorldReached, 1)) {
            TextLevel.gameObject.SetActive(true);
            TextLevel.text = levelNumber.ToString();
            Locked.SetActive(false);
        } else {
            TextLevel.gameObject.SetActive(false);
            Locked.SetActive(true);
            GetComponent<Button>().interactable = false;
        }
    }

    public void LoadScene() {
        GlobalValue.worldPlaying = worldNumber;
        GlobalValue.levelPlaying = levelNumber;

        LoadingSreen.Show();

        // Start a coroutine to wait and then load the scene
        StartCoroutine(ShowAdAndLoadScene());
    }

    // Coroutine to simulate ad duration and load the scene afterward
    IEnumerator ShowAdAndLoadScene() {
        if (adsManager.Instance != null) {
            // Show interstitial ad (if applicable)
            adsManager.Instance.ShowInterstitial();
        }

        // Wait for the simulated ad duration (e.g., 3 seconds)
        yield return new WaitForSeconds(adDuration);

        // After waiting, load the scene
        SceneManager.LoadSceneAsync(loadscene);
    }
}

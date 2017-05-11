using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechHandler : MonoBehaviour {

    public string HidePlaneCmd = "hide plane";
    public GameObject Plane;

    public string ShootCmd = "shoot";
    public CannonBehavior Cannon;

    public string ResetSceneCmd = "reset scene";

    private KeywordRecognizer _keywordRecognizer;

    private void Start()
    {
        _keywordRecognizer = new KeywordRecognizer(new[] { HidePlaneCmd, ResetSceneCmd, ShootCmd }); //Pass strings as arrays
        _keywordRecognizer.OnPhraseRecognized += KeyWordRecognizer_OnPhraseRecognized;
        _keywordRecognizer.Start();
    }

    private void KeyWordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        var cmd = args.text;
        if(cmd == HidePlaneCmd)
        {
            Plane.SetActive(false);
        }
        else if (cmd == ShootCmd)
        {
            Cannon.Shoot();
        }
        else if (cmd == ResetSceneCmd)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }
}

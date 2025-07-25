using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] GamePlayManager _gamePlayManager;
    [SerializeField] Animator _loseAnimator;
    [SerializeField] TextMeshProUGUI _loseText;

    [SerializeField] List<GameObject> _cubeButtons;
    [SerializeField] List<GameObject> _tempCubeButtons;
    [SerializeField] List<GameObject> _glowingCubeButtons;
    [SerializeField] int _pressedCubeButtonNumber;
    [SerializeField] int _maxCubeButtonNumber;
    [SerializeField] GameObject _shatteredCubes;

    private float _currentPitch = 1f; // Track pitch for CubeShow


    private void Awake()
    {
        Instance = this;
    }
    public void RespawnCubes() {
        _glowingCubeButtons = new List<GameObject>();
        _tempCubeButtons = new List<GameObject>(_cubeButtons);
    }
    public void ResetLevel()
    {
        ShatteredCube shattered = GameObject.FindFirstObjectByType<ShatteredCube>();
        if (shattered != null)
        {
            Destroy(shattered.gameObject);
        }

        _pressedCubeButtonNumber = 0;
        

        _currentPitch = 1f; // Reset pitch

        GoNextLevel();
    }

    public void ActiveCubeButtons(bool isActive)
    {
        foreach (GameObject obj in _cubeButtons)
        {
            obj.SetActive(true);
            obj.GetComponent<Collider>().enabled = isActive;
        }
    }

    public IEnumerator StartGlowingCubeButtons(List<GameObject> desiredCubeButtons)
    {
        ActiveCubeButtons(false);
        _currentPitch = 1f;
        yield return new WaitForSeconds(0.75f);

        for (int i = 0; i < desiredCubeButtons.Count; i++)
        {
            SoundManager.instance.PlaySound(SoundManager.SoundNames.AutoCubeShow);
            desiredCubeButtons[i].GetComponent<CubeButton>().GlowCube();
            yield return new WaitForSeconds(0.5f);
        }

        ActiveCubeButtons(true);
    }

    private void Start()
    {
        // ResetLevel(); // Uncomment to auto-start
    }

    public void GoNextLevel()
    {
        _pressedCubeButtonNumber = 0;
        StartLevel();
    }

    public void Replay()
    {
        _loseAnimator.SetTrigger("Off");
        ResetLevel();
    }

    public void StartLevel()
    {
        int randomNumber = Random.Range(0, _tempCubeButtons.Count);
        _glowingCubeButtons.Add(_tempCubeButtons[randomNumber]);
        _tempCubeButtons.RemoveAt(randomNumber);

        StartCoroutine(StartGlowingCubeButtons(_glowingCubeButtons));
    }

    internal void OnCubePressed(GameObject gameObject)
    {
        if (gameObject == _glowingCubeButtons[_pressedCubeButtonNumber])
        {
            SoundManager.instance.PlaySound(SoundManager.SoundNames.CubeShow, _currentPitch);
            _currentPitch += 0.1f; // Increase pitch slightly

            if (_pressedCubeButtonNumber == _glowingCubeButtons.Count - 1)
            {
                if (_glowingCubeButtons.Count == _maxCubeButtonNumber)
                {
                    Debug.Log("WIN");
                    ActiveCubeButtons(false);
                    StopAllCoroutines();
                    _loseText.text = "You Win!";
                    _loseAnimator.SetTrigger("On");
                    SoundManager.instance.PlaySound(SoundManager.SoundNames.LevelComplete);
                }
                else
                {
                    StopAllCoroutines();
                    GoNextLevel();
                }
            }
            else
            {
                _pressedCubeButtonNumber++;
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            SoundManager.instance.PlaySound(SoundManager.SoundNames.GameOver);

            ActiveCubeButtons(false);
            
            foreach (GameObject obj in _cubeButtons) {
                DestoryCube(obj);
                Debug.Log("1");
            }
            
            StopAllCoroutines();
            _loseText.text = "Wrong Cube Selected!";
            _loseAnimator.SetTrigger("On");
        }
    }

    public void DestoryCube(GameObject parent)
    {
       
        GameObject obj = Instantiate(_shatteredCubes);
        obj.transform.position = parent.transform.position;
        parent.SetActive(false);
    }
}

using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    [SerializeField]
    private AudioSource IntroSound;

    [SerializeField]
    private AudioSource MainSound;

    void Start()
    {
        IntroSound.Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("StartGame"))
        {
            IntroSound.Stop();
            cam1.SetActive(false);
            cam2.SetActive(true);
            MainSound.Play();
        }
    }

}

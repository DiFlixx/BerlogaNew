using System.Collections;
using System.Threading;
using UnityEngine;

namespace Assets
{
    public class Finish : MonoBehaviour
    {
        public AudioSource sound;

        private void Start()
        {
            sound = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(gameObject.transform.position == Vector3.zero)
            {
                sound.Play();
                sound = null;
                ChangeScene();
            }
        }

        private void ChangeScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}
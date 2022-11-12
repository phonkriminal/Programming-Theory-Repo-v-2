using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace edeastudio {
    public class TutorialObject : MonoBehaviour
    {
        [SerializeField]
        private string[] m_lines;
        [SerializeField]
        [Range(0.01f, 2.0f)]
        private float m_typeRatio = 0.01f;
        [SerializeField]
        private TMP_Text infoPanel;
        [SerializeField]
        private GameObject audioSfxObject;
        private AudioSfx audioSfx;

        private Queue<string> m_queue = new();

        // Start is called before the first frame update
        void Start()
        {
            InitializeScene();  // ABSTRACTION
            StartCoroutine(nameof(IEStartTyping));

        }

        private void InitializeScene()
        {
            m_queue.Clear();
            for (int i = 0; i < m_lines.Length; i++)
            {
                if (i== 0) { m_lines[i] = $"Hi {MainManager.Instance.GetPlayerName()}, " + m_lines[i]; }
                m_queue.Enqueue(m_lines[i] + System.Environment.NewLine);
            }
            infoPanel.text = "";
            audioSfx = audioSfxObject.GetComponent<AudioSfx>();
            if (audioSfx == null) { Debug.Log("AudioSFX not Found"); }
        }

        private IEnumerator IEStartTyping()
        {
            string line = "";

            while (m_queue.Count > 0)
            {
                char[] chars = m_queue.Dequeue().ToCharArray();
                
                for (int i = 0; i < chars.Length; i++)
                {
                    float humanize = Random.Range(0.01f, 0.05f);
                    float carriage = 0f;
                    float spaceDelay = 0.1f;
                    int iSpace = Random.Range(0, 2);
                    float space = 0f;
                    line += chars[i];
                    
                    if (i == chars.Length - 1)
                    {
                        audioSfx.PlayCarriage();
                        carriage = 3;
                    }
                    else if (chars[i].ToString() == " ") { space = spaceDelay * iSpace; audioSfx.PlaySound(); }
                    else if (chars[0] == '/')
                    {
                        Debug.Log("/");
                        yield return new WaitForSeconds(1);
                        infoPanel.text = "";
                        line = "";
                        break;
                    }
                    else { audioSfx.PlaySound(); }
                    yield return new WaitForSeconds(m_typeRatio + humanize + carriage + space);
                    infoPanel.text = line;
                }
            }
            yield return null;
        }
    }
}
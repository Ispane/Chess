using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    public static DamageUI Instance { get; private set; }
    public Text TextPrefab;

    private class ActiveText
    {
        public Text UIText;
        public float maxTime;
        public float Timer;
        public Vector2 entityPosition = AttackSystem.entityPos;

        public void MoveText(Camera camera)
        {
            float delta = 1.0f - (Timer / maxTime);
            Vector2 pos = entityPosition + new Vector2(1.0f, delta);

            UIText.transform.position = pos;
        }
    }

    const int POOL_SIZE = 20;

    Queue<Text> m_TextPool = new Queue<Text>();
    List<ActiveText> m_ActiveText = new List<ActiveText>();

    void Awake()
    {
        Instance = this;
    }

    Camera m_Camera;
    Transform m_Transform;

    void Start()
    {
        m_Camera = Camera.main;
        m_Transform = transform;
        for (int i = 0; i < POOL_SIZE; i++)
        {
            Text temp = Instantiate(TextPrefab, m_Transform);
            temp.gameObject.SetActive(false);
            m_TextPool.Enqueue(temp);
        }
    }
    void Update()
    {
        for (int i = 0; i < m_ActiveText.Count; i++)
        {
            ActiveText at = m_ActiveText[i];
            at.Timer -= Time.deltaTime;

            if (at.Timer <= 0.0f)
            {
                at.UIText.gameObject.SetActive(false);
                m_TextPool.Enqueue(at.UIText);
                m_ActiveText.RemoveAt(i);
                i--;
            }
            else
            {
                var color = at.UIText.color;
                color.a = at.Timer / at.maxTime;
                at.UIText.color = color;

                at.MoveText(m_Camera);
            }
        }
    }
    public void AddText(int amount, Vector2 entityPos)
    {
        var t = m_TextPool.Dequeue();
        t.text = amount.ToString();
        t.gameObject.SetActive(true);

        ActiveText at = new ActiveText() { maxTime = 1.0f };
        at.Timer = at.maxTime;
        at.UIText = t;
        at.entityPosition = entityPos + Vector2.up;

        at.MoveText(m_Camera);
        m_ActiveText.Add(at);
    }
}
using System.Collections.Generic;
using MonoBehaviours.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class TextManager : MonoSingleton<TextManager>
    {
        [SerializeField] private const float DisplayTimePerCharacter = 0.15f;

        [SerializeField] private const float AdditionalDisplayTime = 1f;


        private static readonly List<Instruction> Instructions = new List<Instruction>();
        private static float _clearTime;


        public Text text;

        protected override void Init()
        {
            text.enabled = false;
        }

        private void Update()
        {
            if (Instructions.Count > 0 && Time.time >= Instructions[0].startTime)
            {
                text.enabled = true;
                text.text = Instructions[0].message;
                text.color = Instructions[0].textColor;

                Instructions.RemoveAt(0);
            }
            else if (Time.time >= _clearTime)
            {
                text.text = string.Empty;
                text.enabled = true;
            }
        }

        public static void DisplayMessage(string message, Color textColor, float delay)
        {
            var startTime = Time.time + delay;

            var displayDuration = message.Length * DisplayTimePerCharacter + AdditionalDisplayTime;

            var newClearTime = startTime + displayDuration;

            if (newClearTime > _clearTime)
                _clearTime = newClearTime;

            var newInstruction = new Instruction
            {
                message = message,
                textColor = textColor,
                startTime = startTime
            };

            Instructions.Add(newInstruction);
        }

        private struct Instruction
        {
            public string message;
            public Color textColor;
            public float startTime;
        }
    }
}
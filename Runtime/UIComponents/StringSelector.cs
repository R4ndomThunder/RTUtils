/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.Collections.Generic;
using UnityEngine;

namespace RTDK.UIComponents
{
    public class StringSelector : SelectorBase
    {
        public List<string> values = new();
        int currentIndex = 0;

        public override void NextSelect()
        {
            base.NextSelect();

            currentIndex++;
            if (currentIndex >= values.Count)
                currentIndex = 0;

            ShowValue();
            OnValueChanged.Invoke(currentIndex);
        }

        public override void PrevSelect()
        {
            base.PrevSelect();

            currentIndex--;
            if (currentIndex < 0)
                currentIndex = values.Count - 1;

            ShowValue();
            OnValueChanged.Invoke(currentIndex);
        }

        public override void SetValue(int index)
        {
            currentIndex = index;
            ShowValue();
            OnValueChanged.Invoke(currentIndex);
        }

        public override void ShowValue()
        {
            valueText.text = values[currentIndex].ToString();
        }
    }
}
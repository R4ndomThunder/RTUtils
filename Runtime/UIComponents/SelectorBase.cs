/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RTDK.UIComponents
{
    public abstract class SelectorBase : Selectable, IEventSystemHandler
    {
        public GameObject prevBtn, nextBtn;
        public TextMeshProUGUI valueText;
        public UnityEvent<int> OnValueChanged;

        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            Color targetColor =
              state == SelectionState.Disabled ? colors.disabledColor :
              state == SelectionState.Highlighted ? colors.highlightedColor :
              state == SelectionState.Normal ? colors.normalColor :
              state == SelectionState.Pressed ? colors.pressedColor :
              state == SelectionState.Selected ? colors.selectedColor : Color.white;

            var items = GetComponentsInChildren<Graphic>();

            foreach (Graphic graphic in items)
            {
                graphic.CrossFadeColor(targetColor, instant ? 0f : colors.fadeDuration, true, true);
            }
        }

        public virtual void NextSelect()
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        public virtual void PrevSelect()
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        public virtual void SetValue(int index)
        {

        }

        public virtual void ShowValue()
        {

        }

        public override void OnMove(AxisEventData eventData)
        {
            switch (eventData.moveDir)
            {
                case MoveDirection.Left:
                    PrevSelect();
                    break;
                case MoveDirection.Right:
                    NextSelect();
                    break;
                default:
                    base.OnMove(eventData);
                    break;
            }
        }
    }
}
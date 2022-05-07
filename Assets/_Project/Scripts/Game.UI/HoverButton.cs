using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public sealed class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event UnityAction OnButtonClicked
        {
            add => _button.onClick.AddListener(value);
            remove => _button.onClick.RemoveListener(value);
        }
        
        [SerializeField] private Button _button = default;
        [SerializeField] private HighlightableText[] _highlightableTexts;
        [SerializeField] private TMP_Text _label;
        
        public bool IsInteractable => _button.interactable;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            EnableGlow();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DisableGlow();
        }
        
        public void Invoke()
        {
            _button.onClick.Invoke();
        }

        private void OnEnable()
        {
            CheckIfIsInteractable();
        }

        private void OnDisable()
        {
            DisableGlow();
        }

        private void EnableGlow()
        {
            if (!_button.interactable)
            {
                return;
            }
            
            foreach (HighlightableText highlightableText in _highlightableTexts)
            {
                highlightableText.EnableGlow();
            }
        }

        private void DisableGlow()
        {
            if (!_button.interactable)
            {
                return;
            }
                
            foreach (HighlightableText highlightableText in _highlightableTexts)
            {
                highlightableText.DisableGlow();
            }
        }

        public void SetInteractable(bool isInteractable)
        {
            _button.interactable = isInteractable;

            CheckIfIsInteractable();
        }

        private void CheckIfIsInteractable()
        {
            foreach (HighlightableText highlightableText in _highlightableTexts)
            {
                if (!_button.interactable)
                {
                    highlightableText.BlockGlow();
                    
                    continue;
                }
                
                highlightableText.UnblockGlow();
            }
        }

        public void SetLabelText(string text)
        {
            _label.text = text;
        }
    }
}

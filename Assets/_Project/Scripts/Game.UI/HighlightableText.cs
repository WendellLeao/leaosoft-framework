using UnityEngine;
using TMPro;

namespace Game.UI
{
    public sealed class HighlightableText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text = default;
        [SerializeField] private Material _originalMaterial;
        [SerializeField] private Material _glowMaterial;
        [SerializeField] private Material _blockedMaterial;
        
        [Header("Colors")]
        [SerializeField] private Color _originalColor;
        [SerializeField] private Color _glowColor;

        public void EnableGlow()
        {
            _text.fontMaterial = _glowMaterial;

            _text.color = _glowColor;
        }

        public void DisableGlow()
        {
            _text.fontMaterial = _originalMaterial;
            
            _text.color = _originalColor;
        }

        public void BlockGlow()
        {
            _text.fontMaterial = _blockedMaterial;
            
            _text.color = _originalColor;
        }
        
        public void UnblockGlow()
        {
            DisableGlow();
        }
    }
}

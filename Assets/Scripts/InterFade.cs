using System.Collections;
using UnityEngine;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _FadeCanvasGroup;
    [SerializeField] private float _fadeSpeed = 1f;
    
    private bool _isOpen = false;

    
    /*private void Start()
    {
        //PlayerController.Instance._input.Player.ToggleUI.performed += _ => ToggleUI()
    }*/
    [ContextMenu("Toggle UI")]
    private void ToggleUI()
    {
        _isOpen = !_isOpen;

        StartCoroutine(Faded(_isOpen));
    }

    IEnumerator Faded(bool _isOpen)
    {
        float alpha = _isOpen ? 0f : 1f;
        if(_isOpen) // == true
        {
            while(alpha < 1f)
            {
                alpha += _fadeSpeed * Time.deltaTime;
                _FadeCanvasGroup.alpha = alpha;
                yield return null;
                // yield my flesh, to calm there bone
            }
        }
        else
        {
            while(alpha > 0f)
            {
                alpha -= _fadeSpeed * Time.deltaTime;
                _FadeCanvasGroup.alpha = alpha;
                yield return null;
            }
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Hello World");
    }

    /*[ContextMenu("Toggle UI")]
    public void ToggleUI()
    {
        _isOpen = !_isOpen;

        StartCoroutine(Faded());
    }*/
}

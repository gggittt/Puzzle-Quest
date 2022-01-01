using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileColor : MonoBehaviour
{
    [SerializeField] private Color _illuminated;
    private Color _original;
    private bool _isIlluminated = false;

    private void Start()
    {
        _original = GetComponent<SpriteRenderer>().color;
    }

    public void SwitchIlluminate()
    {
        Debug.Log($"<color=cyan> _isIlluminated = {_isIlluminated}  </color>");
        if (_isIlluminated)
            DeIlluminate();
        else
            Illuminate();
    }

    public void Illuminate()
    {
        GetComponent<SpriteRenderer>().color = _illuminated;
        _isIlluminated = true;
    }

    public void DeIlluminate()
    {
        GetComponent<SpriteRenderer>().color = _original;
        _isIlluminated = false;
    }
}
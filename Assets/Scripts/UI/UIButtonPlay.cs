
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonPlay : UIBase, IButton, IPointerDownHandler
{
    [SerializeField] private Views _views;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _canvas;
    [SerializeField] private GameField _gameField;
    private float _scale;

    public void OnEnable()
    {
        SetTransparent( 1f );
    }
    
    public void Play()
    {
        _gameField.ReloadField();
        SetTransparent(0.5f);
    }


    public override void Lose()
    {
        SetTransparent(1f);
    }
    

    public void SetTransparent( float alpha )
    {
        var img = GetComponent<Image>();
        var color = img.color;
        color.a = alpha;
        img.color = color;
    }

    public override void EnableForDisplay()
    {
        SetTransparent(1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_gameState.Game == null || (_gameState.Game is GameRunning) == false)
        {
            _gameState.StartGame();
            Play();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}

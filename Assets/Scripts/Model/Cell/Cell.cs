using UnityEngine;

public class Cell : ICell
{
    private readonly ICellView _cellView;
    public Flag Flag { get; private set; }
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set;  }
    public bool IsInitMine { get; private set; }
    public CellData CellData { get; private set; }
    public bool MineSetAllow { get; private set; }
    public ICellView CellView => _cellView;

    public Cell( ICellView cellView, int indexI, int indexJ )
    {
        Value = 0;
        _cellView = cellView;
        IsOpen = false;
       IsInitMine = false;
       IsFlagged = false;
       CellData = cellView.GetCellData();
       MineSetAllow = true;
       Flag = new Flag( _cellView, _cellView.FlagView );
    }

    public void Display( Vector3 position, float scale)
    {
        _cellView.Display(this, position, scale);
    }

    public void CreateMine(int value, int indexI, int indexJ)
    {
        Value = value;
        if (Value == -1)
        {
            IsInitMine = true;
        }
        else IsInitMine = false;
    }

    public void Open()
    {
        IsOpen = true;
        CellView.BrickView.transform.gameObject.SetActive(false);
    }
 
    public bool SetFlag( ContainerMines containerMines )
    {
        if (IsOpen == true) return true;
        Flag.SetFlag( containerMines );
        IsFlagged = Flag.Value;
        AndroidAPI.Vibration(50);
        return IsFlagged && IsInitMine;
    }

 
    public void IncrementValue()
    {
        Value++;
        _cellView.SetTextNumbers( Value  );
    }

    public InputHandler GetInputHandler()
    {
        return _cellView.GetInput();
    }
    
}

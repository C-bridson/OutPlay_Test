


You are working on a match-3 game with the following rules:

• Pairs of jewels adjacent vertically and horizontally can be swapped.
• You can only swap jewels when this will result in a match being created.
• A match happens when there are 3 or more jewels of the same kind adjacent vertically or 
horizontally.
• All jewels involved in matches are set to JewelKind::Empty after each move.
• One point is given for each jewel that has been removed. The best move for a given board is thus 
the one that will remove the most jewels.
• The initial board state contains no matches; therefore, swapping jewels is the only way matches 
can be created.

Given the code below implement the CalculateBestMoveForBoard function

Roadmap
    loop through width and hight for board
    check validation of possaible move
    simulate swap of jewels 
    calculate score based on coloums and rows
    save best move
    return final best move



```cs
public class Board
{
    enum JewelKind
    {
        Empty,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }
    enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    struct Move
    {
        public int x;
        public int y;
        public MoveDirection direction;
    }

    int GetWidth();
    int GetHeight();
    JewelKind GetJewel(int x, int y);
    void SetJewel(int x, int y, JewelKind kind);
    
    Move CalculateBestMoveForBoard()
    {
    // Implement this function
    }
}
```cs
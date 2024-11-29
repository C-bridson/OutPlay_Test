


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
    loop through directions to move
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

    int GetWidth();
    int GetHeight();
    JewelKind GetJewel(int x, int y);
    void SetJewel(int x, int y, JewelKind kind);


    struct Move
    {
        public int x;
        public int y;
        public MoveDirection direction;
        public Move(int x,int y, MoveDirection dir)
        {
            this.x = x;
            this.y = y;
            this.direction = dir;
        }
    }

 
    
    Move CalculateBestMoveForBoard()
    {
        //move down rows
        for(y = 0; y < GetHeight(); y++)
        {
            //moving across columns
            for(x = 0; x < GetWidth(); x++)
            {
                foreach(MoveDirection direction in Enum.GetValues(typeof(MoveDirection)))
                {

                    if(IsSwapValid(x,y,direction))
                    {             

                            // calculate

                        //score
                    }
                }
            }
    
        }
    }

    // Checking if there is a valid tile to swap too.
    // Returns True if valid
    ///
    bool IsSwapValid(int x, int y, MoveDirection direction)
    {
    int swappedX = x;
    int swappedY = y;
    switch(direction)
    {
        case MoveDirection.Up: swappedY -= 1;
        break;
        case MoveDirection.Down: swappedY += 1;
        break;
        case MoveDirection.Left: swappedX -=1; 
        break;
        case MoveDirection.Right: swappedX +=1;
    }

    if(swappedX <0 || swappedX >= GetWidth() || swappedY < 0 || swappedY >= GetHeight() )
    {
        // Out of Bounds;
        return false;
    }
    return true;
    }

}
```cs
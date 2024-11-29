


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
                            int score = CalculateMatchScore(x,y,direction);

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


///
//swaps the position that was valid, checks for matching jewels.
//resets the positions and returns score.
///

int CalculateMatchScore(int x, int y, MoveDirection direction)
{
   int swappedX = x;
   int swappedY = y;
   int score =0;

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

   JewelKind currentSelected = GetJewel(x,y);
   JewelKind targetJewel = GetJewel(swappedX,swappedY);

   // jewels have been swapped around
   SetJewel(x,y,targetJewel);
   SetJewel(swappedX,swappedY,currentSelected);

    //check for any matches in all directions and calculate Row and Column score
   score += CheckMatches(swappedX,swappedY);
   score += CheckMatches(x,y);

   // return jewels that have been swapped back.
   SetJewel(x,y,currentSelected);
   SetJewel(swappedX,swappedY,targetJewel);

   return score;
}


// iterates through rows and columns to find any matching types
// counts up the score the move should make.
int CheckMatches(int x, int y)
{
     //calculate how much the player gets for the swap
    //based on row, column matches.
   JewelKind kind = GetJewel(x,y);
   int score = 0;

   //already have 1st jewel // move across columns
   // Search in 4 directions till no jewel match or 

   int count = 1
   for (int i = x - 1; i >= 0 && GetJewel(i,y) == kind; i--)
   {
      count++;
   }
   
   for(int i = x + 1; i < GetWidth() && GetJewel(i,y) == kind; i++)
   {
      count++
   }

   if (count >= 3)
   {
      score += count;
   }

   //vertical
   count = 1;
   for (int i = y - 1; i >= 0 && GetJewel(x,i) == kind; i--)
   {
      count++;
   }
   for(int i = y + 1; i < GetHeight() && GetJewel(x,i) == kind; i++)
   {
      count++;
   }
   if (count >= 3)
   {
      score += count;
   }

   return score;
}




}
```cs
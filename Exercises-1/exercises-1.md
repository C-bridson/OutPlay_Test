
Goal : predict the position of a ball if and when it arrives at a set height.

Solution development :
Problem described matches a traditional trajectory solution plus bouncing off the walls
Researched how to calculate trajectories 
 -- selected a quadratic formula to solve for time. The equation a*t^2 + b*t + c = 0 where a = 0.5 * G, b = -v.Y, and c = deltaY (difference in height).  
 -- Use 1D kinematics to calculate X Position
 -- Handle wall bounces through remainder from width division
Check that the Target height was reached and return True



```cs
bool TryCalculateXPositionAtHeight(
    float targetHeight,
    Vector2 position,
    Vector2 velocity,
    float gravity,
    float width,
    ref float xPosition)
{

    float acceleration = 0.5f * gravity;
    float heightDifference = position.y - targetHeight;

    //solve for time using a quadratic formula

    float time = (-velocity.y + (Math.Sqrt(Math.Pow(velocity.y, 2) - 4 * acceleration * heightDifference))) / (2 * acceleration);

    //determine if ball reached target height
    // If time is negative, the ball does not reach the target height 
    if (time < 0) 
    { 
        return false;
    }

    //1D kinematics equations to solve for x position after time

    float x = position.x + time * velocity.x;

    //simulate bouncing off the walls

    x = x % (2 * width);

    if (x > width)
    {
        x = (2.0f * width) - x;
    }

    xPosition = x;

    // Return True as target height was reached
    return true;
}
```cs
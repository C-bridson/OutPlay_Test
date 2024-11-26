
goal
predict the position of a ball if and when it arrives at a set height.

using quadratic equations to work out the time it would take to reach the height
the horizontal position can then be determined.

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

    //solve for time with quadratic formula

    float time = (-velocity.y + (Math.Sqrt(Math.Pow(velocity.y, 2) - 4 * acceleration * heightDifference))) / (2 * acceleration);

    //1D kinematics equations

    float x = position.x + time * velocity.x;

    x = x % (2 * width);

    if (x > width)
    {
        x = (2.0f * width) - x;
    }

    xPosition = x;
        return true;
}
```cs
namespace AdventofCode2022.Solvers.HelperClasses;

public class RopeEnd
{
    public Coordinate ActualPosition { get; set; }
    public Coordinate PreviousPosition { get; set; }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'D':
                PreviousPosition = new Coordinate()
                {
                    X = ActualPosition.X,
                    Y = ActualPosition.Y
                };

                ActualPosition.Y -= 1;
                break;
            case 'U':
                PreviousPosition = new Coordinate()
                {
                    X = ActualPosition.X,
                    Y = ActualPosition.Y
                };
                
                ActualPosition.Y += 1;
                break;
            case 'L':
                PreviousPosition = new Coordinate()
                {
                    X = ActualPosition.X,
                    Y = ActualPosition.Y
                };
                
                ActualPosition.X -= 1;
                break;
            case 'R':
                PreviousPosition = new Coordinate()
                {
                    X = ActualPosition.X,
                    Y = ActualPosition.Y
                };
                
                ActualPosition.X += 1;
                break;
        }
    }

    public void UpdateActualPosition(Coordinate c)
    {
        PreviousPosition = new Coordinate()
        {
            X = ActualPosition.X,
            Y = ActualPosition.Y
        };
        ActualPosition.X = c.X;
        ActualPosition.Y = c.Y;
    }
}
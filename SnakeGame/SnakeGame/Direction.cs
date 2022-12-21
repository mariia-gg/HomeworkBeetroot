using System;
using System.Collections.Generic;

namespace SnakeGame;

public class Direction
{
    public static readonly Direction Left = new(0, -1);
    public static readonly Direction Right = new(0, 1);
    public static readonly Direction Up = new(-1, 0);
    public static readonly Direction Down = new(1, 0);

    public int Row { get; set; }

    public int Column { get; set; }

    private Direction(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public Direction Opposite() => new(-Row, -Column);

    public override bool Equals(object obj) =>
        obj is Direction direction && Row == direction.Row && Column == direction.Column;

    public override int GetHashCode() => HashCode.Combine(Row, Column);

    public static bool operator ==(Direction left, Direction right) =>
        EqualityComparer<Direction>.Default.Equals(left, right);

    public static bool operator !=(Direction left, Direction right) => !(left == right);
}
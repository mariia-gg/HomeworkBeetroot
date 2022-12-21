using System;

namespace SnakeGame;

public class Position
{
    public int RowPosition { get; set; }

    public int ColumnPosition { get; set; }

    public Position(int rowPosition, int columnPosition)
    {
        RowPosition = rowPosition;
        ColumnPosition = columnPosition;
    }

    // повертає позицію яку я отримую, переміщаючись на один крок у заданому напрямку 
    public Position GetPosition(Direction dir) =>
        new(RowPosition + dir.Row, ColumnPosition + dir.Column);

    public override bool Equals(object obj) =>
        obj is Position position
        && RowPosition == position.RowPosition
        && ColumnPosition == position.ColumnPosition;

    public override int GetHashCode() => HashCode.Combine(RowPosition, ColumnPosition);

    public static bool operator ==(Position left, Position right) => Equals(left, right);

    public static bool operator !=(Position left, Position right) => !(left == right);
}
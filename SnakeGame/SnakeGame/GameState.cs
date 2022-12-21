using System;
using System.Collections.Generic;

namespace SnakeGame;

public class GameState
{
    private readonly LinkedList<Position> snakePositions = new();

    private readonly Random random = new();
    private readonly LinkedList<Direction> dirChanges = new();

    public int Rows { get; set; }

    public int Columns { get; set; }

    public GridValue[,] Grid { get; set; }

    public Direction Dir { get; set; }

    public int Score { get; private set; }

    public bool GameOver { get; private set; }

    public GameState(int rows, int cols)
    {
        Rows = rows;
        Columns = cols;
        Grid = new GridValue[rows, cols];
        Dir = Direction.Right;

        AddSnake();
        AddFood();
    }

    private void AddSnake()
    {
        var r = Rows / 2;

        for (var i = 1; i <= 3; i++)
        {
            Grid[r, i] = GridValue.Snake;
            snakePositions.AddFirst(new Position(r, i));
        }
    }

    private IEnumerable<Position> EmptyPositions()
    {
        for (var r = 0; r < Rows; r++)
        {
            for (var i = 0; i < Columns; i++)
            {
                if (Grid[r, i] == GridValue.Empty)
                {
                    yield return new Position(r, i);
                }
            }
        }
    }

    private void AddFood()
    {
        var empty = new List<Position>(EmptyPositions());

        if (empty.Count == 0)
        {
            return;
        }

        var pos = empty[random.Next(empty.Count)];
        Grid[pos.RowPosition, pos.ColumnPosition] = GridValue.Food;
    }

    public Position HeadPosition() => snakePositions.First.Value;

    public Position TaiPosition() => snakePositions.First.Value;

    public IEnumerable<Position> SnakePositions() => snakePositions;

    private void AddHead(Position pos)
    {
        snakePositions.AddFirst(pos);
        Grid[pos.RowPosition, pos.ColumnPosition] = GridValue.Snake;
    }

    private void RemoveTail()
    {
        var tail = snakePositions.Last.Value;
        Grid[tail.RowPosition, tail.ColumnPosition] = GridValue.Empty;
        snakePositions.RemoveLast();
    }

    private Direction GetLastDirection()
    {
        if (dirChanges.Count == 0)
        {
            return Dir;
        }

        return dirChanges.Last.Value;
    }

    private bool CanChangeDirection(Direction newDir)
    {
        if (dirChanges.Count == 2)
        {
            return false;
        }

        var lastDir = GetLastDirection();

        return newDir != lastDir && newDir != lastDir.Opposite();
    }

    public void ChangeDirection(Direction dir)
    {
        if (CanChangeDirection(dir))
        {
            dirChanges.AddLast(dir);
        }
    }

    private bool OutsideGrid(Position pos) => pos.RowPosition < 0
        || pos.RowPosition >= Rows
        || pos.ColumnPosition < 0
        || pos.ColumnPosition >= Columns;

    private GridValue WillHit(Position newHeadPos)
    {
        if (OutsideGrid(newHeadPos))
        {
            return GridValue.Outside;
        }

        if (newHeadPos == TaiPosition())
        {
            return GridValue.Empty;
        }

        return Grid[newHeadPos.RowPosition, newHeadPos.ColumnPosition];
    }

    public void Move()
    {
        if (dirChanges.Count > 0)
        {
            Dir = dirChanges.First.Value;
            dirChanges.RemoveFirst();
        }

        var newHeadPos = HeadPosition().GetPosition(Dir);
        var hit = WillHit(newHeadPos);

        if (hit == GridValue.Outside || hit == GridValue.Snake)
        {
            GameOver = true;
        }
        else if (hit == GridValue.Empty)
        {
            RemoveTail();
            AddHead(newHeadPos);
        }

        else if (hit == GridValue.Food)
        {
            AddHead(newHeadPos);
            Score++;
            AddFood();
        }
    }
}
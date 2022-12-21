﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SnakeGame;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Dictionary<GridValue, ImageSource> gridValToImage = new()
    {
        { GridValue.Empty, Images.Empty },
        { GridValue.Snake, Images.Body },
        { GridValue.Food, Images.Food }
    };

    private readonly int rows = 15, cols = 15;
    private readonly Image[,] gridImages;
    private GameState gameState;
    private bool gameRunning;

    public MainWindow()
    {
        InitializeComponent();
        gridImages = SetupGrid();
        gameState = new GameState(rows, cols);
    }

    private async Task RunGame()
    {
        Draw();
        await ShowCountDown();
        Overlay.Visibility = Visibility.Hidden;
        await GameLoop();
        await ShowGameOver();
        gameState = new GameState(rows, cols);
    }

    private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Overlay.Visibility == Visibility.Visible)
        {
            e.Handled = true;
        }

        if (!gameRunning)
        {
            gameRunning = true;
            await RunGame();
            gameRunning = false;
        }
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (gameState.GameOver)
        {
            return;
        }

        switch (e.Key)
        {
            case Key.A:
                gameState.ChangeDirection(Direction.Left);

                break;
            case Key.D:
                gameState.ChangeDirection(Direction.Right);

                break;
            case Key.W:
                gameState.ChangeDirection(Direction.Up);

                break;
            case Key.S:
                gameState.ChangeDirection(Direction.Down);

                break;
        }
    }

    private async Task GameLoop()
    {
        while (!gameState.GameOver)
        {
            await Task.Delay(100);
            gameState.Move();
            Draw();
        }
    }

    private Image[,] SetupGrid()
    {
        var images = new Image[rows, cols];
        GameGrid.Rows = rows;
        GameGrid.Columns = cols;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                var image = new Image
                {
                    Source = Images.Empty
                };

                images[i, j] = image;
                GameGrid.Children.Add(image);
            }
        }

        return images;
    }

    private void Draw()
    {
        DrawGrid();
        ScoreText.Text = $"SCORE {gameState.Score}";
    }

    private void DrawGrid()
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                var gridVal = gameState.Grid[i, j];
                gridImages[i, j].Source = gridValToImage[gridVal];
            }
        }
    }

    private async Task ShowCountDown()
    {
        for (var i = 3; i >= 1; i--)
        {
            OverlayText.Text = i.ToString();
            await Task.Delay(500);
        }
    }

    private async Task ShowGameOver()
    {
        await Task.Delay(1000);
        Overlay.Visibility = Visibility.Visible;
        OverlayText.Text = "PRESS ANY KEY TO START";
    }
}
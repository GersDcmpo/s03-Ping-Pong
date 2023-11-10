using Godot;
using System;

public class LeftWall : Area2D
{
	private int PlayerScore = 0;
	private Label scoreLabel;
	private Label difficultyLabel;

	private Ball ball;

	
	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("PlayerScore");
	   
		difficultyLabel = GetNode<Label>("DifficultyPlayer");
	   
		ball = GetNode<Ball>("../Ball");

		UpdateScoreLabel();
	}

	public void OnWallAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			
			ball.Reset();
			PlayerScore += 5;
			UpdateScoreLabel();

			GD.Print("Player 2 Score: " + PlayerScore);
			   
			if (PlayerScore >= 25 )                                                           
			{
				PlayerScore -= 3;
				difficultyLabel.Text = "Average Difficulty";
			}

			if (PlayerScore >= 40){
				PlayerScore -=1;
				difficultyLabel.Text = "Hard Difficulty";
			}
		}
	}

	private void UpdateScoreLabel()
	{
		if (scoreLabel != null)
		{

			if (PlayerScore >= 0 && PlayerScore < 50 ){
				scoreLabel.Text = "Player 2 Score: " + PlayerScore;
			}
			
			else {
				scoreLabel.Text = "Player 2 Wins " ;
				GetTree().Paused = true;
			}

		}
	}
}

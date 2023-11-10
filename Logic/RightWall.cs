using Godot;

public class RightWall : Area2D
{
	public int EnemyScore = 0;
	private Label scoreLabel;
	private Label difficultyLabel;
	private Ball ball;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("EnemyScore");
		difficultyLabel = GetNode<Label>("DifficultyEnemy");
		ball = GetNode<Ball>("../Ball");
		UpdateScoreLabel();
	}

   public void OnWallAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			EnemyScore += 5;
			ball.Reset();
			UpdateScoreLabel();
			GD.Print("Player 1 Score: " + EnemyScore);
			
			if (EnemyScore >= 25 )
			{
				EnemyScore -= 3;
				difficultyLabel.Text = "Average Difficulty";
			}

			if (EnemyScore >= 40){
				EnemyScore -=1;
				difficultyLabel.Text = "Hard Difficulty";
			}
		}
	}


	private void UpdateScoreLabel()
	{
		if (scoreLabel != null)
		{

			if (EnemyScore >= 0 && EnemyScore < 50 ){
				scoreLabel.Text = "Player 1 Score: " + EnemyScore;
			}
			
			else {
				scoreLabel.Text = "Player 1 Wins " ;
				GetTree().Paused = true;
			}

		}
	}
}

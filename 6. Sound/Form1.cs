using System.Windows.Forms;
using System.Media;

// Simple Pong 6 - Sound

namespace Pong1
{
    public partial class Form1 : Form
    {
        const int WIN = 10;             // How many games it takes to win
        const int INCREASE_SPEED = 1;   // Increase game speed factor
        int playerScore = 0;            // Track player score
        int computerScore = 0;          // Track computer score
        int ComputerPaddleSpeed = 5;        // Set the Computer paddle speed in pixels
        bool GoUp;      // Boolean used to store keyboard up arrow status
        bool GoDown;    // Boolean used to store keyboard down arrow status
        const int PLAYER_PADDLE_SPEED = 8;  // Set the Player paddle speed in pixels
        const int TIME_DELAY = 10;  // How "fast" the game runs
        
        // Used to reinitalize speed after each round
        const int SPEED_X = 2;
        const int SPEED_Y = 2;
        int MoveX = SPEED_X;        // Set horizontal movement/speed of the ball in pixels, based on SPEED_X
        int MoveY = SPEED_Y;        // Set vertical movement/speed of the ball in pixels, based on SPEED_Y

        // Create Soundplayer Objects
        SoundPlayer ballPlay = new SoundPlayer(Properties.Resources.PingPongBallHit);
        SoundPlayer gameOverPlay = new SoundPlayer(Properties.Resources.GameOver);

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Method with boolean (Created) that moves ball while this object/class is running (true)
        public void GameLoop()
        {
            // Infinite "Game Loop"
            while (this.Created)
            {
                MoveBall();                         // Move the ball
                KeepScore();                        // Keep score
                DetectCollision();                  // Detect a collision
                MovePaddle();                       // Move the paddles
                Refresh();                          // Repaint the form
                // Processes all events in the Thread queue so the program animation doesn't stop during refresh
                Application.DoEvents();
                // Pause the foreground or program thread for 10 ms
                System.Threading.Thread.Sleep(TIME_DELAY);
            }
        }
        // Logic to keep score and increase the speed of the game
        private void KeepScore()
        {
            // If the Player missed the ball, computer wins
            if (Ball.Left < 0)
            {
                Ball.Left = ClientSize.Width / 2;    // Move ball to middle of the screen
                MoveX = +MoveX;     // Reverse the ball's direction
                MoveX = MoveX + INCREASE_SPEED;  // Increase speed
                IncreaseMoveY();
                computerScore++;    // Increase computer score
            }

            // If computer missed the ball, player wins
            if (Ball.Left + Ball.Width > ClientSize.Width)
            {
                Ball.Left = ClientSize.Width / 2;    // Move ball to middle of the screen
                MoveX = +MoveX;                      // Reverse the ball's direction
                MoveX = MoveX - INCREASE_SPEED;      // Increase speed
                IncreaseMoveY();   
                playerScore++;      // Increase player score
            }

            // Update the score labels
            lblPlayerScore.Text = "Player: " + playerScore.ToString();
            lblComputerScore.Text = "Computer: " + computerScore.ToString();

            // End the game
            if (playerScore >= WIN)
            {
                gameOverPlay.Play();        // Play a winning sound
                MessageBox.Show("You Won!");
                computerScore = 0;          // Reset the scores for the next round
                playerScore = 0;
                MoveX = SPEED_X;      // Reset speed
                MoveY = SPEED_Y;
            }
            if (computerScore >= WIN)
            {
                gameOverPlay.Play();        // Play a winning sound
                MessageBox.Show("The Computer Won!");
                computerScore = 0;          // Reset the scores for the next round
                playerScore = 0;
                MoveX = SPEED_X;      // Reset speed
                MoveY = SPEED_Y;
            }
        }

        private void IncreaseMoveY()
        {
            if (MoveY < 0)
            {
                MoveY = MoveY - INCREASE_SPEED;  // Increase speed
            }
            else
            {
                MoveY = MoveY + INCREASE_SPEED;  // Increase speed
            }
        }

        // If either paddle collides with the ball, change direction of the ball
        private void DetectCollision()
        {
            // If ball hits the player or computer paddle
            if (Ball.Bounds.IntersectsWith(Player.Bounds) || Ball.Bounds.IntersectsWith(Computer.Bounds))
            {
                MoveX = -MoveX;     // Reverse direction
                ballPlay.Play();    // Play Ping Pong ball strike sound
            }
        }

        // Logic to control the paddle
        private void MovePaddle()
        {
            // Move the computer paddle left or right if the screen is resized
            Computer.Left = ClientSize.Width - (Computer.Width * 2);
           
            // Move the computer paddle up and down
            Computer.Top += ComputerPaddleSpeed;
            
            // If the computer paddle reached top or bottom of screen
            if (Computer.Top < 0 || Computer.Bottom > ClientSize.Height)
            {
                ComputerPaddleSpeed = -ComputerPaddleSpeed; // Change direction of computer paddle
            }
            // If the player has pressed the up arrow and is not at the top of the form
            if (GoUp == true && Player.Top > 0)
            {
                Player.Top -= PLAYER_PADDLE_SPEED;    // Move player paddle up
            }
            // If the player has pressed the down arrow and is not at the bottom of the form
            if (GoDown == true && Player.Bottom < ClientSize.Height)
            {
                Player.Top += PLAYER_PADDLE_SPEED;    // Move player paddle down
            }
        }

        // Logic for pressing a key
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // If player presses up arrow key, change GoUp to true
            if (e.KeyCode == Keys.Up)
            {
                GoUp = true;
            }
            // If player presses down arrow key, change GoDown to true
            if (e.KeyCode == Keys.Down)
            {
                GoDown = true;
            }
        }

        // Logic for releasing a key
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // If player releases up arrow key, change GoUp to false
            if (e.KeyCode == Keys.Up)
            {
                GoUp = false;
            }
            // If player releases down arrow key, change GoDown to false
            if (e.KeyCode == Keys.Down)
            {
                GoDown = false;
            }
        }

        // Logic to move the ball on the playing field
        private void MoveBall()
        {
            Ball.Left = Ball.Left + MoveX;   // Move current Ball Left position by adding X integer
            Ball.Top = Ball.Top + MoveY;   // Move current Ball Top position by adding Y integer

            // If the ball has gone past the left or right edge of the form
            if (Ball.Left < 0 || Ball.Left + Ball.Width > ClientSize.Width)
            {
                MoveX = -MoveX; // Reverse the direction of the ball
            }

            // If the ball has gone past the top or the bottom of the form
            if (Ball.Top < 0 || Ball.Top + Ball.Height > ClientSize.Height)
            {
                MoveY = -MoveY; // Reverse the direction of the ball
            }
        }

    }
}

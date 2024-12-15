using System.Windows.Forms;

// Simple Pong 3 - Keyboard Input

namespace Pong1
{
    public partial class Form1 : Form
    {
        bool GoUp;      // Boolean used to store keyboard up arrow status
        bool GoDown;    // Boolean used to store keyboard down arrow status
        const int PLAYER_PADDLE_SPEED = 8;  // Set the Player paddle speed in pixels
        const int TIME_DELAY = 10;  // How "fast" the game runs
        const int SPEED_X = 2;      // X movement speed constant
        const int SPEED_Y = 2;      // Y movement speed constant
        int MoveX = SPEED_X;        // Set horizontal movement/speed of the ball in pixels, based on SPEED_X
        int MoveY = SPEED_Y;        // Set vertical movement/speed of the ball in pixels, based on SPEED_Y

        public Form1()
        {
            InitializeComponent();
        }

        // Method with boolean (Created) that moves ball while this object/class is running (true)
        public void GameLoop()
        {
            // Main game loop, executes every 10 ms when program starts
            // An infinite "Game Loop" creates constant movement of the ball
            // "this" refers to this current Class (form)
            // "Created" is a boolean. The while loop tests for TRUE if "this" is running
            while (this.Created)
            {
                MoveBall();                         // Move the ball
                MovePaddle();                       // Move the paddles
                Refresh();                          // Repaint the form
                // Processes all events in the Thread queue so the program animation doesn't stop during refresh
                Application.DoEvents();
                // Pause the foreground or program thread for 10 ms
                System.Threading.Thread.Sleep(TIME_DELAY);
            }
        }

        // Logic to control the paddle
        private void MovePaddle()
        {
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
            Ball.Left = Ball.Left + MoveX; // Move current Ball Left position by adding X integer
            Ball.Top = Ball.Top + MoveY;   // Move current Ball Top position by adding Y integer

            // Set boundaries/collision and reverse direction of ball based on dynamic boundaries
            // If we had hard coded the width and height of the form, we couldn't resize the form
            // If the ball has gone past the left or right edge of the formm
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
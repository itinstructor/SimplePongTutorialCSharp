using System.Windows.Forms;

// Simple Pong 1 - Moving Ball

namespace Pong1
{
    public partial class Form1 : Form
    {
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
                MoveBall();                 // Move the ball
                Refresh();                  // Repaint the form
                // Processes all events in the Thread queue so the program animation doesn't stop during refresh
                Application.DoEvents();
                // Pause the foreground/program thread for 10 ms
                System.Threading.Thread.Sleep(TIME_DELAY);
            }
        }

        // Logic to move the ball on the playing field
        private void MoveBall()
        {
            Ball.Left = Ball.Left + MoveX;  // Move current Ball Left position by adding X integer
            Ball.Top = Ball.Top + MoveY;    // Move current Ball Top position by adding Y integer
        }
    }
}

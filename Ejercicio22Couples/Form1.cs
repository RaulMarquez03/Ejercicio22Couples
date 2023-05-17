using System;
using System.Windows.Forms;

namespace Ejercicio22Couples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();

        }
        
                // Use this Random object to choose random icons for the squares
                Random random = new Random();
        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list


        List<string> icons = new List<string>()
                {
"!", "!", "N", "N", "o", "o", "-", "-","x","x","t","t","a","a","j","j","k","k",
"b", "b", "v", "v", "w", "w", "z", "z","s","s","2","2","i","i","e","e","d","d"
                };
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                     iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
               


            }
        }
        // firstClicked points to the first Label control
        // that the player clicks, but it will be null
        // if the player hasn't clicked a label yet
        Label firstClicked = null;
        // secondClicked points to the second Label control
        // that the player clicks
        Label secondClicked = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            
           



        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.GreenYellow)
                    return;
                if (firstClicked == null)
                {
                    
                    firstClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.GreenYellow;
                    return;
                }
                
                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null,
                // so this must be the second icon the player clicked
                // Set its color to black
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.GreenYellow;
                CheckForWinner();

                // If the player clicked two matching icons, keep them
                // black and reset firstClicked and secondClicked
                // so the player can click another icon
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // If the player gets this far, the player
                // clicked two different icons, so start the
                // timer (which will wait three quarters of
                // a second, and then hide the icons)
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Stop the timer
            timer1.Stop();
            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            
                secondClicked.ForeColor = secondClicked.BackColor;
            
            // Reset firstClicked and secondClicked
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            // Go through all of the labels in the TableLayoutPanel,
            // checking each one to see if its icon is matched
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }

        
    }


}
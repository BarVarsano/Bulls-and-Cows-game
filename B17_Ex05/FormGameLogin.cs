namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using BullsAndCows;

    public class FormGameLogin : Form
    {
        private Button m_ButtonStart;
        private Button m_ButtonNumberOfGuesses;
        private int m_NumberOfGuesses;

        public int GetNumberOfGuesses
        {
            get { return m_NumberOfGuesses; }
        }

        public FormGameLogin()
        {
            this.BackColor = default(Color);
            this.Size = new Size(230, 140);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("David", 12, FontStyle.Bold);
            this.Text = "Bulls & Cows - Game Setting";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            m_NumberOfGuesses = LogicManagement<object>.k_MinimumGuesses;

            m_ButtonNumberOfGuesses = new Button();
            m_ButtonNumberOfGuesses.Size = new Size(200, 30);
            m_ButtonNumberOfGuesses.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
            m_ButtonNumberOfGuesses.Text = string.Format("Number Of Guesses : {0}", m_NumberOfGuesses);
            this.Controls.Add(m_ButtonNumberOfGuesses);
            m_ButtonNumberOfGuesses.Click += new EventHandler(m_ButtonNumberOfGuesses_Click);

            m_ButtonStart = new Button();
            m_ButtonStart.Size = new Size(70, 30);
            m_ButtonStart.Location = new Point(m_ButtonNumberOfGuesses.Location.X + 130, m_ButtonNumberOfGuesses.Location.Y + 50);
            m_ButtonStart.Text = "Start";
            this.Controls.Add(m_ButtonStart);
            m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        
        private void m_ButtonNumberOfGuesses_Click(object sender, EventArgs e)
        {
            if ((m_NumberOfGuesses + 1) >= LogicManagement<object>.k_MinimumGuesses && (m_NumberOfGuesses + 1) <= LogicManagement<object>.k_MaximumGuesses)
            {
                m_NumberOfGuesses++;
            }
            else
            {
                MessageBox.Show(
                           string.Format("Note that it is not possible to increase beyond a maximum of {0} guesses.", LogicManagement<object>.k_MaximumGuesses),
                           "Maximum Guesses",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                m_NumberOfGuesses = LogicManagement<object>.k_MinimumGuesses;
            }

            m_ButtonNumberOfGuesses.Text = string.Format("Number Of Guesses : {0}", m_NumberOfGuesses);
        }   
    }
}

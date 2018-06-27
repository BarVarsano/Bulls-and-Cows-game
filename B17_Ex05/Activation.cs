namespace B17_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    public class Activation
    {
        public static void Run()
        {
            DialogResult result = DialogResult.Yes;

            while (result == DialogResult.Yes)
            {
                FormGameLogin formGameSettings = new FormGameLogin();
                result = formGameSettings.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    FormGameBoard formGameBoard = new FormGameBoard(formGameSettings.GetNumberOfGuesses);
                    formGameBoard.ShowDialog();
                    result = formGameBoard.DialogResult;
                }
            }
        }
    }
}
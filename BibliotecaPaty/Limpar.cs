using System;
using System.Windows.Forms;

namespace Biblioteca_da_Patricia.Opcoes
{
    class Limpar
    {
        public static void LimparTODOSTextBox(Control controle)
        {
            //Faz um laço para todos os controles passados no parâmetro
            foreach (Control ctrl in controle.Controls)
            {
                //Se o contorle for um TextBox...
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = String.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).Text = String.Empty;
                }
                else if (ctrl.Controls.Count > 0)
                {
                    LimparTODOSTextBox(ctrl);
                }
            }
        }
    }
}

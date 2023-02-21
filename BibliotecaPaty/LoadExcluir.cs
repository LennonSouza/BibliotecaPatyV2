using Biblioteca_da_Patricia.Opcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaPaty
{
    public class LoadExcluir
    {
        private static BancoDeDados bancoDeDados = new BancoDeDados();

        public static void GetLoad(DataGridView dataGridView1)
        {
            // Adiciona uma coluna para o botão de exclusão
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.Name = "Excluir";
            column.HeaderText = "";
            column.Text = "Excluir";
            column.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(column);
        }

        public static void GetEvent(DataGridView dataGridView1, DataGridViewCellEventArgs e)
        {
            // Verifica se o botão de exclusão foi clicado
            if (e.ColumnIndex == dataGridView1.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                // Obtém o valor da célula correspondente à linha selecionada
                string value = dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

                // Pergunta ao usuário se deseja excluir a linha
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o item \"" + value + "\"?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bancoDeDados.Delete(value);

                    // Exclui a linha correspondente ao botão de exclusão clicado
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}

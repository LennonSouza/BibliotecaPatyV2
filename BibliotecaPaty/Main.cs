using Biblioteca_da_Patricia.Opcoes;
using System.Data;
using System.Drawing.Printing;

namespace BibliotecaPaty
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        private BancoDeDados bancoDeDados = new BancoDeDados();
        public Main()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            Carregar();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadExcluir.GetLoad(dataGridView1);

            // Manipula o evento de clique do botão de exclusão
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadExcluir.GetEvent(dataGridView1, e);
        }

        public void Carregar()
        {
            DataTable dataTable = bancoDeDados.GetAll();

            dataGridView1.DataSource = dataTable;
        }

        private void PrintTable(object sender, PrintPageEventArgs e)
        {
            // Remove a coluna de exclusão, se ela existir
            if (dataGridView1.Columns.Count > 0)
            {
                if (dataGridView1.Columns.Count > 7)
                {
                    if (dataGridView1.Columns[7] is DataGridViewButtonColumn)
                    {
                        dataGridView1.Columns.Remove(dataGridView1.Columns[7]);
                    }
                }
            }

            // Define as margens do documento
            int margin = 40;
            int y = margin;

            // Define o tamanho da tabela
            int tableWidth = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                tableWidth += column.Width;
            }

            // Define o ponto de partida para desenhar cada coluna
            Point[] columnPositions = new Point[dataGridView1.Columns.Count];
            columnPositions[0] = new Point(margin, y);
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {

                columnPositions[i] = new Point(columnPositions[i - 1].X + dataGridView1.Columns[i - 1].Width, y);
                if (i == 1) // adiciona espaço extra para a segunda coluna
                {
                    columnPositions[i].X += 40;
                }
                if (i == 2) // adiciona espaço extra para a quinta coluna
                {
                    columnPositions[i].X += 40;
                }
                if (i == 4) // adiciona espaço extra para a quinta coluna
                {
                    columnPositions[i].X += 70;
                }
                if (i == 5) // adiciona espaço extra para a quinta coluna
                {
                    columnPositions[i].X -= 40;
                }
                if (i == 6) // adiciona espaço extra para a quinta coluna
                {
                    columnPositions[i].X -= 60;
                }

            }

            // Define a fonte em negrito para o cabeçalho da tabela
            Font headerFont = new Font(dataGridView1.Font, FontStyle.Bold);

            // Desenha o cabeçalho da tabela
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {

                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, headerFont, Brushes.Black, columnPositions[i]);

            }

            // Define a fonte padrão para o conteúdo da tabela
            Font cellFont = new Font(dataGridView1.Font, FontStyle.Regular);

            // Desenha as linhas da tabela
            y += 20;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    DataGridViewCell cell = row.Cells[i];
                    string text = cell.FormattedValue.ToString();
                    if (text == "True") text = "Sim"; else if (text == "False") text = "Não";
                    e.Graphics.DrawString(text, cellFont, Brushes.Black, columnPositions[i].X, y);

                }
                y += 20;
            }

            // Define a altura da tabela
            int tableHeight = dataGridView1.Rows.Count * 20 + 40;

            // Define o tamanho da página e da tabela
            e.PageSettings.PaperSize = new PaperSize("A4", 827, tableHeight + margin * 2);
            e.PageSettings.Landscape = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Cria um novo documento de impressão
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintTable);

            DialogResult result = MessageBox.Show("Deseja visualizar antes de imprimir?", "Visualização", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Cria e exibe o diálogo de visualização da impressão
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pd;
                printPreviewDialog.ShowDialog();

                // Fecha o diálogo de visualização
                printPreviewDialog.Close();
            }

            // Reabre o diálogo de impressão
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Atualiza o objeto PrintDocument com as configurações da impressora selecionada
                pd.PrinterSettings = printDialog.PrinterSettings;

                // Imprime o documento
                pd.Print();
            }
        }

        private void cb_adicionar_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_adicionar.Checked == true)
            {
                this.Hide();
                Adicionar add = new Adicionar();
                add.ShowDialog();
                this.Show();

                cb_adicionar.Checked = false;
                Carregar();
            }
        }

        private void cb_atualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_atualizar.Checked == true)
            {
                this.Hide();
                Atualizar att = new Atualizar();
                att.ShowDialog();
                this.Show();

                cb_atualizar.Checked = false;
                Carregar();
            }
        }
    }
}
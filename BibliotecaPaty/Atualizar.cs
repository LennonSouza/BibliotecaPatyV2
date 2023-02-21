using BibliotecaPaty;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca_da_Patricia.Opcoes
{
    public partial class Atualizar : MetroFramework.Forms.MetroForm
    {
        private BancoDeDados bancoDeDados = new BancoDeDados();

        public Atualizar()
        {
            InitializeComponent();
            label1.Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            Carregar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            bancoDeDados.Atualizar(txtnome.Text, txtautor.Text.Trim(), cbgenero.Text.Trim(), cbsubgenero.Text.Trim(), txtpratileira.Text.ToUpper(), txtano.Text, cblido.Checked);

            Limpar.LimparTODOSTextBox(this);
            Carregar();
        }

        private void Atualizar_Load(object sender, EventArgs e)
        {
            LoadExcluir.GetLoad(dataGridView1);

            // Manipula o evento de clique do botão de exclusão
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void cbgenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbgenero.SelectedIndex == 0 || cbgenero.SelectedIndex == 1 || cbgenero.SelectedIndex == 2 || cbgenero.SelectedIndex == 3)
            {
                cbsubgenero.Visible = true;
                lblsubgenero.Visible = true;
            }

            if (cbgenero.SelectedItem.ToString() == "Ficção")
            {
                string a = cbgenero.SelectedItem.ToString();
                cbsubgenero.Items.Clear();

                if (a == "Ficção")
                {
                    cbsubgenero.Items.Add("Aventura");
                    cbsubgenero.Items.Add("Chick-Lit");
                    cbsubgenero.Items.Add("Clássico");
                    cbsubgenero.Items.Add("Contos");
                    cbsubgenero.Items.Add("Contos de Fada");
                    cbsubgenero.Items.Add("Crônicas");
                    cbsubgenero.Items.Add("Erótica");
                    cbsubgenero.Items.Add("Fantasia");
                    cbsubgenero.Items.Add("Infanto-Juvenil");
                    cbsubgenero.Items.Add("Jovem Adulto (YA)");
                    cbsubgenero.Items.Add("Lad Lit");
                    cbsubgenero.Items.Add("Literatura Nacional");
                    cbsubgenero.Items.Add("Literatura Cristã");
                    cbsubgenero.Items.Add("Livros de Colorir");
                    cbsubgenero.Items.Add("Mistério");
                    cbsubgenero.Items.Add("New Adult");
                    cbsubgenero.Items.Add("Paranormal");
                    cbsubgenero.Items.Add("Poesia");
                    cbsubgenero.Items.Add("Quadrinhos");
                    cbsubgenero.Items.Add("Realismo Fantástico");
                    cbsubgenero.Items.Add("Romance Contemporâneo");
                    cbsubgenero.Items.Add("Romance de Banca");
                    cbsubgenero.Items.Add("Romance Epistolar");
                    cbsubgenero.Items.Add("Romance Gay");
                    cbsubgenero.Items.Add("Romance Gótico");
                    cbsubgenero.Items.Add("Romance Histórico");
                    cbsubgenero.Items.Add("Romance Policial");
                    cbsubgenero.Items.Add("Romance Psicológico");
                    cbsubgenero.Items.Add("Ficção Cientifica");
                    cbsubgenero.Items.Add("Sobrenatural");
                    cbsubgenero.Items.Add("Suspense");
                    cbsubgenero.Items.Add("Suspense Romântico");
                    cbsubgenero.Items.Add("Terror");
                    cbsubgenero.Items.Add("Thriller");
                    cbsubgenero.Items.Add("Thriller Médico");
                    cbsubgenero.Items.Add("Urban Fantasy");
                }
            }
            else if (cbgenero.SelectedItem.ToString() == "Não Ficção")
            {
                string a = cbgenero.SelectedItem.ToString();
                cbsubgenero.Items.Clear();

                if (a == "Não Ficção")
                {
                    cbsubgenero.Items.Add("Almanaque");
                    cbsubgenero.Items.Add("Artigo científico");
                    cbsubgenero.Items.Add("Auto-Ajuda");
                    cbsubgenero.Items.Add("Carta");
                    cbsubgenero.Items.Add("Crítica literária");
                    cbsubgenero.Items.Add("Diagrama");
                    cbsubgenero.Items.Add("Diário");
                    cbsubgenero.Items.Add("Dicionário");
                    cbsubgenero.Items.Add("Documentário");
                    cbsubgenero.Items.Add("Enciclopédia");
                    cbsubgenero.Items.Add("Ensaio");
                    cbsubgenero.Items.Add("Filosofia");
                    cbsubgenero.Items.Add("Fotografia");
                    cbsubgenero.Items.Add("História");
                    cbsubgenero.Items.Add("História natural");
                    cbsubgenero.Items.Add("Jornal");
                    cbsubgenero.Items.Add("Jornalismo");
                    cbsubgenero.Items.Add("Memórias");
                    cbsubgenero.Items.Add("Idiomas");
                    cbsubgenero.Items.Add("Catálogos ");
                    cbsubgenero.Items.Add("Manuais");
                }
            }
            else if (cbgenero.SelectedItem.ToString() == "Biografia")
            {
                string a = cbgenero.SelectedItem.ToString();
                cbsubgenero.Items.Clear();

                if (a == "Biografia")
                {
                    cbsubgenero.Items.Add("Auto biografia");
                    cbsubgenero.Items.Add("Biografia Autorizada");
                    cbsubgenero.Items.Add("Biografia Não  Autorizada");
                }
            }
            else if (cbgenero.SelectedItem.ToString() == "Técnico")
            {
                string a = cbgenero.SelectedItem.ToString();
                cbsubgenero.Items.Clear();

                if (a == "Técnico")
                {
                    cbsubgenero.Items.Add("Ciências sociais aplicadas");
                    cbsubgenero.Items.Add("Ciências Humanas");
                    cbsubgenero.Items.Add("Guias");
                    cbsubgenero.Items.Add("Manuais técnicos");
                    cbsubgenero.Items.Add("Culinária");
                }
            }
        }

        private void Atualizar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Main att = new Main();
            att.ShowDialog();
            this.Show();
        }

        public void Carregar()
        {
            cbgenero.Items.Add("Ficção");
            cbgenero.Items.Add("Não Ficção");
            cbgenero.Items.Add("Biografia");
            cbgenero.Items.Add("Técnico");

            DataTable dataTable = bancoDeDados.GetAll();

            dataGridView1.DataSource = dataTable;

            txtnome.MaxLength = 30;
            txtautor.MaxLength = 25;
            txtpratileira.MaxLength = 2;
            txtano.MaxLength = 4;

            cbsubgenero.Visible = false;

            if (dataTable.Rows.Count == 0)
            {
                txtano.Enabled = false;
                txtautor.Enabled = false;
                txtnome.Enabled = false;
                txtpratileira.Enabled = false;
                cbgenero.Enabled = false;
                cblido.Enabled = false;
                btnAtualizar.Enabled= false;

                label1.Visible = true;
            }
        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtnome.Text))
            {
                SQLiteDataAdapter sqliteDataAdapter = bancoDeDados.AtualizarTextChanged(txtnome.Text);
                DataTable tabela = new DataTable();

                sqliteDataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                if (tabela.Rows.Count > 0)
                {
                    txtautor.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    cbgenero.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    cbsubgenero.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtpratileira.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtano.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    cblido.Checked = (bool)this.dataGridView1.CurrentRow.Cells[6].Value;

                    if (!string.IsNullOrWhiteSpace(cbgenero.Text)) cbsubgenero.Visible = true;
                }
                else
                {
                    txtautor.Text = "";
                    cbgenero.Text = "";
                    cbsubgenero.Text = "";
                    txtpratileira.Text = "";
                    txtano.Text = "";
                    cblido.Checked = false;
                    cbsubgenero.Visible = false;
                }
            }
            else
            {
                Carregar();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadExcluir.GetEvent(dataGridView1, e);
        }
    }
}

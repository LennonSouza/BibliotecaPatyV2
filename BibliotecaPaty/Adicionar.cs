using BibliotecaPaty;
using System;
using System.Data;
using System.Windows.Forms;

namespace Biblioteca_da_Patricia.Opcoes
{
    public partial class Adicionar : MetroFramework.Forms.MetroForm
    {
        private BancoDeDados bancoDeDados = new BancoDeDados();

        public Adicionar()
        {
            InitializeComponent();
            this.ActiveControl = txtnome;
            txtnome.Focus();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            lbl_contador.Text = bancoDeDados.Contador().ToString();
            Carregar();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtnome.Text) &&
                !string.IsNullOrWhiteSpace(txtautor.Text) &&
                !string.IsNullOrWhiteSpace(cbgenero.Text) &&
                !string.IsNullOrWhiteSpace(cbsubgenero.Text) &&
                !string.IsNullOrWhiteSpace(txtpratileira.Text) &&
                !string.IsNullOrWhiteSpace(txtano.Text) && txtano.Text.Length == 4)
            {
                txtnome.Text = txtnome.Text.Trim().ToLower();
                bool existe = bancoDeDados.VerificacaoNome(txtnome.Text);
                if (!existe) bancoDeDados.Add(txtnome.Text, txtautor.Text.Trim(), cbgenero.Text.Trim(), cbsubgenero.Text.Trim(), txtpratileira.Text.ToUpper(), txtano.Text, cblido.Checked);

                Limpar.LimparTODOSTextBox(this);
                Carregar();
            }
            else
            {
                MessageBox.Show("Você digitou algo incorreto, tente novemente!\n", "Erro ao adicionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Adicionar_Load(object sender, EventArgs e)
        {
            cbgenero.Items.Add("Ficção");
            cbgenero.Items.Add("Não Ficção");
            cbgenero.Items.Add("Biografia");
            cbgenero.Items.Add("Técnico");

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
                    cbsubgenero.Items.Add("Biografia Não Autorizada");
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

        public void Carregar()
        {
            DataTable dataTable = bancoDeDados.GetAll();
            lbl_contador.Text = bancoDeDados.Contador().ToString();

            dataGridView1.DataSource = dataTable;

            txtnome.MaxLength = 25;
            txtautor.MaxLength = 17;
            txtpratileira.MaxLength = 2;
            txtano.MaxLength = 4;

            cbsubgenero.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadExcluir.GetEvent(dataGridView1, e);
        }
    }
}

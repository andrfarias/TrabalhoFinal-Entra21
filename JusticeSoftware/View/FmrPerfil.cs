using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrPerfil : Form
    {
        public static string caminho = System.Environment.CurrentDirectory;
        public static string caminhoFoto = caminho + @"\foto\";
        public string origemCompleto = "";
        public string pastaDestino = caminhoFoto;
        public string foto = "";
        public string destinoCompleto = "";
        public FmrPerfil()
        {
            InitializeComponent();
        }

        ComandosBD comandos = new ComandosBD();
        Classes.DadosGeral dadosGeral = new Classes.DadosGeral();
        private void FmrPerfil_Load(object sender, EventArgs e)
        {
            pbxFoto.ImageLocation = destinoCompleto;
        }
        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                origemCompleto = openFileDialog1.FileName; //pegando caminho completo do arquivo
                foto = openFileDialog1.SafeFileName; //pegando nome do arquivo
                destinoCompleto = pastaDestino + foto;
            }
            if (destinoCompleto != "") //se tiver imagem selecionada
            {
                System.IO.File.Copy(origemCompleto, destinoCompleto, true); //faz uma copia da imagem para a pasta
                if (File.Exists(destinoCompleto)) //verifica se foi copiado
                {
                    pbxFoto.ImageLocation = destinoCompleto;
                }
            }
            ComandosBD inserir = new ComandosBD();
            inserir.InserirIndividual("Advogado", "Foto", destinoCompleto);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        private void btnCalculoRapido_Click(object sender, EventArgs e)
        {
            var FmrCalcRap = new FmrCalcRap();
            this.Hide();
            FmrCalcRap.Show();
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            var FmrCadastroCliente = new FmrCadastroCliente();
            this.Hide();
            FmrCadastroCliente.Show();
        }

        private void btnCadastrarAuxiliar_Click(object sender, EventArgs e)
        {
            var FmrCadastroAuxiliar = new FmrCadastroAuxiliar();
            this.Hide();
            FmrCadastroAuxiliar.Show();
        }

        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            var FmrFichaCliente = new FmrFichaCliente();
            this.Hide();
            FmrFichaCliente.Show();
        }

        private void FmrPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade indisponível");
        }
    }
}
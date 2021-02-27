using System;
using System.Windows.Forms;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrLogin : Form
    {
        public static string OAB;
        //CONSTRUTOR
        public FmrLogin()
        {
            InitializeComponent();
        }

        //MANTÉM IMAGEM REGULADA
        private void FmrLogin_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;

        }

        //FECHAR O FORMULÁRIO 
        private void FmrLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        //LEVAR AO FORMULÁRIO DE RECUPERAÇÃO DE SENHA
        private void lbl_RecuperarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var FmrRecupSenha = new FmrRecupSenha();
            this.Hide();
            FmrRecupSenha.Show();
        }

        //LEVAR AO FORMULÁRIO DE CADASTRO DO ADVOGADO
        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            var FmrCadastroAdvg = new FmrCadastroAdvg();
            this.Hide();
            FmrCadastroAdvg.Show();
        }

        //MOSTRAR E OCULTAR A SENHA DO USUÁRIO
        private void bnt_RevelaSenha_Click(object sender, EventArgs e)
        {
            if (txt_SenhaUsuario.PasswordChar == '*')
            {
                txt_SenhaUsuario.PasswordChar = '\0';
            }
            else
            {
                txt_SenhaUsuario.PasswordChar = '*';
            }
        }

        ComandosBD BancoDados = new ComandosBD();
        Classes.DadosGeral dadosGeral = new Classes.DadosGeral();
        public static string email;

        //VERIFICAR INFORMAÇÕES INSERIDAS NO BD E ACESSAR O PERFIL
        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            var FmrPerfil = new FmrPerfil();
            if(txt_SenhaUsuario.Text == "")
            {
                MessageBox.Show("Por favor, insira seus dados corretamente");
            }
            else if (BancoDados.Conferir("Email", "Advogado", txt_EmailUsuario.Text, "Senha", txt_SenhaUsuario.Text) > 0)
            {
                var FmrLogin = new FmrLogin();
                email = txt_EmailUsuario.Text;
                this.Hide();
                FmrPerfil.lbCargo.Text = "Advogado";
                FmrPerfil.lbEmail.Text = email;
                OAB = BancoDados.Conferir(email);
                FmrPerfil.Show();
            }
            else if (BancoDados.Conferir("Email", "Assistente", txt_EmailUsuario.Text, "Senha", txt_SenhaUsuario.Text) > 0)
            {
                email = txt_EmailUsuario.Text;
                this.Hide();
                FmrPerfil.lbCargo.Text = "Assistente";
                FmrPerfil.lbEmail.Text = email;
                FmrPerfil.Show();
            }
            else if (BancoDados.Conferir("Email", "Estagiario", txt_EmailUsuario.Text, "Senha", txt_SenhaUsuario.Text) > 0)
            {
                email = txt_EmailUsuario.Text;
                this.Hide();
                FmrPerfil.lbCargo.Text = "Estagiario";
                FmrPerfil.lbEmail.Text = email;
                FmrPerfil.Show();
            }
            else
            {
                MessageBox.Show("Não foi possível encontrar seu usuário, verifique os dados inseridos.");
            }
        }

        private void but_Insta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/justicesoftware/");
        }
        private void but_Face_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/justicesoftware21");
        }

        private void but_LinkedIn_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/company/justicesoftware/");
        }
    }
}

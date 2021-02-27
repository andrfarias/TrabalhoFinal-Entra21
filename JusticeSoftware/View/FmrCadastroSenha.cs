using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Diagnostics;
using System.Text.RegularExpressions;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrCadastroSenha : Form
    {
        //INSTANCIAMENTO PARA BD
        ComandosBD BancoDados = new ComandosBD();

        //DECLARAÇÃO DO VETOR COM OS DADOS DO ADVOGADO
        string[] advDados;

        //DECLARAÇÕES
        string PermissaoSenha = "";
        int codigo;
        private MailMessage Email;

        //CONSTRUTOR #1
        public FmrCadastroSenha()
        {
            InitializeComponent();
        }

        //CONSTRUTOR #2
        public FmrCadastroSenha(string[] DadosDoAdvogado)
        {
            advDados = DadosDoAdvogado;

            InitializeComponent();
        }

        //MANTÉM IMAGEM AJUSTADA
        private void FmrCadastroSenha_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            advDados[8] = "000000";
        }

        //PARA VOLTAR A PRIMEIRA PARTE DO CADASTRO
        private void btn_VoltarCadastro_Click(object sender, EventArgs e)
        {
            var FmrCadastroAdvg = new FmrCadastroAdvg(advDados);
            var FmrCadastroSenha = new FmrCadastroSenha();
            FmrCadastroSenha.Hide();
            FmrCadastroAdvg.Show();
        }

        //FECHAR O FORMULÁRIO
        private void FmrCadastroSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        //MOSTRAR E OCULTAR A SENHA DO USUÁRIO
        private void bnt_RevelaSenha_Click(object sender, EventArgs e)
        {
            if (txt_SenhaVerifica.PasswordChar == '*')
            {
                txt_SenhaVerifica.PasswordChar = '\0';
            }
            else
            {
                txt_SenhaVerifica.PasswordChar = '*';
            }
        }

        //VERIFICAÇÃO DE FORÇA DE SENHA
        private void txt_SenhaVerifica_KeyDown(object sender, KeyEventArgs e)
        {
            FuncoesAuxiliares verifica = new FuncoesAuxiliares();
            FuncoesAuxiliares.ForcaDaSenha forca;
            forca = verifica.GetForcaDaSenha(txt_SenhaVerifica.Text);
            lbl_ForcaSenha.Text = forca.ToString();

            if (lbl_ForcaSenha.Text == "Ruim" | lbl_ForcaSenha.Text == "Fraca")
            {
                lbl_ForcaSenha.ForeColor = Color.Red;
                PermissaoSenha = "Não";
            }
            else if (lbl_ForcaSenha.Text == "Regular")
            {
                lbl_ForcaSenha.ForeColor = Color.AliceBlue;
                PermissaoSenha = "Não";
            }
            else
            {
                lbl_ForcaSenha.ForeColor = Color.Green;
                PermissaoSenha = "Sim";
            }
        }

        //VERIFICAR CÓDIGO VIA E-MAIL
        private void btn_EnviarVerificacao_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            codigo = ran.Next(1000, 10000);

            TextBox[] preenchimentoVerifica = new TextBox[3];
            for (int i = 0; i < preenchimentoVerifica.Length; i++)
            {
                preenchimentoVerifica[i] = new TextBox();
            }

            preenchimentoVerifica[0] = txt_EmailVerifica;
            preenchimentoVerifica[1] = txt_SenhaVerifica;
            preenchimentoVerifica[2] = txt_ConfirmaSenhaVerifica;

            if (PermissaoSenha == "Não" || txt_SenhaVerifica.TextLength < 6)
            {
                txt_SenhaVerifica.Text = "";
                MessageBox.Show("Tente uma senha mais forte, com no mínimo 6 dígitos.");
            }

            int contador = 0;

            for (int i = 0; i < preenchimentoVerifica.Length; i++)
            {
                if (preenchimentoVerifica[i].Text == "")
                {
                    preenchimentoVerifica[i].BackColor = Color.PeachPuff;
                }
                else
                {
                    preenchimentoVerifica[i].BackColor = Color.LightGreen;
                    contador++;
                }
            }
                if (contador == preenchimentoVerifica.Length)
                {
                    try
                    {
                    advDados[1] = txt_EmailVerifica.Text;
                    advDados[8] = txt_SenhaVerifica.Text;

                    Email = new MailMessage();
                        Email.To.Add(new MailAddress(txt_EmailVerifica.Text));
                        Email.From = new MailAddress("tccentra@gmail.com");
                        Email.Subject = "Seu código de verificação - Justice";
                        Email.Body = "Seu código de verificação é " + codigo;
                        SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                        using (cliente)
                        {
                            cliente.Credentials = new System.Net.NetworkCredential("tccentra@gmail.com", "Entra@21TCC");
                            cliente.EnableSsl = true;
                            cliente.Send(Email);
                        }
                        MessageBox.Show("Enviado");
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Houve algum problema com o envio de e-mail. Verifique seus dados.");
                    }
                }
        }

        //CONFIRMAR CAÓDIGO/CADASTRO
        private void btn_ConfirmarVerifica_Click(object sender, EventArgs e)
        {
            if (txt_CodigoVerifica.Text == codigo.ToString())
            {

                if (BancoDados.Inserir(advDados, "Advogado"))
                {
                    MessageBox.Show("Senha criada com sucesso");   
                    var FmrLogin = new FmrLogin();
                    this.Hide();
                    FmrLogin.Show();
                }
                else
                {
                    MessageBox.Show("Código não reconhecido.");
                }
            }
            else
            {
                MessageBox.Show("Código não reconhecido.");
            }
        }
    }
}

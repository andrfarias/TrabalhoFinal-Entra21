using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrRecupSenha : Form
    {
        string email = "";

        //DECLARAÇÕES
        private MailMessage Email;

        //CONSTRUTOR
        public FmrRecupSenha()
        {
            InitializeComponent();
        }

        //MANTÉM IMAGEM AJUSTADA
        private void FmrRecupSenha_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        
        //FECHAR O FORMULÁRIO
        private void FmrRecupSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        //VOLTAR AO LOGIN
        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        //ENVIAR E-MAIL COM SENHA DO USUÁRIO
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            bool verifica = false;

            if (txt_EmailUsuario.Text == "")
            {
                txt_EmailUsuario.BackColor = Color.LightCoral;
            }
            else
            {
                txt_EmailUsuario.BackColor = Color.LightGreen;

                try
                {
                    Email = new MailMessage();
                    Email.To.Add(new MailAddress(txt_EmailUsuario.Text));
                    Email.From = new MailAddress("tccentra@gmail.com");
                    Email.Subject = "Sua senha - Justice";
                    
                    ComandosBD BancoDados = new ComandosBD();

                    if (BancoDados.Conferir("Email", txt_EmailUsuario.Text, "Advogado") == 1 && BancoDados.Conferir("Senha", txt_EmailUsuario.Text, "Advogado") == 1)
                    {
                        verifica = true;

                    }
                    else if (BancoDados.Conferir("Email", txt_EmailUsuario.Text, "Assistente") == 1 && BancoDados.Conferir("Senha", txt_EmailUsuario.Text, "Assistente") == 1)
                    {
                        verifica = true;
                    }
                    else if (BancoDados.Conferir("Email", txt_EmailUsuario.Text, "Estagiario") == 1 && BancoDados.Conferir("Senha", txt_EmailUsuario.Text, "Estagiario") == 1)
                    {
                        verifica = true;
                    }

                    if (verifica == true)
                    {
                        Email.Body = "Sua senha é:";
                        SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                        using (cliente)
                        {
                            cliente.Credentials = new System.Net.NetworkCredential("tccentra@gmail.com", "Entra@21TCC");
                            cliente.EnableSsl = true;
                            cliente.Send(Email);
                        }
                        MessageBox.Show("Enviado");

                        var FmrLogin = new FmrLogin();
                        var FmrRecupSenha = new FmrRecupSenha();
                        FmrRecupSenha.Hide();
                        FmrLogin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Houve algum problema com o envio de e-mail. Verifique seus dados.");
                    } 
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Nossos servidores estão em manutenção no momento. Tente mais tarde.");
                }
            }
        }
    }
}

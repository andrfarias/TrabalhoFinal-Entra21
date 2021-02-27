using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrCadastroAuxiliar : Form
    {
        //INSTANCIAMENTO DA CLASSE ADVOGADO
       
        string[] auxiliar = new string[12];

        //CONSTRUTOR
        public FmrCadastroAuxiliar()
        {
            InitializeComponent();
        }

        //MANTÉM IMAGEM AJUSTADA
        private void FmrCadastroAuxiliar_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        //VOLTAR AO PERFIL
        private void btn_VoltarCadastro_Click(object sender, EventArgs e)
        {
            var FmrPerfil = new FmrPerfil();
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrPerfil.lbCargo.Text = "Advogado";
            FmrPerfil.lbEmail.Text = FmrLogin.email;
            FmrPerfil.Show();
        }

        //FECHAR O FORMULÁRIO
        private void FmrCadastroAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            var FmrPerfil = new FmrPerfil();
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrPerfil.lbCargo.Text = "Advogado";
            FmrPerfil.lbEmail.Text = FmrLogin.email;
            FmrPerfil.Show();
        }

        //DEFINIR QUAIS CAMPOS DEVERÃO APENAS RECEBER NÚMEROS
        private void txt_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //DEFINIR QUAIS CAMPOS APENAS PODEM RECEBER LETRAS
        private void txt_NomeCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //PUXA INFORMAÇÕES PARA OUTROS TEXTBOX VIA CEP
        private void txt_CEP_Leave(object sender, EventArgs e)
        {
            FuncoesAuxiliares funcoes = new FuncoesAuxiliares();

            funcoes.LocalizarCEP(txt_CEP, txt_Logradouro, txt_Bairro, txt_Cidade, txt_Estado);
        }

        //ABRE AS PASTAS DO COMPUTADOR PARA CARREGAR UMA FOTO
        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            txt_Foto.Text = openFileDialog1.FileName;
        }

        //VERIFICA PREENCHIMENTO DE CAMPOS OBRIGATÓRIOS/ENVIA DADOS AO BD
        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            TextBox[] camposObrigatorios = new TextBox[11];
            for (int i = 0; i < camposObrigatorios.Length; i++)
            {
                camposObrigatorios[i] = new TextBox();
            }

            //PREENCHIMENTO DO VETOR COM OS TEXTBOX DO CADASTRO
            {
                FuncoesAuxiliares funcoes = new FuncoesAuxiliares();
                camposObrigatorios[0] = txt_NomeCompleto;
                if (funcoes.VerificaCPF(txt_CPF.Text) == false)
                {
                    txt_CPF.Text = "";
                }
                camposObrigatorios[1] = txt_CPF;
                camposObrigatorios[2] = txt_RG;
                camposObrigatorios[3] = txt_CEP;
                camposObrigatorios[4] = txt_Cidade;
                camposObrigatorios[5] = txt_Estado;
                camposObrigatorios[6] = txt_Bairro;
                camposObrigatorios[7] = txt_Logradouro;
                camposObrigatorios[8] = txt_SenhaVerifica;
                camposObrigatorios[9] = txt_ConfirmaSenhaVerifica;
                camposObrigatorios[10] = txt_EmailVerifica;
            }

            int contador = 0;
            for (int i = 0; i < camposObrigatorios.Length; i++)
            {
                if (camposObrigatorios[i].Text == "")
                {
                    camposObrigatorios[i].BackColor = Color.PeachPuff;
                }
                else
                {
                    contador++;
                }

                if (cmb_TipodeAcesso.SelectedItem == null)
                {
                    contador--;
                }

                if (contador == camposObrigatorios.Length)
                {
                    auxiliar[1] = txt_CPF.Text;
                    auxiliar[2] = txt_RG.Text;
                    auxiliar[3] = txt_CEP.Text;
                    auxiliar[4] = txt_Cidade.Text;
                    auxiliar[5] = txt_Estado.Text;
                    auxiliar[6] = txt_Bairro.Text;
                    auxiliar[7] = txt_Logradouro.Text;
                    auxiliar[8] = txt_SenhaVerifica.Text;
                    auxiliar[9] = txt_EmailVerifica.Text;
                    auxiliar[10] = txt_Foto.Text;
                    auxiliar[11] = dtp_DataNascimento.Value.ToShortDateString();

                    ComandosBD BancoDados = new ComandosBD();

                    if (BancoDados.Inserir(auxiliar, cmb_TipodeAcesso.SelectedItem.ToString()) == true)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso"); ;

                        Form f1 = FindForm();
                        FmrPerfil f2 = new FmrPerfil();
                        f1.Close();
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Verifique seus dados, cadastro não executado.");

                    }
                }
                else
                {
                    MessageBox.Show("Falha no cadastro, verifique os dados.");
                }
            }
        }
    }
}
        


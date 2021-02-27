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
    public partial class FmrCadastroCliente : Form
    {
        string[] cliente = new string[18];
        ComandosBD BancoDados = new ComandosBD();
        Classes.DadosGeral dadosGeral = new Classes.DadosGeral();

        //CONSTRUTOR
        public FmrCadastroCliente()
        {
            InitializeComponent();
        }

        //MANTÉM IMAGEM AJUSTADA
        private void FmrCadastroCliente_Load(object sender, EventArgs e)
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
        
        //FECHAR O PROGRAMA
        private void FmrCadastroCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            var FmrPerfil = new FmrPerfil();
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrPerfil.lbCargo.Text = "Advogado";
            FmrPerfil.lbEmail.Text = FmrLogin.email;
            FmrPerfil.Show();
        }

        //DEFINIR CAMPOS QUE APENAS PODEM RECEBEM NÚMEROS
        private void txt_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //DEFINIR CAMPOS QUE APENAS PODEM RECEBER LETRAS
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

        //ABRE AS PASTAS DO COMPUTADOR PARA SEECIONAR UMA FOTO
        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            txt_Foto.Text = openFileDialog1.FileName;
        }

        //VERIFICA PREENCHIMENTO DE CAMPOS OBRIGATÓRIOS/ENVIA DADOS AO BD
        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            TextBox[] camposObrigatorios = new TextBox[8];
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
            }
            if (contador == camposObrigatorios.Length)
            {
                cliente[0] = txt_NomeCompleto.Text;
                cliente[1] = "";
                cliente[2] = "";
                cliente[3] = txt_CPF.Text;
                cliente[4] = txt_RG.Text;
                cliente[5] = dtp_DataNascimento.Value.ToShortDateString();
                cliente[6] = "";
                cliente[7] = "";
                cliente[8] = "";
                cliente[9] = "";
                cliente[10] = "";
                cliente[11] = "";
                cliente[12] = txt_Foto.Text;
                cliente[13] = FmrLogin.OAB;
                cliente[14] = txt_Cidade.Text;
                cliente[15] = txt_Estado.Text;
                cliente[16] = txt_Bairro.Text;
                cliente[17] = txt_Logradouro.Text;
                                
                if (BancoDados.Inserir(cliente, "Cliente") == true)
                {
                    MessageBox.Show("Cadastro realizado com sucesso");
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

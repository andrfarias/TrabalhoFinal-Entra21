using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrCadastroAdvg : Form
    {
        //DECLARAÇÃO DO VETOR COM OS DADOS DO ADVOGADO
        string[] dadosDoAdvogado = new string[26];

        //CONSTRUTOR #1
        public FmrCadastroAdvg()
        {
            InitializeComponent();
        }

        //CONSTRUTOR - RECEBE OBJETO ADVOGADO PARA RECARREGAR INFORMAÇÕES EM (Frm_CadastroSenha >>> Fmr_Cadastro) #2
        public FmrCadastroAdvg (String[] DadosDoAdv)
        {
            dadosDoAdvogado = DadosDoAdv;
            InitializeComponent();
        }

        //MANTÉM IMAGEM AJUSTADA | MANTÉM INFORMAÇÕES PARA (Frm_CadastroSenha >>> Fmr_Cadastro)
        private void FmrCadastroAdvg_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;

            //PARA CASO (Frm_CadastroSenha >>> Fmr_Cadastro), AS INFORMAÇÕES NÃO SEREM PERDIDAS
            {
                txt_NomeCompleto.Text = dadosDoAdvogado[0];
                //email[1]
                txt_AdvogadoNumOAB.Text = dadosDoAdvogado[2];
                txt_CPF.Text = dadosDoAdvogado[3];
                txt_RG.Text = dadosDoAdvogado[4];
                txt_CNPJ.Text = dadosDoAdvogado[6];
                txt_Foto.Text = dadosDoAdvogado[7];
                //senha[8]
                txt_CEP.Text = dadosDoAdvogado[9];
                txt_Cidade.Text = dadosDoAdvogado[10];
                txt_Estado.Text = dadosDoAdvogado[11];
                txt_Bairro.Text = dadosDoAdvogado[12];
                txt_Logradouro.Text = dadosDoAdvogado[13];
                txt_NumeroCartao1.Text = dadosDoAdvogado[14];
                txt_NumeroCartao2.Text = dadosDoAdvogado[15];
                txt_NumeroCartao3.Text = dadosDoAdvogado[16];
                txt_NumeroCartao4.Text = dadosDoAdvogado[17];
                txt_CodigoSeguranca.Text = dadosDoAdvogado[18];
                txt_CEPComercial.Text = dadosDoAdvogado[19];
                txt_LogradouroEmpresa.Text = dadosDoAdvogado[20];
                txt_NumeroEndComercial.Text = dadosDoAdvogado[21];
                txt_NumeroEndComercial.Text = dadosDoAdvogado[22];
                txt_ComplementoEndComercial.Text = dadosDoAdvogado[23];
                txt_EmpresaNumOAB.Text = dadosDoAdvogado[24];
                
                if (dadosDoAdvogado[8] == "000000")
                {
                    dtp_DataNascimento.Value = Convert.ToDateTime(dadosDoAdvogado[5]);
                    dtp_ValidadeCartao.Value = Convert.ToDateTime(dadosDoAdvogado[25]);
                }
            }
        }

        //VOLTAR AO LOGIN
        private void btn_VoltarCadastro_Click(object sender, EventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        //FECHAR O FORMULÁRIO
        private void FmrCadastroAdvg_FormClosing(object sender, FormClosingEventArgs e)
        {
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrLogin.Show();
        }

        //DEFINIR QUAIS CAMPOS DO CADASTRO APENAS RECEBE NÚMEROS
        private void txt_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //PUXAR INFORMAÇÕES AUTOMÁTICAS PELA EDIÇÃO DA CAIXA DE CEP
        private void txt_CEP_Leave(object sender, EventArgs e)
        {
            FuncoesAuxiliares funcoes = new FuncoesAuxiliares();

            funcoes.LocalizarCEP(txt_CEP, txt_Logradouro, txt_Bairro, txt_Cidade, txt_Estado);
        }

        //PUXAR INFORMAÇÕES AUTOMÁTICAS PELA EDIÇÃO DA CAIXA DE CEP COMERCIAL
        private void txt_CEPComercial_Leave(object sender, EventArgs e)
        {
            FuncoesAuxiliares funcoes = new FuncoesAuxiliares();
            funcoes.LocalizarCEP(txt_CEPComercial, txt_LogradouroEmpresa, txt_ComplementoEndComercial);
        }

        //ABRE AS PASTAS DO COMPUTADOR PARA CARREGAR UMA FOTO
        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            txt_Foto.Text = openFileDialog1.FileName;
        }

        //MOSTRA CAIXAS DE PREENCHIMENTO DE DADOS EMPRESA
        private void chk_EmpresaSim_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_EmpresaSim.Checked == true)
            {
                chk_EmpresaNao.Checked = false;

                lbl_TituloDadosEmpresa.Visible = true;

                lbl_CEPComercial.Visible = true;
                txt_CEPComercial.Visible = true;

                lbl_NumeroEndComercial.Visible = true;
                txt_NumeroEndComercial.Visible = true;

                lbl_ComplementoEndComercial.Visible = true;
                txt_ComplementoEndComercial.Visible = true;

                lbl_EmpresaNumOAB.Visible = true;
                txt_EmpresaNumOAB.Visible = true;

                lbl_CNPJ.Visible = true;
                txt_CNPJ.Visible = true;

                lbl_LogradouroEmpresa.Visible = true;
                txt_LogradouroEmpresa.Visible = true;
            }
        }

        //OCULTA CAIXAS DE PREENCHIMENTO DE DADOS DA EMPRESA
        private void chk_EmpresaNao_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_EmpresaNao.Checked == true)
            {
                chk_EmpresaSim.Checked = false;

                lbl_TituloDadosEmpresa.Visible = false;

                lbl_LogradouroEmpresa.Visible = false;
                txt_LogradouroEmpresa.Visible = false;

                lbl_CEPComercial.Visible = false;
                txt_CEPComercial.Visible = false;

                lbl_NumeroEndComercial.Visible = false;
                txt_NumeroEndComercial.Visible = false;

                lbl_ComplementoEndComercial.Visible = false;
                txt_ComplementoEndComercial.Visible = false;

                lbl_EmpresaNumOAB.Visible = false;
                txt_EmpresaNumOAB.Visible = false;

                lbl_CNPJ.Visible = false;
                txt_CNPJ.Visible = false;
            }
        }

        //SALVA AS ALTERAÇÕES NAS CAIXAS PREENCHIDAS
        private void txt_NomeCompleto_KeyDown(object sender, KeyEventArgs e)
        {
            DateTimePicker VerificaMudancaCartao = dtp_ValidadeCartao;
            DateTimePicker VerificaMudancaNascimento = dtp_DataNascimento;

            dadosDoAdvogado[0] = txt_NomeCompleto.Text;
            //email[1]
            dadosDoAdvogado[2] = txt_AdvogadoNumOAB.Text;
            dadosDoAdvogado[3] = txt_CPF.Text;
            dadosDoAdvogado[4] = txt_RG.Text;
            dadosDoAdvogado[6] = txt_CNPJ.Text;
            dadosDoAdvogado[7] = txt_Foto.Text;
            //senha[8]

            dadosDoAdvogado[9]= txt_CEP.Text;
            dadosDoAdvogado[10] = txt_Cidade.Text;
            dadosDoAdvogado[11] = txt_Estado.Text;
            dadosDoAdvogado[12] = txt_Bairro.Text;
            dadosDoAdvogado[13] = txt_Logradouro.Text;
            
            dadosDoAdvogado[14] = txt_NumeroCartao1.Text;
            dadosDoAdvogado[15] = txt_NumeroCartao2.Text;
            dadosDoAdvogado[16] = txt_NumeroCartao3.Text;
            dadosDoAdvogado[17] = txt_NumeroCartao4.Text;
            dadosDoAdvogado[18] = txt_CodigoSeguranca.Text;

            //CAIXA DE EMPRESA NÃO VERIFICADA == FALSE
            if (chk_EmpresaNao.Checked == false)
            {
                dadosDoAdvogado[19] = txt_CEPComercial.Text;
                dadosDoAdvogado[20] = txt_LogradouroEmpresa.Text;
                dadosDoAdvogado[21] = txt_NumeroEndComercial.Text;
                dadosDoAdvogado[22] = "";
                dadosDoAdvogado[23] = txt_ComplementoEndComercial.Text;
                dadosDoAdvogado[24] = txt_EmpresaNumOAB.Text;
            }
            else
            {
                dadosDoAdvogado[19] = "";
                dadosDoAdvogado[20] = "";
                dadosDoAdvogado[21] = "";
                dadosDoAdvogado[22] = "";
                dadosDoAdvogado[23] = "";
            }
           
            
            dadosDoAdvogado[25] = dtp_ValidadeCartao.Value.ToShortDateString();
            dadosDoAdvogado[5] = dtp_DataNascimento.Value.ToShortDateString();

            if (dtp_ValidadeCartao.Value != VerificaMudancaCartao.Value)
            {
                dadosDoAdvogado[25] = dtp_ValidadeCartao.Value.ToShortDateString();
            }
            if (dtp_DataNascimento.Value != VerificaMudancaNascimento.Value)
            {
                dadosDoAdvogado[5] = dtp_DataNascimento.Value.ToShortDateString();
            }
        }

        //VERIFICA PREENCHIMENTO DE CAMPOS OBRIGATÓRIOS
        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            int valorVetor;

            if (chk_EmpresaSim.Checked == true)
            {
                valorVetor = 19;
            }
            else
            {
                valorVetor = 14;
            }

            TextBox[] camposObrigatorios = new TextBox[valorVetor];
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
                camposObrigatorios[3] = txt_AdvogadoNumOAB;
                camposObrigatorios[4] = txt_CEP;
                camposObrigatorios[5] = txt_Cidade;
                camposObrigatorios[6] = txt_Estado;
                camposObrigatorios[7] = txt_Bairro;
                camposObrigatorios[8] = txt_Logradouro;
                if (txt_NumeroCartao1.TextLength < 4)
                {
                    txt_NumeroCartao1.Text = "";
                }
                camposObrigatorios[9] = txt_NumeroCartao1;
                if(txt_NumeroCartao2.TextLength < 4)
                {
                    txt_NumeroCartao2.Text = "";
                }
                camposObrigatorios[10] = txt_NumeroCartao2;
                if (txt_NumeroCartao3.TextLength < 4)
                {
                    txt_NumeroCartao3.Text = "";
                }
                camposObrigatorios[11] = txt_NumeroCartao3;
                if (txt_NumeroCartao4.TextLength < 4)
                {
                    txt_NumeroCartao4.Text = "";
                }
                camposObrigatorios[12] = txt_NumeroCartao4;
                if (txt_CodigoSeguranca.TextLength < 3)
                {
                    txt_CodigoSeguranca.Text = "";
                }
                camposObrigatorios[13] = txt_CodigoSeguranca;
                if (chk_EmpresaSim.Checked == true)
                {
                    camposObrigatorios[14] = txt_CEPComercial;
                    camposObrigatorios[15] = txt_LogradouroEmpresa;
                    camposObrigatorios[16] = txt_NumeroEndComercial;
                    camposObrigatorios[17] = txt_EmpresaNumOAB;
                    if (funcoes.VerificaCNPJ(txt_CNPJ.Text) == false)
                    {
                        txt_CNPJ.Text = "";
                    }
                    camposObrigatorios[18] = txt_CNPJ;
                }
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

                if (contador == camposObrigatorios.Length)
                {
                    dadosDoAdvogado[5] = dtp_DataNascimento.Value.ToShortDateString();
                    dadosDoAdvogado[25] = dtp_ValidadeCartao.Value.ToShortDateString();
                    MessageBox.Show("Cadastro realizado com sucesso");
                    Form f1 = FindForm();
                    FmrCadastroSenha f2 = new FmrCadastroSenha(dadosDoAdvogado);
                    f1.Hide();
                    f2.Show();
                }
            }
        }

        //DEFINE CAMPOS QUE APENAS RECEBEM LETRAS
        private void txt_NomeCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lbl_DadosEmpresaTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Localidade_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TituloAdvogado_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TituloDadosEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TituloDadosPagamento_Click(object sender, EventArgs e)
        {

        }
    }
}

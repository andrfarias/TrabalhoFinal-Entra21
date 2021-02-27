using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public class FuncoesAuxiliares
    {
        //CONSTRUTOR
        public FuncoesAuxiliares()
        {
        }

        //COMPLEMENTAR TEXTBOX'S POR CEP
        public void LocalizarCEP(TextBox CEP, TextBox Logradouro, TextBox Bairro, TextBox Cidade, TextBox Estado)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + CEP.Text + "/json/");
                request.AllowAutoRedirect = false;
                HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

                if (ChecaServidor.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Servidor indisponível");
                    return;
                }

                using (Stream webStream = ChecaServidor.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            response = Regex.Replace(response, "[{},]", string.Empty);
                            response = response.Replace("\"", "");

                            String[] substrings = response.Split('\n');

                            int cont = 0;
                            foreach (var substring in substrings)
                            {
                                if (cont == 1)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    if (valor[0] == "erro")
                                    {
                                        MessageBox.Show("CEP não encontrado");
                                        CEP.Focus();
                                        return;
                                    }
                                }

                                //LOGRADOURO
                                if (cont == 2)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    Logradouro.Text = TiraEspaco(valor[1]);
                                }

                                //BAIRRO
                                if (cont == 4)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    Bairro.Text = TiraEspaco(valor[1]);
                                }

                                //CIDADE
                                if (cont == 5)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    Cidade.Text = TiraEspaco(valor[1]);
                                }

                                //ESTADO
                                if (cont == 6)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    Estado.Text = TiraEspaco(valor[1]);
                                }
                                cont++;
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("CEP não encontrado.");
            }
        }

        //SOBRECARGA - COMPLEMENTAR TEXTBOX'S POR CEP COMERCIAL
        public void LocalizarCEP(TextBox CEP, TextBox Logradouro, TextBox Complemento)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + CEP.Text + "/json/");
                request.AllowAutoRedirect = false;
                HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

                if (ChecaServidor.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Servidor indisponível");
                    return;
                }

                using (Stream webStream = ChecaServidor.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            response = Regex.Replace(response, "[{},]", string.Empty);
                            response = response.Replace("\"", "");

                            String[] substrings = response.Split('\n');

                            int cont = 0;
                            foreach (var substring in substrings)
                            {
                                if (cont == 1)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    if (valor[0] == "  erro")
                                    {
                                        MessageBox.Show("CEP não encontrado");
                                        CEP.Focus();
                                        return;
                                    }
                                }

                                //LOGRADOURO
                                if (cont == 2)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    Logradouro.Text = TiraEspaco(valor[1]);
                                }

                                //COMPLEMENTO
                                if (cont == 3)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    Complemento.Text = TiraEspaco(valor[1]);

                                    if (valor[1] == "")
                                    {
                                        Complemento.Text = "-";
                                    }
                                }

                                cont++;
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("CEP não encontrado.");
            }
        }

        //TIRAR ESPAÇO DAS INFORMAÇÕES PUXADAS PELO VIACEP
        public string TiraEspaco(string palavra)
        {
            char[] vetorPalavra = new char[palavra.Length];

            for (int i = 1; i < vetorPalavra.Length; i++)
            {
                vetorPalavra[i - 1] = palavra[i];
            }
            for (int i = 0; i < vetorPalavra.Length - 1; i++)
            {
                if (i == 0)
                {
                    palavra = Convert.ToString(vetorPalavra[i]);
                }
                else
                {
                    palavra += Convert.ToString(vetorPalavra[i]);
                }
            }
            return palavra;
        }

        //VERIFICAR DE CPF
        public bool VerificaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        //VERIFICAR DE  CNPJ
        public bool VerificaCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        //FORÇA DA SENHA
        public enum ForcaDaSenha
        {
            Ruim,
            Fraca,
            Regular,
            Boa,
            Forte,
        }

        //DEFINE FORÇA DA SENHA
        public int GeraPontosSenha(string senha)
        {
            if (senha == null) return 0;
            int pontosPorTamanho = GetPontoPorTamanho(senha);
            int pontosPorMinusculas = GetPontoPorMinusculas(senha);
            int pontosPorMaiusculas = GetPontoPorMaiusculas(senha);
            int pontosPorDigitos = GetPontoPorDigitos(senha);
            int pontosPorSimbolos = GetPontoPorSimbolos(senha);
            int pontosPorRepeticao = GetPontoPorRepeticao(senha);
            return pontosPorTamanho + pontosPorMinusculas + pontosPorMaiusculas + pontosPorDigitos + pontosPorSimbolos - pontosPorRepeticao;
        }

        //AVALIAR O TAMANHO DA SENHA
        private int GetPontoPorTamanho(string senha)
        {
            return Math.Min(10, senha.Length) * 6;
        }

        //AVALIAR O USO DE LETRAS MINÚSCULAS
        private int GetPontoPorMinusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        //AVALIAR O USO DE LETRAS MAIÚSCULAS
        private int GetPontoPorMaiusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        //AVALIAR O USO DE NÚMEROS
        private int GetPontoPorDigitos(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        //AVALIAR O USO DE SÍBOLOS
        private int GetPontoPorSimbolos(string senha)
        {
            int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        //AVALIAR O USO DE REPETIÇÃO DE CARACTERES
        private int GetPontoPorRepeticao(string senha)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
            bool repete = regex.IsMatch(senha);
            if (repete)
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

        //GERAR OS PONTOS DA SENHA
        public ForcaDaSenha GetForcaDaSenha(string senha)
        {
            int placar = GeraPontosSenha(senha);

            if (placar < 10)
                return ForcaDaSenha.Ruim;
            else if (placar < 30)
                return ForcaDaSenha.Fraca;
            else if (placar < 40)
                return ForcaDaSenha.Regular;
            else if (placar < 50)
                return ForcaDaSenha.Boa;
            else
                return ForcaDaSenha.Forte;
        }
    }
}

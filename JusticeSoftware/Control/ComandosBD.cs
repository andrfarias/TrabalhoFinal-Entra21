using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JusticeSoftware.Classes
{
    class ComandosBD 
    {
        SqlConnection conecta = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emanuela\Desktop\JusticeVersaoFinal\JusticeSoftware\JusticeSoftware\Model\BancoDeDados.mdf;Integrated Security=True");
        SqlCommand CMD;
        public string[] elementos { get; set; }
        public int contagem { get; set; }

        public string retorno { get; set; }
        public bool Inserir(string[] Elementos, string tabela)
        {
            if (tabela == "Advogado")
            {
               elementos = Elementos;
              
                    var insert = $"INSERT into Advogado (Nome , Email, OAB, CPF, RG, DataDeNasc, CNPJ, Foto, Senha, CEPpessoal, Cidade, Estado, Bairro, Logradouro, NumCartao1, NumCartao2, NumCartao3, NumCartao4, CodSeguranca, CEPcomercial, LogradouroCom, NumComercial,NumPessoal, ComplementoComercial, OABempresa, ValCartao) values ('{elementos[0]}','{elementos[1]}','{elementos[2]}','{elementos[3]}','{elementos[4]}','{elementos[5]}','{elementos[6]}','{elementos[7]}','{elementos[8]}','{elementos[9]}','{elementos[10]}','{elementos[11]}','{elementos[12]}','{elementos[13]}','{elementos[14]}','{elementos[15]}','{elementos[16]}','{elementos[17]}','{elementos[18]}','{elementos[19]}','{elementos[20]}','{elementos[21]}','{elementos[22]}','{elementos[23]}','{elementos[24]}','{elementos[25]}')";

                    CMD = new SqlCommand(insert, conecta);
                    conecta.Open();
                    CMD.ExecuteNonQuery();
                    conecta.Close();
              
            }
            else if (tabela == "Assistente")
            {
                elementos = Elementos;
                
                    var insert = $"INSERT into Assistente (Nome , OABvinc, CPF, RG, DataNasc, Foto, Senha, Logradouro, CEP, Cidade, Estado, Bairro, Email) values ('{elementos[0]}','{elementos[1]}','{elementos[2]}','{elementos[3]}','{elementos[4]}','{elementos[5]}','{elementos[6]}','{elementos[7]}','{elementos[8]}','{elementos[9]}','{elementos[10]}','{elementos[11]}')";

                    CMD = new SqlCommand(insert, conecta);
                    conecta.Open();
                    CMD.ExecuteNonQuery();
                    conecta.Close();
                

            }
            else if(tabela == "Cliente" )
            {
                elementos = Elementos;
                
                    var insert = $"INSERT into Cliente (Nome, Email, NumProcesso, CPF, RG, DataDeNasc, InicioPena, FimPena, ProgAberto, ProgSemi, QtdePena, Observacoes, Foto, OABvinculada, Cidade, Estado, Bairro, Logradouro) values ('{elementos[0]}','{elementos[1]}','{elementos[2]}','{elementos[3]}','{elementos[4]}','{elementos[5]}','{elementos[6]}','{elementos[7]}','{elementos[8]}','{elementos[9]}','{elementos[10]}','{elementos[11]}','{elementos[12]}','{elementos[13]}','{elementos[14]}', '{elementos[15]}','{elementos[16]}', '{elementos[17]}')";

                    CMD = new SqlCommand(insert, conecta);
                    conecta.Open();
                    CMD.ExecuteNonQuery();
                    conecta.Close();
                

            }
            else if (tabela == "Estagiario")
            {
                elementos = Elementos;
                
                    var insert = $"INSERT into Estagiario (Nome , OABvinc, CPF, RG, DataNasc, Foto, Senha, Logradouro, CEP, Cidade, Estado, Bairro, Email) values ('{elementos[0]}','{elementos[1]}','{elementos[2]}','{elementos[3]}','{elementos[4]}','{elementos[5]}','{elementos[6]}','{elementos[7]}','{elementos[8]}','{elementos[9]}','{elementos[10]}','{elementos[11]}')";

                CMD = new SqlCommand(insert, conecta);
                    conecta.Open();
                    CMD.ExecuteNonQuery();
                    conecta.Close();
                

            }
            return true;
        }
        public bool InserirIndividual(string tabela, string coluna, string dadosEntrada)
        {
            string inserirInd = $"INSERT into {tabela} ({coluna}) values ('{dadosEntrada}')";
            CMD = new SqlCommand(inserirInd, conecta);
            conecta.Open();
            CMD.ExecuteNonQuery();
            conecta.Close();
            return true;
        }
        public bool Deletar(string tabela, string coluna, string dadosEntrada)
        {
            string delete = $"DELETE from {tabela} WHERE {coluna} = '{dadosEntrada}'";
            CMD = new SqlCommand(delete, conecta);
            conecta.Open();
            CMD.ExecuteNonQuery();
            conecta.Close();
            return true;
        }
        public bool Alterar(string tabela , string colunaAlterada , string alteracao, string coluna , string dadosProcura)
            // colunaAlterada = Informação para ser aletarda.
            //dadosProcura =  dado usado para busca ex: cpf e numero de processo
            //aletracao = Informação nova a ser colocada na tabela
            //colunaProcura = coluna usada como base para procurar o cliente
        {
            string alterar = $"UPDATE {tabela} Set {colunaAlterada} = '{alteracao}' WHERE {coluna} = '{dadosProcura}'";
            CMD = new SqlCommand(alterar, conecta);

            conecta.Open();
            CMD.ExecuteNonQuery();
            conecta.Close();
            return true;
        }
        public int Conferir(string coluna, string tabela , string dadosEntrada)
        {
            SqlDataReader dr;
            var consulta = $"SELECT {coluna} from {tabela} WHERE {coluna} ='{dadosEntrada}'";
            CMD = new SqlCommand(consulta, conecta);
            conecta.Open();
            dr = CMD.ExecuteReader();

            while (dr.Read())
            {
              contagem++;
            }
            conecta.Close();
            dr.Close();

            return contagem;
            // se o valor da variavel contagem retornar maior que 0, significa que o dado pesquisado já existe no banco de dados.
        }
        public int Conferir(string coluna, string tabela, string valorColuna1, string coluna2, string valorColuna2)
        {
            SqlDataReader dr;
            var consulta = $"SELECT {coluna} from {tabela} WHERE {coluna} = '{valorColuna1}' AND {coluna2} = '{valorColuna2}'";
            CMD = new SqlCommand(consulta, conecta);
            conecta.Open();
            dr = CMD.ExecuteReader();

            while (dr.Read())
            {
                contagem++;
            }
            conecta.Close();
            dr.Close();

            return contagem;
            // se o valor da variavel contagem retornar maior que 0, significa que o dado pesquisado já existe no banco de dados.
        }
        public string Conferir(string email)
        {
            SqlDataReader dr;
            var consulta = $"SELECT OAB from Advogado WHERE Email = '{email}'";
            CMD = new SqlCommand(consulta, conecta);
            conecta.Open();
            dr = CMD.ExecuteReader();
            string oab = "";

            while (dr.Read())
            {
                oab = dr[0].ToString();
            }
            conecta.Close();
            dr.Close();

            return oab;
            // se o valor da variavel contagem retornar maior que 0, significa que o dado pesquisado já existe no banco de dados.
        }

        public string Selecionar(string tabela, string coluna, string info)
        {
            SqlDataReader dr;
            string selecionar = $"SELECT {coluna} FROM {tabela} WHERE {coluna} = '{info}'";
            CMD = new SqlCommand(selecionar, conecta);
            conecta.Open();
            dr = CMD.ExecuteReader();
            while (dr.Read())
            {
                retorno = (string)dr[coluna];
            }

            conecta.Close();
            dr.Close();
            return retorno;
        }
        public List<DadosCliente> Carregar(string oab)
        {
            SqlDataReader dr;
            string selecionar = $"SELECT * FROM Cliente WHERE (OABvinculada = '{oab}')";
            CMD = new SqlCommand(selecionar, conecta);
            conecta.Open();
            dr = CMD.ExecuteReader();

            List<DadosCliente> temp = new List<DadosCliente>();

            while (dr.Read())
            {
                Classes.DadosCliente dadostemp = new Classes.DadosCliente();
                dadostemp.nomeCompleto = dr["Nome"].ToString();
                dadostemp.email = dr["Email"].ToString();
                dadostemp.NrProcesso = dr["NumProcesso"].ToString();
                dadostemp.cpf = dr["CPF"].ToString();
                dadostemp.rg = dr["RG"].ToString();
                dadostemp.dataNascimento = dr["DataDeNasc"].ToString();
                dadostemp.dtInicio = dr["InicioPena"].ToString();
                dadostemp.dtFinal = dr["FimPena"].ToString();
                dadostemp.dtInicioSemi = dr["ProgSemi"].ToString();
                dadostemp.dtInicioAberto = dr["ProgAberto"].ToString();
                dadostemp.diasPena = dr["QtdePena"].ToString();

                temp.Add(dadostemp);

            }

            conecta.Close();
            dr.Close();
            return temp;
        }

    }
}


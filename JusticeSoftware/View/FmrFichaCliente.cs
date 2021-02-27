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
using iTextSharp.text;
using iTextSharp.text.pdf;
using JusticeSoftware.Classes;

namespace JusticeSoftware
{
    public partial class FmrFichaCliente : Form
    {
        public string OAB;
        public FmrFichaCliente()
        {
            InitializeComponent();
        }

        private void FmrFichaCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bancoDeDadosDataSet1.Cliente'. Você pode movê-la ou removê-la conforme necessário.

            BackgroundImageLayout = ImageLayout.Stretch;

            ComandosBD bd = new ComandosBD();
            var FmrLogin = new FmrLogin();
            OAB = FmrLogin.OAB;
            List<DadosCliente> datagrid = bd.Carregar(OAB);
            foreach (var item in datagrid)
            {
                dataGridView1.Rows.Add(new string[] { item.nomeCompleto, item.NrProcesso, item.diasPena, item.dtInicio, item.dtInicioSemi, item.dtInicioAberto, item.dtFinal});

            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            string caminho = @"C:\Users\Public\Documents " + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("RELATÓRIO\n\n");
            doc.Add(titulo);

            string nome = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string numProcesso = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string qtdPena = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string iniPena = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string progSemi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string progAberto = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string fimPena = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string obs = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();


            Paragraph paragrafo = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12));
            //string conteudo = string.Format("Nome: {0}\nNúmero de processo: {1} \nCrime: {2}", nome, numProcess, crime);
            string conteudo = string.Format("Nome: {0}\nNúmero de processo: {1} \nQuantidade da pena: {2} dias\nInício da pena: {3} \nProgressão ao semiaberto: {4} \nProgressão ao aberto: {5} \nFim da pena: {6} \nObservações: {7} ", nome, numProcesso, qtdPena, iniPena, progSemi, progAberto, fimPena, obs);
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            doc.Close();
            System.Diagnostics.Process.Start(caminho);

        }
        public static string NrProc = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[7].Selected)
            {
                var FmrCalcRelatorio = new FmrCalcRelatorio();
                NrProc = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Hide();
                FmrCalcRelatorio.Show();
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[8].Selected)
            {
                Document doc = new Document(PageSize.A4);
                doc.SetMargins(40, 40, 40, 80);
                string caminho = @"C:\Users\Public\Documents " + "relatorio.pdf";

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

                doc.Open();

                Paragraph titulo = new Paragraph();
                titulo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.Add("RELATÓRIO\n\n");
                doc.Add(titulo);

                string nome = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string numProcesso = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string qtdPena = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string iniPena = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string progSemi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string progAberto = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                string fimPena = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();



                Paragraph paragrafo = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12));
                //string conteudo = string.Format("Nome: {0}\nNúmero de processo: {1} \nCrime: {2}", nome, numProcess, crime);
                string conteudo = string.Format("Nome: {0}\nNúmero de processo: {1} \nQuantidade da pena: {2} dias\nInício da pena: {3} \nProgressão ao semiaberto: {4} \nProgressão ao aberto: {5} \nFim da pena: {6} \n", nome, numProcesso, qtdPena, iniPena, progSemi, progAberto, fimPena);
                paragrafo.Add(conteudo);
                doc.Add(paragrafo);

                doc.Close();
                System.Diagnostics.Process.Start(caminho);
            }    
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            var FmrPerfil = new FmrPerfil();
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrPerfil.lbCargo.Text = "Advogado";
            FmrPerfil.lbEmail.Text = FmrLogin.email;
            FmrPerfil.Show();
        }
    }
}

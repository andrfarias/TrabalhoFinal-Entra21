using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JusticeSoftware
{
    public partial class FmrCalcRap : Form
    {
        public FmrCalcRap()
        {
            InitializeComponent();
        }

        private void FmrCalcRap_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AnosInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MesesInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DiasInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DTPickerInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DiasRemicao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbOrgCr_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOrgCr.Checked)
            {
                cbHediondo.Hide();
                cbViloento.Hide();
                cbPeqDelito.Hide();
            }
            else
            {
                cbHediondo.Show();
                cbViloento.Show();
                cbPeqDelito.Show();
            }
        }

        private void cbHediondo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHediondo.Checked)
            {
                cbOrgCr.Hide();
                cbViloento.Hide();
                cbPeqDelito.Hide();
                cbHomicidio.Show();
            }
            else
            {
                cbOrgCr.Show();
                cbViloento.Show();
                cbPeqDelito.Show();
                cbHomicidio.Hide();
            }
        }

        private void cbViloento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbViloento.Checked)
            {
                cbOrgCr.Hide();
                cbHediondo.Hide();
                cbPeqDelito.Hide();
            }
            else
            {
                cbOrgCr.Show();
                cbHediondo.Show();
                cbPeqDelito.Show();
            }
        }

        private void cbPeqDelito_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPeqDelito.Checked)
            {
                cbOrgCr.Hide();
                cbHediondo.Hide();
                cbViloento.Hide();
            }
            else
            {
                cbOrgCr.Show();
                cbHediondo.Show();
                cbViloento.Show();
            }
        }

        private void cbHomicidio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbReincidente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btCalc_Click(object sender, EventArgs e)
        {
            //           -- METODOLOGIA PARA CÁLCULO --
            // DTINICIO = DATA DE ESCOLHIDA, ACRESCENTASSE OS ANOS,
            // OS MESES E OS DIAS CHEGANDO ASSIM AO ÚLTIMO DIA DE PENA.
            // APÓS ISSO É CÁLCULADO VIA TIMESPAN A DIFERENÇA DE DIAS ENTRE AS
            // DATAS E A PARTIR DESTA QUANTIADE DE DIAS SÃO FEITOS OS CÁLCULOS
            // PARA DETERMINAR OS PERÍDOS DO REGIME. 

            if (cbOrgCr.Checked == false && cbHediondo.Checked == false
                && cbViloento.Checked == false && cbPeqDelito.Checked == false)
            {
                MessageBox.Show("VOCÊ DEVE SELECIONAR UM AGRAVANTE");
            }
            else
            {
                int anosPena = Convert.ToInt32(AnosInput.Value);
                int mesesPena = Convert.ToInt32(MesesInput.Value);
                int diasPena = Convert.ToInt32(DiasInput.Value);
                int diasRemição = Convert.ToInt32(DiasRemicao.Value);
                var dtInicio = new DateTime();
                var dtFinal = new DateTime();
                var dtFinalFechado = new DateTime();
                var dtInicioSemi = new DateTime();
                var dtFinalSemi = new DateTime();
                var dtInicioAberto = new DateTime();
                dtInicio = DTPickerInicio.Value;
                dtFinal = dtInicio.AddYears(anosPena);
                dtFinal = dtFinal.AddMonths(mesesPena);
                dtFinal = dtFinal.AddDays(diasPena);
                TimeSpan prisao = dtFinal - dtInicio;
                int diasPrisao = Convert.ToInt32(prisao.TotalDays);
                int totalDias = diasPrisao;

                double diasFechado = 0;
                double diasSemi = 0;
                double diasAberto = 0;
                if (cbReincidente.Checked) // É REINCIDENTE
                {
                    if (cbOrgCr.Checked) // ORG CRIMINOSA - 50%
                    {
                        diasFechado = Math.Round((diasPrisao * .5), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .5, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                    if (cbHediondo.Checked) // HEDIONDO - 70% OU 40%
                    {
                        if (cbHomicidio.Checked)
                        {
                            diasFechado = Math.Round((diasPrisao * .7), MidpointRounding.AwayFromZero);
                            diasSemi = Math.Round((diasPrisao - diasFechado) * .7, MidpointRounding.AwayFromZero);
                            diasAberto = (totalDias - diasFechado - diasSemi);
                        }
                        else
                        {
                            diasFechado = Math.Round((diasPrisao * .4), MidpointRounding.AwayFromZero);
                            diasSemi = Math.Round((diasPrisao - diasFechado) * .4, MidpointRounding.AwayFromZero);
                            diasAberto = (totalDias - diasFechado - diasSemi);
                        }
                    }
                    if (cbViloento.Checked) // VIOLENTE - 30% 
                    {
                        diasFechado = Math.Round((diasPrisao * .3), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .3, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                    if (cbPeqDelito.Checked) // PEQUENO DELITO - 20% 
                    {
                        diasFechado = Math.Round((diasPrisao * .2), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .2, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                } // É REINCIDENTE
                else // NÃO É REINCIDENTE
                {
                    if (cbOrgCr.Checked) // ORG CRIMINOSA - 50%
                    {
                        diasFechado = Math.Round((diasPrisao * .5), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .5, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                    if (cbHediondo.Checked) // HEDIONDO - 40%
                    {
                        diasFechado = Math.Round((diasPrisao * .4), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .4, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                    if (cbViloento.Checked) // VIOLENTO - 25%
                    {
                        diasFechado = Math.Round((diasPrisao * .25), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .25, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                    if (cbPeqDelito.Checked) // VIOLENTO - 16%
                    {
                        diasFechado = Math.Round((diasPrisao * .16), MidpointRounding.AwayFromZero);
                        diasSemi = Math.Round((diasPrisao - diasFechado) * .16, MidpointRounding.AwayFromZero);
                        diasAberto = (totalDias - diasFechado - diasSemi);
                    }
                } // RÉU PRIMÁRIO
                dtFinal = dtFinal.AddDays(-diasRemição); // REMIÇÃO
                dtFinalFechado = dtInicio.AddDays(diasFechado);
                dtInicioSemi = dtFinalFechado.AddDays(1);
                dtFinalSemi = dtFinalFechado.AddDays(diasSemi);
                dtInicioAberto = dtFinalSemi.AddDays(1);
                labelFechadoInicio.Text = dtInicio.ToShortDateString();
                labelFechadoFim.Text = dtFinalFechado.ToShortDateString();
                labelSemiInicio.Text = dtInicioSemi.ToShortDateString();
                labelSemiFim.Text = dtFinalSemi.ToShortDateString();
                labelAbertoInicio.Text = dtInicioAberto.ToShortDateString();
                labelAbertoFim.Text = dtFinal.ToShortDateString();
            }
        }

        private void btVoltar_Click(object sender, EventArgs e) // VOLTA PARA PERFIL
        {
            var FmrPerfil = new FmrPerfil();
            var FmrLogin = new FmrLogin();
            this.Hide();
            FmrPerfil.lbCargo.Text = "Advogado";
            FmrPerfil.lbEmail.Text = FmrLogin.email;
            FmrPerfil.Show();
        }

        private void btProxCalc_Click(object sender, EventArgs e)
        {
            DTPickerInicio.Value = DateTime.Today;
            AnosInput.Value = 0;
            MesesInput.Value = 0;
            DiasInput.Value = 0;
            DiasRemicao.Value = 0;
            cbOrgCr.Checked = false;
            cbHediondo.Checked = false;
            cbViloento.Checked = false;
            cbPeqDelito.Checked = false;
            cbHomicidio.Checked = false;
            cbReincidente.Checked = false;
            labelFechadoInicio.Text = "DD/MM/AAAA";
            labelFechadoFim.Text = "DD/MM/AAAA";
            labelSemiInicio.Text = "DD/MM/AAAA";
            labelSemiFim.Text = "DD/MM/AAAA";
            labelAbertoInicio.Text = "DD/MM/AAAA";
            labelAbertoFim.Text = "DD/MM/AAAA";
        }
    }
}

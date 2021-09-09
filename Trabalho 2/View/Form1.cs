using Trabalho_2.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_2
{
    public partial class Form1 : Form
    {
        char[,] mJogo = new char[3, 3];
        List<string> lCoords = new List<string>();
        List<string> lStringsValidas = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }

       
        

        private void btnNewGame_Click(object sender, EventArgs e)
        {

            NewGame();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            NewGamePlus();

        }

        private void btn00_Click(object sender, EventArgs e)
        {
            ChangeColor(btn00);
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            ChangeColor(btn01);

        }

        private void btn02_Click(object sender, EventArgs e)
        {
            ChangeColor(btn02);

        }

        private void btn10_Click(object sender, EventArgs e)
        {
            ChangeColor(btn10);

        }

        private void btn11_Click(object sender, EventArgs e)
        {
            ChangeColor(btn11);

        }

        private void btn12_Click(object sender, EventArgs e)
        {
            ChangeColor(btn12);

        }

        private void btn20_Click(object sender, EventArgs e)
        {
            ChangeColor(btn20);

        }

        private void btn21_Click(object sender, EventArgs e)
        {
            ChangeColor(btn21);

        }

        private void btn22_Click(object sender, EventArgs e)
        {
            ChangeColor(btn22);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtProcura.Text.Length > 0)
            {
                string sStringPontuacao = "";
                int iPontos = CalculaPontos(txtProcura.Text, out sStringPontuacao);
                TabelaPontos(iPontos, false);
                txtProcura.Text = "";
                ClearSelectedCoordinates();
            }

        }

        private void TabelaPontos(int iPontos, bool bReset)
        {
            int iPontosFinal = 0;
            try
            {
                iPontosFinal = iPontos + Convert.ToInt32(lblPontos.Text);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            if (bReset)
            {
                lblPontos.Text = "0";
            }
            else
            {
                lblPontos.Text = iPontosFinal.ToString();
            }
            string sTemp = "";
            for (int i = 0; i < lStringsValidas.Count; i++)
            {
                sTemp = sTemp + lStringsValidas[i] + "\n";
            }
            lblStrings.Text = sTemp;
        }

       

        private void ClearSelectedCoordinates()
        {
            if (btn00.ForeColor == Color.Green)
            {
                btn00.ForeColor = SystemColors.ControlText;
            }

            if (btn01.ForeColor == Color.Green)
            {
                btn01.ForeColor = SystemColors.ControlText;
            }

            if (btn02.ForeColor == Color.Green)
            {
                btn02.ForeColor = SystemColors.ControlText;
            }

            if (btn10.ForeColor == Color.Green)
            {
                btn10.ForeColor = SystemColors.ControlText;
            }

            if (btn11.ForeColor == Color.Green)
            {
                btn11.ForeColor = SystemColors.ControlText;
            }

            if (btn12.ForeColor == Color.Green)
            {
                btn12.ForeColor = SystemColors.ControlText;
            }

            if (btn20.ForeColor == Color.Green)
            {
                btn20.ForeColor = SystemColors.ControlText;
            }

            if (btn21.ForeColor == Color.Green)
            {
                btn21.ForeColor = SystemColors.ControlText;
            }

            if (btn22.ForeColor == Color.Green)
            {
                btn22.ForeColor = SystemColors.ControlText;
            }


        }


        private int CalculaPontos(string sPalavra, out string sStringPontuacao)
        {
            string sLastCoord = ProcuraLetra(sPalavra.Substring(0, 1));
            int iTotalLetras = 0;
            sStringPontuacao = "";
            if (sLastCoord == "-1" || lCoords.Contains(sLastCoord))
            {
                return iTotalLetras;
            }
            else
            {
                iTotalLetras++;
                FechaBotao(sLastCoord);

                sStringPontuacao = sPalavra.Substring(0, 1);
                lCoords.Add(sLastCoord);
            }
            string sNewCoord;
            for (int i = 1; i < sPalavra.Length; i++)
            {
                sNewCoord = ProcuraLetra(sPalavra.Substring(i, 1));
                if (!lCoords.Contains(sNewCoord) && sNewCoord != "-1" && ChecaCoordenadas(sLastCoord, sNewCoord))
                {
                    FechaBotao(sNewCoord);
                    sLastCoord = sNewCoord;
                    lCoords.Add(sNewCoord);
                    sStringPontuacao += sPalavra.Substring(i, 1);
                    iTotalLetras++;
                }
                else
                {
                    if (sStringPontuacao.Length > 0)
                    {
                        lStringsValidas.Add(sStringPontuacao);
                    }
                    return iTotalLetras / 2;
                }
            }

            if (sStringPontuacao.Length > 0)
            {
                lStringsValidas.Add(sStringPontuacao);
            }
            return iTotalLetras / 2;
        }

        private void FechaBotao(string sCoord)
        {
            switch (sCoord)
            {
                case "00":
                    btn00.ForeColor = Color.Red;
                    break;

                case "01":
                    btn01.ForeColor = Color.Red;
                    break;

                case "02":
                    btn02.ForeColor = Color.Red;
                    break;

                case "10":
                    btn10.ForeColor = Color.Red;
                    break;

                case "11":
                    btn11.ForeColor = Color.Red;
                    break;
                case "12":
                    btn12.ForeColor = Color.Red;
                    break;

                case "20":
                    btn20.ForeColor = Color.Red;
                    break;

                case "21":
                    btn21.ForeColor = Color.Red;
                    break;

                case "22":
                    btn22.ForeColor = Color.Red;
                    break;


                default:
                    break;
            }
        }
        private bool ChecaCoordenadas(string sCoord1, string sCoord2)
        {
            int iCoord00 = Convert.ToInt32(sCoord1[0]);
            int iCoord01 = Convert.ToInt32(sCoord1[1]);
            int iCoord10 = Convert.ToInt32(sCoord2[0]);
            int iCoord11 = Convert.ToInt32(sCoord2[1]);

            if ((iCoord00 == iCoord10 || iCoord00 - 1 == iCoord10 || iCoord00 + 1 == iCoord10) && (iCoord01 == iCoord11 || iCoord01 - 1 == iCoord11 || iCoord01 + 1 == iCoord11))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NewTable()
        {
            btn00.ForeColor = SystemColors.ControlText;
            btn01.ForeColor = SystemColors.ControlText;
            btn02.ForeColor = SystemColors.ControlText;
            btn10.ForeColor = SystemColors.ControlText;
            btn11.ForeColor = SystemColors.ControlText;
            btn12.ForeColor = SystemColors.ControlText;
            btn20.ForeColor = SystemColors.ControlText;
            btn21.ForeColor = SystemColors.ControlText;
            btn22.ForeColor = SystemColors.ControlText;
            txtProcura.Text = "";
            lCoords = new List<string>();
        }

        private void NewGamePlus()
        {
            NewTable();
            GeraMatriz();
        }
        private void NewGame()
        {
            NewTable();
            GeraMatriz();
            lStringsValidas = new List<string>();
            TabelaPontos(0, true);
        }

        private bool ChangeColor(Button btn)
        {
            if (btn.ForeColor == Color.Red)
            {
                return false;
            }

            if (btn.ForeColor == SystemColors.ControlText)
            {
                btn.ForeColor = Color.Green;
                txtProcura.Text = txtProcura.Text + btn.Text;
                return true;
            }
            else
            {
                btn.ForeColor = SystemColors.ControlText;
                txtProcura.Text = txtProcura.Text.Replace(btn.Text, "");

                return false;
            }
        }
        private void GeraMatriz()
        {
            mJogo = new char[3, 3];

            for (int i = 0; i < 9; i++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                char c = 'a';
                int j = 0;

                switch (i)
                {
                    case 0:

                        j = rand.Next(1, 100 + 1);
                        if (j <= 50)
                        {
                            c = 'A';
                        }
                        else
                        {
                            c = 'D';
                        }
                        mJogo[0, 0] = c;
                        btn00.Text = c.ToString();


                        break;
                    case 1:
                        j = rand.Next(1, 100 + 1);
                        if (j <= 50)
                        {
                            c = 'E';
                        }
                        else
                        {
                            c = 'F';
                        }
                        mJogo[0, 1] = c;
                        btn01.Text = c.ToString();

                        break;
                    case 2:
                        j = rand.Next(1, 100 + 1);
                        if (j <= 50)
                        {
                            c = 'B';
                        }
                        else
                        {
                            c = 'C';
                        }
                        mJogo[0, 2] = c;
                        btn02.Text = c.ToString();

                        break;


                    case 3:
                        j = rand.Next(1, 90 + 1);
                        if (j <= 30)
                        {
                            c = 'G';
                        }
                        else if (j <= 60)
                        {
                            c = 'I';
                        }
                        else
                        {
                            c = 'U';
                        }
                        mJogo[1, 0] = c;
                        btn10.Text = c.ToString();

                        break;


                    case 4:

                        j = rand.Next(1, 90 + 1);
                        if (j <= 30)
                        {
                            c = 'H';
                        }
                        else if (j <= 60)
                        {
                            c = 'J';
                        }
                        else
                        {
                            c = 'V';
                        }
                        mJogo[1, 1] = c;
                        btn11.Text = c.ToString();

                        break;

                    case 5:
                        j = rand.Next(1, 100 + 1);
                        if (j <= 50)
                        {
                            c = 'K';
                        }
                        else
                        {
                            c = 'L';
                        }
                        mJogo[1, 2] = c;
                        btn12.Text = c.ToString();

                        break;
                    case 6:
                        j = rand.Next(1, 90 + 1);
                        if (j <= 30)
                        {
                            c = 'M';
                        }
                        else if (j <= 60)
                        {
                            c = 'O';
                        }
                        else
                        {
                            c = 'Q';
                        }
                        mJogo[2, 0] = c;
                        btn20.Text = c.ToString();

                        break;
                    case 7:
                        j = rand.Next(1, 90 + 1);
                        if (j <= 30)
                        {
                            c = 'N';
                        }
                        else if (j <= 60)
                        {
                            c = 'T';
                        }
                        else
                        {
                            c = 'P';
                        }
                        mJogo[2, 1] = c;
                        btn21.Text = c.ToString();

                        break;

                    case 8:
                        j = rand.Next(1, 90 + 1);
                        if (j <= 30)
                        {
                            c = 'R';
                        }
                        else if (j <= 2)
                        {
                            c = 'S';
                        }
                        else
                        {
                            c = 'Z';
                        }
                        mJogo[2, 2] = c;
                        btn22.Text = c.ToString();

                        break;


                    default:
                        break;
                }
            }
        }



        private string ProcuraLetra(string sLetra)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sLetra == mJogo[i, j].ToString())
                    {
                        return i.ToString() + j.ToString();
                    }
                }
            }

            return "-1";
        }

    }
}

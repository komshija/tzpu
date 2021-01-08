using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGen
{
    public partial class glavna_forma : Form
    {
        private Dictionary<int, double> oblastZastupljenost;
        private Dictionary<int, string> namesOfDomains = new Dictionary<int, string>(5 * 3);
        
        private List<int> oblasti;
        private List<double> zastupljenost;
        private int brPitanja;
       
        bool changed = false;
        public glavna_forma()
        {
            InitializeComponent();
            oblastZastupljenost = new Dictionary<int, double>();
            for (int i = 0; i < 15; i++)
                oblastZastupljenost.Add(i, 0.0);
            rb_nizovi.Checked = true;

            namesOfDomains.Add(0, "Nizovi Lako");
            namesOfDomains.Add(1, "Algoritmi Lako");
            namesOfDomains.Add(2, "Funkcije Lako");
            namesOfDomains.Add(3, "Fajlovi Lako");
            namesOfDomains.Add(4, "Matrice Lako");

            namesOfDomains.Add(5, "Nizovi Srednje");
            namesOfDomains.Add(6, "Algoritmi Srednje");
            namesOfDomains.Add(7, "Funkcije Srednje");
            namesOfDomains.Add(8, "Fajlovi Srednje");
            namesOfDomains.Add(9, "Matrice Srednje");

            namesOfDomains.Add(10, "Nizovi Tesko");
            namesOfDomains.Add(11, "Algoritmi Tesko");
            namesOfDomains.Add(12, "Funkcije Tesko");
            namesOfDomains.Add(13, "Fajlovi Tesko");
            namesOfDomains.Add(14, "Matrice Tesko");

            brPitanja = 5;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;

            if (!rb.Checked)
                return;

            int rb_tag = Convert.ToInt32(rb.Tag);
            changed = true;
            PrepareTrackBars(rb_tag, rb_tag + 5, rb_tag + 10);
        }

        private void PrepareTrackBars(int sliderLakoTag, int sliderSrednjeTag, int sliderTeskoTag)
        {
            trackBar_lako.Tag = sliderLakoTag;
            trackBar_srednje.Tag = sliderSrednjeTag;
            trackBar_tesko.Tag = sliderTeskoTag;

            trackBar_lako.Value = Convert.ToInt32(oblastZastupljenost[sliderLakoTag]);
            trackBar_srednje.Value = Convert.ToInt32(oblastZastupljenost[sliderSrednjeTag]);
            trackBar_tesko.Value = Convert.ToInt32(oblastZastupljenost[sliderTeskoTag]);

        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (changed)
            {
                changed = false;
                return;
            }

            var trackBar = sender as TrackBar;
            int tag = Convert.ToInt32(trackBar.Tag);
            if(GetTrackBarSum() > 10)
            {
                trackBar.Value = Convert.ToInt32(oblastZastupljenost[tag]);
                return;
            }
            else
                oblastZastupljenost[tag] = trackBar.Value;

            var points = chart_zastupljenost.Series["series_zastupljenost"].Points;
            points.Clear();

            foreach (var item in oblastZastupljenost.Where(x => x.Value != 0))
                points.AddXY(namesOfDomains[item.Key].ToString(), Convert.ToDouble(item.Value));

            points.Invalidate();
        }

        private void btn_kreiraj_Click(object sender, EventArgs e)
        {

            StringBuilder stringBuilder = new StringBuilder();
            oblasti = new List<int>();
            zastupljenost = new List<double>();

            stringBuilder.AppendLine($"Broj broj pitanja: {nUpDwn_brPitanja.Value}");
            double sum = 0;
            double odnos = 0;
            foreach (var item in oblastZastupljenost.Where(x => x.Value != 0))
            {
                odnos = item.Value / 10.0;
                stringBuilder.AppendLine(namesOfDomains[item.Key] + " : " + (odnos * 100) + "%");
                sum += odnos;
                oblasti.Add(item.Key);
                zastupljenost.Add(odnos);
            }
            if(sum < 1)
                MessageBox.Show("Zbir zastupljenosti nije 100% na testu!","Greska!",buttons: MessageBoxButtons.OK,icon:MessageBoxIcon.Error);
            else
            {
                var result = MessageBox.Show(stringBuilder.ToString(),"Da li ste sigurni?",buttons: MessageBoxButtons.YesNo,icon: MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Zovi 
                    Logic.GeneticAlgorithmUse gen = new Logic.GeneticAlgorithmUse();
                    try
                    {
                        var t = gen.UseAlgorithm(oblasti, zastupljenost, brPitanja);
                        TestPreview testPreviewForm = new TestPreview(t);
                        testPreviewForm.ShowDialog();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Došlo je do greske.", "Greska!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        return;
                    }


                }
            }
        }


        private int GetTrackBarSum()
        {
            return trackBar_lako.Value + trackBar_srednje.Value + trackBar_tesko.Value;
        }

        private void oAplikacijiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OAplikaciji oAplikacijiForm = new OAplikaciji();
            oAplikacijiForm.ShowDialog();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uputstvo uputstvoForm = new Uputstvo();
            uputstvoForm.Show();
        }

        private void nUpDwn_brPitanja_ValueChanged(object sender, EventArgs e)
        {
            brPitanja = (int)nUpDwn_brPitanja.Value;
        }
    }
}

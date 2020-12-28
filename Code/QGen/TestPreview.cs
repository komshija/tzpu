using DataAccess;
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
    public partial class TestPreview : Form
    {
        class Prikaz
        {
            public int Id { get; set; }
            public string Tekst { get; set; }
            public string Oblasti { get; set; }
        }

        private Test test;
        IList<Prikaz> questions;
        public TestPreview(Test test)
        {
            this.test = test;
            questions = test.questions.Select(q =>
            new Prikaz
            {
                Id = q.Id,
                Tekst = q.Text,
                Oblasti = q.DomainsToString()
            }).ToList();
            
            
            InitializeComponent();
        }

        private void TestPreview_Load(object sender, EventArgs e)
        {
            foreach (var qt in questions)
                dgv_test.Rows.Add(new string[] { qt.Id.ToString(), qt.Tekst, qt.Oblasti });
        }

        private void dgv_test_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_test.Rows)
                row.Height = (dgv_test.ClientRectangle.Height - dgv_test.ColumnHeadersHeight) / dgv_test.Rows.Count;
        }
    }
}

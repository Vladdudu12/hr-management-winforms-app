using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hr_management_app.UserControls
{
    public partial class Grafic : UserControl
    {

        Graphics g;
        double[] vect = new double[20];
        int nrElem = 0;
        bool vb = false;
        const int marg = 10;
        Color culoare = Color.White;
        Font font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);

        public Grafic()
        {
            InitializeComponent();
            g = this.CreateGraphics();

        }

        private void pdPrint(object sender, PrintPageEventArgs e)
        {
            if (vb == true)
            {
                Graphics gr = e.Graphics;
                Rectangle rec = new Rectangle(e.PageBounds.X + marg, e.PageBounds.Y + 4 * marg,
                                e.PageBounds.Width - 2 * marg, e.PageBounds.Height - 5 * marg);
                Pen pen = new Pen(Color.Black, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 3;
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();

                Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];
                for (int i = 0; i < nrElem; i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    gr.FillEllipse(br, recs[i]);
                    gr.DrawString(vect[i].ToString(), font, br, new Point(recs[i].Location.X, recs[i].Location.Y - font.Height));
                }
                for (int i = 0; i < nrElem - 1; i++)
                {
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2), (int)recs[i].Location.Y),
                        new Point((int)(recs[i + 1].Location.X + latime / 2), (int)recs[i + 1].Location.Y));
                }
            }
        }


        private void buttonGrafic_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void buttonImprimare_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pdPrint);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg, panel1.ClientRectangle.Y + 4 * marg,
                                          panel1.ClientRectangle.Width - 2 * marg, panel1.ClientRectangle.Height - 5 * marg);
            Pen pen = new Pen(Color.Green, 3);
            gr.DrawRectangle(pen, rec);

            double latime = rec.Width / nrElem / 3;
            double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
            double vMax = vect.Max();

            Brush br = new SolidBrush(culoare);

            Rectangle[] recs = new Rectangle[nrElem];
            for (int i = 0; i < nrElem; i++)
            {
                recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                                        (int)latime,
                                        (int)(vect[i] / vMax * rec.Height));
                gr.FillEllipse(br, recs[i]);
                gr.DrawString(vect[i].ToString(), font, br, new Point(recs[i].Location.X, recs[i].Location.Y - font.Height));
            }

            for (int i = 0; i < nrElem - 1; i++)
                gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2), (int)recs[i].Location.Y),
                            new Point((int)(recs[i + 1].Location.X + latime / 2), (int)recs[i + 1].Location.Y));
        }

    }

}

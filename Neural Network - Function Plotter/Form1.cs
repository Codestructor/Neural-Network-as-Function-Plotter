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

namespace Neural_Network___Function_Plotter
{
    public partial class Form1 : Form
    {
        public static Graphics gfx;

        Pen blackP = new Pen(Color.Black, 2);
        Pen redP = new Pen(Color.Red, 2);
        Pen greenP = new Pen(Color.Green, 2);

        int x0, y0, xf, yf; //Pixels - must pe int
        int ox, oy; //Pixels - must be int

        double inX, finX;
        double step;
        double ratioX, ratioY;

        List<double> inputVals = new List<double>();
        List<double> inputKnown = new List<double>();
        List<double> targetVals = new List<double>();
        List<double> resultVals = new List<double>();

        void axisDraw(int x0, int xf, int y0, int yf)
        {
            gfx.DrawLine(blackP, x0, (y0 + yf) / 2, xf, (y0 + yf) / 2);
            gfx.DrawLine(blackP, (x0 + xf) / 2, y0, (x0 + xf) / 2, yf);
        }


        public void setInterval(double paramInX, double paramFinX)
        {
            inX = paramInX;
            finX = paramFinX;

            lblX0.Parent = pnlPlot;
            lblXF.Parent = pnlPlot;

            lblX0.Location = new Point(x0, oy - lblX0.Height - 5);
            lblX0.Text = paramInX.ToString();
            lblXF.Location = new Point(xf-lblXF.Width, oy - lblXF.Height - 5);
            lblXF.Text = paramFinX.ToString();

            step = (finX - inX) / xf; //Cat x per pixel

            double absInX, absFinX;

            if (paramInX > 0)
                absInX = paramInX;
            else
                absInX = -paramInX;

            if (paramFinX > 0)
                absFinX = paramFinX;
            else
                absFinX = -paramFinX;

            ratioX = absInX > absFinX ? absInX : absFinX;
            ratioX = 1 / ratioX;

            double minImf=9999, maxImf=-9999;
            double y;

            for (double x = inX + step; x <= finX; x += step)
            {
                y=valYf1(x);
                if (y < minImf)
                    minImf = y;
                else if (y > maxImf)
                    maxImf = y;
            }

            minImf = minImf>=0 ? minImf : -minImf;
            maxImf = maxImf>=0?maxImf : - maxImf;

            //ratioY = 1 / maxImf;
            ratioY = 1 / (double)pnlPlot.Height;
        }

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gfx = pnlPlot.CreateGraphics();

            x0 = 0;
            xf = pnlPlot.Width;
            y0 = pnlPlot.Height;
            yf = 0;

            setInterval(-10.5, 10.5);

            ox = (x0 + xf) / 2;
            oy = (y0 + yf) / 2;

            axisDraw(x0, xf, y0, yf);
        }

        private double valYf1(double x)
        {
            return 2 * x * x * x + 4 * x * x;
        }

        private int f1(double x)
        {
            return (int)Math.Round( valYf1(x) / step); //2x^3+x^2
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            int lastY, currentY;

            lastY = f1(inX);
            for (double x = inX + step; x <= finX; x += step)
            {
                try
                {
                    currentY = f1(x);
                    gfx.DrawLine(redP, (int)((x - inX) / step) - 1, oy - lastY, (int)((x - inX) / step), oy - currentY);
                    lastY = currentY;
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void pnlPlot_MouseClick(object sender, MouseEventArgs e)
        {
            int xClick = e.Location.X;
            double inputX = (double)xClick * step + inX;
            int yClick = oy - f1(inputX);

            //if (yClick <= pnlPlot.Height && yClick >= 0)
            //{
                gfx.DrawLine(blackP, xClick - 5, yClick, xClick + 5, yClick);
                gfx.DrawLine(blackP, xClick, yClick - 5, xClick, yClick + 5);

                inputKnown.Add(inputX * ratioX);
                targetVals.Add(valYf1(inputX) * ratioY);
            //}
            //else
            //{
              //  MessageBox.Show("Out of range");
           // }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
               e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtBoxPath.Text = files[0];
        }

        const int dim = 100;

        List<int> topology;
        Net myNet;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtBoxPath.Text == "")
            {
                MessageBox.Show("Fill path.");
                return;
            }
            try
            {
                StreamReader str = new StreamReader(txtBoxPath.Text);
                string[] data = new string[dim];

                data = str.ReadLine().Split(' ');

                topology = new List<int>();

                for (int i = 0; i < data.Length; i++)
                {
                    topology.Add(Convert.ToInt32(data[i]));
                }

                str.Close();

                myNet = new Net(topology);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Path is invalid. Retry.");
            }

            inputVals.Clear();
            for (double x = inX + step; x <= finX; x += step)
            {
                inputVals.Add(x * ratioX);
            }
        }

        public void plotNetOutputs()
        {
            List<double> auxInput = new List<double>();

            resultVals.Clear();
            auxInput.Clear();

            auxInput.Add(inputVals[0]);
            myNet.feedForward(auxInput);
            myNet.getResults(resultVals);

            Point lastP = new Point((int)Math.Round((inputVals[0] / ratioX - inX) / step), oy - (int)Math.Round(resultVals[0] / ratioY / step));
            Point currentP = new Point();

            for (int p = 1; p < inputVals.Count(); p++)
            {
                resultVals.Clear();
                auxInput.Clear();

                auxInput.Add(inputVals[p]);
                myNet.feedForward(auxInput);
                myNet.getResults(resultVals);
                currentP.X = (int)Math.Round((inputVals[p] / ratioX - inX) / step);
                currentP.Y = oy - (int)Math.Round(resultVals[0] / ratioY / step);

                gfx.DrawLine(greenP, lastP, currentP);

                lastP = currentP;
            }

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            for(int i=1; i<=20; i++)
            {
                List<double> auxInput = new List<double>();
                List<double> auxTarget = new List<double>();

                for (int p = 0; p < inputKnown.Count(); p++)
                {
                    auxInput.Clear();
                    auxTarget.Clear();

                    auxInput.Add(inputKnown[p]);
                    auxTarget.Add(targetVals[p]);

                    myNet.feedForward(auxInput);
                    myNet.backProp(auxTarget);
                }

                plotNetOutputs();
            }
        }
    }
}

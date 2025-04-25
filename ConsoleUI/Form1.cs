using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleUI
{
    public partial class MainWindow: Form
    {
        private FigureService figureService;
        private List<int> selectedIndices;

        public MainWindow()
        {
            InitializeComponent();
            figureService = new FigureService();
        }


        private void addPointButton_Click(object sender, EventArgs e)
        {
            
            bool isXDouble = double.TryParse(pointXTextBox.Text, out double x);
            bool isYDouble = double.TryParse(pointYTextBox.Text, out double y);
            if (isXDouble && isYDouble)
            {
                PointFigure point = new PointFigure(x, y);
                figureService.Add(point);
                colorBordersToBlack();
            }
            else
            {
                if (!isXDouble)
                {
                    pointXTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isYDouble)
                {
                    pointYTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
            }
        }

        private void addCircleButton_Click(object sender, EventArgs e)
        {
            bool isXDouble = double.TryParse(circleXTextBox.Text, out double x);
            bool isYDouble = double.TryParse(circleYTextBox.Text, out double y);
            bool isRadiusDouble = double.TryParse(circleRadiusTextBox.Text, out double radius);
            if (isXDouble && isYDouble && isRadiusDouble)
            {
                Circle circle = new Circle(x, y, radius);
                figureService.Add(circle);
                colorBordersToBlack();
            }
            else
            {
                if (!isXDouble)
                {
                    circleXTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isYDouble)
                {
                    circleYTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isRadiusDouble)
                {
                    circleRadiusTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
            }
        }

        private void colorBordersToBlack()
        {
            List<TextBox> allTextBoxes = GetAllTextBoxes(this);
            foreach (TextBox textBox in allTextBoxes)
            {
                textBox.BackColor = Color.Black;
            }
        }

        private List<TextBox> GetAllTextBoxes(Control control)
        {
            var textBoxes = new List<TextBox>();

            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    textBoxes.Add((TextBox)c);
                }
                // Рекурсивный поиск в контейнерах
                textBoxes.AddRange(GetAllTextBoxes(c));
            }

            return textBoxes;
        }

        private void pointDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void pointsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

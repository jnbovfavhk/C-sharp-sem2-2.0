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
using System.Xml.Serialization;


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
            refreshListViews();
        }


        private void addPointButton_Click(object sender, EventArgs e)
        {
            
            bool isXDouble = double.TryParse(pointXTextBox.Text, out double x);
            bool isYDouble = double.TryParse(pointYTextBox.Text, out double y);
            if (isXDouble && isYDouble)
            {
                
                PointFigure point = new PointFigure(x, y);
                figureService.Add(point);
                refreshListViews();

                pointXTextBox.Text = "";
                pointYTextBox.Text = "";
                colorBordersToWhite();
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

        private void pointDeleteButton_Click(object sender, EventArgs e)
        {
            deleteFromData(pointsListView, 2);
        }


        private void addCircleButton_Click(object sender, EventArgs e)
        {
            bool isXDouble = double.TryParse(circleXTextBox.Text, out double x);
            bool isYDouble = double.TryParse(circleYTextBox.Text, out double y);
            bool isRadiusDouble = double.TryParse(circleRadiusTextBox.Text, out double radius);
            bool isRadiusPositive = radius > 0;
            if (isXDouble && isYDouble && isRadiusDouble && isRadiusPositive)
            {

                Circle circle = new Circle(x, y, radius);
                figureService.Add(circle);

                refreshListViews();

                circleXTextBox.Text = "";
                circleYTextBox.Text = "";
                circleRadiusTextBox.Text = "";
                colorBordersToWhite();
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
                if (!isRadiusDouble || !isRadiusPositive)
                {
                    circleRadiusTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
            }
        }


        private void deleteCirclebutton_Click(object sender, EventArgs e)
        {
            deleteFromData(circlesListView, 5);
        }

        private void addTriangleButton_Click(object sender, EventArgs e)
        {
            bool isP1XDouble = double.TryParse(triangleP1XTextBox.Text, out double p1x);
            bool isP1YDouble = double.TryParse(triangleP1YTextBox.Text, out double p1y);
            bool isP2XDouble = double.TryParse(triangleP2XTextBox.Text, out double p2x);
            bool isP2YDouble = double.TryParse(triangleP2YTextBox.Text, out double p2y);
            bool isP3XDouble = double.TryParse(triangleP3XTextBox.Text, out double p3x);
            bool isP3YDouble = double.TryParse(triangleP3YTextBox.Text, out double p3y);

            if (isP1XDouble && isP1YDouble && isP2XDouble && isP2YDouble && isP3XDouble && isP3YDouble)
            {

                Triangle tr = new Triangle(p1x, p1y, p2x, p2y, p3x, p3y);
                figureService.Add(tr);
                refreshListViews();

                triangleP1XTextBox.Text = "";
                triangleP1YTextBox.Text = "";
                triangleP2XTextBox.Text = "";
                triangleP2YTextBox.Text = "";
                triangleP3XTextBox.Text = "";
                triangleP3YTextBox.Text = "";

                colorBordersToWhite();
            }
            else
            {
                if (!isP1XDouble)
                {
                    triangleP1XTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isP1YDouble)
                {
                    triangleP1YTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isP2XDouble)
                {
                    triangleP2XTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isP2YDouble)
                {
                    triangleP2YTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isP3XDouble)
                {
                    triangleP3XTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isP3YDouble)
                {
                    triangleP3YTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
            }
        }

        private void deleteTriangleButton_Click(object sender, EventArgs e)
        {
            deleteFromData(trianglesListView, 7);
        }

        private void addRectangleButton_Click(object sender, EventArgs e)
        {
            bool isXDouble = double.TryParse(rectangleXTextBox.Text, out double x);
            bool isYDouble = double.TryParse(rectangleYTextBox.Text, out double y);
            bool isWidthDouble = double.TryParse(rectangleWidthTextBox.Text, out double width);
            bool isHeightDouble = double.TryParse(rectangleHeightTextBox.Text, out double height);
            bool isWidthPositive = width > 0;
            bool isHeightPositive = height > 0;


            if (isXDouble && isYDouble && isWidthDouble && isHeightDouble && isWidthPositive && isHeightPositive)
            {

                Entities.Rectangle rect = new Entities.Rectangle(x, y, height, width);
                figureService.Add(rect);
                refreshListViews();

                rectangleXTextBox.Text = "";
                rectangleYTextBox.Text = "";
                rectangleWidthTextBox.Text = "";
                rectangleHeightTextBox.Text = "";

                colorBordersToWhite();
            }
            else
            {
                if (!isXDouble)
                {
                    rectangleXTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isYDouble)
                {
                    rectangleYTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isWidthDouble || !isWidthPositive)
                {
                    rectangleWidthTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
                if (!isHeightDouble || !isHeightPositive)
                {
                    rectangleHeightTextBox.BackColor = Color.FromArgb(250, 128, 114);
                }
            }
        }

        private void deleteRectangleButton_Click(object sender, EventArgs e)
        {
            deleteFromData(rectanglesListView, 8);
        }


        private void addPoint(double x, double y)
        {
            int figureIdx = addFigureReturnIndex("Point", x, y, 0, 0);
            pointsListView.Items.Add(new ListViewItem(new[] { x.ToString(), y.ToString(), figureIdx.ToString() }));
        }

        private void addCircle(double x, double y, double radius, double perimeter, double area)
        {
            int figureIdx = addFigureReturnIndex("Circle", x, y, perimeter, area);
            circlesListView.Items.Add(new ListViewItem(new[] { x.ToString(), y.ToString(), radius.ToString(), perimeter.ToString(), area.ToString(), figureIdx.ToString() }));
        }

        private void addTriangle(double x, double y, List<PointFigure> pointList, double perimeter, double area)
        {
            double point1X = pointList[0].GetX();
            double point1Y = pointList[0].GetY();
            double point2X = pointList[1].GetX();
            double point2Y = pointList[1].GetY();
            double point3X = pointList[2].GetX();
            double point3Y = pointList[2].GetY();
            
            int figureIdx = addFigureReturnIndex("Triangle", x, y, perimeter, area);
            trianglesListView.Items.Add(new ListViewItem(new[] { x.ToString(), y.ToString(), 
                "(" + point1X.ToString() + "; " + point1Y.ToString() + ")", 
                "(" + point2X.ToString() + "; " + point2Y.ToString() + ")", 
                "(" + point3X.ToString() + "; " + point3Y.ToString() + ")", 
                perimeter.ToString(), area.ToString(), figureIdx.ToString() }));
        }


        private void addRectangle(double x, double y, PointFigure leftUp, PointFigure rightDown, double height, double width, double perimeter, double area)
        {
            double leftUpX = leftUp.GetX();
            double leftUpY = leftUp.GetY();
            double rightDownX = rightDown.GetX();
            double rightDownY = rightDown.GetY();
            String leftUpPoint = "(" + leftUp.GetX() + "; " + leftUp.GetY() + ")";
            String rightDownPoint = "(" + rightDown.GetX() + "; " + rightDown.GetY() + ")";

            int figureIdx = addFigureReturnIndex("Rectangle", x, y, perimeter, area);
            rectanglesListView.Items.Add(new ListViewItem(new[] {x.ToString(), y.ToString(),
                leftUpPoint, rightDownPoint,
                height.ToString(), width.ToString(),
                perimeter.ToString(), area.ToString(), figureIdx.ToString()}));
        }


        private int addFigureReturnIndex(String type, double x, double y, double perimeter, double area)
        {
            figuresListView.Items.Add(new ListViewItem(new[] { type,  x.ToString(), y.ToString(), perimeter.ToString(), area.ToString()}));
            
            return figuresListView.Items.Count;
        }
        

        private void colorBordersToWhite()
        {
            List<TextBox> allTextBoxes = GetAllTextBoxes(this);
            foreach (TextBox textBox in allTextBoxes)
            {
                textBox.BackColor = Color.White;
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



        public void refreshListViews()
        {
            List<Figure> figuresList = figureService.GetFiguresList();

            pointsListView.Items.Clear();
            figuresListView.Items.Clear();
            trianglesListView.Items.Clear();
            rectanglesListView.Items.Clear();
            circlesListView.Items.Clear();

            

            foreach (Figure fig in figuresList)
            {

                if ((fig is PointFigure) && !(fig is Circle))
                {
                    addPoint(fig.GetX(), fig.GetY());
                }
                if (fig is Circle)
                {
                    Circle circ = (Circle)fig;
                    addCircle(circ.GetX(), circ.GetY(), circ.getRadius(), circ.Perimeter(), circ.Area());
                }
                if (fig is Triangle)
                {
                    Triangle tr = (Triangle)fig;
                    addTriangle(tr.GetX(), tr.GetY(), tr.GetPoints(), tr.Perimeter(), tr.Area());
                }
                if (fig is Entities.Rectangle)
                {
                    Entities.Rectangle rect = (Entities.Rectangle)fig;
                    addRectangle(rect.GetX(), rect.GetY(), rect.GetPoints()[0], rect.GetPoints()[3], rect.GetHeight(), rect.GetWidth(), rect.Perimeter(), rect.Area());

                }
            }
        }


        // Вспомогательный метод, чтобы не возникало ошибки индекса больше длины списка
        private void deleteFromData(ListView listView, int figureIndexColumn)
        {
            // Создаем список для хранения индексов, которые нужно удалить
            List<int> indexesToDelete = new List<int>();

            // Сначала собираем все индексы для удаления
            foreach (ListViewItem item in listView.SelectedItems)
            {
                indexesToDelete.Add(int.Parse(item.SubItems[figureIndexColumn].Text) - 1);
            }

            // Удаляем в обратном порядке (от большего к меньшему)
            indexesToDelete = indexesToDelete.OrderByDescending(x => x).ToList();

            foreach (int idx in indexesToDelete)
            {
                
                figureService.DeleteByIndex(idx);
                refreshListViews();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace oaip8laba
{
    public partial class Form1 : Form
    {
        Rectangle rectagle;
        Square square;
        Ellips ellips;
        Circle circle;
        ShapeContainer shapeContainer;
        Init init;
        Polygon polygon;
        Ship ship;
        private int zhizhka = 0; 
       /* int numPoints;*/
        private Point[] pointFs;
        bool flag;
        public Form1()
        {
            init = new Init();
            shapeContainer = new ShapeContainer();
                InitializeComponent();
                Init.bitmap = new
        Bitmap(pictureBox1.ClientSize.Width,
        pictureBox1.ClientSize.Height);
                Init.pen = new Pen(Color.Black, 5);
               
                Init.pictureBox = pictureBox1;
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Enabled = false;
        }
        //отрисовка фигур
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton2.Checked)
                { rectagle = new Rectangle(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
        int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                    ShapeContainer.AddFigure(this.rectagle);
                    rectagle.Draw();
                    comboBox1.Items.Clear();
                    try
                    {
                        foreach (Figure figure in ShapeContainer.figureList)
                        {
                            comboBox1.Items.Add(figure);
                        }
                    } catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                if(radioButton1.Checked)
                {
                    square = new Square(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
        int.Parse(textBox3.Text), int.Parse(textBox3.Text));
                    ShapeContainer.AddFigure(this.square);
                    square.Draw();
                    comboBox1.Items.Clear();
                    try
                    {
                        foreach (Figure figure in ShapeContainer.figureList)
                        {
                            comboBox1.Items.Add(figure);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                
                    if (radioButton3.Checked)
                    {
                        ellips = new Ellips(int.Parse(textBox1.Text),
                    int.Parse(textBox2.Text),
            int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                        ShapeContainer.AddFigure(this.ellips);
                        ellips.Draw();
                        comboBox1.Items.Clear();
                        try
                        {
                            foreach (Figure figure in ShapeContainer.figureList)
                            {
                                comboBox1.Items.Add(figure);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                if (radioButton4.Checked)
                {
                    circle = new Circle(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
        int.Parse(textBox3.Text), int.Parse(textBox3.Text));
                    ShapeContainer.AddFigure(this.circle);
                    circle.Draw();
                    comboBox1.Items.Clear();
                    try
                    {
                        foreach (Figure figure in ShapeContainer.figureList)
                        {
                            comboBox1.Items.Add(figure);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

                if (radioButton6.Checked)
                {
                    ship  = new Ship(int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
        int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                    ShapeContainer.AddFigure(this.ship);
                    ship.Draw();
                    comboBox1.Items.Clear();
                    try
                    {
                        foreach (Figure figure in ShapeContainer.figureList)
                        {
                            comboBox1.Items.Add(figure);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        //удаление
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedItem== null) 
                {
                    throw new Exception();
                }
                else
                {
                    Figure figure;
                    figure = (Figure)comboBox1.SelectedItem;
                    figure.DeleteF(figure);
                    comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                    comboBox1.Update();
                    comboBox1.ResetText();
                } 

            }catch(Exception Ex ) { MessageBox.Show(Ex.Message);
            }
        }
        //перемещение
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    throw new Exception();
                }
                else
                {
                    Figure figure;
                    figure = (Figure)comboBox1.SelectedItem;
                    figure.MoveTo(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                    
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Enabled == true)//квадрат
            {
                textBox4.Enabled = false;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
            }
        }
        /// 
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = true;//прямоугольник
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = true;//эллипс
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Enabled == true)//круг
            {
                textBox4.Enabled = false;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //расстановка точек
       
        int tochka = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            {
                
                try
                {
                    zhizhka = int.Parse(textBox5.Text);
                    if(flag == false)
                    {
                    label9.Text = $"Введите координаты {tochka + 1}-й точки: ";
                    this.pointFs = new Point[zhizhka];
                        flag = true;
                    }
                    else
                    {
                        if (tochka  < zhizhka - 1)
                        {
                            label9.Text = $"Введите координаты {tochka + 2}-й точки: ";
                            this.pointFs[tochka].X = int.Parse(textBox1.Text);
                    this.pointFs[tochka].Y = int.Parse(textBox2.Text);
                   tochka++;
                            
                        }
                        else
                        {
                            this.pointFs[tochka].X = int.Parse(textBox1.Text);
                            this.pointFs[tochka].Y = int.Parse(textBox2.Text);
                            flag = false;
                            tochka = 0;
                            label9.Text = "Фигура отрисована";
                            button5.Enabled = true;
                        }
                    }

                    
            /*  }
                else
                {
                    numPoints = int.Parse(textBox5.Text);
                    if (i != numPoints - 1)
                    {
                        i++;
                        label9.Text = $"Введите координаты {i + 1}-й точки: ";
                        Init.pointFs[i].X = int.Parse(textBox1.Text);
                        Init.pointFs[i].Y = int.Parse(textBox2.Text);
                    }
                    else
                    {
                        button4.Enabled = false;
                        button5.Enabled = true;
                        flag = false;
                    }

                }*/
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            } 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //отрисовка полигона
        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {

                polygon = new Polygon(this.pointFs);

                ShapeContainer.AddFigure(this.polygon);
                polygon.Draw();
                comboBox1.Items.Clear();
                try
                {
                    foreach (Figure figure in ShapeContainer.figureList)
                    {
                        comboBox1.Items.Add(figure);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                button5.Enabled=false;
            }

            /*  Graphics g = Graphics.FromImage(Init.bitmap);
              polygon = new Polygon(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
              ShapeContainer.AddFigure(this.polygon);
              polygon.Draw();*/


        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Enabled == true)
            {
                textBox4.Enabled = false;//многоугольник
                textBox3.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }
    }
    }




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

        }

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

            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

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
            if (radioButton1.Enabled == true)
            {
                textBox4.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled=true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Enabled == true)
            {
                textBox4.Enabled = false;
            }
        }
    }
}

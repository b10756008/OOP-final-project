using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace _8_Puzzle
{
    class MachineMove
    {

        public static string[] path;
        public static void Action(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7, Button btn8, Button btn9, Color clr)
        {
            
            string item;
            for (int i = path.Length-1; i >= 0; i--)
            {
                
                item = path[i];
                if (btn1.Text == "")
                {
                    switch (item)
                    {
                        case "下":
                            {
                                btn1.Text = btn4.Text;
                                btn1.BackColor = btn4.BackColor;
                                btn1.ForeColor = btn4.ForeColor;
                                btn1.FlatAppearance.BorderSize = 3;

                                btn4.Text = "";
                                btn4.BackColor = clr;
                                btn4.ForeColor = clr;
                                btn4.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                        case "右":
                            {
                                btn1.Text = btn2.Text;
                                btn1.BackColor = btn2.BackColor;
                                btn1.ForeColor = btn2.ForeColor;
                                btn1.FlatAppearance.BorderSize = 3;

                                btn2.Text = "";
                                btn2.BackColor = clr;
                                btn2.ForeColor = clr;
                                btn2.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                    }

                    

                }
                else if (btn2.Text == "")
                {
                    switch (item)
                    {
                        case "下":
                            {
                                btn2.Text = btn5.Text;
                                btn2.BackColor = btn5.BackColor;
                                btn2.ForeColor = btn5.ForeColor;
                                btn2.FlatAppearance.BorderSize = 3;

                                btn5.Text = "";
                                btn5.BackColor = clr;
                                btn5.ForeColor = clr;
                                btn5.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                        case "左":
                            {
                                btn2.Text = btn1.Text;
                                btn2.BackColor = btn1.BackColor;
                                btn2.ForeColor = btn1.ForeColor;
                                btn2.FlatAppearance.BorderSize = 3;

                                btn1.Text = "";
                                btn1.BackColor = clr;
                                btn1.ForeColor = clr;
                                btn1.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "右":
                            {
                                btn2.Text = btn3.Text;
                                btn2.BackColor = btn3.BackColor;
                                btn2.ForeColor = btn3.ForeColor;
                                btn2.FlatAppearance.BorderSize = 3;

                                btn3.Text = "";
                                btn3.BackColor = clr;
                                btn3.ForeColor = clr;
                                btn3.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                    }

                }
                else if (btn3.Text == "")
                {
                    switch (item)
                    {
                        case "下":
                            {
                                btn3.Text = btn6.Text;
                                btn3.BackColor = btn6.BackColor;
                                btn3.ForeColor = btn6.ForeColor;
                                btn3.FlatAppearance.BorderSize = 3;

                                btn6.Text = "";
                                btn6.BackColor = clr;
                                btn6.ForeColor = clr;
                                btn6.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                        case "左":
                            {
                                btn3.Text = btn2.Text;
                                btn3.BackColor = btn2.BackColor;
                                btn3.ForeColor = btn2.ForeColor;
                                btn3.FlatAppearance.BorderSize = 3;

                                btn2.Text = "";
                                btn2.BackColor = clr;
                                btn2.ForeColor = clr;
                                btn2.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                    }

                }
                else if (btn4.Text == "")
                {
                    switch (item)
                    {
                        case "下":
                            {
                                btn4.Text = btn7.Text;
                                btn4.BackColor = btn7.BackColor;
                                btn4.ForeColor = btn7.ForeColor;
                                btn4.FlatAppearance.BorderSize = 3;

                                btn7.Text = "";
                                btn7.BackColor = clr;
                                btn7.ForeColor = clr;
                                btn7.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "上":
                            {
                                btn4.Text = btn1.Text;
                                btn4.BackColor = btn1.BackColor;
                                btn4.ForeColor = btn1.ForeColor;
                                btn4.FlatAppearance.BorderSize = 3;

                                btn1.Text = "";
                                btn1.BackColor = clr;
                                btn1.ForeColor = clr;
                                btn1.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                        case "右":
                            {
                                btn4.Text = btn5.Text;
                                btn4.BackColor = btn5.BackColor;
                                btn4.ForeColor = btn5.ForeColor;
                                btn4.FlatAppearance.BorderSize = 3;

                                btn5.Text = "";
                                btn5.BackColor = clr;
                                btn5.ForeColor = clr;
                                btn5.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                    }

                }
                else if (btn5.Text == "")
                {
                    switch (item)
                    {
                        case "下":
                            {
                                btn5.Text = btn8.Text;
                                btn5.BackColor = btn8.BackColor;
                                btn5.ForeColor = btn8.ForeColor;
                                btn5.FlatAppearance.BorderSize = 3;

                                btn8.Text = "";
                                btn8.BackColor = clr;
                                btn8.ForeColor = clr;
                                btn8.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "上":
                            {
                                btn5.Text = btn2.Text;
                                btn5.BackColor = btn2.BackColor;
                                btn5.ForeColor = btn2.ForeColor;
                                btn5.FlatAppearance.BorderSize = 3;

                                btn2.Text = "";
                                btn2.BackColor = clr;
                                btn2.ForeColor = clr;
                                btn2.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "左":
                            {
                                btn5.Text = btn4.Text;
                                btn5.BackColor = btn4.BackColor;
                                btn5.ForeColor = btn4.ForeColor;
                                btn5.FlatAppearance.BorderSize = 3;

                                btn4.Text = "";
                                btn4.BackColor = clr;
                                btn4.ForeColor = clr;
                                btn4.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "右":
                            {
                                btn5.Text = btn6.Text;
                                btn5.BackColor = btn6.BackColor;
                                btn5.ForeColor = btn6.ForeColor;
                                btn5.FlatAppearance.BorderSize = 3;

                                btn6.Text = "";
                                btn6.BackColor = clr;
                                btn6.ForeColor = clr;
                                btn6.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                    }

                }
                else if (btn6.Text == "")
                {
                    switch (item)
                    {
                        case "下":
                            {
                                btn6.Text = btn9.Text;
                                btn6.BackColor = btn9.BackColor;
                                btn6.ForeColor = btn9.ForeColor;
                                btn6.FlatAppearance.BorderSize = 3;

                                btn9.Text = "";
                                btn9.BackColor = clr;
                                btn9.ForeColor = clr;
                                btn9.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "上":
                            {
                                btn6.Text = btn3.Text;
                                btn6.BackColor = btn3.BackColor;
                                btn6.ForeColor = btn3.ForeColor;
                                btn6.FlatAppearance.BorderSize = 3;

                                btn3.Text = "";
                                btn3.BackColor = clr;
                                btn3.ForeColor = clr;
                                btn3.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "左":
                            {
                                btn6.Text = btn5.Text;
                                btn6.BackColor = btn5.BackColor;
                                btn6.ForeColor = btn5.ForeColor;
                                btn6.FlatAppearance.BorderSize = 3;

                                btn5.Text = "";
                                btn5.BackColor = clr;
                                btn5.ForeColor = clr;
                                btn5.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                    }


                }
                else if (btn7.Text == "")
                {
                    switch (item)
                    {

                        case "上":
                            {
                                btn7.Text = btn4.Text;
                                btn7.BackColor = btn4.BackColor;
                                btn7.ForeColor = btn4.ForeColor;
                                btn7.FlatAppearance.BorderSize = 3;

                                btn4.Text = "";
                                btn4.BackColor = clr;
                                btn4.ForeColor = clr;
                                btn4.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                
                                break;
                            }

                        case "右":
                            {
                                btn7.Text = btn8.Text;
                                btn7.BackColor = btn8.BackColor;
                                btn7.ForeColor = btn8.ForeColor;
                                btn7.FlatAppearance.BorderSize = 3;

                                btn8.Text = "";
                                btn8.BackColor = clr;
                                btn8.ForeColor = clr;
                                btn8.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                    }

                    

                }
                else if (btn8.Text == "")
                {
                    switch (item)
                    {

                        case "上":
                            {
                                btn8.Text = btn5.Text;
                                btn8.BackColor = btn5.BackColor;
                                btn8.ForeColor = btn5.ForeColor;
                                btn8.FlatAppearance.BorderSize = 3;

                                btn5.Text = "";
                                btn5.BackColor = clr;
                                btn5.ForeColor = clr;
                                btn5.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "左":
                            {
                                btn8.Text = btn7.Text;
                                btn8.BackColor = btn7.BackColor;
                                btn8.ForeColor = btn7.ForeColor;
                                btn8.FlatAppearance.BorderSize = 3;

                                btn7.Text = "";
                                btn7.BackColor = clr;
                                btn7.ForeColor = clr;
                                btn7.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "右":
                            {
                                btn8.Text = btn9.Text;
                                btn8.BackColor = btn9.BackColor;
                                btn8.ForeColor = btn9.ForeColor;
                                btn8.FlatAppearance.BorderSize = 3;

                                btn9.Text = "";
                                btn9.BackColor = clr;
                                btn9.ForeColor = clr;
                                btn9.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                    }

                    

                }

                else if (btn9.Text == "")
                {
                    switch (item)
                    {

                        case "上":
                            {
                                btn9.Text = btn6.Text;
                                btn9.BackColor = btn6.BackColor;
                                btn9.ForeColor = btn6.ForeColor;
                                btn9.FlatAppearance.BorderSize = 3;

                                btn6.Text = "";
                                btn6.BackColor = clr;
                                btn6.ForeColor = clr;
                                btn6.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }
                        case "左":
                            {
                                btn9.Text = btn8.Text;
                                btn9.BackColor = btn8.BackColor;
                                btn9.ForeColor = btn8.ForeColor;
                                btn9.FlatAppearance.BorderSize = 3;

                                btn8.Text = "";
                                btn8.BackColor = clr;
                                btn8.ForeColor = clr;
                                btn8.FlatAppearance.BorderSize = 0;
                                Thread.Sleep(200);
                                break;
                            }

                    }
                    

                }

            }

            Array.Clear(MachineMove.path, 0, MachineMove.path.Length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace _8_Puzzle
{
    public partial class Puzzle : Form
    {
        List<string> path = new List<string>();
        BfsSearch bfs = new BfsSearch();
        AStar astar = new AStar();
        PQueue Pqueue = new PQueue();
      
      
        Thread trBFS, trFIRST, trPbfs,trAStar,trReset;
        Stopwatch sw = new Stopwatch();
        bool ResetRunner=false, BfsRunCheck= false, PbfsRunCheck = false, AstarRunCheck = false,ResetRunCheck=false;

        //*****************************************************

        public Puzzle()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            trFIRST = new Thread(new ThreadStart(myThread2));
            trFIRST.Start();
        }

        //********************************************************
        //設定移動button

        private void button1_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button1, button2, button4, panel1.BackColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button2, button1, button3, button5, panel1.BackColor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button3, button2, button6, panel1.BackColor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button4, button7, button5, button1, panel1.BackColor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button5, button8, button6, button4, button2, panel1.BackColor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button6, button9, button5, button3, panel1.BackColor);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button7, button8, button4, panel1.BackColor);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button8, button9, button7, button5, panel1.BackColor);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserMoveBtn.MoveBTN(button9, button8, button6, panel1.BackColor);
        }

        //*****************************************************

        ////******* BFS Search ********//
        private void btn_Start_Click(object sender, EventArgs e) 
        {
            if (!BfsRunCheck && !PbfsRunCheck && !AstarRunCheck)
            {
                ResetRunner = true;

                trFIRST.Abort();
                label3_Info.Font = new Font("微軟正黑體", 16);
                lbl_depth_ans.Text = 0.ToString();
                lbl_Gnodes_ans.Text = 0.ToString();
                lbl_Snodes_ans.Text = 0.ToString();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                bfs.queueArray.Clear();
                bfs.i = 0;
                bfs.j = 0;

                try
                {
                    bfs.PuzzleArrayFunc(button1, button2, button3, button4, button5, button6, button7, button8, button9);
                    if (bfs.Goal(bfs.queueArray[0].PuzzelStruct))
                    {
                        label3_Info.ForeColor = Color.LightSkyBlue;
                        label3_Info.Text = "Goal state !";
                        bfs.queueArray.Clear();

                    }
                    else
                    {

                        trBFS = new Thread(new ThreadStart(ThreadBFS));
                        trBFS.Start();
                        BfsRunCheck = true;

                        btn_Reset.ForeColor = Color.DarkRed;
                        btn_Reset.BackColor = Color.DarkGray;
                        btn_Reset.FlatAppearance.BorderColor = Color.Silver;
                        btn_Reset.Text = "Stop";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
   

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            
            Environment.Exit(Environment.ExitCode);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Time_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Snodes_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Info_Click(object sender, EventArgs e)
        {

        }

        private void Puzzle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Puzzle_Load(object sender, EventArgs e)
        {

        }



        

        //*****************************************************
        //A*
        private void btn_AStar_Click(object sender, EventArgs e)
        {
            if (!BfsRunCheck && !PbfsRunCheck && !AstarRunCheck)
            {
                ResetRunner = true;

                trFIRST.Abort();
                label3_Info.Font = new Font("微軟正黑體", 16);
                lbl_depth_ans.Text = 0.ToString();
                lbl_Gnodes_ans.Text = 0.ToString();
                lbl_Snodes_ans.Text = 0.ToString();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                astar.i = 0;
                astar.j = 0;
                 
                try
                {
                    astar.PuzzleArrayFunc(button1, button2, button3, button4, button5, button6, button7, button8, button9);
                    if (astar.Goal(Pqueue.Peek().PuzzleCLASS))
                    {
                        label3_Info.ForeColor = Color.LightSkyBlue;
                        label3_Info.Text = "Goal state !";
                        Pqueue.Clear();

                    }
                    else
                    {
                        trAStar = new Thread(new ThreadStart(ThreadAStar));
                        trAStar.Start();
                        AstarRunCheck = true;

                        btn_Reset.ForeColor = Color.DarkRed;
                        btn_Reset.BackColor = Color.DarkGray;
                        btn_Reset.FlatAppearance.BorderColor = Color.Silver;
                        btn_Reset.Text = "Stop";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //*****************************************************
        //Reset

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (ResetRunner)
            {
                if (BfsRunCheck) { trBFS.Abort();BfsRunCheck = false; }
                if (PbfsRunCheck) { trPbfs.Abort();PbfsRunCheck = false; }   
                if (AstarRunCheck) { trAStar.Abort(); AstarRunCheck = false; }
                if (ResetRunCheck) { trReset.Abort();ResetRunCheck = false; }

                btn_Reset.Text = "Reset";
                btn_Reset.BackColor = Color.Gray;
                btn_Reset.ForeColor = btn_Start.ForeColor;
                trFIRST = new Thread(new ThreadStart(myThread2));
                trFIRST.Start();
                lbl_depth_ans.Text = 0.ToString();
                lbl_Gnodes_ans.Text = 0.ToString();
                lbl_Snodes_ans.Text = 0.ToString();
                lbl_time_ans.Text = 0.ToString();
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                path.Clear();
                bfs.queueArray = new List<puzzeli>();
                bfs.PathList.Clear();
                bfs.i = 0;
                bfs.j = 0;

              


                Pqueue.Clear();
                astar.i = 0;
                astar.j = 0;
                astar.NodeNumber.Clear();
                PQueue.count = 0;
                
                GC.Collect();

                ResetRunner = false;
            }

        }
        //*****************************************************
        //Reset的顏色、閃爍設定
        void ThreadReset()
        {
            ResetRunCheck = true;
            btn_Reset.Text = "Reset";
            while (true)
            {
                btn_Reset.FlatAppearance.BorderColor = Color.Silver;
                btn_Reset.BackColor = Color.DarkGray;
                btn_Reset.ForeColor = Color.DarkGreen;
                Thread.Sleep(500);
                btn_Reset.FlatAppearance.BorderColor = Color.DarkGray;
                btn_Reset.BackColor = Color.Gray;
                btn_Reset.ForeColor = btn_Start.ForeColor;
                Thread.Sleep(500);
            }
        }
        //*****************************************************
        //A*的訊息
        void ThreadAStar()
        {
            List<string> temp;
            NodeAStar nodeResult;

            label3_Info.ForeColor = Color.DarkTurquoise;
            label3_Info.Text = "搜尋中 ...";
            sw.Start();
            nodeResult = astar.AstarSearch();
            label3_Info.Text = "你被電腦打敗了 <(￣︶￣)>";
            sw.Stop();

            lbl_time_ans.Text = sw.Elapsed.TotalMilliseconds.ToString() + "  ms";
            sw.Reset();

            temp = astar.PathFinder(nodeResult);
            foreach (UInt64 item in astar.NodeNumber)
            {
                listBox1.Items.Add(item);
            }

            foreach (string item in temp)
            {
                listBox2.Items.Add(item);
            }

           

            lbl_Snodes_ans.Text = astar.i.ToString();
            lbl_Gnodes_ans.Text = PQueue.count.ToString();
            lbl_depth_ans.Text = temp.Count.ToString();

            MachineMove.path = temp.ToArray();
            temp.Clear();

            label3_Info.ForeColor = Color.LightPink;
            label3_Info.Text = "你已放棄思考 (┛◉Д◉)┛彡┻━┻";
            Thread.Sleep(300);
            label3_Info.Text = "";
            Thread.Sleep(300);
            label3_Info.Text = "你已放棄思考 (┛◉Д◉)┛彡彡┻━┻";
            Thread.Sleep(300);
            label3_Info.Text = "";
            Thread.Sleep(300);
            label3_Info.Text = "你已放棄思考 (┛◉Д◉)┛彡彡彡┻━┻";

            label3_Info.ForeColor = Color.Cyan;
            label3_Info.Text = "看我Bang (~‾▿‾)~";
            Thread.Sleep(300);
            label3_Info.Text = "看我BangBang (~‾▿‾)~";
            Thread.Sleep(300);
            label3_Info.Text = "看我BangBangBang (~‾▿‾)~";            
            
            MachineMove.Action(button1, button2, button3, button4, button5, button6, button7, button8, button9, panel1.BackColor);
            label3_Info.ForeColor = Color.YellowGreen;
            label3_Info.Text = "你被電腦打敗了 <(￣︶￣)>";
            astar.NodeNumber.Clear();

            Pqueue.Clear();
            astar.i = 0;
            astar.j = 0;
            PQueue.count = 0;
            trReset = new Thread(new ThreadStart(ThreadReset));
            trReset.Start();

        }

        //*****************************************************

        


        

        //*****************************************************
        //BFS的訊息

        void ThreadBFS()
        {
            List<int> temp;

            label3_Info.ForeColor = Color.DarkTurquoise;
            label3_Info.Text = "搜尋中 ...";
            sw.Start();
            label3_Info.Text = bfs.BfsSearchFunction();
            sw.Stop();

            lbl_time_ans.Text = sw.Elapsed.TotalMilliseconds.ToString() + "  ms";
            sw.Reset();
            temp = bfs.PathFinder(bfs.i);
            foreach (var item in temp)
            {
                listBox1.Items.Add(item.ToString());
            }
            foreach (int item in temp)
            {
                listBox2.Items.Add(bfs.queueArray.ElementAt(item).ActionStruct);
                path.Add(bfs.queueArray.ElementAt(item).ActionStruct);
            }

            lbl_Snodes_ans.Text = bfs.i.ToString();
            lbl_Gnodes_ans.Text = bfs.queueArray.Count.ToString();
            lbl_depth_ans.Text = bfs.DepthFinder().ToString();

            MachineMove.path = path.ToArray();
            path.Clear();
            temp.Clear();

            label3_Info.ForeColor = Color.LightPink;
            label3_Info.Text = "你已放棄思考 (┛◉Д◉)┛彡┻━┻ ";
            Thread.Sleep(300);
            label3_Info.Text = "";
            Thread.Sleep(300);
            label3_Info.Text = "你已放棄思考 (┛◉Д◉)┛彡彡┻━┻ ";
            Thread.Sleep(300);
            label3_Info.Text = "";
            Thread.Sleep(300);
            label3_Info.Text = "你已放棄思考 (┛◉Д◉)┛彡彡彡┻━┻ ";
            label3_Info.ForeColor = Color.Cyan;
            label3_Info.Text = "看我Bang (~‾▿‾)~";
            Thread.Sleep(300);
            label3_Info.Text = "看我BangBang (~‾▿‾)~";
            Thread.Sleep(300);
            label3_Info.Text = "看我BangBangBang (~‾▿‾)~";
            
            MachineMove.Action(button1, button2, button3, button4, button5, button6, button7, button8, button9, panel1.BackColor);
            label3_Info.ForeColor = Color.YellowGreen;
            label3_Info.Text = "你被電腦打敗了 <(￣︶￣)> ";
            bfs.queueArray.Clear();
            bfs.PathList.Clear();
            bfs.i = 0;
            bfs.j = 0;

            trReset = new Thread(new ThreadStart(ThreadReset));
            trReset.Start();


        }

        //*****************************************************

        void myThread2()
        {
            label3_Info.ForeColor = Color.SkyBlue;
            label3_Info.Font = new Font("微軟正黑體", 14);
            while (true)
            {
                label3_Info.ForeColor = Color.SkyBlue;
                label3_Info.Font = new Font("微軟正黑體", 14);
                label3_Info.Text = "快點恢復原狀! ಠ ೧ ಠ";
                Thread.Sleep(1000);
                label3_Info.Text = "";
                Thread.Sleep(200);

            }
        }

        
    }
}

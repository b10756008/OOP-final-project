using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _8_Puzzle
{
    public struct puzzeli
    {
        public Int16[,] PuzzelStruct;
        public string ActionStruct;
    }

    //*****************************************************
    class BfsSearch
    {        
        public Int16[,] puzzle = new Int16[3,3];
        public List<puzzeli> queueArray = new List<puzzeli>();
        public List<int> PathList = new List<int>();
        puzzeli pz = new puzzeli();
        public int i = 0, j = 0;

        //*****************************************************

        public void PuzzleArrayFunc(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7, Button btn8, Button btn9)
        {            
            if (btn1.Text=="")//當button為空值的時候，該格位子等於0
            {
                puzzle[0, 0] = 0;
            }
            else
            {
                puzzle[0, 0] = Convert.ToInt16(btn1.Text);
            }

            if (btn2.Text == "")
            {
                puzzle[0, 1] = 0;
            }
            else
            {
                puzzle[0, 1] = Convert.ToInt16(btn2.Text);
            }

            if (btn3.Text == "")
            {
                puzzle[0, 2] = 0;
            }
            else
            {
                puzzle[0, 2] = Convert.ToInt16(btn3.Text);
            }

            if (btn4.Text == "")
            {
                puzzle[1, 0] = 0;
            }
            else
            {
                puzzle[1, 0] = Convert.ToInt16(btn4.Text);
            }

            if (btn5.Text == "")
            {
                puzzle[1, 1] = 0;
            }
            else
            {
                puzzle[1, 1] = Convert.ToInt16(btn5.Text);
            }

            if (btn6.Text == "")
            {
                puzzle[1, 2] = 0;
            }
            else
            {
                puzzle[1, 2] = Convert.ToInt16(btn6.Text);
            }

            if (btn7.Text == "")
            {
                puzzle[2, 0] = 0;
            }
            else
            {
                puzzle[2, 0] = Convert.ToInt16(btn7.Text);
            }

            if (btn8.Text == "")
            {
                puzzle[2, 1] = 0;
            }
            else
            {
                puzzle[2, 1] = Convert.ToInt16(btn8.Text);
            }

            if (btn9.Text == "")
            {
                puzzle[2, 2] = 0;
            }
            else
            {
                puzzle[2, 2] = Convert.ToInt16(btn9.Text);
            }

            pz.PuzzelStruct = puzzle;
            queueArray.Add(pz);
        }
        //*****************************************************
        public bool Goal(Int16[,] puzzleArray)//拼圖的目標
        {

            if (queueArray[i].PuzzelStruct == null)
            {
                return false;
            }
            else if (puzzleArray[0, 0] == 1 &&
                    puzzleArray[0, 1] == 2 &&
                    puzzleArray[0, 2] == 3 &&
                    puzzleArray[1, 0] == 4 &&
                    puzzleArray[1, 1] == 5 &&
                    puzzleArray[1, 2] == 6 &&
                    puzzleArray[2, 0] == 7 &&
                    puzzleArray[2, 1] == 8 &&
                    puzzleArray[2, 2] == 0)
            {
                return true;
            }

            return false;

        }
        //*****************************************************
        public string BfsSearchFunction()//BFS的搜尋控制
        {  
            while (Goal(queueArray[i].PuzzelStruct) == false)
            {
                if (queueArray[i].PuzzelStruct == null)
                {
                    if (i >= 1)
                    {
                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        for (int i = 0; i < 4; i++)
                        {
                            queueArray.Add(pz);
                        }
                    }
                    i++;

                }
                else
                {
                    addNode(queueArray[i].PuzzelStruct);
                    i++;
                }          
            }
                       
            return "Puzzle Solved!";
            
        }
        //*****************************************************

        public void addNode (Int16[,] puzzle)//
        {
            

            puzzeli puzzle8 = new puzzeli();
            string id = SearchArray((Int16[,])puzzle);
            Int16 temp;
            switch (id)
            {
                case "00":
                    {
                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1, 0];
                        puzzle8.PuzzelStruct[1, 0] = puzzle8.PuzzelStruct[0, 0];
                        puzzle8.PuzzelStruct[0, 0] = temp;
                        pz.PuzzelStruct= puzzle8.PuzzelStruct;
                        pz.ActionStruct= "下";
                        queueArray.Add(pz);

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])queueArray[i].PuzzelStruct.Clone();
                        temp = puzzle8.PuzzelStruct[0,1];
                        puzzle8.PuzzelStruct[0,1] = puzzle8.PuzzelStruct[0, 0];
                        puzzle8.PuzzelStruct[0, 0] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "右";
                        queueArray.Add(pz);
                        
                        break;
                    }
                case "01":
                    {
                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,1];
                        puzzle8.PuzzelStruct[1,1] = puzzle8.PuzzelStruct[0,1];
                        puzzle8.PuzzelStruct[0,1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "下";
                        queueArray.Add(pz);

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[0,0];
                        puzzle8.PuzzelStruct[0,0] = puzzle8.PuzzelStruct[0,1];
                        puzzle8.PuzzelStruct[0,1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "左";
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[0, 2];
                        puzzle8.PuzzelStruct[0, 2] = puzzle8.PuzzelStruct[0, 1];
                        puzzle8.PuzzelStruct[0, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "右";
                        queueArray.Add(pz);

        
                        break;
                    }
                case "02":
                    {
                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,2];
                        puzzle8.PuzzelStruct[1,2] = puzzle8.PuzzelStruct[0,2];
                        puzzle8.PuzzelStruct[0,2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "下";
                        queueArray.Add(pz);

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);


                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[0,1];
                        puzzle8.PuzzelStruct[0,1] = puzzle8.PuzzelStruct[0,2];
                        puzzle8.PuzzelStruct[0,2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "左";
                        queueArray.Add(pz);


                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);


                        break;
                    }
                case "10":
                    {
                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2,0];
                        puzzle8.PuzzelStruct[2,0] = puzzle8.PuzzelStruct[1,0];
                        puzzle8.PuzzelStruct[1,0] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "下";
                        queueArray.Add(pz);


                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[0,0];
                        puzzle8.PuzzelStruct[0,0] = puzzle8.PuzzelStruct[1, 0];
                        puzzle8.PuzzelStruct[1, 0] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "上";
                        queueArray.Add(pz);

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);


                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,1];
                        puzzle8.PuzzelStruct[1,1] = puzzle8.PuzzelStruct[1, 0];
                        puzzle8.PuzzelStruct[1, 0] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "右";
                        queueArray.Add(pz);


                        

                        break;
                    }
                case "11":
                    {
                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2,1];
                        puzzle8.PuzzelStruct[2,1] = puzzle8.PuzzelStruct[1,1];
                        puzzle8.PuzzelStruct[1, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "下";
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[0,1];
                        puzzle8.PuzzelStruct[0,1] = puzzle8.PuzzelStruct[1, 1];
                        puzzle8.PuzzelStruct[1, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "上";
                        queueArray.Add(pz);


                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1, 0];
                        puzzle8.PuzzelStruct[1, 0] = puzzle8.PuzzelStruct[1, 1];
                        puzzle8.PuzzelStruct[1, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "左";
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,2];
                        puzzle8.PuzzelStruct[1,2] = puzzle8.PuzzelStruct[1, 1];
                        puzzle8.PuzzelStruct[1, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "右";
                        queueArray.Add(pz);


                        break;
                    }
                case "12":
                    {
                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2,2];
                        puzzle8.PuzzelStruct[2,2] = puzzle8.PuzzelStruct[1,2];
                        puzzle8.PuzzelStruct[1, 2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "下";
                        queueArray.Add(pz);


                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[0,2];
                        puzzle8.PuzzelStruct[0,2] = puzzle8.PuzzelStruct[1, 2];
                        puzzle8.PuzzelStruct[1, 2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "上";
                        queueArray.Add(pz);

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);


                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,1];
                        puzzle8.PuzzelStruct[1,1] = puzzle8.PuzzelStruct[1, 2];
                        puzzle8.PuzzelStruct[1, 2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "左";
                        queueArray.Add(pz);


                        break;
                    }
                case "20":
                    {

                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,0];
                        puzzle8.PuzzelStruct[1, 0] = puzzle8.PuzzelStruct[2,0];
                        puzzle8.PuzzelStruct[2, 0] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "上";
                        queueArray.Add(pz);
             
                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2,1];
                        puzzle8.PuzzelStruct[2,1] = puzzle8.PuzzelStruct[2, 0];
                        puzzle8.PuzzelStruct[2, 0] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "右";
                        queueArray.Add(pz);
              
                        break;
                    }
                case "21":
                    {
                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,1];
                        puzzle8.PuzzelStruct[1,1] = puzzle8.PuzzelStruct[2,1];
                        puzzle8.PuzzelStruct[2, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "上";
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2, 0];
                        puzzle8.PuzzelStruct[2, 0] = puzzle8.PuzzelStruct[2, 1];
                        puzzle8.PuzzelStruct[2, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "左";
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2,2];
                        puzzle8.PuzzelStruct[2,2] = puzzle8.PuzzelStruct[2, 1];
                        puzzle8.PuzzelStruct[2, 1] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "右";
                        queueArray.Add(pz);


                        break;
                    }
                case "22":
                    {
                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[1,2];
                        puzzle8.PuzzelStruct[1,2] = puzzle8.PuzzelStruct[2,2];
                        puzzle8.PuzzelStruct[2, 2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "上";
                        queueArray.Add(pz);

                        puzzle8.PuzzelStruct = (Int16[,])(queueArray[i].PuzzelStruct).Clone();
                        temp = puzzle8.PuzzelStruct[2, 1];
                        puzzle8.PuzzelStruct[2, 1] = puzzle8.PuzzelStruct[2, 2];
                        puzzle8.PuzzelStruct[2, 2] = temp;
                        pz.PuzzelStruct = puzzle8.PuzzelStruct;
                        pz.ActionStruct = "左";
                        queueArray.Add(pz);


                        pz.PuzzelStruct = null;
                        pz.ActionStruct = null;
                        queueArray.Add(pz);

              
                        break;
                    }                
            }
        }
        //*****************************************************
        public string SearchArray(Int16[,] puzzleSearch)//尋找
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzleSearch[i, j] == 0)
                        return i.ToString() + j.ToString();//尋找代表的字串
                }
            }
            return "";
        }
        //*****************************************************
        public List<int> PathFinder(int node)//把走過的路徑加到清單
        {
            if (node == i)
            {
                PathList.Add(i);
                j++;
            }

            if(node>4)
            {
                j++;
                float temp = ((float)node) / 4;
                int root = (int)(temp - 0.25);
                PathList.Add(root);
                PathFinder(root);
            }

            return PathList;            
        }
        //*****************************************************
        public int DepthFinder()
        {
            return j;
        }
    }
}

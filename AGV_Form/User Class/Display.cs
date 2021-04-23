using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGV_Form
{
    class Display
    {
        public static string Mode;
        public static Color LineColor;
        public static float LineWidth;
        public static Point[] Points = new Point[2];
        public static Label[] LabelAGV = new Label[AGV.MaxNumOfAGVs]; // LabelAGV[i] for AGV ID = i
        public static Label[] SimLabelAGV = new Label[AGV.MaxNumOfAGVs];


        public static void AddPath(Panel panel, List<int> path, List<Node> Nodes, Color color, float width)
        {
            LineColor = color;
            LineWidth = width;
            List<Point> listPoint = new List<Point>();
            for (int i = 0; i < path.Count; i++)
            {
                listPoint.Add(new Point(Nodes[path[i]].X, Nodes[path[i]].Y));
            }
            Points = listPoint.ToArray();
            panel.Refresh();
        }
        public static void UpdateListViewAGVs(ListView listView, List<AGV> listData)
        {
            listView.Items.Clear();
           
                
                foreach (AGV agv in listData)
                {
                    listView.Items.Add("AGV#" + agv.ID, 0);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(agv.Status);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(agv.CurrentNode.ToString());
                    listView.Items[listView.Items.Count - 1].SubItems.Add(agv.CurrentOrient.ToString());
                    listView.Items[listView.Items.Count - 1].SubItems.Add(agv.DistanceToCurrentNode.ToString());
                    listView.Items[listView.Items.Count - 1].SubItems.Add(agv.Velocity.ToString());
                if (agv.Status == "Running")
                    listView.Items[listData.IndexOf(agv)].BackColor = Color.PaleGreen;
                else
                    listView.Items[listData.IndexOf(agv)].BackColor = Color.White;
            }
                
            
        }
        public static Point SimUpdatePositionAGV(int agvID, int speed)
        {
            
            var index = AGV.SimListAGV.FindIndex(a => a.ID == agvID);
            AGV agv = AGV.SimListAGV[index];
            //List<char> fullpath = AGV.FullPathOfAGV[agvID].ToList();
            
            string[] frameArr = AGV.FullPathOfAGV[agvID].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            
            Point oldPosition = Display.SimLabelAGV[agvID].Location;
            Point newPosition = new Point();

            int indexNode = Array.FindIndex(frameArr, a => a == agv.CurrentNode.ToString()); ;
            if (frameArr[indexNode + 1] == "G"|| frameArr[indexNode + 1] == null )
            {
                       
                if (agv.Path.Count() != 0)
                {
                    
                    AGV.FullPathOfAGV[agvID] = Navigation.GetNavigationFrame(agv.Path[0], Node.MatrixNodeOrient);
                    //agv.Path.RemoveAt(0);
                }
                else
                {
                    agv.Status = "Stop";
                }
                        
                    // agv.CurrentOrient = Display.UpdateOrient(frameArr[indexNode + 1]);
                



            }
            else
            {
                int currentNode = agv.CurrentNode;
                int nextNode = Convert.ToInt32(frameArr[indexNode + 2]);
                if (agv.CurrentOrient != Display.UpdateOrient(frameArr[indexNode + 1]))
                {
                    agv.DistanceToCurrentNode -= 5;
                    if(agv.DistanceToCurrentNode <=0)
                    {
                        agv.CurrentOrient = Display.UpdateOrient(frameArr[indexNode + 1]);
                        agv.DistanceToCurrentNode = 0;
                    }
                    
                }
                else
                {

                    agv.DistanceToCurrentNode += 5;
                    if (agv.DistanceToCurrentNode >= Node.MatrixNodeDistance[currentNode, nextNode])
                    {
                        agv.DistanceToCurrentNode = 0;
                        agv.CurrentNode = nextNode;
                        if (frameArr[indexNode + 3] != "G")
                            agv.CurrentOrient = Display.UpdateOrient(frameArr[indexNode + 3]);
                    }
                    agv.Status = "Running";
                }
            }
            
            List<Node> Nodes = DBUtility.GetDataFromDB<List<Node>>("NodeInfoTable");
            int x = Nodes[agv.CurrentNode].X - 50 / 2;
            int y = Nodes[agv.CurrentNode].Y - 50 / 2;
            switch (agv.CurrentOrient)
            {
                case 'E':
                    newPosition = new Point(x + agv.DistanceToCurrentNode, y);
                    break;
                case 'W':
                    newPosition = new Point(x - agv.DistanceToCurrentNode, y);
                    break;
                case 'S':
                    newPosition = new Point(x, y + agv.DistanceToCurrentNode);
                    break;
                case 'N':
                    newPosition = new Point(x, y - agv.DistanceToCurrentNode);
                    break;
                default: newPosition = oldPosition;
                    break;
            }

            return newPosition;
        }

        public static char UpdateOrient(string direction)
        {
            char orient = new char();
            
            switch (direction)
            {
                case "E":
                
                    orient = 'E';
                    break;
                case "W":
             
                    orient = 'W';
                    break;
                case "S":
                
                    orient = 'S';
                    break;
                case "N":
               
                    orient = 'N';
                    break;
                
            }
            return orient;
        }

        public static void GoUp(int agvID)
        {
            int x = SimLabelAGV[agvID].Location.X;
            int y = SimLabelAGV[agvID].Location.Y;
            SimLabelAGV[agvID].Location = new Point(x, y+3);

        }
        public static void AddLabelAGV(string Mode,int agvID, int initExitNode, char initOrientation, int initDistanceToExitNode)
        {
            Label lbAGV = new Label();
            lbAGV.BackColor = SystemColors.ActiveCaption;
            lbAGV.Font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                                                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbAGV.Size = new Size(50, 50);
            lbAGV.ForeColor = Color.Black;
            lbAGV.Text = "AGV#" + agvID.ToString();
            lbAGV.TextAlign = ContentAlignment.MiddleCenter;
            lbAGV.Name = "AGV" + agvID.ToString();

            // Init the Location of new AGV
            List<Node> Nodes = DBUtility.GetDataFromDB<List<Node>>("NodeInfoTable");
            int x = Nodes[initExitNode].X - lbAGV.Size.Width / 2;
            int y = Nodes[initExitNode].Y - lbAGV.Size.Height / 2;
            switch (initOrientation)
            {
                case 'E':
                    lbAGV.Location = new Point(x + initDistanceToExitNode, y);
                    break;
                case 'W':
                    lbAGV.Location = new Point(x - initDistanceToExitNode, y);
                    break;
                case 'N':
                    lbAGV.Location = new Point(x, y - initDistanceToExitNode);
                    break;
                case 'S':
                    lbAGV.Location = new Point(x, y + initDistanceToExitNode);
                    break;
            }
            // Add to Array for use
            switch (Mode)
            {
                case "Real Time":
                    LabelAGV[agvID] = lbAGV;                    
                    break;
                case "Simulation":
                    SimLabelAGV[agvID] = lbAGV;                    
                    break;
            }
        }

        public static void RemoveLabelAGV(string Mode,int agvID)
        {
            //var label = panel.Controls.OfType<Label>().FirstOrDefault(lb => lb.Name == "AGV" + agvID.ToString());
            
                //panel.Controls.Remove(label);
                //label.Dispose();

                switch (Mode)
                {
                    case "Real Time":
                        Array.Clear(LabelAGV, agvID, 1);
                        break;
                    case "Simulation":
                        Array.Clear(SimLabelAGV, agvID, 1);
                        break;
                }
            
        }
        public static void UpdateComStatus(int ID, Color messageColor)
        {
            HomeScreenForm.colorComStatus.Add(messageColor);
            string timeNow = DateTime.Now.ToString(" h:mm:ss.fff tt");
            if(ID == 1)
            {
                HomeScreenForm.textComStatus.Add(timeNow + " ID: "+ ID.ToString() + "asdfasdfasdfasfasdfasdfasdfasdfasdfsdfasdfasdfasdfasdfsadfasdfasdf\n");
            }
            else if (ID == 2)
            {
                HomeScreenForm.textComStatus.Add(timeNow + " ID: " + ID.ToString() + "\n");
            }
        }
        public static void UpdateListViewTasks(ListView listView, List<Task> listData)
        {
            listView.Items.Clear();
            foreach (Task task in listData)
            {                                 
                    listView.Items.Add(task.Name, 1);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(task.Status);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(task.Type);
                    listView.Items[listView.Items.Count - 1].SubItems.Add("AGV#" + task.AGVID.ToString());
                    listView.Items[listView.Items.Count - 1].SubItems.Add("Node " + task.PickNode.ToString());
                    listView.Items[listView.Items.Count - 1].SubItems.Add("Node " + task.DropNode.ToString());
                    listView.Items[listView.Items.Count - 1].SubItems.Add(task.Priority);
                    listView.Items[listView.Items.Count - 1].SubItems.Add(task.PalletCode);
                    if (task.Status == "Doing")
                        listView.Items[listData.IndexOf(task)].BackColor = Color.PaleGreen;
                    else
                        listView.Items[listData.IndexOf(task)].BackColor = Color.White;
                
            }
        }
    }
}

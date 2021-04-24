using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_Form
{
    class Task
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string PalletCode { get; set; }
        public int AGVID { get; set; }
        public int PickNode { get; set; }
        public int DropNode { get; set; }
        public int PickLevel { get; set; }
        public int DropLevel { get; set; }
        public string Status { get; set; }

        // Constructor of Task
        public Task(string name, string type, string palletCode,
                    int agvID, int pickNode, int dropNode, int pickLevel, int dropLevel, string status)
        {
            this.Name = name;
            this.Type = type;
            this.PalletCode = palletCode;
            this.AGVID = agvID;
            this.PickNode = pickNode;
            this.DropNode = dropNode;
            this.PickLevel = pickLevel;
            this.DropLevel = dropLevel;
            this.Status = status;
        }

        // Information list of real-time Task
        public static List<Task> ListTask = new List<Task>();

        // Information list of simulation Task
        public static List<Task> SimListTask = new List<Task>();

        public static List<Task> SimHistoryTask = new List<Task>();
        public static void SimUpdatePathFromTaskOfAGVs(AGV agv)
        {

            // Clear all path (this do not affect Task.SimListTask)
            //agv.Tasks.Clear();

            // Find all task of this AGV
            //agv.Tasks = Task.SimListTask.FindAll(t => t.AGVID == agv.ID);&& agv.Path.Count ==0

            // if not having task or path has been initialized, skip to next AGV
            if (agv.Tasks.Count != 0  )
            {
                Task currentTask = agv.Tasks[0];

                //agv.Path.RemoveAt(0);agv.CurrentNode != currentTask.PickNode &&
                if ( currentTask.Status == "Waiting")
                {
                    agv.Path.Add(Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.CurrentNode, agv.Tasks[0].PickNode));
                    
                    agv.Tasks[0].Status = "Doing";
                }
                else if(agv.CurrentNode == currentTask.PickNode)
                {
                    agv.Path.RemoveAt(0);
                    agv.Path.Add(Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv.CurrentNode, agv.Tasks[0].DropNode));
                }
                else if(agv.CurrentNode == currentTask.DropNode && agv.DistanceToCurrentNode == 0 && currentTask.Status == "Doing" )
                {
                            
                             agv.Tasks.RemoveAt(0);
                             agv.Path.Clear();
                             Task.SimListTask.Remove(currentTask);
                }
                       
                        
            }            
        }

        public static void OutputAutoAdd(string palletCode, List<Task> listTaskToAdd, List<AGV> listAGV, List<RackColumn> listColumn)
        {
            // auto select agv
            //if (SimlistAGV.Count == 0) return;
            int agvID = 1;

            // find pick node & level
            RackColumn col = listColumn.Find(c => c.PalletCodes.Contains(palletCode));
            int pickNode = col.AtNode;
            int pickLevel = Array.IndexOf(col.PalletCodes, palletCode) + 1;

            // select drop node (output1 or output2)
            int dropNode = agvID % 2 == 1 ? 51 : 52;

            Task newTask = new Task("Auto " + palletCode, "Output", palletCode, agvID, pickNode, dropNode, pickLevel, 1, "Waiting");
            listTaskToAdd.Add(newTask);
        }

    }
}

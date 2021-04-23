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
        public string Priority { get; set; }
        public string PalletCode { get; set; }
        public int AGVID { get; set; }
        public int PickNode { get; set; }
        public int DropNode { get; set; }
        public string Status { get; set; }

        // Constructor of Task
        public Task(string name, string type, string priority, string palletCode,
                    int agvID, int pickNode, int dropNode, string status)
        {
            this.Name = name;
            this.Type = type;
            this.Priority = priority;
            this.PalletCode = palletCode;
            this.AGVID = agvID;
            this.PickNode = pickNode;
            this.DropNode = dropNode;
            this.Status = status;
        }

        // Information list of real-time Task
        public static List<Task> ListTask = new List<Task>();

        // Information list of simulation Task
        public static List<Task> SimListTask = new List<Task>();
        public static void AddFirstPathOfAGVs(AGV agv)
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
                else if(agv.CurrentNode == currentTask.DropNode)
                {
                            
                             agv.Tasks.Remove(currentTask);
                             agv.Path.Clear();
                             Task.SimListTask.Remove(currentTask);
                }
                        
                        
            }            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_Form
{
    class Collision
    {
        public static int node1, node2;
        public static double dis1, dis2;
        private static int i = 0;
        private static string path_tam;
        private static int hisNode = 0;
        private static int CollisionType = 0;
        private static int agv1_node = 0;
        public static void DetectColission(AGV agv1, AGV agv2)
        {
            
            if (AGV.SimListAGV.Count < 2) return;
           // AGV agv1 = AGV.SimListAGV[0];
           
               // AGV agv2 = AGV.SimListAGV[1];
            double t1 = 0, t2 = 0, dt = 0;

            int agv1_nextNode=0 , agv1_nextNode_1=0 ;
            int agv1_index;
            
            if (agv1.Path.Count == 0) return;
            int goal1 = agv1.Path[0][agv1.Path[0].Count-1];
            try 
            {
                agv1_index = agv1.Path[0].FindIndex(p => p == agv1.CurrentNode);
                agv1_node = agv1.Path[0][agv1_index - 1];
                agv1_nextNode = agv1.Path[0][agv1_index + 1];
                agv1_nextNode_1 = agv1.Path[0][agv1_index + 2];
                // node1 = agv1_nextNode;
            }
            catch { }


            if (agv2.Path.Count == 0) return;
            int goal2 = agv2.Path[0][agv2.Path[0].Count - 1];

            int agv2_nextNode=0, agv2_nextNode_1=0;
            int agv2_index;
            if (agv2.Path.Count == 0) return;
            try
            {
                agv2_index = agv2.Path[0].FindIndex(p => p == agv2.CurrentNode);
                agv2_nextNode = agv2.Path[0][agv2_index + 1];
                agv2_nextNode_1 = agv2.Path[0][agv2_index + 2];
                // node2 = agv2_nextNode;
            }
            catch { }

            

            if (agv1_nextNode == agv2_nextNode ) // va cham cheo
            {
                if (agv1_nextNode_1 != agv2.CurrentNode && agv2_nextNode_1 != agv1.CurrentNode)
                {
                    List<Node> Nodes = DBUtility.GetDataFromDB<List<Node>>("NodeInfoTable");
                    int x = Nodes[agv1_nextNode].X;
                    int y = Nodes[agv1_nextNode].Y;
                    int x1 = Nodes[agv1.CurrentNode].X;
                    int y1 = Nodes[agv1.CurrentNode].Y;
                    int x2 = Nodes[agv2.CurrentNode].X;
                    int y2 = Nodes[agv2.CurrentNode].Y;
                    double d1 = 0, d2 = 0;
                    switch (agv1.CurrentOrient)
                    {
                        case 'E':
                            d1 = Math.Sqrt(Math.Pow(x - x1 - agv1.DistanceToCurrentNode, 2) + Math.Pow(y - y1, 2));
                            break;
                        case 'W':
                            d1 = Math.Sqrt(Math.Pow(x - x1 + agv1.DistanceToCurrentNode, 2) + Math.Pow(y - y1, 2));
                            break;
                        case 'S':
                            d1 = Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1 - agv1.DistanceToCurrentNode, 2));
                            break;
                        case 'N':
                            d1 = Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1 + agv1.DistanceToCurrentNode, 2));
                            break;
                    }

                    switch (agv2.CurrentOrient)
                    {
                        case 'E':
                            d2 = Math.Sqrt(Math.Pow(x - x2 - agv2.DistanceToCurrentNode, 2) + Math.Pow(y - y2, 2));
                            break;
                        case 'W':
                            d2 = Math.Sqrt(Math.Pow(x - x2 + agv2.DistanceToCurrentNode, 2) + Math.Pow(y - y2, 2));
                            break;
                        case 'S':
                            d2 = Math.Sqrt(Math.Pow(x - x2, 2) + Math.Pow(y - y2 - agv2.DistanceToCurrentNode, 2));
                            break;
                        case 'N':
                            d2 = Math.Sqrt(Math.Pow(x - x2, 2) + Math.Pow(y - y2 + agv2.DistanceToCurrentNode, 2));
                            break;
                    }

                    t1 = d1 / agv1.Velocity;
                    t2 = d2 / agv2.Velocity;
                    // dt = Math.Abs(t1 - t2);
                    if (d1 < 160 && agv1.CurrentOrient != agv2.CurrentOrient)
                    {
                        agv1.IsColision = false;
                        agv2.IsColision = true;
                        agv2.Status = "Pausing";
                        CollisionType = 1;
                    }
                    else if (d2 < 160 && agv1.CurrentOrient != agv2.CurrentOrient)
                    {
                        agv1.Status = "Pausing";
                        agv1.IsColision = true;
                        agv2.IsColision = false;
                        CollisionType = 1;
                    }
                    dis1 = d1;
                    dis2 = d2;
                }
                else if (agv1_nextNode_1 == agv2.CurrentNode && agv2_nextNode_1 != agv1.CurrentNode)
                {
                   
                    
                        agv1.IsColision = true;
                        agv2.IsColision = false;
                        CollisionType = 1;
                        agv1.Status = "Pausing";
                   
                    
                }
                else if (agv1_nextNode_1 != agv2.CurrentNode && agv2_nextNode_1 == agv1.CurrentNode)
                {
                   
                  
                        agv1.IsColision = false;
                        agv2.IsColision = true;
                        CollisionType = 1;
                        agv2.Status = "Pausing";
                   
                }
                else if(agv1_nextNode_1 == agv2.CurrentNode && agv2_nextNode_1 == agv1.CurrentNode)
                        {
                    int instead_node = GotoNodeNeibor(agv1.CurrentNode,goal2);
                    Debug.WriteLine(instead_node.ToString());

                    List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, instead_node);
                    //path_tam = AGV.FullPathOfAGV[1];
                    AGV.FullPathOfAGV[1] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                    CollisionType = 2;
                    agv1.Status = "Avoid";
                }
               
                //i=1;
            }
            else if (agv1_nextNode == agv2.CurrentNode && agv2_nextNode == agv1.CurrentNode)
            {
                int instead_node = GotoNodeNeibor(agv1.CurrentNode, goal2);
                Debug.WriteLine(instead_node.ToString());

                List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, instead_node);
                //path_tam = AGV.FullPathOfAGV[1];
                AGV.FullPathOfAGV[1] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                CollisionType = 2;
                agv1.Status = "Avoid";
            }

            else
            {
                if(CollisionType ==2 )
                {
                    int node_ss = GotoNodeNeibor(agv2.CurrentNode,goal1);
                    if(agv1.CurrentNode == node_ss)
                    { 
                        List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, goal1);
                        AGV.FullPathOfAGV[1] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                        AGV.SimListAGV[0].PathCopmpleted = 1;
                        CollisionType = 0;
                        agv1.Status = "Running";
                    }
                    
                }
                if (CollisionType == 3)
                {
                    int node_ss = GotoNodeNeibor(agv1.CurrentNode,goal2);
                    if (agv2.CurrentNode == node_ss)
                    {
                        List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv2.CurrentNode, goal2);
                        AGV.FullPathOfAGV[2] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                        AGV.SimListAGV[1].PathCopmpleted = 1;
                        CollisionType = 0;
                    }

                }
                if (CollisionType ==1)
                {
                    agv1.IsColision = false;
                    agv2.IsColision = false;
                    CollisionType = 0;
                    agv1.Status = "Running";
                    agv1.Status = "Running";
                }
                
                //i = 0;
            }
            
        }
        private static int GotoNodeNeibor(int currentNode,int goal)
        {
            int min_distance = 10000;
            int node = 0;
            foreach (RackColumn rack in RackColumn.ListColumn)
            {
                if(rack.AtNode != goal)
                {
                    int distance = 0;
                    List<int> path = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, currentNode, rack.AtNode);
                    for (int i = 0; i < path.Count - 2; i++)
                    {

                        int dx = Math.Abs(Node.ListNode[path[i + 1]].X - Node.ListNode[path[i]].X);
                        int dy = Math.Abs(Node.ListNode[path[i + 1]].Y - Node.ListNode[path[i]].Y);
                        distance += (int)Math.Sqrt(dx * dx + dy * dy);

                    }
                    if (distance < min_distance)
                    {
                        min_distance = distance;
                        node = rack.AtNode;
                    }
                }
                
                
            }
            return node;
        }
    }
}

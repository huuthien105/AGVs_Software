using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_Form
{
    class RealCollision
    {
            //public static int CollisionType = 0;
    public static int[] CollisionType = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            public static int[] goal = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            public static int[] goal_type45 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            public static int[] goal_type23 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            public static string OldDrop = null;
            public static void DetectColission(AGV agv1, AGV agv2, int type)
            {

            #region Load nexnode of each AGV
            int agv1_nextNode = 0, agv1_nextNode_1 = 0;
                int agv1_index = 0;
                try
                {
                    goal[agv1.ID] = agv1.Path[0][agv1.Path[0].Count - 1];
                    agv1_index = agv1.Path[0].FindIndex(p => p == agv1.CurrentNode);
                }
                catch { }
                try
                {
                    agv1_nextNode = agv1.Path[0][agv1_index + 1];
                }
                catch { }
                try
                {
                    agv1_nextNode_1 = agv1.Path[0][agv1_index + 2];
                }
                catch { }

                int agv2_nextNode = 0, agv2_nextNode_1 = 0;
                int agv2_index = 0;
                try
                {
                    agv2_index = agv2.Path[0].FindIndex(p => p == agv2.CurrentNode);
                    goal[agv2.ID] = agv2.Path[0][agv2.Path[0].Count - 1];
                }
                catch { }
                try
                {
                    agv2_nextNode = agv2.Path[0][agv2_index + 1];
                }
                catch { }
                try
                {
                    agv2_nextNode_1 = agv2.Path[0][agv2_index + 2];
                }
                catch { }
            #endregion

                #region AGV1 STOP AND AGV2 RUNNING
                if (agv1.Stop && !agv2.Stop)
                    {
                        float deltaDistance = (float)Math.Sqrt(Math.Pow(Node.ListNode[agv1.CurrentNode].X - Node.ListNode[agv1_nextNode].X, 2) +
                                              Math.Pow(Node.ListNode[agv1.CurrentNode].Y - Node.ListNode[agv1_nextNode].Y, 2));


                        Node.MatrixNodeDistance = Node.CreateAdjacencyMatrix(Node.ListNode);

                        int[,] d = Node.MatrixNodeDistance;
                        if (agv1.DistanceToCurrentNode < 20.0)
                        {
                            foreach (string adj in Node.ListNode[agv1.CurrentNode].AdjacentNode)
                            {
                                int i = Convert.ToInt32(adj);
                                d[agv1.CurrentNode, i] = 10000;
                                d[i, agv1.CurrentNode] = 10000;

                            }
                            foreach (string adj in Node.ListNode[agv1.CurrentNode].AdjacentNode)
                            {
                                int i = Convert.ToInt32(adj);
                                if (agv2_nextNode == i)
                                {
                                    List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, d, agv2.CurrentNode, goal[agv2.ID]);
                                    agv2.Path[0] = newpath;
                                    string drop = 
                                    AGV.FullPathOfAGV[agv2.ID] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                                }
                            }

                        }
                        else if (agv1.DistanceToCurrentNode > (deltaDistance / 2 - 20.0))
                        {
                            foreach (string adj in Node.ListNode[agv1_nextNode].AdjacentNode)
                            {
                                int i = Convert.ToInt32(adj);
                                d[agv1_nextNode, i] = 10000;
                                d[i, agv1_nextNode] = 10000;



                            }
                            foreach (string adj in Node.ListNode[agv1_nextNode].AdjacentNode)
                            {
                                int i = Convert.ToInt32(adj);
                                if (agv2_nextNode == i)
                                {
                                    List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, d, agv2.CurrentNode, goal[agv2.ID]);
                                    agv2.Path[0] = newpath;
                                    AGV.FullPathOfAGV[agv2.ID] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                                }
                            }


                        }
                        else if (agv1.DistanceToCurrentNode > 20.0 && agv1.DistanceToCurrentNode < (deltaDistance / 2 - 20.0))
                        {
                            d[agv1.CurrentNode, agv1_nextNode] = 100000;
                            d[agv1_nextNode, agv1.CurrentNode] = 100000;
                            if (agv2.CurrentNode == agv1_nextNode || agv2.CurrentNode == agv1.CurrentNode)
                            {
                                List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, d, agv2.CurrentNode, goal[agv2.ID]);
                                agv2.Path[0] = newpath;
                                AGV.FullPathOfAGV[2] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                            }
                        }

                        return;
                    }
                    #endregion
                #region AGV1 RUNNING AND AGV2 STOP
                else if (!agv1.Stop && agv2.Stop)
                {
                    float delta2Distance = (float)Math.Sqrt(Math.Pow(Node.ListNode[agv2.CurrentNode].X - Node.ListNode[agv2_nextNode].X, 2) +
                                          Math.Pow(Node.ListNode[agv2.CurrentNode].Y - Node.ListNode[agv2_nextNode].Y, 2));


                    Node.MatrixNodeDistance = Node.CreateAdjacencyMatrix(Node.ListNode);

                    int[,] d2 = Node.MatrixNodeDistance;
                    if (agv2.DistanceToCurrentNode < 20.0)
                    {
                        foreach (string adj in Node.ListNode[agv2.CurrentNode].AdjacentNode)
                        {
                            int i = Convert.ToInt32(adj);
                            d2[agv2.CurrentNode, i] = 10000;
                            d2[i, agv2.CurrentNode] = 10000;

                        }
                        foreach (string adj in Node.ListNode[agv2.CurrentNode].AdjacentNode)
                        {
                            int i = Convert.ToInt32(adj);
                            if (agv2_nextNode == i)
                            {
                                List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, d2, agv1.CurrentNode, goal[agv1.ID]);
                                agv1.Path[0] = newpath;
                                OldDrop = SplitDrop(AGV.FullPathOfAGV[1]);

                                AGV.FullPathOfAGV[1] = "N-0-"+agv1.CurrentOrient+"-"+Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient)+"-"+OldDrop;
                                SendPath2AGV();
                            }
                        }
                    }
                    else if (agv2.DistanceToCurrentNode > (delta2Distance / 2 - 20.0))
                    {
                        foreach (string adj in Node.ListNode[agv2_nextNode].AdjacentNode)
                        {
                            int i = Convert.ToInt32(adj);
                            d2[agv2_nextNode, i] = 10000;
                            d2[i, agv2_nextNode] = 10000;

                        }
                        foreach (string adj in Node.ListNode[agv2_nextNode].AdjacentNode)
                        {
                            int i = Convert.ToInt32(adj);
                            if (agv1_nextNode == i)
                            {
                                List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, d2, agv1.CurrentNode, goal[agv1.ID]);
                                agv1.Path[0] = newpath;
                                OldDrop = SplitDrop(AGV.FullPathOfAGV[1]);
                                AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-" + OldDrop;
                            SendPath2AGV();
                        }
                        }
                    }
                    else if (agv2.DistanceToCurrentNode > 20.0 && agv2.DistanceToCurrentNode < (delta2Distance / 2 - 20.0))
                    {
                        d2[agv2.CurrentNode, agv2_nextNode] = 100000;
                        d2[agv2_nextNode, agv2.CurrentNode] = 100000;
                        if (agv1.CurrentNode == agv2_nextNode || agv1.CurrentNode == agv2.CurrentNode)
                        {
                            List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, d2, agv1.CurrentNode, goal[agv1.ID]);
                            agv1.Path[0] = newpath;
                             OldDrop = SplitDrop(AGV.FullPathOfAGV[1]);
                            AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-" + OldDrop;
                        SendPath2AGV();
                    }
                    }

                    return;
                }
                #endregion
                else if (agv1.Stop && agv2.Stop)
                {
                    Node.MatrixNodeDistance = Node.CreateAdjacencyMatrix(Node.ListNode);
                    return;
                }

                Node.MatrixNodeDistance = Node.CreateAdjacencyMatrix(Node.ListNode);
                if (agv2.CurrentNode == goal[agv1.ID] && CollisionType[type] == 0)
                {
                    Debug.WriteLine("ABC");
                    if (agv1_nextNode == goal[agv1.ID])
                    {
                        int instead_node = GotoNodeNeibor(agv1.CurrentNode, agv2.CurrentOrient, goal[agv1.ID]);

                        List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, instead_node);
                        OldDrop = SplitDrop(AGV.FullPathOfAGV[1]);
                        
                        AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-N-0" ;
                        SendPath2AGV();
                        goal_type45[agv1.ID] = goal[agv1.ID];
                        agv1.Path[0] = newpath;
                        CollisionType[type] = 4;
                        agv1.Status = "Waitting";
                    }

                }
                else if (agv1.CurrentNode == goal[agv2.ID] && CollisionType[type] == 0)
                {
                    if (agv2_nextNode == goal[agv2.ID])
                    {
                        int instead_node = GotoNodeNeibor(agv2.CurrentNode, agv1.CurrentOrient, goal[agv2.ID]);

                        List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv2.CurrentNode, instead_node);
                        AGV.FullPathOfAGV[agv2.ID] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                        goal_type45[agv2.ID] = goal[agv2.ID];
                        agv2.Path[0] = newpath;
                        CollisionType[type] = 5;
                        agv2.Status = "Waitting";
                    }
                }
                else if (agv1_nextNode == agv2_nextNode) // va cham cheo
                {

                    if (agv1_nextNode_1 != agv2.CurrentNode && agv2_nextNode_1 != agv1.CurrentNode && CollisionType[type] == 0)
                    {

                        List<Node> Nodes = DBUtility.GetDataFromDB<List<Node>>("NodeInfoTable");
                        int x = Nodes[agv1_nextNode].X;
                        int y = Nodes[agv1_nextNode].Y;
                        int x1 = Nodes[agv1.CurrentNode].X;
                        int y1 = Nodes[agv1.CurrentNode].Y;
                        int x2 = Nodes[agv2.CurrentNode].X;
                        int y2 = Nodes[agv2.CurrentNode].Y;
                        double d1 = 0, d2 = 0;
                        #region TINH KHOANG CACH D1 VA D2
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
                        #endregion
                        if (d1 < 100 && agv1.CurrentOrient != agv2.CurrentOrient && CollisionType[type] == 0)
                        {
                            agv1.IsColision = false;
                            agv2.IsColision = true;
                            agv2.Status = "Pausing";
                            CollisionType[type] = 1; // agv 1 chay agv2 dung
                        }
                        else if (d2 < 100 && agv1.CurrentOrient != agv2.CurrentOrient && CollisionType[type] == 0)
                        {
                            agv1.Status = "Pausing";
                            agv1.IsColision = true;
                            StopAGV();
                            agv2.IsColision = false;
                            CollisionType[type] = 2;// agv2 chay agv 1 dung
                        }

                    }
                    else if (agv1_nextNode_1 == agv2.CurrentNode && agv2_nextNode_1 != agv1.CurrentNode && CollisionType[type] == 0)
                    {

                        agv1.IsColision = true;
                        StopAGV();
                        agv2.IsColision = false;
                        CollisionType[type] = 2;
                        agv1.Status = "Pausing";


                    }
                    else if (agv1_nextNode_1 != agv2.CurrentNode && agv2_nextNode_1 == agv1.CurrentNode && CollisionType[type] == 0)
                    {


                        agv1.IsColision = false;
                        agv2.IsColision = true;
                        CollisionType[type] = 1;
                        agv2.Status = "Pausing";

                    }
                    else if (agv1_nextNode_1 == agv2.CurrentNode && agv2_nextNode_1 == agv1.CurrentNode && CollisionType[type] == 0)
                    {
                        int instead_node = GotoNodeNeibor(agv1.CurrentNode, agv2.CurrentOrient, goal[agv2.ID]);


                        List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, instead_node);
                            OldDrop = SplitDrop(AGV.FullPathOfAGV[1]);
                        AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-N-0";
                    
                        SendPath2AGV();
                        goal_type23[agv1.ID] = goal[agv1.ID];
                        agv1.Path[0] = newpath;
                        CollisionType[type] = 3;
                        agv1.Status = "Avoid";

                    }
                    else
                    {
                        double delta = 0;// khoang cach giua AGV1 vaf AGV 2
                        List<Node> Nodes = DBUtility.GetDataFromDB<List<Node>>("NodeInfoTable");
                        int x1 = Nodes[agv1.CurrentNode].X;
                        int y1 = Nodes[agv1.CurrentNode].Y;
                        int x2 = Nodes[agv2.CurrentNode].X;
                        int y2 = Nodes[agv2.CurrentNode].Y;
                        Point L1 = new Point();
                        Point L2 = new Point();
                        #region Tinh toa do hien tai cua moi AGV
                        switch (agv1.CurrentOrient)
                        {
                            case 'E':
                                L1 = new Point(x1 + (int)agv1.DistanceToCurrentNode, y1);
                                break;
                            case 'W':
                                L1 = new Point(x1 - (int)agv1.DistanceToCurrentNode, y1);
                                break;
                            case 'S':
                                L1 = new Point(x1, y1 + (int)agv1.DistanceToCurrentNode);
                                break;
                            case 'N':
                                L1 = new Point(x1, y1 + (int)agv1.DistanceToCurrentNode);
                                break;
                        }

                        switch (agv2.CurrentOrient)
                        {
                            case 'E':
                                L2 = new Point(x2 + (int)agv2.DistanceToCurrentNode, y2);
                                break;
                            case 'W':
                                L2 = new Point(x2 - (int)agv2.DistanceToCurrentNode, y2);
                                break;
                            case 'S':
                                L2 = new Point(x2, y2 + (int)agv2.DistanceToCurrentNode);
                                break;
                            case 'N':
                                L2 = new Point(x2, y2 + (int)agv2.DistanceToCurrentNode);
                                break;
                        }
                        #endregion
                        delta = Math.Sqrt(Math.Pow(L2.X - L1.X, 2) + Math.Pow(L2.Y - L1.Y, 2));
                        Debug.WriteLine(delta.ToString());
                        if (CollisionType[type] == 1 && delta < 140)
                        {
                            if (agv2.DistanceToCurrentNode > 0)
                                agv2.DistanceToCurrentNode -= 2;
                        }
                        else if (CollisionType[type] == 2 && delta < 140)
                        {
                            if (agv1.DistanceToCurrentNode > 0)
                                agv1.DistanceToCurrentNode -= 2;
                        }
                    }
                }
                else if (agv1_nextNode == agv2.CurrentNode && agv2_nextNode == agv1.CurrentNode && CollisionType[type] == 0)
                {
                    int instead_node = GotoNodeNeibor(agv1.CurrentNode, agv2.CurrentOrient, goal[agv2.ID]);


                    List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, instead_node);
                    OldDrop = SplitDrop(AGV.FullPathOfAGV[1]);
                    AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-N-0";
                    SendPath2AGV();
                    goal_type23[agv1.ID] = goal[agv1.ID];
                    agv1.Path[0] = newpath;
                    CollisionType[type] = 3;
                    agv1.Status = "Avoid";
                }

                else
                {

                    if (CollisionType[type] == 3)
                    {
                        if (agv2.CurrentNode == agv1.Path[0][0])
                        {
                            Debug.WriteLine("ABCDEFG");
                            List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, goal_type23[agv1.ID]);
                            AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-" +OldDrop;
                            SendPath2AGV();
                            agv1.PathCopmpleted = 1;
                            agv1.Path[0] = newpath;
                            CollisionType[type] = 0;
                            agv1.Status = "Running";

                        }

                    }
                    else if (CollisionType[type] == 4)
                    {
                        if (agv2.CurrentNode != goal_type45[agv1.ID])
                        {
                            List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv1.CurrentNode, goal_type45[agv1.ID]);
                            AGV.FullPathOfAGV[1] = "N-0-" + agv1.CurrentOrient + "-" + Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient) + "-" + OldDrop;
                            SendPath2AGV();
                            agv1.PathCopmpleted = 1;
                            agv1.Path[0] = newpath;
                            CollisionType[type] = 0;
                            agv1.Status = "Running";

                        }
                    }
                    else if (CollisionType[type] == 5)
                    {

                        if (agv1.CurrentNode != goal_type45[agv2.ID])
                        {
                            List<int> newpath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, agv2.CurrentNode, goal_type45[agv2.ID]);
                            AGV.FullPathOfAGV[agv2.ID] = Navigation.GetNavigationFrame(newpath, Node.MatrixNodeOrient);
                            agv2.PathCopmpleted = 1;
                            agv2.Path[0] = newpath;
                            CollisionType[type] = 0;
                            agv2.Status = "Running";

                        }
                    }
                    else if (CollisionType[type] == 2)
                    {

                        agv1.IsColision = false;
                        RunAGV();
                        CollisionType[type] = 0;
                        agv1.Status = "Running";
                    }
                    else if (CollisionType[type] == 1)
                    {
                        agv2.IsColision = false;
                        CollisionType[type] = 0;
                        agv2.Status = "Running";
                    }


                    //i = 0;
                }

            }
            public static int GotoNodeNeibor(int currentNode, char conflictOrient, int goal)
            {
                int min_distance = 10000;
                int node = 0;
                char orient = 'A';
                //List<int> conflictPath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, currentNode, conflictNode);
                switch (conflictOrient)
                {
                    case 'W':
                        orient = 'E';
                        break;
                    case 'E':
                        orient = 'W';
                        break;
                    case 'S':
                        orient = 'N';
                        break;
                    case 'N':
                        orient = 'S';
                        break;
                }


                foreach (RackColumn rack in RackColumn.ListColumn)
                {
                    if (rack.AtNode != goal)
                    {
                        List<int> conflictPath = Algorithm.A_starFindPath(Node.ListNode, Node.MatrixNodeDistance, currentNode, rack.AtNode);
                        string pathConflict = Navigation.GetNavigationFrame(conflictPath, Node.MatrixNodeOrient);
                        if (orient != pathConflict[3])
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

                }
                return node;
            }
            public static void SendPath2AGV()
            {
                AGV agv = AGV.ListAGV[0]; 
                

                Communication.SendPathData(AGV.FullPathOfAGV[agv.ID]);
                Debug.WriteLine(AGV.FullPathOfAGV[agv.ID]);
                Display.UpdateComStatus("send", agv.ID, "Send Path 1", Color.Green);
                
            }
            public static void StopAGV()
            {

            }
            public static void RunAGV()
            {

            }
        public static string SplitDrop(string fullpath)
        {
            string drop = null;
            
            for(int i = fullpath.Length-3;i<fullpath.Length;i++)
            {
                drop += fullpath[i];
            }
            return drop;
        }
        public static int ReturnToNodeForward(int currentNode)
            {
                int min_distance = 10000;
                int node = 0;


                foreach (RackColumn rack in RackColumn.ListColumn)
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
                return node;
            }
        }
    }




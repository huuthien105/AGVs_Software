using System;
using System.Collections.Generic;
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
        public static void DetectColission()
        {
            
            if (AGV.SimListAGV.Count < 2) return;
            AGV agv1 = AGV.SimListAGV[0]; 
            AGV agv2 = AGV.SimListAGV[1];
            double t1 = 0, t2 = 0, dt = 0;

            int agv1_nextNode=0 , agv1_nextNode_1=0 ;
            int agv1_index;
            if (agv1.Path.Count == 0) return;
            try 
            {
                agv1_index = agv1.Path[0].FindIndex(p => p == agv1.CurrentNode);
                agv1_nextNode = agv1.Path[0][agv1_index + 1];
                agv1_nextNode_1 = agv1.Path[0][agv1_index + 2];
                // node1 = agv1_nextNode;
            }
            catch { }
           
      
               

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
           
            if (agv1_nextNode == agv2_nextNode && agv1_nextNode_1 != agv2.CurrentNode && agv2_nextNode_1!= agv1.CurrentNode ) // va cham cheo
            {
                //agv1.IsColision = true;
                //if (i == 1) return;
                //int pixelDistance = (int)Math.Round();
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
                // t1 = d1 / agv1.Velocity;
                // t2 = d2 / agv2.Velocity;
                // dt = Math.Abs(t1 - t2);
                if (d1 < 160 && agv1.CurrentOrient != agv2.CurrentOrient)
                {
                    agv1.IsColision = false;
                    agv2.IsColision = true;
                }
                else if(d2 < 160 && agv1.CurrentOrient != agv2.CurrentOrient)
                {
                    agv1.IsColision = true;
                    agv2.IsColision = false;
                }
                dis1 = d1;
                dis2 = d2;
                //i=1;
            }
            else if (agv1_nextNode == agv2_nextNode && agv1_nextNode_1 == agv2.CurrentNode && agv2_nextNode_1 == agv1.CurrentNode)
            { }
            else
            {
                agv1.IsColision = false;
                agv2.IsColision = false;
                //i = 0;
            }
            
        }
    }
}

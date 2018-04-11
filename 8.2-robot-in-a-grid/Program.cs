using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._2_robot_in_a_grid
{
    /*Imagine a robot sitting on the upper left corner of grid with r rows and c columns. The robot can only move in two directions, right and down
    but certain cells are off limits such that the robot cannot step on them. Design an algorithm to find a path for the robot from the top left to bottom right
    THOUGHTS:   Only need to find a path, not count ways to get there. Brute force solution would be to start at the end and recursively travel 
                up and left until we hit the start point, storing locations on the way. This results in many re-computations; ie. at point r,c.
                We move to r-1,c or r,c-1. From either spot, we have to pathfind to either (r-2,c), (r-1,c-1), (r-1,c-1), and (r,c-2). Observe that
                (r-1,c-1) shows up twice, hence the recomputation.
                Lets try to eliminate that recomputation. 
                Lets introduce a map of some sort to cache points that we've been to*/
    class Program
    {
        public class Point{
            int x;
            int y;
            public Point(int row, int col){this.x = col; this.y = row;}
        }

        public IList<Point> GetPath(bool[,] map){
            IList<Point> path = new List<Point>();
            HashSet<Point> visited = new HashSet<Point>();
            if(GetPath(map, map.GetLength(0) - 1, map.GetLength(1) - 1, visited, path)) return path;
            else return null;
        }

        bool GetPath(bool[,] map, int row, int col, HashSet<Point> visited, IList<Point> path){
            //base case
            if (row < 0 || col < 0 || !map[row,col]) return false;
            Point here = new Point(row, col);
            //if we've seen this point before, 
            if (visited.Contains(here)){
                return false;
            }
            //if we're at origin, or there exists a path from the start to here, add the current point
            if((row == 0 && col == 0) || GetPath(map, row - 1, col, visited, path) || GetPath(map, row, col - 1, visited, path){
                path.Add(here);
                return true;
            }
            //else we're at a point that doesn't contain a path, add it to visited so we can remember not to visit here
            visited.Add(here);
            return false;

        }
        public 
        static void Main(string[] args)
        {
        }
    }
}

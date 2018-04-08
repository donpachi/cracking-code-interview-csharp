using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._7_build_order
{
    /*given a list of projects and their dependencies (list of pairs of projects, second project being dependent on the first)
    Find a build order that will allow the projects to be built if all a projects dependencies must be built before the project. 
    If no valid build order exists, return an error
    THOUGHTS:
    Lets create a custom exception for fun
    Immediately, I think that for a projec to even start, there must be a node that has no dependency, otherwise it would be impossible
    (throw exception). Lets start by looking for all projects that have no dependencies, and build those. Each time we build a project,
    We can eliminate it from the dependencies from all other projects, and then from there build the projects that have no dependencies.
    Keep doing this cyclicly until we have visited all the nodes. (Graph traversal) If nodes are left with no way to build them (cyclic)
    throw error.
    
    To make object referencing and such more readable, lets represent this graph through object reference representation.

    SIDE THOUGHT: This also might be solveable using DFS...? lets try after iterative approach
    ASSUMPTIONS: 
        -We have access to such a data structure project, where each project keeps track of its dependencies and the number of dependencies
        -input is given to us via string, so lets parse the string and build a graph (cant expect created graph to be given to us)  */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Projects{
        class Project{
            IList<Project> dependencies = new List<Project>();
            Dictionary<string, Project> projectMap = new Dictionary<string, Project>();
            public string Name{get; set;}
            int numDependencies = 0;
            public Project(string name){
                Name = name;
            }

            public void AddDependency(Project project){
                //note here that I could use a hashset (and get rid of the list and dictionary) if i created my own GetHashCode implementation
                if(!projectMap.ContainsKey(project.Name)){
                    dependencies.Add(project);
                    projectMap.Add(project.Name, project);
                    numDependencies++;
                }
            }
        }
    }
}

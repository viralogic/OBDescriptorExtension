using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBabel;

namespace OBDescriptorExtension
{
    public class Search
    {
        public static void DepthLimitedSearch(OBAtom atom, int depth, List<OBAtom> path, ref List<IEnumerable<OBAtom>> foundPaths)
        {
            path.Add(atom);
            if (depth >= 0)
            {
                if (depth == 0)
                {
                    foundPaths.Add(path);
                }
                else
                {
                    var neighbors = atom.Neighbors().Where(n => !path.Select(v => v.GetIdx()).Contains(n.GetIdx()));
                    foreach (var neighbor in neighbors)
                    {
                        var pathArray = new OBAtom[path.Count()];
                        path.CopyTo(pathArray);
                        Search.DepthLimitedSearch(neighbor, depth - 1, pathArray.ToList(), ref foundPaths);
                    }
                }
            }
        }
    }
}

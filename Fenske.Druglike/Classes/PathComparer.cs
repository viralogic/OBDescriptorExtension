using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBDescriptorExtension;

namespace OBDescriptorExtension
{
    public class PathComparer : IEqualityComparer<Path>
    {
        public bool Equals(Path x, Path y)
        {
            return
                (x.PathAtoms.Count() == y.PathAtoms.Count()) &&
                (x.StartAtom.GetIdx() == y.StartAtom.GetIdx() || x.StartAtom.GetIdx() == y.EndAtom.GetIdx()) &&
                (x.EndAtom.GetIdx() == y.StartAtom.GetIdx() || x.EndAtom.GetIdx() == y.EndAtom.GetIdx()) &&
                (x.PathAtoms.All(a => y.PathAtoms.Select(j => j.GetIdx()).Contains(a.GetIdx())));
        }

        public int GetHashCode(Path obj)
        {
            return obj.PathAtoms.Select(i => i.GetIdx().GetHashCode()).Sum();
        }
    }
}

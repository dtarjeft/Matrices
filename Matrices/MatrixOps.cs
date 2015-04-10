using System.Collections.Generic;

namespace Matrices
{
    public static class MatrixOps
    {
        public static Dictionary<int[], double> ShortestPath(Matrix m, int startNodeInd)
        {
            var res = new Matrix(m.XDim, m.YDim, m.MatrixArr);
            var resDict = new Dictionary<int[], double>();
            var connectedList = new List<int> { startNodeInd - 1 };
            var done = false;
            while (!done)
            {
                done = true;
                var nextLoc = new[] { 0, 0 };
                foreach (var i in connectedList) // Find the minimum non-connected value.
                {
                    for (var j = 0; j < m.YDim; j++)
                    {
                        if (connectedList.Contains(j)) continue; // Skip columns that are already connected.
                        if (res[i, j] >= res[nextLoc[0], nextLoc[1]]) continue;
                        nextLoc[0] = i;
                        nextLoc[1] = j;
                    }
                }
                if (connectedList.Contains(nextLoc[0]) && connectedList.Contains(nextLoc[1]))
                {
                    res[nextLoc[0], nextLoc[1]] += m.MaxValue;
                    done = false;
                    continue;
                }
                connectedList.Add(nextLoc[1]);
                resDict.Add(new[] { nextLoc[0], nextLoc[1] }, res[nextLoc[0], nextLoc[1]]);

                for (var i = 0; i < m.XDim; i++)
                {
                    if (connectedList.Contains(i)) continue;
                    done = false;
                }
            }
            return resDict;
        }
    }
}
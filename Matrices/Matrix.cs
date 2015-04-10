using System;

namespace Matrices
{
    public class Matrix
    {
        public int XDim { get; set; }
        public int YDim { get; set; }
        public double[,] MatrixArr { get; set; }
        public Matrix(int xDim, int yDim,double[,] numList = null)
        {
            XDim = xDim;
            YDim = yDim;
            MatrixArr = new double[XDim, YDim];
            if (numList != null)
            {
                MatrixArr = numList;
            }
            else
            {
                for (var i0 = 0; i0 < MatrixArr.GetLength(0); i0++)
                    for (var i1 = 0; i1 < MatrixArr.GetLength(1); i1++)
                    {
                        this[i0, i1] = 0.0;
                    }
            }
        }

        public double this[int x, int y]
        {
            get { return MatrixArr[x,y]; }
            set { MatrixArr[x, y] = value; }
        }
        public static Matrix operator *(Matrix thisMatrix, Matrix thatMatrix)
        {
            if (thatMatrix == null) throw new ArgumentNullException("thatMatrix");
            // May need to add in checks for illegal matrices at some point.. Certainly shouldn't let them vote. Yee-haw.
            var result = new Matrix(thisMatrix.XDim, thatMatrix.YDim);
            for (var i = 0; i < result.XDim; i++)
            {
                for (var j = 0; j < result.YDim; j++)
                {
                    var sum = 0.0;
                    for (var k = 0; k < thatMatrix.XDim; k++)
                    {
                        sum += thisMatrix[i, k] * thatMatrix[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix thisMatrix, Matrix thatMatrix)
        {
            var xMin = (thisMatrix.XDim < thatMatrix.XDim ? thisMatrix.XDim : thatMatrix.XDim);
            var yMin = (thisMatrix.YDim < thatMatrix.YDim ? thisMatrix.YDim : thatMatrix.YDim);
            var result = new Matrix(xMin, yMin);
            for (var i = 0; i < xMin; i++)
            {
                for (var j = 0; j < yMin; j++)
                {
                    result[i, j] = thisMatrix[i, j] + thatMatrix[i, j];
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix thisMatrix, double scalar)
        {
            var result = new Matrix(thisMatrix.XDim, thisMatrix.YDim);
            for (var i = 0; i < thisMatrix.XDim; i++)
            {
                for (var j = 0; j < thisMatrix.YDim; j++)
                {
                    result[i, j] = thisMatrix[i, j] + scalar;
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix thisMatrix, double scalar)
        {
            return thisMatrix + (-1 * scalar);
        }

        public bool PopulateMatrix(double[,] input)
        {
            if (input.GetLength(0) != XDim || input.GetLength(1) != YDim) return false;
            MatrixArr = input;
            return true;
        }

        public double MaxValue
        {
            get
            {
                double max = 0;
                foreach (var d in MatrixArr)
                {
                    if (d > max)
                    {
                        max = d;
                    }
                }
                return max;
            } 
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < XDim; i++)
            {
                for (var j = 0; j < YDim; j++)
                {
                    result += (this[i, j]+ " ");
                }
                result +="\n";
            }
            return result;
        }
    }
}

using System;

namespace Neural_Network___Function_Plotter.Utils
{
    public static class MathUtils
    {
        public static double TransferFunction(double x)
        {
            //For this fction the input vals must be scaled to fit in (-1, 1)
            //Obv, the output vals will be in the range of (-1, 1)
            return Math.Tanh(x);
        }

        public static double TransferFunctionDerivative(double x)
        {
            return 1.0 - Math.Tanh(x) * Math.Tanh(x);
        }
    }
}
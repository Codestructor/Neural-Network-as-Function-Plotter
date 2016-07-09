using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network___Function_Plotter
{
    class Connection
    {
        public double weight;
        public double deltaWeight;
    }

    class Neuron
    {
        //Constructor
        public Neuron(int numOutputs, int myIndex, Random rand)
        {
            //Does not include the bias neuron as it receives no inputs
            for (int c = 0; c < numOutputs; c++) //c -> connection
            {
                Connection con = new Connection();
                if (rand.Next(0, 9999) % 2 == 0)
                    con.weight = rand.NextDouble();
                else
                    con.weight = -rand.NextDouble();
                m_outputWeights.Add(con);
                //Console.WriteLine(con.weight.ToString());
            }

            m_myIndex = myIndex;
        }

        //Public
        public static double eta = 0.1;
        /*
         * 0.0 - slow learner
         * 0.2 - medium learner
         * 1.0 - reckless learner
         */
        public static double alpha = 0.3;
        /*
         * 0.0 - no momentum
         * 0.5 - moderate momentum
         */
        public void setInputVal(double val) { m_input = val; }

        public void setOutputVal(double val) { m_outputVal = val; }

        public double getOutputVal() { return m_outputVal; }

        public double getInputVal() { return m_input; }

        public Connection getConnection(int index) { return m_outputWeights[index]; }

        public void calcOutputGradients(double targetVal)
        {
            double delta = targetVal - m_outputVal;
            m_gradient = delta * Neuron.transferFunctionDerivative(m_input);
        }

        public void calcHiddenGradient(Layer nextLayer)
        {
            double dow = sumDOW(nextLayer);
            m_gradient = dow * Neuron.transferFunctionDerivative(m_input);
        }

        public void updateInputWeights(Layer prevLayer)
        {
            for (int n = 0; n < prevLayer.neuronsList.Count(); n++)
            {
                Neuron neuron = prevLayer.neuronsList[n];
                double oldDeltaWeight = neuron.getConnection(m_myIndex).deltaWeight;

                //eta = overall learning rate
                //alpha = momentum -> adds a fraction of the previous deltaweight
                double newDeltaWeight = eta * neuron.getInputVal() * m_gradient + alpha * oldDeltaWeight;

                neuron.m_outputWeights[m_myIndex].deltaWeight = newDeltaWeight;
                neuron.m_outputWeights[m_myIndex].weight += newDeltaWeight;
            }
        }

        public void feedForward(Layer prevLayer)
        {
            m_input = 0.0;

            for (int n = 0; n < prevLayer.neuronsList.Count(); n++)
            {
                m_input += prevLayer.neuronsList[n].getOutputVal() * prevLayer.neuronsList[n].getConnection(m_myIndex).weight;
            }

            m_outputVal = Neuron.transferFunction(m_input);
        }

        //Private
        private double m_input;
        private double m_outputVal;
        private double m_gradient;
        private int m_myIndex;
        private List<Connection> m_outputWeights = new List<Connection>();

        private static double transferFunction(double x)
        {
            //For this fction the input vals must be scaled to fit in (-1, 1)
            //Obv, the output vals will be in the range of (-1, 1)
            return Math.Tanh(x);
        }

        private static double transferFunctionDerivative(double x)
        {
            return 1.0 - Math.Tanh(x) * Math.Tanh(x);
        }

        private double sumDOW(Layer nexLayer)
        {
            double sum = 0.0;

            //Sum our contributions of the errors at the nodes we feed
            for (int n = 0; n < nexLayer.neuronsList.Count() - 1; n++)
            {
                sum += m_outputWeights[n].weight * nexLayer.neuronsList[n].m_gradient;
            }

            return sum;
        }
    }
}

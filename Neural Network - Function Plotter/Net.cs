using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural_Network___Function_Plotter
{
    public class Net
    {
        public Net(List<int> topology)
        {
            int numLayers = topology.Count();
            Random rand = new Random();

            for (int layerNum = 0; layerNum < numLayers; layerNum++)
            {
                int numOutputs;
                if (layerNum == numLayers - 1)
                    numOutputs = 0;
                else
                    numOutputs = topology[layerNum + 1];
                //Console.WriteLine("Layer number {0}", layerNum);
                Layer layer = new Layer(topology[layerNum], numOutputs, rand);
                m_layers.Add(layer);
            }

            nrInputs = topology[0];
            nrOutputs = topology[numLayers - 1];
        }

        //Public
        public int nrInputs;
        public int nrOutputs;

        public void feedForward(List<double> inputVals)
        {
            if (inputVals.Count() != m_layers[0].neuronsList.Count() - 1)
                return;

            //Assign the input values into the input neurons
            for (int i = 0; i < inputVals.Count(); i++)
            {
                m_layers[0].neuronsList[i].setOutputVal(inputVals[i]);
            }

            //Forward propagate
            for (int layerNum = 1; layerNum < m_layers.Count(); layerNum++)
            {
                Layer prevLayer = m_layers[layerNum - 1];
                for (int n = 0; n < m_layers[layerNum].neuronsList.Count() - 1; n++)
                {
                    m_layers[layerNum].neuronsList[n].feedForward(prevLayer);
                }
            }
        }

        public void backProp(List<double> targetVals)
        {
            //Calculate overall net error (RMS = Root-Mean-Square of output neuron errors)
            Layer outputLayer = m_layers[m_layers.Count() - 1];
            m_error = 0.0; //overall error of the net (RMS)

            for (int n = 0; n < outputLayer.neuronsList.Count() - 1; n++)
            {
                double delta = targetVals[n] - outputLayer.neuronsList[n].getOutputVal();
                m_error += delta * delta;
            }

            m_error /= 2;

            /*
             * Let the cost function be C=1/2sum((aj-t)^2)
             * Then dC/daj=aj-t
             */

            /*m_error /= outputLayer.neuronsList.Count() - 1;
            m_error = Math.Sqrt(m_error); //RMS*/

            //Calculate output layer gradients
            for (int n = 0; n < outputLayer.neuronsList.Count() - 1; n++)
            {
                outputLayer.neuronsList[n].calcOutputGradients(targetVals[n]);
            }

            //Calculate gradients on hidden layers
            for (int layerNum = m_layers.Count() - 2; layerNum > 0; layerNum--)
            {
                Layer hiddenLayer = m_layers[layerNum];
                Layer nextLayer = m_layers[layerNum + 1];

                for (int n = 0; n < hiddenLayer.neuronsList.Count(); n++)
                    hiddenLayer.neuronsList[n].calcHiddenGradient(nextLayer);
            }

            //For all layers, from outputs to 1st hidden layer, update connection weights
            for (int layerNum = m_layers.Count() - 1; layerNum > 0; layerNum--)
            {
                Layer layer = m_layers[layerNum];
                Layer prevLayer = m_layers[layerNum - 1];

                for (int n = 0; n < layer.neuronsList.Count() - 1; n++)
                {
                    layer.neuronsList[n].updateInputWeights(prevLayer);
                }
            }

        }

        public void getResults(List<double> resultVals)
        {
            resultVals.Clear();

            Layer endLayer = m_layers[m_layers.Count() - 1];

            for (int n = 0; n < endLayer.neuronsList.Count() - 1; n++)
            {
                resultVals.Add(endLayer.neuronsList[n].getOutputVal());
            }
        }

        //Private
        private List<Layer> m_layers = new List<Layer>();
        private double m_error;
    }
}
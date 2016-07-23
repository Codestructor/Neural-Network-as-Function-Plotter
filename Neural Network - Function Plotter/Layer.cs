using System;
using System.Collections.Generic;

namespace Neural_Network___Function_Plotter
{
    public class Layer
    {
        public List<Neuron> neurons = new List<Neuron>();

        public Layer(int neuronsNum, int numOutputs, Random rand)
        {
            //<= for it adds a bias neuron, too

            for (int neuronNum = 0; neuronNum <= neuronsNum; neuronNum++)
            {
                Neuron neuron = new Neuron(numOutputs, neuronNum, rand);
                neurons.Add(neuron);
            }

            neurons[neuronsNum].Output = 1.0;
            neurons[neuronsNum].Input = 1.0;
        }
    }
}
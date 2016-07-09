using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network___Function_Plotter
{
    class Layer
    {
        //Constructor
        public Layer(int neuronsNum, int numOutputs, Random rand)
        {
            //<= for it adds a bias neuron, too

            for (int neuronNum = 0; neuronNum <= neuronsNum; neuronNum++)
            {
                Neuron neuron = new Neuron(numOutputs, neuronNum, rand);
                neuronsList.Add(neuron);
                //Console.WriteLine("Added Neuron ({0})", neuronNum);
            }

            neuronsList[neuronsNum].setOutputVal(1.0);
            neuronsList[neuronsNum].setInputVal(1.0);
        }

        //Public
        public List<Neuron> neuronsList = new List<Neuron>();
    }
}

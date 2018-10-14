using Moq;
using RestrictedBoltzmannMachine.ConnectionNamespace;
using RestrictedBoltzmannMachine.NeuronNamespace;
using System;
using System.Collections.Generic;
using Xunit;

namespace RestrictedBoltzmannMachineTest
{
    public class NeuronTests
    {
        [Fact]
        public void Construction_ValuesPassed_PropertiesProperlySet()
        {
            var neuron = new Neuron(false, 1.11);

            Assert.Equal(false, neuron.State);
            Assert.Equal(1.11, Math.Round(neuron.Bias, 2));
        }

        [Fact]
        public void AddInputNeuron_NeuronPassed_InputProperlySet()
        {
            var neuron = new Neuron(false, 1.11);
            var inputNeuron = new Mock<INeuron>();
            var mockList = new List<IConnection>();
            inputNeuron.SetupGet(x => x.Outputs).Returns(mockList);

            neuron.AddInputNeuron(inputNeuron.Object, 3.33);

            Assert.Equal(1, neuron.Inputs.Count);
            Assert.Equal(inputNeuron.Object, neuron.Inputs[0].InputNeruon);
            Assert.Equal(neuron, neuron.Inputs[0].OutputNeruon);
            Assert.Equal(3.33, neuron.Inputs[0].Weight);
        }

        [Fact]
        public void AddOutputNeuron_NeuronPassed_InputProperlySet()
        {
            var neuron = new Neuron(false, 1.11);
            var outputNeuron = new Mock<INeuron>();
            var mockList = new List<IConnection>();
            outputNeuron.SetupGet(x => x.Inputs).Returns(mockList);

            neuron.AddOutputNeuron(outputNeuron.Object, 3.33);

            Assert.Equal(1, neuron.Outputs.Count);
            Assert.Equal(outputNeuron.Object, neuron.Outputs[0].OutputNeruon);
            Assert.Equal(neuron, neuron.Outputs[0].InputNeruon);
            Assert.Equal(3.33, neuron.Outputs[0].Weight);
        }
    }
}

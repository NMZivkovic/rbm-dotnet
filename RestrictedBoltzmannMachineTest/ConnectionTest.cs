using Moq;
using RestrictedBoltzmannMachine.ConnectionNamespace;
using RestrictedBoltzmannMachine.NeuronNamespace;
using System;
using Xunit;

namespace RestrictedBoltzmannMachineTest
{
    public class ConnectionTest
    {
        [Fact]
        public void Construction_ValidParamsPassed_PropertiesProperlySet()
        {
            var inputNeuron = new Mock<INeuron>();
            var outputNeuron = new Mock<INeuron>();

            var connection = new Connection(1.11, inputNeuron.Object, outputNeuron.Object);

            Assert.Equal(1.11, connection.Weight);
            Assert.Equal(inputNeuron.Object, connection.InputNeruon);
            Assert.Equal(outputNeuron.Object, connection.OutputNeruon);
        }

        [Fact]
        public void UpdateWeights_PositiveGradient_WeightUpdatedProperly()
        {
            var inputNeuron = new Mock<INeuron>();
            inputNeuron.Setup(x => x.State).Returns(true);

            var outputNeuron = new Mock<INeuron>();
            outputNeuron.Setup(x => x.State).Returns(true);

            var connection = new Connection(1.11, inputNeuron.Object, outputNeuron.Object);
            connection.UpdateWeight(0.11);

            Assert.Equal(1.22, Math.Round(connection.Weight, 2));
        }

        [Fact]
        public void UpdateWeights_NegativeGradient_WeightUpdatedProperly()
        {
            var inputNeuron = new Mock<INeuron>();
            inputNeuron.Setup(x => x.CDState).Returns(true);

            var outputNeuron = new Mock<INeuron>();
            outputNeuron.Setup(x => x.CDState).Returns(true);

            var connection = new Connection(1.11, inputNeuron.Object, outputNeuron.Object);
            connection.UpdateWeight(0.11);

            Assert.Equal(1, connection.Weight);
        }
    }
}

using Moq;
using RestrictedBoltzmannMachine.LayerNamespace;
using RestrictedBoltzmannMachine.NeuronNamespace;
using System.Collections.Generic;
using Xunit;

namespace RestrictedBoltzmannMachineTest
{
    public class LayerTest
    {
        [Fact]
        public void Construction_ValuesPassed_ObjectProperlyInitialized()
        {
            var layer = new TestLayer(3);
            Assert.Equal(3, layer.Neurons.Count);
        }

        [Fact]
        public void ConnectLayers_TwoTestLayers_LayersConnected()
        {
            var layer1 = new TestLayer(3);
            var layer2 = new TestLayer(1);
            layer1.ConnectLayers(layer2);

            Assert.Single(layer1.Neurons[0].Outputs);
            Assert.Equal(3, layer2.Neurons[0].Inputs.Count);
        }
    }
}

using RestrictedBoltzmannMachine.LayerNamespace;
using Xunit;

namespace RestrictedBoltzmannMachineTest
{
    public class VisibleLayerTests
    {
        [Fact]
        public void PushValuesToInput_ArrayOfBools_StateOfVisibleItemsChanged()
        {
            var layer = new VisibleLayer(3);
            bool[] input = { true, false, true };

            layer.PushValuesToInput(input);

            Assert.True(layer.Neurons[0].State);
            Assert.False(layer.Neurons[1].State);
            Assert.True(layer.Neurons[2].State);
        }
    }
}

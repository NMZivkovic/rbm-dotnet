using RestrictedBoltzmannMachine.LayerNamespace;
using System.Linq;

namespace RestrictedBoltzmannMachine
{
    public class RBM
    {
        private HiddenLayer _hiddenLayer;
        private VisibleLayer _visibleLayer;
        private float _learningRate;

        public RBM(int hiddenLayerSize, int visibleLayerSize, float learningRate)
        {
            _learningRate = learningRate;
            _hiddenLayer = new HiddenLayer(hiddenLayerSize);
            _visibleLayer = new VisibleLayer(visibleLayerSize);

            _visibleLayer.ConnectLayers(_hiddenLayer);
        }

        public void Train(bool[][] input, int numberOfIterations)
        {
            for (int n = 0; n < numberOfIterations; n++)
            {
                for (int i = 0; i < input.GetLength(1); i++)
                {
                    _visibleLayer.PushValuesToInput(input[i]);
                    _hiddenLayer.CalculateState();
                    _visibleLayer.CalculateCDState();
                    _hiddenLayer.CalculateCDState();

                    UpdateWeights();
                }
            }
        }

        private void UpdateWeights()
        {
            foreach(var inputNeuron in _visibleLayer.Neurons)
            {
                inputNeuron.Outputs.ForEach(x => x.UpdateWeight(_learningRate));
            }
        }
    }
}

using System;

namespace RestrictedBoltzmannMachine.Functions
{
    public class Sigmoid
    {
        private double _coeficient;

        public Sigmoid(double coeficient)
        {
            _coeficient = coeficient;
        }

        public double CalculateOutput(double input)
        {
            return (1 / (1 + Math.Exp(-input * _coeficient)));
        }
    }
}

namespace NetCoreExamples.NewFeatures._6
{
    public class ReadOnlyAutoproperties
    {
        public const float PIConst = 3.14f;
        public readonly float PIField;

        public float PIAutoProperty { get; } = 3.14f;
        public float PIPrivateSet { get; private set; }

        public ReadOnlyAutoproperties(float piField)
        {
            PIField = piField;
        }

        public StatusField StatusField { get; private set; } = StatusField.Visible;

        public void IncrementPrecisionPI()
        {
            float newValuePI = 3.1416f;

            PIConst = newValuePI;
            PIField = newValuePI;
            PIAutoProperty = newValuePI;
            PIPrivateSet = newValuePI;
        }

        public void ChangeStatusFieldToVisible()
        {
            StatusField = StatusField.Visible;
        }
    }

    public enum StatusField
    {
        Visible,
        Hidden,
    }
}

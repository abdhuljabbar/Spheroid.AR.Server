namespace Spheroid.AR
{
    public readonly struct Height
    {
        public float Value { get; }
        public HeightOptions Options { get; }

        public HeightRelativity Relativity => Options.Relativity;
        public HeightAlignment Alignment => Options.Alignment;
        public bool IsDefaultValue => Options.IsDefaultValue;

        public Height(float value, HeightOptions options)
        {
            Value = value;
            Options = options;
        }
    }
}
